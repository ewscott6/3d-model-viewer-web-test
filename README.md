# Dynamic 3D Model Display and Conversion

This project is a web application that allows users to dynamically display 3D models and convert files from `.ipt` format to `.STEP` format. It uses Node.js, Express, and a simple frontend setup to achieve this functionality.

## Features

- **Dynamic 3D Model Viewer:** Users can view 3D models and choose from a list of available models.
- **File Conversion:** Users can convert `.ipt` files to `.STEP` files with a click of a button.
- **Responsive Design:** The application is designed to be responsive and user-friendly.

## Prerequisites

- Node.js (v12.x or later)
- npm (v6.x or later)
- .NET Core SDK (for running the C# converter application)

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/your-repo.git
   cd your-repo
   ```

2. Install the dependencies:
   ```sh
   npm install
   ```

3. Build the C# converter application:
   Navigate to the `src/csharp/ConverterApp` directory and build the project:
   ```sh
   dotnet build -c Release
   ```

## Usage

1. Start the server:
   ```sh
   npm start
   ```

2. Open your browser and navigate to:
   ```
   http://localhost:3000
   ```

3. Use the interface to:
   - View different 3D models by selecting from the dropdown and clicking the load buttons.
   - Convert `.ipt` files to `.STEP` files by clicking the `DOWNLOAD .STEP` button.

## Project Structure

- `index.html`: Main HTML file that contains the structure and layout of the webpage.
- `styles.css`: Custom styles for the webpage.
- `script.js`: JavaScript file to handle the frontend logic for model loading and file conversion.
- `app.js`: Main server file to set up and start the Express server.
- `routes.js`: Defines routes for handling file conversion and model fetching.
- `ConverterApp.cs`: C# application for converting `.ipt` files to `.STEP` format.

## Code Explanation

### index.html

- Contains the structure for the 3D model viewer and the conversion button.
- Uses the `<model-viewer>` component for displaying 3D models.

### styles.css

- Custom CSS for styling the webpage.

### script.js

- Contains the JavaScript logic for fetching and displaying 3D models.
- Handles the file conversion request and download process.

### app.js

- Sets up the Express server and serves static files.
- Defines API endpoint for fetching model paths based on IDs.

### routes.js

- Defines the route for converting `.ipt` files to `.STEP` files using the C# application.

### ConverterApp.cs

- The C# application that performs the file conversion.
- Executed by the route defined in `routes.js`.

## Contributing

If you would like to contribute, please fork the repository and use a feature branch. Pull requests are welcome.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
```

Feel free to adjust any sections or details as necessary for your project.