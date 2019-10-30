using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        bool aux = false;
        public bool Guardar(string archivo, string datos)
        {
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(datos))
            {
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo));
                    sw.WriteLine(datos);
                    sw.Close();
                    aux = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }

            return aux;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool aux = false;
            datos = "";
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamReader sw = new StreamReader(Path.Combine(desktop, archivo));
                    datos = sw.ReadToEnd();
                    sw.Close();
                    aux = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return aux;
        }


    }
}
