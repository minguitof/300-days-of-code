<script setup>
import { useWeather } from '../composables/useWeather'
// import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

const { ciudad, temperatura, condicion, cargando, error } = useWeather()
</script>

<template>
  <div class="weather-box">
    <p v-if="cargando">Cargando clima...</p>
    <p v-else-if="error">❌ {{ error }}</p>
    <p v-else>{{ ciudad }} - {{ temperatura }}°C | {{ condicion }}</p>
  </div>
</template>

<style scoped>
.weather-box {
  padding: 1rem;
  font-size: 1.5rem;
}

.weather-box p {
  font-size: 1.6rem;
  font-family: 'Poppins', sans-serif;
  font-weight: 600;
  letter-spacing: 0.5px;
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
  text-align: center;
  margin: 0.5rem 0;
}





</style>
