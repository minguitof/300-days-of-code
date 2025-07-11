using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Estudiantes
{
    string nombreUsuario;
    string carrera;
    List<double> notas = new List<double>();
    double promedio;

    public void ObtenerInfo(string nombreUsuario, string carrera) 
    {
        this.nombreUsuario = nombreUsuario;
        this.carrera = carrera;
    }

    public void CalcularPromedio() 
    {
        double suma = 0;

        foreach (var nota in notas)
        {
            suma += nota;
        }
        promedio = notas.Count > 0 ? suma / notas.Count : 0;
    }

    public void AgregarNotas(double nota)
    { 
        notas.Add(nota);
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\nEstudiante: {nombreUsuario} - Carrera: {carrera}");
        Console.WriteLine($"Promedio final: {promedio:F2}");

        if (promedio >= 3.0)
        {
            Console.WriteLine("🎉 ¡Excelente! Tienes derecho a beca y has aprobado melo el curso.");
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
        List<Estudiantes> listaEstudiantes = new List<Estudiantes>();
        string continuar = "s";

        while (continuar.ToLower() == "s")
        {
            Estudiantes MiEstudiante = new Estudiantes();

            Console.Write("\nNombre del estudiante: ");
            string nombre = Console.ReadLine();

            Console.Write("Carrera del estudiante: ");
            string carrera = Console.ReadLine();

            MiEstudiante.ObtenerInfo(nombre, carrera);

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
                while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
                {
                    Console.WriteLine("Por favor, ingrese una nota válida entre 0 y 10.");
                    Console.Write($"Ingrese la nota #{i}: ");
                }

                MiEstudiante.AgregarNotas(nota);
            }

            MiEstudiante.CalcularPromedio();
            MiEstudiante.MostrarInfo();

            listaEstudiantes.Add(MiEstudiante);

            Console.Write("\n¿Deseas ingresar otro estudiante? (s/n): ");
            continuar = Console.ReadLine();
        }

        Console.WriteLine("\nResumen completo:");
        foreach (Estudiantes e in listaEstudiantes)
        {
            e.MostrarInfo();
            Console.WriteLine("---------------------------------");
        }
    }
}