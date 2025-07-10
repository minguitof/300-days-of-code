using System;

class Calculadora
{
    public int PedirNumero(string mensaje)
    {
        Console.Write(mensaje);
        return int.Parse(Console.ReadLine());
    }

    public void Sumar()
    {
        int a = PedirNumero("Ingrese el primer número: ");
        int b = PedirNumero("Ingrese el segundo número: ");
        Console.WriteLine($"Resultado: {a + b}");
    }

    public void Restar()
    {
        int a = PedirNumero("Ingrese el primer número: ");
        int b = PedirNumero("Ingrese el segundo número: ");
        Console.WriteLine($"Resultado: {a - b}");
    }

    public void Multiplicar()
    {
        int a = PedirNumero("Ingrese el primer número: ");
        int b = PedirNumero("Ingrese el segundo número: ");
        Console.WriteLine($"Resultado: {a * b}");
    }

    public void Dividir()
    {
        int a = PedirNumero("Ingrese el primer número: ");
        int b = PedirNumero("Ingrese el segundo número: ");
        if (b == 0)
        {
            Console.WriteLine("No se puede dividir entre 0.");
        }
        else
        {
            Console.WriteLine($"Resultado: {a / b}");
        }
    }

    public void Residuo()
    {
        int a = PedirNumero("Ingrese el primer número: ");
        int b = PedirNumero("Ingrese el segundo número: ");
        if (b == 0)
        {
            Console.WriteLine("No se puede dividir entre 0.");
        }
        else
        {
            Console.WriteLine($"Resultado: {a % b}");
        }
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("#13 Ejercicio - Con clases");
        Console.WriteLine("=============================================\n");

        Calculadora calc = new Calculadora();
        int opcion = 0;

        while (opcion != 6)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Residuo");
            Console.WriteLine("6. Salir\n");

            Console.Write("Elija una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: calc.Sumar(); break;
                case 2: calc.Restar(); break;
                case 3: calc.Multiplicar(); break;
                case 4: calc.Dividir(); break;
                case 5: calc.Residuo(); break;
                case 6: Console.WriteLine("¡Hasta luego!"); break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }
}

