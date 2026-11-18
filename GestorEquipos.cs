//Logica de inventario: registrar, prestar, devolver y listar equipos
static class GestorEquipos
{
    //Lista de equipos del laboratorio
    private static List<Equipo> equipos = new List<Equipo>();

    //Agrega un equipo a la lista
    public static void AgregarEquipo(Equipo equipo)
    {
        equipos.Add(equipo);
    }

    //Devuelve la lista de equipos
    public static List<Equipo> ObtenerEquipos()
    {
        return equipos;
    }

    //Busca un equipo por su codigo
    public static Equipo? BuscarEquipo(string codigo)
    {
        return equipos.FirstOrDefault(e => e.Codigo == codigo);
    }

    //Presta un equipo a un estudiante
    public static bool PrestarEquipo(string codigo, string estudiante, string fechaPrestamo)
    {
        var equipo = BuscarEquipo(codigo);
        if (equipo != null && equipo.Disponible)
        {
            equipo.Disponible = false;
            equipo.Estudiante = estudiante;
            equipo.FechaPrestamo = fechaPrestamo;
            return true;
        }
        return false;
    }

    //Devuelve un equipo prestado
    public static bool DevolverEquipo(string codigo)
    {
        var equipo = BuscarEquipo(codigo);
        if (equipo != null && !equipo.Disponible)
        {
            equipo.Disponible = true;
            equipo.Estudiante = null;
            equipo.FechaPrestamo = null;
            return true;
        }
        return false;
    }
}