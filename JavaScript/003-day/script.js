function changeBackground() {
    const elementos = document.getElementsByClassName("changeColor");

    if (elementos.length > 0) {
        const primero = elementos[0];

        if (primero.style.backgroundColor === "red") {
            primero.style.backgroundColor = "blue";
        } else {
            primero.style.backgroundColor = "red";
        }
    }
}
