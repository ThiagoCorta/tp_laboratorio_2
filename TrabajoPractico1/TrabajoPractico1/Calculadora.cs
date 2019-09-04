using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    class Calculadora
    {
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

        private static string ValidarOperador(string operador)
        {
                
            if(operador!="-" && operador!="+" && operador!="/" && operador != "*")
            {
                return "+";
            }

            return operador;
        }
    }
}