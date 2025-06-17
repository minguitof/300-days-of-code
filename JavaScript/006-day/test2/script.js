const obtenerValor = document.getElementById("tareaInput");
const botonAgregar = document.getElementById("agregarTarea");
const mensaje = document.getElementById("mensaje");
const lista = document.getElementById("listaTareas");
const inputBusqueda = document.getElementById("buscarTarea");
const botonModo = document.getElementById("toggleModo");

// variable que genera el localstorage 
let tareas = JSON.parse(localStorage.getItem("tareas")) || [];
console.log("📦 Cargadas desde localStorage:", tareas);

// permite actualizar los cambios del contador cuando se modifica una nota
function mostrarResumenDeTareas() {
  const total = lista.children.length;
  const completadas = [...lista.children].filter(li =>
    li.classList.contains("completada")
  ).length;

  const contador = document.getElementById("contadorTareas");
  contador.textContent = `${total} tarea${total !== 1 ? 's' : ''} – ${completadas} completada${completadas !== 1 ? 's' : ''}`;
}

// aplicar filtro a las notas si estan todas, completadas o pendientes
function filtrarTareasPorEstado(filtro) {
  const tareasDOM = document.querySelectorAll("#listaTareas li");

  tareasDOM.forEach(li => {
    const esCompletada = li.classList.contains("completada");

    // Eliminar clases previas
    li.classList.remove("ocultar");

    if (filtro === "completadas" && !esCompletada) {
      li.classList.add("ocultar");
    } else if (filtro === "pendientes" && esCompletada) {
      li.classList.add("ocultar");
    }
  });
}

// permite agregar una tarea a la lista
function guardarTareasEnLocalStorage() {
  localStorage.setItem("tareas", JSON.stringify(tareas));
  console.log("📦 Cargadas en localStorage:", tareas);
}

function mostrarTareaEnPantalla(texto, completada = false, horaCreacion = "") {
  if (!horaCreacion) {
    horaCreacion = new Date().toISOString();
  }

  const horaVisible = new Date(horaCreacion).toLocaleTimeString([], {
    hour: '2-digit',
    minute: '2-digit'
  });

  const li = document.createElement("li");
  li.classList.add("tarea");

  const contenedorTexto = document.createElement("div");
  contenedorTexto.style.display = "flex";
  contenedorTexto.style.justifyContent = "space-between";
  contenedorTexto.style.alignItems = "center";
  contenedorTexto.style.width = "100%";

  const spanTexto = document.createElement("span");
  spanTexto.textContent = `${texto} 🕐 ${horaVisible}`;
  spanTexto.style.flexGrow = "1";

  const contenedorBotones = document.createElement("div");
  contenedorBotones.style.display = "flex";
  contenedorBotones.style.gap = "8px";

  const botonEditar = document.createElement("button");
  botonEditar.textContent = "✏️";
  botonEditar.title = "Editar";

  botonEditar.addEventListener("click", (e) => {
    e.stopPropagation();

    const inputEditar = document.createElement("input");
    inputEditar.type = "text";
    inputEditar.value = texto;
    inputEditar.size = Math.max(texto.length, 10);

    li.replaceChild(inputEditar, contenedorTexto);
    inputEditar.focus();

    inputEditar.addEventListener("keydown", (event) => {
      if (event.key === "Enter") {
        const nuevoTexto = inputEditar.value.trim();
        if (nuevoTexto !== "") {
          spanTexto.textContent = `${nuevoTexto} 🕐 ${horaVisible}`;
          tareas = tareas.map(t =>
            t.texto === texto && t.horaCreacion === horaCreacion
              ? { ...t, texto: nuevoTexto }
              : t
          );
          guardarTareasEnLocalStorage();
          mostrarResumenDeTareas();
          li.replaceChild(contenedorTexto, inputEditar);
        }
      }
    });
  });

  const botonEliminar = document.createElement("button");
  botonEliminar.textContent = "❌";
  botonEliminar.title = "Eliminar";
  botonEliminar.style.cursor = "pointer";

  botonEliminar.addEventListener("click", (e) => {
    e.stopPropagation();
    li.classList.remove("mostrar");
    li.classList.add("ocultar");

    setTimeout(() => {
      li.remove();
    }, 500);
    borrarTareaDelArrayYLocalStorage(texto, horaCreacion);
  });

  contenedorBotones.appendChild(botonEditar);
  contenedorBotones.appendChild(botonEliminar);
  contenedorTexto.appendChild(spanTexto);
  contenedorTexto.appendChild(contenedorBotones);
  li.appendChild(contenedorTexto);
  lista.appendChild(li);

  mostrarResumenDeTareas();

  requestAnimationFrame(() => {
    li.classList.add("mostrar");
  });

  li.addEventListener("click", () => {
    spanTexto.classList.toggle("completada");
    li.classList.toggle("completada");
    marcarTareaComoCompletadaOPendiente(texto, li.classList.contains("completada"));
  });
}



// permite actualizar la tarea y verifica si se encuentra completada
function marcarTareaComoCompletadaOPendiente(texto, completada) {
  tareas = tareas.map(t => 
    t.texto === texto ? { ...t, completada } : t
  );
  guardarTareasEnLocalStorage();
  mostrarResumenDeTareas()
}

