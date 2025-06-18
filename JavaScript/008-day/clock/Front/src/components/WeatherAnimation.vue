<template>
  <div class="weather-animation">
    <div v-if="weather === 'sunny'" class="sun-container">
      <div class="sun"></div>
      <div class="rays"></div>
    </div>
    <div v-else-if="weather === 'rainy'" class="rain">
      <div class="drop" v-for="n in 30" :key="n" :style="{ left: `${Math.random() * 100}%` }"></div>
    </div>
    <div v-else-if="weather === 'partly-cloudy'" class="clouds">
      <div class="cloud" v-for="n in 3" :key="n" :style="{ top: `${n * 20}px`, left: `${n * 30}px` }"></div>
    </div>

    <!-- Puedes seguir con 'cloudy', 'snowy', etc. -->
  </div>
</template>

<script setup>
import { computed } from 'vue'
// import { useWeatherStore } from './components/Weather.vue' // o donde sea que tengas el estado

const props = defineProps({
  backgroundClass: String,
})

const weather = computed(() => {
  if (props.backgroundClass.includes('sunny')) return 'sunny'
  if (props.backgroundClass.includes('rainy')) return 'rainy'
  if (props.backgroundClass.includes('partly-cloudy')) return 'partly-cloudy'
  return 'none'
})

</script>

<style scoped>
.weather-animation {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  pointer-events: none;
}

/* ☀️ Sol girando */
.sun-container {
  position: absolute;
  top: 2rem;
  left: 2rem;
  width: 120px;
  height: 120px;
}

.sun {
  position: absolute;
  top: 20px;
  left: 20px;
  width: 80px;
  height: 80px;
  background: radial-gradient(circle, #FFD700, #FFA500);
  border-radius: 50%;
  z-index: 2;
  animation: rotate 10s linear infinite, pulse 3s ease-in-out infinite;
}

.rays {
  position: absolute;
  top: 0;
  left: 0;
  width: 120px;
  height: 120px;
  background: repeating-conic-gradient(
    from 0deg,
    #FFD700 0deg 10deg,
    transparent 10deg 20deg
  );
  border-radius: 50%;
  animation: rotate 20s linear infinite;
  opacity: 0.5;
  z-index: 1;
}

@keyframes rotate {
  from { transform: rotate(0deg); }
  to { transform: rotate(360deg); }
}

@keyframes pulse {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.1); }
}


/* 🌧 Lluvia */
.rain {
  position: absolute;
  width: 100%;
  height: 100%;
  overflow: hidden;
}

.drop {
  position: absolute;
  width: 2px;
  height: 20px;
  background: rgba(255, 255, 255, 0.5);
  top: -20px;
  animation: fall 1.2s linear infinite;
}

@keyframes fall {
  to {
    transform: translateY(100vh);
  }
}

/*🌦️ Parcialmente Nublado */

.clouds {
  position: absolute;
  width: 100%;
  height: 100%;
  overflow: hidden;
}

.cloud {
  position: absolute;
  width: 100px;
  height: 60px;
  background: #fff;
  border-radius: 50px;
  box-shadow: 30px 0px 0px #fff, 60px 0px 0px #fff;
  opacity: 0.8;
  animation: float 10s ease-in-out infinite alternate;
}

@keyframes float {
  0% { transform: translateX(0); }
  100% { transform: translateX(40px); }
}

</style>
