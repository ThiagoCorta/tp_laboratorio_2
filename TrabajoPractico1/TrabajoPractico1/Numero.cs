using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico1
{
    class Numero
    {
        private double numero;

        public Numero()
        {

        }

        public Numero(double num)
        {
            this.numero = num;
        }

        public Numero(string strNum)
        {
            this.numero = ValidarNumero(strNum);
        }

        public double ValidarNumero(string strNum)
        {
            double aux = 0;
            double.TryParse(strNum, out aux);
            return aux;
        }


        public double SetNumero { set { this.numero = value; } }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

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

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public string DecimalBinario(double x)
        {
            string resultado = "";
            int numIng = Convert.ToInt32(x);

            while (numIng > 1)
            {
                int resto = numIng % 2;
                resultado = Convert.ToString(resto) + resultado;
                numIng /= 2;
            }
            return resultado = Convert.ToString(numIng) + resultado;
            
        }

        public double BinarioDecimal(string x)
        {
            return Convert.ToDouble(x);
        }

    }
}
