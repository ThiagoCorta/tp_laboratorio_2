using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TrabajoPractico1
{
    public partial class MiCalculadora : Form
    {
        private static Calculadora calc;
        private static Numero numero1;
        private static Numero numero2;
        private static double resultado;
        private static string operador;
        public MiCalculadora()
        {
            InitializeComponent();
            
        }

        private void MiCalculadora_Load(object sender, EventArgs e)
        {
            calc = new Calculadora();
            numero1 = new Numero();
            numero2 = new Numero();
            resultado = 0;
            operador = "";

        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
                resultado = calc.Operar(numero1, numero2, operador);
                this.label1.Text = resultado.ToString();
            
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            string numactual = label1.Text;
            this.label1.Text = "";
            this.label1.Text = numero1.BinarioDecimal(numactual).ToString();
            

        }

        private void Button1_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            numero1.SetNumero = numero1.ValidarNumero(textBox1.Text);
            /*double aux = numero1.ValidarNumero(sender.ToString());
            numero1.SetNumero = aux;*/
            

            
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = this.listBox1.SelectedItem.ToString();

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
           numero2.SetNumero = numero2.ValidarNumero(textBox2.Text);
            /*double aux = numero2.ValidarNumero(sender.ToString());
            numero2.SetNumero = aux;*/

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = String.Empty;
           this.textBox2.Text = String.Empty;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
            this.label1.Text = resultado.ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.label1.Text = numero1.DecimalBinario(resultado);
        }
    }
}
