class Auto
{
    string marca;
    string modelo;
    int anio;

    public void ObtenerInfo(string marca, string modelo, int anio) 
    {
        this.marca = marca;
        this.modelo = modelo;
        this.anio = anio;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\nHas escogido la marca {marca} del modelo {modelo} es un modelo {anio}");
    }

    public void Encender() 
    {
        Console.WriteLine("\nEl auto está encendido.");
    }

    public void Apagar() 
    {
        Console.WriteLine("\nEl auto está apagado.");
    }

}

class Program 
{
    static void Main() 
    {
        Auto MiAuto = new Auto();

        Console.Write("\n Ingrese el nombre de la marca que deseas adquirir ");
        string marca = Console.ReadLine();

        Console.Write("\n Ingrese el nombre del modelo que deseas adquirir ");
        string modelo = Console.ReadLine();

        Console.Write("\n Ingrese el año que deseas el vehiculo ");
        int anio = int.Parse(Console.ReadLine());

        MiAuto.ObtenerInfo(marca, modelo, anio);

        MiAuto.MostrarInfo();
        MiAuto.Encender();
    }
}