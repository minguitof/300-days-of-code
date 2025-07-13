using System;

public class ConsoleColorViewer
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Paleta de Colores de Console.ForegroundColor ---");
        Console.WriteLine("--------------------------------------------------");

        // Itera sobre todos los valores del enumerado ConsoleColor
        foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"Texto con color: {color}");
        }

        Console.ResetColor(); // Restablece el color al final
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("Colores mostrados en tu consola.");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}