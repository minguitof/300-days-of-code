using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiVideoJuego // Mi gran caja de herramientas para el juego
{
    public class Jugador // Una clase pública para que otras partes del juego puedan usarla
    {
        public string Nombre { get; set; } // Propiedad del jugador, accesible públicamente
        private int _salud; // La salud es privada, solo la clase Jugador la manipula directamente

        // Constructor: se ejecuta cuando creamos un nuevo Jugador
        public Jugador(string nombreInicial)
        {
            Nombre = nombreInicial;
            _salud = 100; // Salud inicial
            Console.WriteLine($"¡{Nombre} ha entrado al juego con {_salud} de salud!");
        }

        // Método: El jugador recibe daño
        public void RecibirDano(int cantidad) // No devuelve nada (void)
        {
            _salud -= cantidad;
            if (_salud <= 0)
            {
                Console.WriteLine($"{Nombre} ha sido derrotado.");
            }
            else
            {
                Console.WriteLine($"{Nombre} ahora tiene {_salud} de salud.");
            }
        }

        // Método: El jugador cura su salud, devuelve la salud actual
        public int Curar(int cantidad)
        {
            _salud += cantidad;
            if (_salud > 100) _salud = 100; // No puede exceder el máximo
            return _salud; // Devuelve la salud actual
        }
    }

    public static class GestorDeJuego // Una clase estática, no necesitamos un objeto GestorDeJuego
    {
        public static void IniciarJuego() // Un método estático
        {
            Console.WriteLine("--- El juego ha comenzado ---");
            Jugador jugador1 = new Jugador("Heroe Valiente"); // Creando una instancia de Jugador
            jugador1.RecibirDano(20);
            int saludActual = jugador1.Curar(10); // Llama a un método que devuelve un valor
            Console.WriteLine($"Salud final de {jugador1.Nombre}: {saludActual}");
            Console.WriteLine("--- Fin del juego ---");
        }
    }
}

// En el punto de entrada de tu aplicación (generalmente Program.cs)
// usando el namespace MiVideoJuego;
// MiVideoJuego.GestorDeJuego.IniciarJuego(); // Llamando al método estático sin crear objeto
