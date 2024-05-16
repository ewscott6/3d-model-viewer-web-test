document.getElementById('convertBtn').addEventListener('click', function() {
    // Placeholder: Update this URL as needed based on your backend setup
    fetch('/convert', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        // Send necessary data as JSON. Modify this as needed.
        body: JSON.stringify({ filePath: 'public/models/4000120.ipt' })
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.blob();
    })
    .then(blob => {
        // Create a link element, use it to download the file
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.style.display = 'none';
        a.href = url;
        a.download = 'convertedModel.step'; // Specify the download file name
        document.body.appendChild(a);
        a.click();
        window.URL.revokeObjectURL(url);
    })
    .catch(error => {
        console.error('There has been a problem with your fetch operation:', error);
    });
});
