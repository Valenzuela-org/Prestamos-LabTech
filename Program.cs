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
        Console.WriteLine("5. Consultar disponibles por categoría");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
    }

    //Pide los datos de un equipo y lo agrega a la lista
    static void AgregarEquipo()
    {
        string codigo;

        //Repite hasta que el codigo no exista o pulse 0 para salir
        while (true)
        {
            codigo = Utilidades.PedirTexto("Ingrese el código del equipo (o pulse 0 para cancelar): ");

            if (codigo == "0")
            {
                return;
            }

            if (GestorEquipos.BuscarEquipo(codigo) == null)
            {
                break; //Sale del bucle
            }
            Console.WriteLine("El equipo ya está registrado. Intente con otro código");
        }

        string nombre = Utilidades.PedirTexto("Ingrese el nombre del equipo: ");
        string categoria = Utilidades.PedirTexto("Ingrese la categoría del equipo: ");

        //Equipo nuevo como disponible por defecto
        Equipo nuevoEquipo = new Equipo
        {
            Codigo = codigo,
            Nombre = nombre,
            Categoria = categoria,
            Disponible = true
        };

        if (GestorEquipos.AgregarEquipo(nuevoEquipo))
        {
            Console.WriteLine("Equipo agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("El equipo ya está registrado.");
        }
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

    //Pide los datos para prestar un equipo y llama al gestor
    static void PrestarEquipo()
    {
        Equipo? equipo = null;
        //Repite hasta encontrar un equipo valido, si no existe o ya está prestado se sale del metodo
        while (equipo == null)
        {
            string codigo = Utilidades.PedirTexto("Ingrese el código del equipo a prestar (o pulse 0 para cancelar): ");

            if (codigo == "0")
            {
                return;
            }
            equipo = GestorEquipos.BuscarEquipo(codigo);

            //Validar si el codigo existe antes de pedir el estudiante y la fecha
            if (equipo == null)
            {
                Console.WriteLine("El equipo no fue encontrado.");
            }

            //Si ya está prestado no pide los demás datos
            else if (!equipo.Disponible)
            {
                Console.WriteLine($"El equipo ya está prestado a {equipo.Estudiante} el {equipo.FechaPrestamo}.");
                equipo = null;
            }
        }

        //Solo si el equipo es valido se procede
        string estudiante = Utilidades.PedirTexto("Ingrese el nombre del estudiante: ");
        string fechaPrestamo = Utilidades.PedirTexto("Ingrese la fecha de préstamo (dd/mm/yyyy): ");

        string resultado = GestorEquipos.PrestarEquipo(equipo.Codigo, estudiante, fechaPrestamo);
        Console.WriteLine(resultado);
    }

    //Pide el codigo de un equipo y llama al gestor para devolverlo
    static void DevolverEquipo()
    {
        string codigo = Utilidades.PedirTexto("Ingrese el código del equipo a devolver: ");
        string resultado = GestorEquipos.DevolverEquipo(codigo);
        Console.WriteLine(resultado);
    }

    //Pide una categoria y muestra los equipos disponibles
    static void ContarDisponiblesCategoria()
    {
        string categoria = Utilidades.PedirTexto("Ingrese la categoría a consultar: ");
        int cantidad = GestorEquipos.ContarDisponiblesCategoria(categoria);
        Console.WriteLine($"Equipos disponibles en la categoría {categoria}: {cantidad}");
    }

    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine() ?? "";
            switch (opcion)
            {
                case "1":
                    AgregarEquipo();
                    break;
                case "2":
                    ListarEquipos();
                    break;
                case "3":
                    PrestarEquipo();
                    break;
                case "4":
                    DevolverEquipo();
                    break;
                case "5":
                    ContarDisponiblesCategoria();
                    break;
                case "6":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}