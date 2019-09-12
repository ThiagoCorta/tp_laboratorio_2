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

        public Numero()
        {

        }

        public Numero(double num)
        {
            this.numero = num;
        }

        public Numero(string strNum)
        {
            double aux = 0;
            double.TryParse(strNum, out aux);
            SetNumero = aux;
        }

        private double ValidarNumero(string strNum)
        {
            double aux = 0;
            double.TryParse(strNum, out aux);
            return aux;
        }


        private double SetNumero { set {

                this.numero = ValidarNumero(value.ToString());
            }
        }
        
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

        public double BinarioDecimal(string x)
        {
            if (string.IsNullOrEmpty(x))
                throw new ArgumentNullException("x");

            double d = 0;
            foreach (var c in x)
            {
                d *= 2;
                if (c == '1')
                    d += 1;
                else if (c != '0')
                    throw new FormatException();
            }

            return d;
        }
    }
}
