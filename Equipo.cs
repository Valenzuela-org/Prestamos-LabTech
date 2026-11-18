//Class de equipo del laboratorio (laptop, mouse, cable, etc.)
class Equipo
{
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Categoria { get; set; } = "";

    //true: diponible, false: no disponible
    public bool Disponible { get; set; }

    //Datos del ultimo prestamos
    public string? Estudiante { get; set; }
    public string? FechaPrestamo { get; set; }
}
