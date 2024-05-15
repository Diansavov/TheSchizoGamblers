const img = document.getElementById('imageCrop');
let cropper = new Cropper(img);

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

    const cropButton = document.getElementById('crop-btn');
    cropButton.addEventListener('click', () => {
      const croppedCanvas = cropper.getCroppedCanvas(); 
      if (croppedCanvas) {
        const croppedImage = croppedCanvas.toDataURL();
        document.getElementById('real-profile-pic').src = croppedImage;
      }
    });
  }
}

document.getElementById('profileButton').addEventListener('click', triggerFileUpload);
document.getElementById('pictureInput').addEventListener('change', handleFileUpload);