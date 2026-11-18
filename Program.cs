//Programa principal: menú y llama los otros modulos
class Program
{
    static void MostrarMenu()
    {
        Console.WriteLine("=== Sistema de Gestión de Equipos ===");
        Console.WriteLine("1. Agregar equipo");
        Console.WriteLine("2. Listar equipos");
        Console.WriteLine("3. Prestar equipo");
        Console.WriteLine("4. Devolver equipo");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
    }

//Pide los datos de un equipo y lo agrega a la lista
static void AgregarEquipo()
    {
        string codigo = Equipo.PedirTexto("Ingrese el código del equipo: ");
        string nombre = Equipo.PedirTexto("Ingrese el nombre del equipo: ");
        string categoria = Equipo.PedirTexto("Ingrese la categoría del equipo: ");

        //Equipo nuevo como disponible por defecto
        Equipo nuevoEquipo = new Equipo
        {
            Codigo = codigo,
            Nombre = nombre,
            Categoria = categoria,
            Disponible = true
        };

        GestorEquipos.AgregarEquipo(nuevoEquipo);
        Console.WriteLine("Equipo agregado exitosamente.");
    }

    //Muestra los equipos en la lista
    static void ListarEquipos()
    {
        var equipos = GestorEquipos.ObtenerEquipos();
        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
            return;
        }

        Console.WriteLine("=== Lista de Equipos ===");
        foreach (var equipo in equipos)
        {
            string estado = equipo.Disponible ? "Disponible" : $"Prestado a {equipo.Estudiante} el {equipo.FechaPrestamo}";
            Console.WriteLine($"Código: {equipo.Codigo}, Nombre: {equipo.Nombre}, Categoría: {equipo.Categoria}, Estado: {estado}");
        }
    }
    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine()?? "";
            switch (opcion)
            {
                case "1":
                    AgregarEquipo();
                    break;
                case "2":
                    ListarEquipos();
                    break;
                case "3":
                    // Lógica para prestar equipo
                    break;
                case "4":
                    // Lógica para devolver equipo
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}