class Persona
{
    public string nombre;
    public int edad;

    public void MostrarInformacion()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Edad: " + edad + " años");
    }
}

class Program
{
    static void Main()
    {
        Persona p1 = new Persona();
        p1.nombre = "Laura";
        p1.edad = 25;

        p1.MostrarInformacion();
    }
}

