<template>
  <div class="clock-container">
    <div class="clock-face">
        <div class="center-dot"></div>

      <!-- Números del reloj -->
      <div
        v-for="n in 12"
        :key="n"
        class="number"
        :style="getNumberPosition(n)"
      >
        {{ n }}
      </div>

      <!-- Agujas -->
      <div class="hand hour" :style="hourStyle"></div>
      <div class="hand minute" :style="minuteStyle"></div>
      <div class="hand second" :style="secondStyle"></div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted, onUnmounted, computed } from 'vue'

const now = ref(new Date())
const tick = ref(0)

// Actualizamos la hora cada segundo

let intervalId
onMounted(() => {
  intervalId = setInterval(() => {
    now.value = new Date()
    tick.value++
  }, 1000)
})
onUnmounted(() => {
  clearInterval(intervalId)
})

// 🕒 Cálculo de rotación de cada aguja
const secondStyle = computed(() => ({
  transform: `rotate(${tick.value * 6}deg)`
}))
const minuteStyle = computed(() => ({
  transform: `rotate(${now.value.getMinutes() * 6}deg)`
}))
const hourStyle = computed(() => {
  const hours = now.value.getHours() % 12
  const minutes = now.value.getMinutes()
  return {
    transform: `rotate(${(hours * 30) + (minutes * 0.5)}deg)`
  }
})

// 📍 Posición de los números del reloj
const getNumberPosition = (n) => {
  const angle = (n - 3) * 29.6 // desplazamos 3 para que el 12 quede arriba
  const radius = 132
  const x = 137 + radius * Math.cos((angle * Math.PI) / 180)
  const y = 127 + radius * Math.sin((angle * Math.PI) / 180)
  return {
    position: 'absolute',
    left: `${x}px`,
    top: `${y}px`,
    transform: 'translate(50%, 30%)',
    fontWeight: 'bold',
    fontSize: '1.25rem',
  }
}
</script>

<style scoped>

.clock-container {
  width: 300px;
  height: 300px;
  margin: auto;
  margin-top: 3rem;
  background-color: #f0f0f0;
  border-radius: 70%;
  position: relative;
  box-shadow: 0 0 10px rgba(0,0,0,0.2);
}

.clock-face {
  width: 100%;
  height: 100%;
  position: relative;
}

.hand {
  width: 2px;
  background-color: #333;
  position: absolute;
  /* Centrar las manecillas en el medio del reloj */
  top: 30%; /* La parte superior de la manecilla empieza en el 50% de la altura del contenedor */
  left: 50%; /* La parte izquierda de la manecilla empieza en el 50% del ancho del contenedor */
  /* El origen de la rotación está en la parte inferior central de la manecilla */
  transform-origin: bottom center;
  transition: transform 0.3s ease-in-out;
}

.hour {
  height: 60px;
  width: 4px;
  /* Mueve la manecilla 50% de su ancho a la izquierda y 100% de su alto hacia arriba
     para que su "bottom center" (origen de rotación) coincida con el centro del reloj. */
  transform: translate(-50%, -100%);
}
.minute {
  height: 80px;
  width: 3px;
  top: 23%;
  background-color: rgb(37, 21, 22);
  /* Aplica el mismo principio para la manecilla de minutos */
  transform: translate(-50%, -100%);
}
.second {
  height: 100px;
  width: 2px;
  top: 17%;
  background-color: red;
  /* Aplica el mismo principio para la manecilla de segundos */
  transform: translate(-50%, -100%);
  transition: transform 0.3s linear;
}

.center-dot {
  width: 8px;
  height: 8px;
  background-color: black;
  border-radius: 50%;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  z-index: 10;
  transition: transform 0.5s ease-in-out;
}

/* Estilos para los números, que ya están bien */
.number {
  position: absolute;
  font-weight: bold;
  font-size: 1.25rem;
  color: black;
  transform: translate(-50%, -50%); /* Para centrar los números en su posición calculada */
}

</style>
