// useWeather.js
import { ref, onMounted } from 'vue'

const ciudad = ref('')
const temperatura = ref(null)
const condicion = ref('')
const cargando = ref(true)
const error = ref(null)
const backgroundClass = ref('default-bg')

// Solo se ejecuta una vez
let loaded = false

export function useWeather() {
  if (!loaded) {
    onMounted(fetchWeather)
    loaded = true
  }  

  async function fetchWeather() {
    try {
      const apiKey = import.meta.env.VITE_API_KEY 
      const url = `https://api.weatherapi.com/v1/current.json?key=${apiKey}&q=Medellin&lang=es`

      const res = await fetch(url)
      const data = await res.json()

      if (res.ok || data.current) {
        ciudad.value = data.location.name
        temperatura.value = data.current.temp_c
        condicion.value = data.current.condition.text
        const condicionTexto = condicion.value.toLowerCase()

        if (condicionTexto.includes('lluvia')) {
          backgroundClass.value = 'rainy-bg'
        } else if (condicionTexto.includes('parcial') || condicionTexto.includes('algo nublado')) {
          backgroundClass.value = 'partly-cloudy-bg'
        } else if (condicionTexto.includes('nublado') || condicionTexto.includes('nuboso')) {
          backgroundClass.value = 'cloudy-bg'
        } else if (condicionTexto.includes('soleado') || condicionTexto.includes('despejado')) {
          backgroundClass.value = 'sunny-bg'
        } else {
          backgroundClass.value = 'default-bg'
        }


        // 👉 Esto lo agregas justo después
        document.body.className = '' // Limpiar clases previas
        document.body.classList.add(backgroundClass.value)
      } else {
        throw new Error(data.error?.message || 'Error al obtener el clima')
      }
    } catch (err) {
      error.value = err.message
    } finally {
      cargando.value = false
    }
  }
  if (import.meta.env.DEV) {
  window.weatherDebug = {
    backgroundClass,
    setBackground: (clase) => {
      backgroundClass.value = clase
    }
  }
}


  return {
    ciudad,
    temperatura,
    condicion,
    cargando,
    error,
    backgroundClass,
  }
}

