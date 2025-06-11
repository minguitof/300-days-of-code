let titulo = document.getElementById("titulo");
// uso de InnerHTML y TextContent
titulo.innerHTML = "Nuevo <strong>título</strong>";
titulo.textContent = "Crud Sencillo en JS";

// inicia el array
let n = [
  "Lucía",
  "Mateo",
  "Sofía",
  "Diego",
  "Valentina",
  "Leo",
  "Isabella",
  "Santiago",
  "Camila",
  "Andrés",
  "Paula",
  "Julián",
  "Emma",
  "Tomás",
  "Martina"
];

// actualiza los datos del array con los nuevos cambios.
function actualizarHTML() {
  resultado.innerHTML = `
    <ul>
      ${n.map((matri, index) => `<li>${index}: ${matri}</li>`).join("")}
    </ul>
  `;
}

// función para agregar un nuevo elemento
function mostrarValor() {
  let input = document.getElementById("miInput");
  n.push(input.value);
  console.log(n);
  actualizarHTML();
}

//  función para actualizar el nombre del usuario
function updateName() {
  let input = document.getElementById("miUpdate");
  let numero = Number(input.value.trim());
  
  if (!isNaN(numero) && input.value.trim() !== "" && n[numero] !== undefined) {
    document.getElementById("valorUsuarioModificar").innerHTML =
      `<br> <div>Seleccionaste al usuario: <strong>${n[numero]}</strong></div>`;

    // Mostrar el input para el nuevo valor
    document.getElementById("contenedorNuevoValor").style.display = "block";

    // Guardar el índice en un atributo data (o usar una variable global)
    document.getElementById("nuevoValorInput").dataset.indice = numero;
  } else {
    document.getElementById("valorUsuarioModificar").innerHTML =
      `<div style="color: red;">Eso no es un número válido o no hay usuario en ese índice.</div>`;
    
    // Ocultar el input por si estaba visible
    document.getElementById("contenedorNuevoValor").style.display = "none";
  }
}

// guarda el nuevo valor y permite mostrarlo en pantalla
function guardarNuevoValor() {
  let nuevoValor = document.getElementById("nuevoValorInput").value.trim();
  let indice = document.getElementById("nuevoValorInput").dataset.indice;

  if (nuevoValor !== "") {
    n[indice] = nuevoValor;
    actualizarHTML(); // actualiza la lista en pantalla
    document.getElementById("valorUsuarioModificar").innerHTML = `<br> <div style="color: green;">Usuario actualizado correctamente.</div>`;
    document.getElementById("contenedorNuevoValor").style.display = "none";
  } else {
    document.getElementById("valorUsuarioModificar").innerHTML = `<div style="color: red;">Debe ingresar un valor válido.</div>`;
  }
}

// funcióñ para busqueda del usuario en array y permitir eliminar del array
function borrarUsuario() {
  const input = document.getElementById("indiceBorrar");
  const mensaje = document.getElementById("mensajeBorrado");
  const indice = Number(input.value.trim());

  if (!isNaN(indice) && indice >= 0 && indice < n.length) {
    const eliminado = n.splice(indice, 1);
    mensaje.innerHTML = `<br> <span style="color: green;">Usuario eliminado: ${eliminado[0]}</span>`;
    actualizarHTML();
    input.value = ""; // limpia el input
  } else {
    mensaje.innerHTML = `<br> <span style="color: red;">Índice inválido. No se eliminó nada.</span>`;
  }
}

// Mostrar lista al cargar
actualizarHTML();