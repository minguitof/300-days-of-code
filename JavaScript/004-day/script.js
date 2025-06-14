// # tarea 1 - uso de document.querySelector()

let tarea1UnaCard = document.querySelector(".card");

respuestaTest1 = tarea1UnaCard.textContent = "Texto cambiado con JS";

console.log(respuestaTest1);


// # tarea 1 - uso de document.querySelectorAll()

tarea1TodasCard = document.querySelectorAll(".card");

// uso del foreach
tarea1TodasCard.forEach((card, index) => {
    card.style.background = "#e0f7fa";
    console.log("El div ha sido cambiado para los indices: " + index);
});


// # tarea 2 - uso de addEventListener()

// document.addEventListener("click", function (e) {
//     console.log("Has hecho click en el documento");
// });


function manejarClick(e) {
    console.log("Has hecho click en el documento" + e.target);
}

document.addEventListener("click", manejarClick);

//  # tarea 3 - uso de input con addEventListener()

// Espera a que el DOM esté completamente cargado
document.addEventListener("DOMContentLoaded", function () {
  // Obtener referencias al input y al párrafo
  const input = document.getElementById("miInput");
  const parrafo = document.getElementById("miParrafo");

  // Agregar el event listener al input
  input.addEventListener("input", function () {
    parrafo.textContent = input.value; // Actualiza el texto del párrafo con lo que se escribe
  });
});


// # tarea 4 - uso de formulario con actualizar valores + validación con preventDefault()

const formulario = document.getElementById("miFormularioTarea4");
const mensaje = document.getElementById("mensajeTarea4");

formulario.addEventListener("submit", function(event) {
    event.preventDefault();

    const nombre = document.getElementById("nombre").value.trim();
    const edad = document.getElementById("edad").value.trim();
    const email = document.getElementById("email").value.trim();

    if (nombre.length > 0 && edad.length > 0 && email.length > 0) {
        mensaje.textContent = `Hola ${nombre}, tenés ${edad} años y su correo es: ${email}.`;
        mensaje.style.color = "green";
    } else {
        mensaje.textContent = "Por favor completá todos los campos.";
        mensaje.style.color = "red";
    }
})

// # tarea 5 - uso de classList.toggle() 

const boton = document.getElementById('buttonTarea5');
const caja = document.querySelector('.caja-toggle');

boton.addEventListener('click', () => {
  caja.classList.toggle('activo');
});

