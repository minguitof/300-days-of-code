class Animal
{
    string nombre;
    string tipo;

    public void SetInfo(string n, string t)
    {
        nombre = n;
        tipo = t;
    }

    public void MostrarInfo()
    {
        Console.WriteLine("Nombre del animal: " + nombre);
        Console.WriteLine("Tipo de animal: " + tipo);
    }
}

class Mascotas
{
    string nombre;
    string especie;
    int edad;

    public void SetInfoMascotas(string n, string es, int ed) 
    {
        nombre = n;
        especie = es;
        edad = ed;
    }

    public void MostrarInfoMascotas()
    {
        Console.WriteLine($"El nombre de la mascota es: {nombre}");
        Console.WriteLine($"La especie de la mascota es: {especie}");
        Console.WriteLine($"La edad de la mascota es: {edad}");
    }

    public void CumplirAnios() {
        edad++;
        Console.WriteLine($"Feliz cumpleaños, {nombre}! Ahora tienes {edad} años.");
    }

}

class Program
{
    static void Main()
    {
        Animal miAnimal = new Animal();
        miAnimal.SetInfo("Firulais", "Perro");
        miAnimal.MostrarInfo();

        Console.WriteLine("\n");

        Mascotas Mimascota = new Mascotas();

        Mimascota.SetInfoMascotas("Pepito", "Bullterry", 2);
        Mimascota.MostrarInfoMascotas();
        Mimascota.CumplirAnios();

        Console.WriteLine("\n");

        Console.Write("Ingrese el nombre de la mascota: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la especie de la mascota: ");
        string especie = Console.ReadLine();

        Console.Write("Ingrese la edad de la mascota: ");
        int edad = int.Parse(Console.ReadLine()); // 👈 importante convertir a int

        Mimascota.SetInfoMascotas(nombre, especie, edad);

        Console.WriteLine("\n--- Información cargada ---\n");
        Mimascota.MostrarInfoMascotas();
        Mimascota.CumplirAnios();

    }
}
