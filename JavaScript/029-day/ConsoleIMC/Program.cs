using System;
using System.Net.NetworkInformation;

class IMC
{
    string nombre;
    double estatura;
    double kilogramos;

    public void ObtenerDatos(string nombre, double estatura, double kilogramos) 
    {
        this.nombre = nombre;
        this.estatura = estatura;   
        this.kilogramos = kilogramos;
    }

    public void CalculoIMC() 
    {
        double EstaturaCuadrado = estatura * estatura;
        double resultado = kilogramos / EstaturaCuadrado;

        Console.WriteLine($"\n{nombre}, tu IMC es: {resultado:F2}");

        if (resultado < 18.5)
        {
            Console.WriteLine("\nHermano come más, no me gusta verte en bajo peso, estas quedado");
        }
        else if (resultado < 25)
        {
            Console.WriteLine("\nHermano estas melo, eso es todo");
        }
        else if (resultado < 30)
        {
            Console.WriteLine("\nHermano estas a tiempo, no dejes avanzar la obesidad");            
        }
        else 
        {
            Console.WriteLine("\nNo me estas diciendo tu información real, se real para darte info real");
        }
    }
}

class Program
{
    static void Main()
    { 
        IMC MiIMC = new IMC();

        Console.Write("Dime tu nombre ");
        string nombre = Console.ReadLine();

        Console.Write("Dime tu estatura (Sí en Centimetros) ");
        int estatura = int.Parse(Console.ReadLine());

        Console.Write("Dime tu peso (Sí en kilogramos) ");
        int kilogramos = int.Parse(Console.ReadLine());

        double estaturaMetros = estatura / 100.0;

        Console.WriteLine(estaturaMetros);

        MiIMC.ObtenerDatos(nombre, estaturaMetros, kilogramos);

        MiIMC.CalculoIMC();
    }
}