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


        private int validarDni(ENacionalidad nacionalidad, int dni)
        {
            int aux = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (!(dni > 0 && dni < 90000000))
                    {
                        throw new NacionalidadInvalidaException("Dni invalido para persona Argentina");
                    }
                    else aux = dni;
                    break;
                case ENacionalidad.Extranjero:
                    if (!(dni > 90000000 && dni < 100000000))
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

        private int validarDni(ENacionalidad nacionalidad, string dni)
        {
            int auxDni;
            if (int.TryParse(dni, out auxDni))
            {
                return this.validarDni(nacionalidad, auxDni);
            }
            return 0;

        }

        private Boolean validarString(string str)
        {

            if (Regex.IsMatch(str, @"^[a-zA-z]+$"))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre : {this.nombre}");
            sb.AppendLine($"Apellido : {this.apellido}");
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
