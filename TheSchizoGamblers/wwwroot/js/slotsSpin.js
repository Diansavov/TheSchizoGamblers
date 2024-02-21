const btn = document.getElementById("spinButton");

btn.onclick = () => {
    const imges = document.querySelectorAll("[id=slotsFigure]");
    
    imges.forEach(element => {
        element.style.transform = "translateY(180px)";
        element.style.transition = "transform 500ms ease-in-out";
    });
}