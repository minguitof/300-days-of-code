using System;
using System.Collections.Generic;

class Estudiante
{
    string nombre;
    string carrera;
    List<double> notas = new List<double>();
    double promedio;

    public void ObtenerInfo(string nombre, string carrera)
    { 
        this.nombre = nombre;
        this.carrera = carrera;
    }

    public void CalcularPromedio()
    {
        double suma = 0;
        foreach (double nota in notas)
        {
            suma += nota;
        }
        promedio = notas.Count > 0 ? suma / notas.Count : 0;
    }

    public void AgregarNota(double nota)
    {
        notas.Add(nota);
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\nEstudiante: {nombre} - Carrera: {carrera}");
        Console.WriteLine($"Promedio final: {promedio:F2}");

        if (promedio >= 4.0)
        {
            Console.WriteLine("🎉 ¡Excelente! Tienes derecho a beca.");
        }
        else if (promedio >= 3.0)
        {
            Console.WriteLine("🙂 Vas bien, pero no alcanzas beca aún.");
        }
        else
        {
            Console.WriteLine("😕 Hay que mejorar ese rendimiento, confio en ti hermano, y se que puedes dar mas y no me estas dando ese 100%.");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Estudiante> listaEstudiantes = new List<Estudiante>();
        string continuar = "s";

        while (continuar.ToLower() == "s")
        {
            Estudiante Miestudiante = new Estudiante();

            Console.Write("\nNombre del estudiante: ");
            string nombre = Console.ReadLine();

            Console.Write("Carrera del estudiante: ");
            string carrera = Console.ReadLine();

            Miestudiante.ObtenerInfo(nombre, carrera);

            int cantidadNotas;

            Console.Write("¿Cuántas notas desea ingresar? ");

            while (!int.TryParse(Console.ReadLine(), out cantidadNotas) || cantidadNotas <= 0)
            {
                Console.WriteLine("Por favor, ingrese un número entero válido mayor que 0.");
                Console.Write("¿Cuántas notas desea ingresar? ");
            }

            for (int i = 1; i <= cantidadNotas; i++)
            {
                double nota;
                Console.Write($"Ingrese la nota #{i}: ");
                while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 5)
                {
                    Console.WriteLine("Por favor, ingrese una nota válida entre 0 y 5.");
                    Console.Write($"Ingrese la nota #{i}: ");
                }

                Miestudiante.AgregarNota(nota);
            }

            Miestudiante.CalcularPromedio();
            Miestudiante.MostrarInfo();

            listaEstudiantes.Add(Miestudiante);

            Console.Write("\n¿Deseas ingresar otro estudiante? (s/n): ");
            continuar = Console.ReadLine();
        }

        Console.WriteLine("\nResumen completo:");
        foreach (Estudiante e in listaEstudiantes)
        {
            e.MostrarInfo();
            Console.WriteLine("---------------------------------");
        }
    }
}
