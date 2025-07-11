using System;
using System.Linq;

class Program
{
    static void Main()
    { 
        List<int> listaEdades = new List<int>();

        Console.Write("Ingrese la cantidad de personas que desea calcular las edades ");
        int captureEdades = int.Parse(Console.ReadLine());

        for (int i = 0; i < captureEdades; i++)
        {
            Console.Write($"Ingrese la edad del participante {i + 1}: ");
            int edades = int.Parse(Console.ReadLine());

            listaEdades.Add(edades);
        }

        //Edad mas joven
        int edadJoven = listaEdades.Min();
        int edadMayor = listaEdades.Max();
        double promedioEdad = listaEdades.Average();
        int countMayoresEdad = listaEdades.Count(e => e >= 18);
        int count20to30 = listaEdades.Count(e => e >= 20 && e <= 30);
        Console.WriteLine($"\nEl usuario mas joven tiene: {edadJoven}");
        Console.WriteLine($"El usuario mas viejo tiene: {edadMayor}");
        Console.WriteLine($"La edad promedio de los participantes es: {promedioEdad}");
        Console.WriteLine($"La cantidad de personas mayores de edad (+18) son: {countMayoresEdad}");
        Console.WriteLine($"La cantidad de personas entre 20 y 30 años son: {count20to30}");


    }
}