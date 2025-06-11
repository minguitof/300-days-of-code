var a = "ohana";
console.log(a);

var matrix = []
// var b = prompt("");
// console.log(b);

for (let i = 1; i <= 1; i++) {
    var c = prompt("");
    matrix.push(c);
    console.log(matrix);
}

function actualizarHTML() {
  resultado.innerHTML = `
    <ul>
      ${matrix.map(matri => `<li>${matri}</li>`).join("")}
    </ul>
  `;
}

let resultado = document.getElementById("resultado");

resultado.innerHTML = "<ul>" +
    matrix.map(matri => `<li>${matri}</li>`).join("") +
    "</ul>"
    actualizarHTML();

let eliminar = document.getElementById("eliminar");

eliminar.addEventListener("click", function(){
    var eliminarItem = prompt("Ingrese valor a eliminar: ");

    if (!isNaN(eliminarItem) && eliminarItem.trim() !== "") {
      let numero = Number(eliminarItem);
      alert("Ingresaste el número: " + numero + " deseas eliminar el registro `" + matrix[numero] + "`");
      matrix.pop(numero);
    } else {
      alert("Eso no es un número válido.");
    }
    console.log(matrix)
});


let modificar = document.getElementById("modificar");

modificar.addEventListener("click", function(){
    var modificarItem = prompt("Ingrese valor a modificar: ");

    if (!isNaN(modificarItem) && modificarItem.trim() !== "") {
      let numero = Number(modificarItem);
      alert("Seleccionastes al usuario: " + matrix[numero]);
      newWorth = prompt("Ingrese el nuevo valor: ");
      matrix[numero] = newWorth;
    } else {
      alert("Eso no es un número válido.");
    }
    console.log(matrix);
    actualizarHTML();
})

