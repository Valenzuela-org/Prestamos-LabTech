//Logica de inventario: registrar, prestar, devolver y listar equipos
using System.Security.Cryptography.X509Certificates;

static class GestorEquipos
{
    //Lista de equipos del laboratorio
    private static List<Equipo> equipos = new List<Equipo>();

    //Agrega un equipo solo si no existe, devuelve false si ya estaba registrado
    public static bool AgregarEquipo(Equipo equipo)
    {
        if (BuscarEquipo(equipo.Codigo) != null)
        {
            return false;
        }
        equipos.Add(equipo);
        return true;
    }

    //Devuelve la lista de equipos
    public static List<Equipo> ObtenerEquipos()
    {
        return equipos;
    }

    //Busca un equipo por su codigo sin importar mayusculas o minusculas, devuelve null si no lo encuentra
    public static Equipo? BuscarEquipo(string codigo)
    {
        return equipos.FirstOrDefault(e => e.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    }

    //Presta un equipo a un estudiante segun situacion
    public static string PrestarEquipo(string codigo, string estudiante, string fechaPrestamo)
    {
        var equipo = BuscarEquipo(codigo);
        if (equipo == null)
        {
            return "El equipo no fue encontrado.";
        }
        if (!equipo.Disponible)
        {
            return $"El equipo ya está prestado a {equipo.Estudiante} el {equipo.FechaPrestamo}.";
        }

        equipo.Disponible = false;
        equipo.Estudiante = estudiante;
        equipo.FechaPrestamo = fechaPrestamo;
        return "Equipo prestado exitosamente.";
    }

    //Devuelve un equipo prestado, tambien con mensaje
    public static string DevolverEquipo(string codigo)
    {
        var equipo = BuscarEquipo(codigo);

        if (equipo == null)
        {
            return "El equipo no fue encontrado.";
        }
        if (equipo.Disponible)
        {
            return "El equipo no está prestado.";
        }
        equipo.Disponible = true;
        equipo.Estudiante = null;
        equipo.FechaPrestamo = null;
        return "Equipo devuelto exitosamente.";
    }

    //Cuenta los equipos disponibles por categoria
    public static int ContarDisponiblesCategoria(string categoria)
    {
        return equipos.Count(e=>e.Disponible && e.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));
    }

    //Devuelve solo disponibles
    public static List<Equipo> ObtenerDisponibles()
    {
        return equipos.Where(e=>e.Disponible).ToList();
    }
}
