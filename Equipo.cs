//Class de equipo del laboratorio (laptop, mouse, cable, etc.)
class Equipo
{
    public string Codigo { get; set; }="";
    public string Nombre { get; set; }="";
    public string Categoria { get; set; }="";

    //true: diponible, false: no disponible
    public bool Disponible { get; set; }

    //Datos del ultimo prestamos
    public string? Estudiante { get; set; }
    public string? FechaPrestamo { get; set; }
    
    //Pedir texto y se asegura que no esté vacio
    public static string PedirTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? texto = Console.ReadLine();

            //Limpia espacios en blanco al inicio y final del texto
            texto = Utilidades.QuitarEspacios(texto?? "");
            
            if (!string.IsNullOrEmpty(texto))
            {
                return texto;
            }
            Console.WriteLine("El texto no puede estar vacío. Intente de nuevo.");
        }
    }
}