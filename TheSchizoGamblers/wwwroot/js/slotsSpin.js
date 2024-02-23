const btn = document.getElementById("spinButton");

function spinSlots(imges, bottomImges) {

    for (let i = 0; i < imges.length; i++) {
        if (i > 9) {
            bottomImges[i].style.transform = "translateY(180px)";
            bottomImges[i].style.transition = "transform 500ms ease-in-out";
        }
        else {
            imges[i].style.transform = "translateY(180px)";
            imges[i].style.transition = "transform 500ms ease-in-out";
        }
    }
}

btn.onclick = () => {
    const imges = document.querySelectorAll("[class=slots-image]");
    const bottomImges = document.querySelectorAll("[id=slotsFigure]");

    spinSlots(imges, bottomImges);

    setTimeout(() => {
        document.getElementById("slotForm").submit();
    }, 600);

    return false;
}
