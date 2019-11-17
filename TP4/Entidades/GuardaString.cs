using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension a la clase string
        /// Guarda el texto en el archivo que se ubica en el desktop
        /// Si el archivo ya existe agrega info en el si no lo crea
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>True si pudo agregar la info false si ocurrio algo o se lanzo una excepcion</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(texto))
            {
                string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);
                bool append = File.Exists(desktop);
                StreamWriter sw = new StreamWriter(desktop, append);
                try
                {
                    sw.WriteLine(texto);
                    aux = true;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al escribir el archivo", e);

                }
                finally
                {
                    sw.Close();

                }
            }
            return aux;
        }
    }
}
