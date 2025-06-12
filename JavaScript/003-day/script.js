// function changeBackgroundForClassName() {
//     const elementos = document.getElementsByClassName("changeColor");

//     if (elementos.length > 0) {
//         const primero = elementos[0];

//         if (primero.style.backgroundColor === "red") {
//             primero.style.backgroundColor = "blue";
//         } else {
//             primero.style.backgroundColor = "red";
//         }
//     }
// }

// // #tarea 1
let exampleForID = document.getElementById("exampleForIDName");

// console.log("Con el objeto " + exampleForID);
// console.log("Con el valor del objeto " + exampleForID.textContent);
// console.log("Con el valor del ID del objeto " + exampleForID.id);

// console.log("========================================================================================================")

// #tarea 2
let elementos = document.getElementsByTagName('li');
var conteo = elementos.length;
console.log("Hay " + conteo + " elementos con la etiqueta " + "<li>");
console.log(elementos[2].textContent);

// #tarea 3
let cajaExamples = document.getElementsByClassName("caja");
console.log("La cantidad es: " + cajaExamples.length);

const segundoDiv = cajaExamples[1];

// Paso 3: Obtener su contenido con innerHTML y guardarlo en una variable
const contenidoCajaExamples = segundoDiv.innerHTML;

console.log("La palabra del segundo DIV es: " + contenidoCajaExamples);

// # tarea 4
let tarea4 = exampleForID.innerHTML = "Se modifica el texto con JS de la Tarea 4";


// # tarea 5 
document.getElementById("tarea5").style.backgroundColor = "lightblue";

// # tarea 6
function tarea6() {
  const imagen = document.getElementById('miImagen');
  imagen.src = (imagen.src.includes('local-github.png')) ? 'local-github-2.png' : 'local-github.png';
}

// # tarea 7
const tarea7 = document.getElementById("tarea7");

const nuevoParrafo = document.createElement("p");
nuevoParrafo.textContent = "Este es un parrafo nuevo creado con JS";

tarea7.appendChild(nuevoParrafo);


// # tarea 8
// Crear un nuevo div (div2)
const nuevoDiv = document.createElement("div");
nuevoDiv.id = "div2";
nuevoDiv.textContent = "Este es el DIV 2 cambiado desde JS";

// Obtener el contenedor y el div existente (div1)
const contenedor = document.getElementById("contenedorTarea8");
const divAntiguo = document.getElementById("div1Tarea8");

// Reemplazar div1 con div2
contenedor.replaceChild(nuevoDiv, divAntiguo);

// # Tarea 9
const tarea9Remove = document.getElementById("tarea3");
const itemTarea9Remove = document.getElementById("removeChild");

tarea9Remove.removeChild(itemTarea9Remove);

// # tarea 10
const tarea10Change = document.getElementById("tarea10Change");

function tarea10(){
    tarea10Change.textContent = "Este es el texto cambiado desde JS";
}