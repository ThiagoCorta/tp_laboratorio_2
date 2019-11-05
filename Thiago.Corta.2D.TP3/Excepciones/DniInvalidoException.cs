using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
    private const string mensajeBase = "El dni es invalido";

        public DniInvalidoException() : base(mensajeBase)
        {

        }

        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        {

        }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }

    }
}
