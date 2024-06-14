const btn = document.getElementById("spinButton");
let currentIndex = 0;
const matrixBottomImages = FillSlotsMatrix();
const spinLenght = 250;

function FillSlotsMatrix() {
    const imges = document.querySelectorAll("[class=slots-image]");
    const bottomImges = document.querySelectorAll("[id=slotsFigure]");

    const matrixImages = [[], [], []];
    const matrixBottomImages = [[], [], []];

    for (let i = 0; i < matrixImages.length; i++) {
        for (let j = 0; j < 5; j++) {
            matrixBottomImages[i][j] = bottomImges[currentIndex];
            currentIndex++;
        }
    }
    return matrixBottomImages;
}

function spinSlots(matrixBottomImages, spinDegree) {

    for (let i = 0; i < matrixBottomImages.length; i++) {
        for (let j = 0; j < matrixBottomImages[i].length; j++) {
            matrixBottomImages[i][j].style.transform = `translateY(${spinDegree}px)`;
            matrixBottomImages[i][j].style.transition = `transform ${spinLenght + (100 * j)}ms ease-in-out`;
        }
    }

}
document.body.onload = () => {
    const yes = document.querySelectorAll("[id=imagesContainer]");
    
    for (let i = 0; i < yes.length; i++) {
        yes[i].classList.remove("no-js-Animation");
    }
    
    setTimeout(() => {
        spinSlots(matrixBottomImages, 0)
    }, 250);
}
 
btn.onclick = () => {
    btn.disabled = true;

    spinSlots(matrixBottomImages, 180);

    setTimeout(() => {
        document.getElementById("slotForm").submit();
    }, spinLenght + 450);

    return false;
}
