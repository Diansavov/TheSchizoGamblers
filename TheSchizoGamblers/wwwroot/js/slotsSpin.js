const btn = document.getElementById("spinButton");

function spinSlots(matrixImages, matrixBottomImages, currentIteration, flippedIteration) {

    for (let i = 0; i < matrixImages.length - flippedIteration; i++) {
        for (let j = 0; j < matrixImages[i].length; j++) {

            matrixImages[i][j].style.transform = `translateY(${180 * flippedIteration}px)`;
            matrixImages[i][j].style.transition = "transform 500ms ease-in-out";

            matrixBottomImages[currentIteration][j].style.transform = "translateY(180px)";
            matrixBottomImages[currentIteration][j].style.transition = "transform 500ms ease-in-out";
        }
    }

    if (flippedIteration == matrixImages.length) {
        for (let j = 0; j < matrixImages[0].length; j++) {
            matrixBottomImages[currentIteration][j].style.transform = "translateY(180px)";

            matrixBottomImages[currentIteration][j].style.transition = "transform 500ms ease-in-out";
        }
    }
    setTimeout(() => {
        spinSlots(matrixImages, matrixBottomImages, currentIteration - 1, flippedIteration + 1);
    }, 500);

}

btn.onclick = () => {
    const currentIteration = 2;
    const flippedIteration = 1;
    let currentIndex = 0;

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

    spinSlots(matrixImages, matrixBottomImages, currentIteration, flippedIteration);

    setTimeout(() => {
        document.getElementById("slotForm").submit();
    }, 1600);

    return false;
}
