using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo de apertura de archivos para guardar una jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si pudo guardarlo, false si no pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            return txt.Guardar("jornada.log", jornada.ToString());
        }

        /// <summary>
        /// Metodo para leer el contenido de un archivo
        /// </summary>
        /// <returns>El string con el contenido que tenia el archivo</returns>
        public static string Leer()
        {
            string aux = "";
            Texto txt = new Texto();
            txt.Leer("jornada.log", out aux);
            return aux;
        }
        /// <summary>
        /// Muestra toda la informacion de la jornada, clase profesor alumnos.
        /// </summary>
        /// <returns>el string con toda la info</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CLASE DE {this.clase} POR {this.instructor.ToString()}");
            sb.AppendLine("ALUMNOS :");
            foreach (Alumno item in this.alumnos)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Jornada y alumno son iguales si el alumno participa en la clase que se da en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si es parte, false si no lo es</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if (item.DNI == a.DNI) return true;
            }
            return false;
        }
        /// <summary>
        /// Jornada y alumno son iguales si el alumno participa en la clase que se da en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si es parte, false si no lo es</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega a un alumno a la jornada si es que el no existe alli actualmente
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a) j.alumnos.Add(a);
            return j;
        }

        #endregion
    }
}
