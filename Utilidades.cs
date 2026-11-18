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
}