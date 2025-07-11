using System;
using System.Diagnostics.Contracts;

class Program
{
    static void Main()
    {
        double[] temperaturas = new double[7];

        Console.WriteLine("Usuario, ingrese las temperaturas de los 7 días de la semana");


        for (int i = 0; i < temperaturas.Length; i++)
        {
            Console.Write($"Día {i + 1}: ");

            while (!double.TryParse(Console.ReadLine(), out temperaturas[i])) 
            {
                Console.WriteLine("Valor Invalido. Intenta de nuevo: ");
            }
        }

        // Cálculo promedio
        double suma = 0;

        foreach (var temp in temperaturas)
        {
            suma += temp;
        }

        double promedio = suma / temperaturas.Length;


        // Más alta y más baja
        double max = temperaturas[0];
        double min = temperaturas[0];

        foreach (double temp in temperaturas)
        {
            if (temp > max) max = temp;
            if (temp < min) min = temp;
        }

        // Días por encima del promedio
        int diasSobrePromedio = 0;
        foreach (double temp in temperaturas)
        {
            if (temp > promedio) diasSobrePromedio++;
        }

        Console.WriteLine($"\nPromedio semanal: {promedio:F2} °C");
        Console.WriteLine($"Temperatura más alta: {max} °C");
        Console.WriteLine($"Temperatura más baja: {min} °C");
        Console.WriteLine($"Días con temperatura sobre el promedio: {diasSobrePromedio}");

    }
}