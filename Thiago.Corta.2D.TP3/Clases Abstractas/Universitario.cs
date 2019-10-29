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
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Legajo : {this.legajo}");
            sb.Append(base.ToString());
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Universitario))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Sobrecargas

        public static bool operator ==(Universitario p1, Universitario p2)
        {
            if (p1.Equals(p2))
            {
                if (p1.DNI == p2.DNI && p1.legajo == p2.legajo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Universitario p1, Universitario p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
