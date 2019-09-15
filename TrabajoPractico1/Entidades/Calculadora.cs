using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Recive dos instancias de la clase Numero y un string.
        /// Realiza la operacion matematica segun el signo que se paso como parametro (string)
        /// Retorna el valor de la operacion
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double Operar(Numero n1, Numero n2, string operador)
        {

            double cuenta = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    cuenta = n1 + n2;
                    break;
                case "-":
                    cuenta = n1 - n2;
                    break;
                case "/":
                    cuenta = n1 / n2;
                    break;
                case "*":
                    cuenta = n1 * n2;
                    break;
            }
            return cuenta;
        }

        /// <summary>
        /// Recive un string y valida cual de los operadores es, + - / * etc y lo devuelve.
        /// Caso contrario que no sea ninguno de esos, devuelve +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
           
            if (operador != "-" && operador != "+" && operador != "/" && operador != "*")
            {
                return "+";
            }

            return operador;
        }

    }
}
