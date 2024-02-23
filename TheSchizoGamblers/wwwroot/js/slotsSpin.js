const btn = document.getElementById("spinButton");

function spinSlots(matrixImages, matrixBottomImages, currentIteration) {
    
    for (let i = 0; i < matrixImages.length; i++) {        
        if (i == currentIteration) {
            for (let j = 0; j < matrixImages[i].length; j++) {

                matrixBottomImages[i][j].style.transform = "translateY(180px)";
                matrixBottomImages[i][j].style.transition = "transform 500ms ease-in-out";
            } 
        }
        else{
            for (let j = 0; j < matrixImages[i].length; j++) {

                matrixImages[i][j].style.transform = "translateY(180px)";
                matrixImages[i][j].style.transition = "transform 500ms ease-in-out";
            }
        }
    }
    setTimeout(() => {
        spinSlots(matrixImages, matrixBottomImages, currentIteration - 1);
    }, 500);

}

btn.onclick = () => {
    const currentIteration = 2;
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

    spinSlots(matrixImages, matrixBottomImages, currentIteration);

    setTimeout(() => {
        document.getElementById("slotForm").submit();
    }, 1600);

    return false;
}
