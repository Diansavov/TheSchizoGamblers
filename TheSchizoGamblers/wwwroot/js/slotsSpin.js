const btn = document.getElementById("spinButton");
const currentIteration = 2;
const flippedIteration = 1;
let currentIndex = 0;
const [matrixImages, matrixBottomImages] = FillSlotsMatrix();
const spinLenght = 250;

function FillSlotsMatrix() {
    const imges = document.querySelectorAll("[class=slots-image]");
    const bottomImges = document.querySelectorAll("[id=slotsFigure]");

    const matrixImages = [[], [], []];
    const matrixBottomImages = [[], [], []];

    for (let i = 0; i < matrixImages.length; i++) {
        for (let j = 0; j < 5; j++) {
            matrixImages[i][j] = imges[currentIndex];
            matrixBottomImages[i][j] = bottomImges[currentIndex];
            currentIndex++;
        }
    }
    return [matrixImages, matrixBottomImages];
}

function spinSlots(matrixImages, matrixBottomImages) {

    for (let i = 0; i < matrixImages.length; i++) {
        for (let j = 0; j < matrixImages[i].length; j++) {
            matrixBottomImages[i][j].style.transform = "translateY(180px)";
            matrixBottomImages[i][j].style.transition = `transform ${spinLenght}ms ease-in-out`;
        }
    }

}
document.body.onload = () => {
    btn.disabled = true;

    setTimeout(() => {
        btn.disabled = false;
    }, 200);
}

btn.onclick = () => {
    btn.disabled = true;

    spinSlots(matrixImages, matrixBottomImages, currentIteration, flippedIteration);

    setTimeout(() => {
        document.getElementById("slotForm").submit();
    }, spinLenght);

    return false;
}