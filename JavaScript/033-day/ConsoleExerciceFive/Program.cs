using ConsoleExerciceFive;
using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Empleado> listaEmpleados = new List<Empleado>();

        //1
        Empleado emp1 = new Empleado("Mario",5000000m,"Dev");
        listaEmpleados.Add(emp1);

        Empleado emp2 = new Empleado("Juan", 4000000m, "Support");
        listaEmpleados.Add(emp2);

        Empleado emp3 = new Empleado("Pepito", 3000000m, "IT");
        listaEmpleados.Add(emp3);


        Console.WriteLine("--- Menú de Gestión de Empleados ---");
        Console.WriteLine("1. Aumentar Salario");
        Console.WriteLine("2. Eliminar Empleado");
        Console.WriteLine("3. Mostrar Todos los Empleados");
        Console.WriteLine("4. Salir");
        Console.Write("Elige una opción: ");

        //recorrer el foreach
        foreach (var empleado in listaEmpleados)
        {
            empleado.MostrarInformacion();
        }

        Console.WriteLine("\n --- Aumento del salario --- \n");

        Console.WriteLine("Ingrese el ID del empleado a aumentar el salario");
        string idTexto = Console.ReadLine();

        int idParaAumento;


        bool encontrado = false;

        if (int.TryParse(idTexto, out idParaAumento))
        {
            Console.WriteLine("Ingrese el porcentaje de aumento (Ej. 10 para un 10%)");
            string porcentajeTexto = Console.ReadLine();

            decimal porcentajeAumento;


            if (decimal.TryParse(porcentajeTexto, out porcentajeAumento))
            {
                foreach (var empleado in listaEmpleados)
                {
                    if (empleado.IdEmpleado == idParaAumento) // AQUI LA COMPARACIÓN MARIO
                    {
                        decimal montoAumento = empleado.Salario * (porcentajeAumento / 100m);

                        empleado.Salario += montoAumento;

                        Console.WriteLine("\n¡Salario actualizado con éxito!");
                        empleado.MostrarInformacion();
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine($"Empleado con ID {idParaAumento} no encontrado en la lista.");
                }
            }
            else
            {
                Console.WriteLine("Entrada de porcentaje no válida. Por favor, ingrese un número.");
            }
        }
        else
        {
            Console.WriteLine("Entrada de ID no válida. Por favor, ingrese un número entero.");
        }


    }
}