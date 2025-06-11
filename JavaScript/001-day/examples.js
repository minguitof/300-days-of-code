// iniciamos el array
var matrix = ["pepitoo", "pepitooo"];

let resultado = document.getElementById("resultado");

// función que recorre el array en busca de nuevos cambios para el HTML
function actualizarHTML() {
  resultado.innerHTML = `
    <ul>
      ${matrix.map(matri => `<li>${matri}</li>`).join("")}
    </ul>
  `;
}

// DIV para eliminar información
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
    actualizarHTML();
});

// DIV de modificar valor
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

// llamado de función actualiza pantalla
actualizarHTML();