// verifica la tarea pulsada para hacer un filter para despues removerla del array y actualizar los cambios
function borrarTareaDelArrayYLocalStorage(texto) {
  tareas = tareas.filter(t => t.texto !== texto);
  guardarTareasEnLocalStorage();
  mostrarResumenDeTareas();
}

function borrarTodasNotas(){
    document.getElementById("listaTareas").innerHTML = "";
    localStorage.clear();
    tareas = []; // importante limpiar el array también
    mostrarResumenDeTareas();
    console.log("🧼 Se han borrado todas las notas satisfactoriamente");
}

// permite borrar todas las notas.
document.getElementById('eliminarTodo').addEventListener('click', borrarTodasNotas);

function aplicarFiltroCombinado() {
  const termino = inputBusqueda.value.trim().toLowerCase();
  const filtroEstado = document.getElementById("filterNotes").value;
  const tareasDOM = document.querySelectorAll("#listaTareas li");

  tareasDOM.forEach(li => {
    const textoTarea = li.querySelector("span").textContent.toLowerCase();
    const esCompletada = li.classList.contains("completada");

    const coincideBusqueda = textoTarea.includes(termino);
    const coincideEstado = 
      filtroEstado === "todas" ||
      (filtroEstado === "completadas" && esCompletada) ||
      (filtroEstado === "pendientes" && !esCompletada);

    // Mostrar solo si cumple ambas condiciones
    li.style.display = (coincideBusqueda && coincideEstado) ? "list-item" : "none";
  });
}

// permite filtrar por palabra y estado de la nota.
inputBusqueda.addEventListener("input", aplicarFiltroCombinado);
document.getElementById("filterNotes").addEventListener("change", aplicarFiltroCombinado);


// listener que permite escuchar el select de los ordenamiento por antiguedad de las notas.
document.getElementById("ordenarTareas").addEventListener("change", (e) => {
  const orden = e.target.value;
  ordenarTareas(orden);
});

// declaramos función para obtener los valores de las notas mas recientes, etc.
function ordenarTareas(criterio) {
  let tareasOrdenadas = [...tareas]; // no modificamos el original aún

  if (criterio === "nuevas") {
    tareasOrdenadas.sort((a, b) => {
      return new Date(b.horaCreacion) - new Date(a.horaCreacion);
    });
  } else if (criterio === "antiguas") {
    tareasOrdenadas.sort((a, b) => {
      return new Date(a.horaCreacion) - new Date(b.horaCreacion);
    });
  }

  // Limpiar lista y volver a pintar con el nuevo orden
  lista.innerHTML = "";
  tareasOrdenadas.forEach(t => {
    mostrarTareaEnPantalla(t.texto, t.completada, t.horaCreacion);
  });
}

// boton que permite app cambiar de mood oscuro o normal
botonModo.addEventListener("click", () => {
  document.body.classList.toggle("modo-oscuro");

  // Guardar preferencia en localStorage
  const estaOscuro = document.body.classList.contains("modo-oscuro");
  localStorage.setItem("modoOscuro", estaOscuro ? "true" : "false");

  botonModo.textContent = estaOscuro ? "☀️ Modo claro" : "🌙 Modo oscuro";
});

// Al cargar, aplicar preferencia si estaba activado
window.addEventListener("DOMContentLoaded", () => {
  const modoOscuroGuardado = localStorage.getItem("modoOscuro");
  if (modoOscuroGuardado === "true") {
    document.body.classList.add("modo-oscuro");
    botonModo.textContent = "☀️ Modo claro";
  }
});


// Cargar tareas guardadas al inicio
tareas.forEach(tarea => mostrarTareaEnPantalla(tarea.texto, tarea.completada, tarea.horaCreacion));
mostrarResumenDeTareas();

botonAgregar.addEventListener("click", () => {
  const valorTarea = obtenerValor.value.trim();
  const valorNormalizado = valorTarea.toLowerCase();

  // obtenemos la hora formateada
  const ahora = new Date();
  const horas = ahora.getHours().toString().padStart(2, '0');
  const minutos = ahora.getMinutes().toString().padStart(2, '0');
  // const horaFormateada = `${horas}:${minutos}`;
  const horaISO = new Date().toISOString();


  if (valorTarea === "") {
    mensaje.innerHTML = "El campo no puede estar vacío";
  } else if (tareas.some(t => t.texto.trim().toLowerCase() === valorNormalizado)) {
    mensaje.innerHTML = "Esa tarea ya existe.";
  } else {
    mensaje.innerHTML = "";
    mostrarTareaEnPantalla(valorTarea, false, horaISO);
    tareas.push({
      texto: valorTarea,
      completada: false,
      horaCreacion: horaISO
    });
    guardarTareasEnLocalStorage();
    obtenerValor.value = "";
  }
});

// escucha al boton cuando es cambiado el change para modificar el filtro
document.getElementById("filterNotes").addEventListener("change", (e) => {
  const filtroSeleccionado = e.target.value;
  filtrarTareasPorEstado(filtroSeleccionado);
});