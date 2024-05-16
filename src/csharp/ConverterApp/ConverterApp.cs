using System;
using Inventor;
using System.Runtime.InteropServices;

namespace ConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide both input and output file paths.");
                return;
            }

            string iptFilePath = args[0];
            string stepFilePath = args[1];

            Inventor.Application inventorApplication = null;

            try
            {
                Console.WriteLine("Attempting to start Inventor...");
                Type inventorType = Type.GetTypeFromProgID("Inventor.Application");
                inventorApplication = (Inventor.Application)Activator.CreateInstance(inventorType);
                inventorApplication.SilentOperation = true;
                Console.WriteLine("Inventor started successfully.");

                Console.WriteLine($"Attempting to open file: {iptFilePath}");
                Document iptDocument = inventorApplication.Documents.Open(iptFilePath, true);
                Console.WriteLine("File opened successfully.");

                if (iptDocument.DocumentType == DocumentTypeEnum.kPartDocumentObject)
                {
                    Console.WriteLine("Document confirmed as part document.");
                    PartDocument partDocument = (PartDocument)iptDocument;

                    Console.WriteLine($"Attempting to export to STEP: {stepFilePath}");
                    ExportToStep(partDocument, stepFilePath, inventorApplication);
                    Console.WriteLine("Exported successfully.");
                }
                else
                {
                    Console.WriteLine("The provided file is not a part document.");
                }

                Console.WriteLine("Attempting to close the IPT document...");
                iptDocument.Close(true);
                Console.WriteLine("IPT document closed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (inventorApplication != null)
                {
                    try
                    {
                        Console.WriteLine("Attempting to close Inventor...");
                        inventorApplication.Quit();
                        Console.WriteLine("Inventor closed successfully.");
                    }
                    catch (COMException ex)
                    {
                        Console.WriteLine($"Error while closing Inventor: {ex.Message}");
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(inventorApplication);
                        inventorApplication = null;
                        Console.WriteLine("Released Inventor application object.");
                    }
                }
            }
        }

        static void ExportToStep(PartDocument partDocument, string stepFilePath, Inventor.Application inventorApplication)
        {
            TranslatorAddIn stepTranslator = null;
            try
            {
                stepTranslator = (TranslatorAddIn)inventorApplication.ApplicationAddIns.ItemById["{90AF7F40-0C01-11D5-8E83-0010B541CD80}"];
                if (stepTranslator != null)
                {
                    TranslationContext translationContext = inventorApplication.TransientObjects.CreateTranslationContext();
                    translationContext.Type = IOMechanismEnum.kFileBrowseIOMechanism;

                    NameValueMap options = inventorApplication.TransientObjects.CreateNameValueMap();
                    // Additional options can be set here

                    DataMedium dataMedium = inventorApplication.TransientObjects.CreateDataMedium();
                    dataMedium.FileName = stepFilePath;

                    stepTranslator.SaveCopyAs(partDocument, translationContext, options, dataMedium);
                }
                else
                {
                    Console.WriteLine("STEP translator could not be found.");
                }
            }
            finally
            {
                if (stepTranslator != null)
                {
                    Marshal.ReleaseComObject(stepTranslator);
                    stepTranslator = null;
                    Console.WriteLine("Released STEP translator object.");
                }
            }
        }
    }
}
