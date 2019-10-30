using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
  public class Xml<T> : IArchivo<T>
  {
    public bool Guardar(string archivo, T datos)
    {
      throw new NotImplementedException();
    }

    public bool Leer(string archivo, out T datos)
    {
      throw new NotImplementedException();
    }
  }
}
