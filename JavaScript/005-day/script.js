const obtenerValor = document.getElementById("tareaInput");
const botonAgregar = document.getElementById("agregarTarea");
const mensaje = document.getElementById("mensaje");
const lista = document.getElementById("listaTareas");

// variable que genera el localstorage 
let tareas = JSON.parse(localStorage.getItem("tareas")) || [];
console.log("📦 Cargadas desde localStorage:", tareas);

// permite actualizar los cambios del contador cuando se modifica una nota
function actualizarContador() {
  const total = lista.children.length;
  const completadas = [...lista.children].filter(li =>
    li.classList.contains("completada")
  ).length;

  const contador = document.getElementById("contadorTareas");
  contador.textContent = `${total} tarea${total !== 1 ? 's' : ''} – ${completadas} completada${completadas !== 1 ? 's' : ''}`;
}

// aplicar filtro a las notas si estan todas, completadas o pendientes
function aplicarFiltro(filtro) {
  const tareasDOM = document.querySelectorAll("#listaTareas li");

  tareasDOM.forEach(li => {
    const esCompletada = li.classList.contains("completada");

    if (filtro === "todas") {
      li.style.display = "list-item";
    } else if (filtro === "completadas") {
      li.style.display = esCompletada ? "list-item" : "none";
    } else if (filtro === "pendientes") {
      li.style.display = !esCompletada ? "list-item" : "none";
    }
  });
}

// permite agregar una tarea a la lista
function guardarTareas() {
  localStorage.setItem("tareas", JSON.stringify(tareas));
  console.log("📦 Cargadas en localStorage:", tareas);
}

// permite crear el elemento cuando se da clic en agregar en el boton, y permite la logica
function crearElementoTarea(texto, completada = false) {
  const li = document.createElement("li");
  li.classList.add("tarea");

  const spanTexto = document.createElement("span");
  spanTexto.textContent = texto;

  const botonEliminar = document.createElement("button");
  botonEliminar.textContent = "❌";
  botonEliminar.style.marginLeft = "10px";
  botonEliminar.style.cursor = "pointer";

  // Eliminar tarea con botón
  botonEliminar.addEventListener("click", (e) => {
    e.stopPropagation();
    li.classList.remove("mostrar");
    li.classList.add("ocultar");

    setTimeout(() => {
      li.remove();
    }, 515); // duración de la animación en ms

    // función eliminar
    eliminarTarea(texto);
  });

  // Marcar como completada
  if (completada) li.classList.add("completada");
  li.addEventListener("click", () => {
    li.classList.toggle("completada");
    actualizarEstadoTarea(texto, li.classList.contains("completada"));
  });

  // 📝 Editar al hacer doble clic en el texto
  spanTexto.addEventListener("dblclick", (e) => {
    e.stopPropagation();

    const inputEditar = document.createElement("input");
    inputEditar.type = "text";
    inputEditar.value = texto;
    inputEditar.size = Math.max(texto.length, 10);

    // Reemplaza el span por el input
    li.replaceChild(inputEditar, spanTexto);
    inputEditar.focus();

    // escucha cuando el usuario le da Enter al Input
    inputEditar.addEventListener("keydown", (event) => {
      if (event.key === "Enter") {
        const nuevoTexto = inputEditar.value.trim();
        if (nuevoTexto !== "") {
          spanTexto.textContent = nuevoTexto;
          li.replaceChild(spanTexto, inputEditar);

          // Actualizar en array de tareas
          tareas = tareas.map(t =>
            t.texto === texto ? { ...t, texto: nuevoTexto } : t
          );
          texto = nuevoTexto; // actualiza la variable local
          guardarTareas();
          actualizarContador();
        }
      }
    });
  });

  li.appendChild(spanTexto);
  li.appendChild(botonEliminar);
  lista.appendChild(li);
  actualizarContador();

   // Animación
  requestAnimationFrame(() => {
  li.classList.add("mostrar");
});
}


// permite actualizar la tarea y verifica si se encuentra completada
function actualizarEstadoTarea(texto, completada) {
  tareas = tareas.map(t => 
    t.texto === texto ? { ...t, completada } : t
  );
  guardarTareas();
  actualizarContador()
}

// verifica la tarea pulsada para hacer un filter para despues removerla del array y actualizar los cambios
function eliminarTarea(texto) {
  tareas = tareas.filter(t => t.texto !== texto);
  guardarTareas();
  actualizarContador();
}

function borrarTodasNotas(){
    document.getElementById("listaTareas").innerHTML = "";
    localStorage.clear();
    tareas = []; // importante limpiar el array también
    actualizarContador();
    console.log("🧼 Se han borrado todas las notas satisfactoriamente");
}

document.getElementById('eliminarTodo').addEventListener('click', borrarTodasNotas);

// Cargar tareas guardadas al inicio
tareas.forEach(tarea => crearElementoTarea(tarea.texto, tarea.completada));
actualizarContador();

botonAgregar.addEventListener("click", () => {

  const valorTarea = obtenerValor.value.trim();

  if (valorTarea === "") {
    mensaje.innerHTML = "El campo no puede estar vacío";
  } else {
    mensaje.innerHTML = "";
    crearElementoTarea(valorTarea);
    tareas.push({ texto: valorTarea, completada: false });
    guardarTareas();
    obtenerValor.value = "";
  }
});

// escucha al boton cuando es cambiado el change para modificar el filtro
document.getElementById("filterNotes").addEventListener("change", (e) => {
  const filtroSeleccionado = e.target.value;
  aplicarFiltro(filtroSeleccionado);
});