using System;

class TemperatureConverter
{
    double temperatura;

    public void obtenerInfo(double temperatura)
    {
        this.temperatura = temperatura;
    }

    public void ConverterFK()
    {
        double Fahrenheit = (temperatura * 9 / 5) + 32;
        double Kelvin = temperatura + 273.15;

        Console.WriteLine($"\n🔥 Conversión de {temperatura} °C:");
        Console.WriteLine($"- Fahrenheit: {Fahrenheit:F2} °F");
        Console.WriteLine($"- Kelvin: {Kelvin:F2} °K");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("\nIngrese su temperatura en °C: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double temperatura))
            {
                TemperatureConverter converter = new TemperatureConverter();
                converter.obtenerInfo(temperatura);
                converter.ConverterFK();
            }
            else
            {
                Console.WriteLine("❌ Entrada inválida. Por favor, ingrese un número válido.");
                continue; // vuelve a pedir la temperatura
            }

            Console.Write("\n¿Desea hacer otra conversión? (s/n): ");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta != "s")
            {
                Console.WriteLine("👋 Gracias por usar el conversor. ¡Hasta la próxima!");
                break;
            }
        }
    }
}
