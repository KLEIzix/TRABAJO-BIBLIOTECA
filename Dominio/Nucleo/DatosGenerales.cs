using System.IO;

namespace Dominio.Nucleo
{
    public static class DatosGenerales
    {
        // Usar siempre archivo en el directorio de salida (bin/Debug/net8.0/)
        public static string RutaJson { get; set; } =
            Path.Combine(AppContext.BaseDirectory, "SolucionItems", "secrets.json");

        /*tatic DatosGenerales()
         {
             Console.WriteLine("Buscando archivo en: " + RutaJson);
        */

        public static bool UsaAzure { get; set; } = false;

        public static string Clave { get; set; } =
            "EVBgi345936456ghhVBJGtgnifytsidi3456678jhgUTytutyiiyi";

        public static string UsuarioDatos { get; set; } =
            EncriptarConversor.Encriptar("Test.Trghhjsgdj");
    }
}