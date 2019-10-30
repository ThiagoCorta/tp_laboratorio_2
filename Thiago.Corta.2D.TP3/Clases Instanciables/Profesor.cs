using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;


        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }


        #endregion

        #region Metodos
        /// <summary>
        /// Agrega a la lista de clases que da el profesor, 2 clases generadas de forma random
        /// </summary>
        private void _randomClases()
        {
            int length = Enum.GetValues(typeof(Universidad.EClases)).Length;
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, length));
            }
        }

        /// <summary>
        /// Muestra todos ls datos del profesor y que clases participa.
        /// </summary>
        /// <returns>el string con la info</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();

        }

        /// <summary>
        /// Genera un string con las clases que da el profesor
        /// </summary>
        /// <returns>Devuelve el string generado</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Clases del dia : ");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Muestra todos lo datos del profesor de forma publica usando metodos privados de la clase para generar el string
        /// </summary>
        /// <returns>Toda la info del profe!</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un profesor es igual a la clase si el profesor puede dar la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si da la clase, false si no la da</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase) return true;
            }
            return false;
        }

        /// <summary>
        /// Un profesor es igual a la clase si el profesor puede dar la clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>true si da la clase, false si no la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


        #endregion
    }
}
