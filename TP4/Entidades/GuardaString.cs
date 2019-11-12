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
        public static bool nombre(this String texto, string archivo)
        {
            bool aux = false;
            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(texto))
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (!File.Exists(Path.Combine(desktop, archivo)))
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo));
                        sw.WriteLine(texto);
                        sw.Close();
                        aux = true;
                    }
                    catch
                    {
                        throw new FileLoadException();
                    }
                }
                else if (File.Exists(Path.Combine(desktop, archivo)))
                {
                    try
                    {
                        StreamWriter sw = File.AppendText(Path.Combine(desktop, archivo));
                        sw.WriteLine(texto);
                        sw.Close();
                    }
                    catch
                    {
                        throw new FileLoadException();
                    }

                }
            }
            return aux;
        }

    }
}
