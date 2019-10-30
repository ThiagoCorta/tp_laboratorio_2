using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
  public class Texto : IArchivo<string>
  {
    public bool Guardar(string archivo, string datos)
    {
      bool aux = false;
      try
      {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        StreamWriter sw = new StreamWriter(Path.Combine(desktop, archivo));

        sw.WriteLine(datos);
        sw.Close();
        aux = true;
      }
      catch (IOException e)
      {
        throw new IOException("Error al guardar datos en el archivo");
      }

      return aux;
    }

    public bool Leer(string archivo, out string datos)
    {
      bool aux = false;
      try
      {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        StreamReader sw = new StreamReader(Path.Combine(desktop, archivo));
        datos = sw.ReadToEnd();
        sw.Close();
        aux = true;
      }
      catch (IOException e)
      {
        throw new IOException("Error al guardar datos en el archivo");
      }
      return aux;
    }


  }
}
