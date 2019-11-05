using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Universitarios

        public Universitario() : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Usando mostrar datos de la base, le agrega el legajo al string
        /// </summary>
        /// <returns>los datos de la persona mas el legajo</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO : {this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Ve si el objeto que le llega como parametro es de tipo universitario
        /// </summary>
        /// <param name="obj">objeto a analizar</param>
        /// <returns>true si es o false si no es</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Ve si un universitario es igual a otro si su dni y legajo coinciden
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son iguales, false si no</returns>
        public static bool operator ==(Universitario p1, Universitario p2)
        {
            if (p1.Equals(p2))
            {
                if (p1.DNI == p2.DNI || p1.legajo == p2.legajo)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Ve si un universitario es igual a otro si su dni y legajo coinciden
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son iguales, false si no</returns>
        public static bool operator !=(Universitario p1, Universitario p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
