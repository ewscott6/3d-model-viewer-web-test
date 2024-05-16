const express = require('express');
const routes = require('./routes');
const bodyParser = require('body-parser');
const path = require('path');
const app = express();
const port = 3000;
const modelPaths = {
    '1': '/models/4000120.glb',
    '2': '/models/5000066.glb',
    '3': '/models/4cross.glb'
    // Add more mappings as needed
};

app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, '../../public')));

// Use routes
app.use('/', routes);

// API endpoint to get model path by ID
app.get('/api/models/:id', (req, res) => {
    const { id } = req.params;
    const modelPath = modelPaths[id];
    console.log(`Model path for ID: ${id} is ${modelPath}`);
    if (modelPath) {
        res.send(modelPath);
    } else {
        res.status(404).send('Model not found');
        console.error(`Model not found for ID: ${id}`);
    }
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});
