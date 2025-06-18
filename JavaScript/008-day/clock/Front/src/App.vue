<script setup>
import Clock from './components/ClockAnimated.vue'
import Weather from './components/Weather.vue'
import WeatherAnimation from './components/WeatherAnimation.vue'
import { useWeather } from './composables/useWeather.js'

const { backgroundClass } = useWeather()
</script>

<template>
  <div class="background-container">
    <h1>Analog Watch 🕑👋</h1>  
    <Clock />
    <Weather />
    <WeatherAnimation :backgroundClass="backgroundClass" />
  </div>
</template>

<style>

.background-container {
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

</style>