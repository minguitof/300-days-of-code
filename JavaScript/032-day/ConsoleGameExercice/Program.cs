using System;
using MiVideoJuego;

namespace MiVideoJuego
{
    class Program
    {
        public static void Main(string[] args)
        {
            GestorDeJuego.IniciarJuego();

            // espacio para usar metodos static, ya que Main no puedo saber sobre no-static, o sea que lo declaro aca, para hacer lo mismo que hice en el metodo/función

            Console.WriteLine("\n\n");
            Console.WriteLine("--- El juego ha comenzado desde Main ---");

            // 1. Crear una instancia del Jugador:
            // Estás "dándole vida" a un jugador específico en la memoria.
            Jugador miHeroe = new Jugador("Valiente Caballero");

            // 2. Interactuar con el Jugador a través de sus métodos:
            Console.WriteLine($"Salud inicial de {miHeroe.Nombre}: {miHeroe.Curar(0)}"); // Usamos Curar(0) para solo obtener la salud

            // El héroe recibe daño:
            miHeroe.RecibirDano(30);
            Console.WriteLine($"Después de recibir daño, salud de {miHeroe.Nombre}: {miHeroe.Curar(0)}");

            // El héroe se cura:
            int saludDespuesDeCurar = miHeroe.Curar(15);
            Console.WriteLine($"Después de curarse, salud de {miHeroe.Nombre}: {saludDespuesDeCurar}");

            // Crear otro jugador para ver que son independientes:
            Jugador otroJugador = new Jugador("Arquera Letal");
            otroJugador.RecibirDano(50);
            Console.WriteLine($"Salud de {otroJugador.Nombre}: {otroJugador.Curar(0)}");

            Console.WriteLine("--- Fin de la demostración desde Main ---");
        }
    }
}