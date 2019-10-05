using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo,marca,color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }


        /// <summary>
        /// sobrescribe el mostrar de producto, mostrando el producto / calorias
        /// </summary>
        /// <returns>el producto dulce</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"CALORIAS : {this.CantidadCalorias}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
