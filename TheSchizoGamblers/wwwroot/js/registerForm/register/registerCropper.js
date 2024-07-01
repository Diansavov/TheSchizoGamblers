function triggerFileUpload() {
    document.getElementById('pictureInput').click();
}
function handleFileUpload(event) {
    var file = event.target.files[0];

    if (file) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var image = document.getElementById('imageCrop');
            image.src = e.target.result;

            cropper.destroy();
            cropper = new Cropper(image, {
                aspectRatio: 1 / 1,
                zoomable: false,
                background: false,
                guides: false,
                cropBoxResizable: false,
                cropBoxMovable: false,
                dragMode: 'move',
                responsive: false,
                toggleDragModeOnDblclick: false,
                minContainerWidth: 466,
                minContainerHeight: 400,
            });
        };
        reader.readAsDataURL(file);

        displayCroppedImage();
    }
}
// Display Cropped Image
function displayCroppedImage() {
    console.log('displayImage');

    const cropButton = document.getElementById('crop-btn');
    cropButton.addEventListener('click', () => {
        let croppedCanvas = cropper.getCroppedCanvas();
        if (croppedCanvas) {
            setInputFile();
            const croppedImage = croppedCanvas.toDataURL();
            document.getElementById('real-profile-pic').src = croppedImage;
        }
    });
}
// Send to form cropped image
function setInputFile() {
    const hiddenInput = document.getElementById('real-pic-input');
    let croppedCanvas = cropper.getCroppedCanvas();

    if (croppedCanvas) {
        croppedCanvas.toBlob((blob) => {
            const file = new File([blob], "croppedImage.png", { type: "image/png" });
            const dataTransfer = new DataTransfer();
            dataTransfer.items.add(file);
            hiddenInput.files = dataTransfer.files;
        }, 'image/png');
    }
}

const img = document.getElementById('imageCrop');
let cropper = new Cropper(img);

document.getElementById('profileButton').addEventListener('click', triggerFileUpload);
document.getElementById('pictureInput').addEventListener('change', handleFileUpload);