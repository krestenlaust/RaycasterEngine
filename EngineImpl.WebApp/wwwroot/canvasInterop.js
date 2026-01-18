window.canvasInterop = {
    render: function(canvas, pixels, width, height) {
        const ctx = canvas.getContext('2d');
        const imageData = ctx.createImageData(width, height);
        imageData.data.set(new Uint8ClampedArray(pixels));
        ctx.putImageData(imageData, 0, 0);
    }
};
