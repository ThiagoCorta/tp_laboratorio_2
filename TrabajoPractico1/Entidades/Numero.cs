using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Setea los datos en 0
        /// </summary>
        public Numero()
        {

        }

        /// <summary>
        /// Setea el parametro NUM en el campo numero de la clase.
        /// </summary>
        /// <param name="num"></param>
        public Numero(double num)
        {
            this.numero = num;
        }

        /// <summary>
        /// Recive un string que lo parsea a double para poder usar la propiedad de set numero que valida el numero ing.
        /// </summary>
        /// <param name="strNum"></param>
        public Numero(string strNum)
        {
            double aux = 0;
            double.TryParse(strNum, out aux);
            SetNumero = aux;
        }

        /// <summary>
        /// funcion que va a usar la propiedad setnumero, quedo un poco raro pero funciona.
        /// </summary>
        /// <param name="strNum"></param>
        private double ValidarNumero(string strNum)
        {
            double aux = 0;
            double.TryParse(strNum, out aux);
            return aux;
        }

        /// <summary>
        /// valida y setea el numero.
        /// </summary>
        private double SetNumero { set {

                this.numero = ValidarNumero(value.ToString());
            }
        }

        /// <summary>
        /// Recive 2 instancias de la esta clase y retorna la suma los atributos que tienen ambas.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Recive 2 instancias de la esta clase y retorna la resta los atributos que tienen ambas.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Recive 2 instancias de la esta clase y retorna la division y valida que no se divida por cero los atributos que tienen ambas.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else
            {
                return double.MinValue;
            }
        }

        /// <summary>
        /// Recive 2 instancias de la esta clase y retorna la multipliacion los atributos que tienen ambas.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Convierte a binario el numero decimal que es pasado como parametro.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string DecimalBinario(string x) 
        {
            string resultado = "";
            long numIng = Convert.ToInt64(x);
            numIng = Math.Abs(numIng);

            while (numIng > 1)
            {
                long resto = numIng % 2;
                resultado = Convert.ToString(resto) + resultado;
                numIng /= 2;
            }
            return resultado = Convert.ToString(numIng) + resultado;

        }

        /// <summary>
        /// Convierte a decimal el numero binario que es pasado como parametro.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double BinarioDecimal(string x)
        {
            double d = 0;
            foreach (var num in x)
            {
                d *= 2;
                if (num == '1')
                    d += 1;
                else if (num != '0')
                    d = 0;
            }

            return d;
        }
    }
}
