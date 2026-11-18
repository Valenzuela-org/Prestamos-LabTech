//Funciones de utilidad para el proyecto
static class Utilidades
{
    //Quita los espacios en blanco al inicio y final de un string
    public static string QuitarEspacios(string texto)
    {
        return texto.Trim();
    }

    //Devuelve true si el texto tiene contenido, false si es null o vacio
    public static bool TieneContenido(string texto)
    {
        return !string.IsNullOrEmpty(texto);
    }

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