using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{


    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #region Constructores


        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (validarString(value))
                {
                    this.nombre = value;
                }
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (validarString(value))
                {
                    this.apellido = value;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = validarDni(this.nacionalidad, value);

            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.validarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el entero que le llega como parametro este dentro de los rangos y en su contrario tira excepciones
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns>el dni validado si pudo, 0 si no pudo </returns>
        private int validarDni(ENacionalidad nacionalidad, int dni)
        {
            int aux = 0;
            if (dni == 0) throw new DniInvalidoException("Dni ingresado es invalido");
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (!(dni >= 1 && dni < 90000000))
                    {
                        throw new NacionalidadInvalidaException("Dni invalido para persona Argentina");
                    }
                    else aux = dni;
                    break;
                case ENacionalidad.Extranjero:
                    if (!(dni >= 90000000 && dni < 100000000))
                    {
                        throw new NacionalidadInvalidaException("Dni invalido para persona extranjera");
                    }
                    else aux = dni;
                    break;
                default:
                    break;
            }
            return aux;
        }

        /// <summary>
        /// Le llega un dni como string y lo parsea a entero
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dni"></param>
        /// <returns>0 si no pudo el dni en entero si pudo</returns>
        private int validarDni(ENacionalidad nacionalidad, string dni)
        {
            int auxDni;

            if (int.TryParse(dni, out auxDni))
            {
                return this.validarDni(nacionalidad, auxDni);
            }
            return 0;

        }

        /// <summary>
        /// Valida que la cadena que se le manda como parametro tenga cierto formato, en este caso solo caracteres de a-z y A-Z
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true si cumple, false si no cumple</returns>
        private Boolean validarString(string str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-z]+$"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Crea una cadena con la informacion de la persona
        /// </summary>
        /// <returns>La cadena con la info de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO : {this.apellido},{this.nombre}");
            sb.AppendLine($"Nacionalidad : {this.nacionalidad}");
            sb.AppendLine($"DNI: {this.dni}");
            return sb.ToString();
        }
        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }

}
