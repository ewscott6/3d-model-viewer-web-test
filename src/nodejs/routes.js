const express = require('express');
const router = express.Router();
const { exec } = require('child_process');
const path = require('path');

// Define base paths
const projectRoot = path.resolve(__dirname, '../../..'); // Adjust based on the structure
const converterAppPath = path.join(projectRoot, 'src/csharp/ConverterApp/bin/Release/net472/win-x64/ConverterApp.exe');
const inputFilePath = path.join(projectRoot, 'public/models/4000120.ipt');
const outputFilePath = path.join(projectRoot, 'public/models/test.step');

// Route for converting .ipt to .STEP
router.post('/convert', (req, res) => {
    exec(`"${converterAppPath}" "${inputFilePath}" "${outputFilePath}"`, (error, stdout, stderr) => {
        if (error) {
            console.error(`exec error: ${error}`);
            return res.status(500).send('Conversion failed');
        }
        // Send the converted file back to the client
        console.log(`stdout: ${stdout}`);
        res.download(outputFilePath, 'model.step');
    });
});

module.exports = router;
