using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TrabajoPractico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MiCalculadora());

            Numero num1 = new Numero();
            Numero num2 = new Numero();

            Console.ReadKey();
        }
    }
}
