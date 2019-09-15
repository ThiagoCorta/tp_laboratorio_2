using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double aux = 0;
            if(double.TryParse(tbOperador1.Text,out aux) && double.TryParse(tbOperador2.Text, out aux) && (aux!=0 || cbOperadores.Text !="/"))
            {
                Calculadora calc = new Calculadora();
                Numero operador1 = new Numero(tbOperador1.Text);
                Numero operador2 = new Numero(tbOperador2.Text);
                lbResultado.Text = calc.Operar(operador1, operador2, cbOperadores.Text).ToString();
                btnBinConvert.Enabled = true;
            }
            else
            {

                var result = System.Windows.Forms.MessageBox.Show("Error verifique los campos.", "Atencion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1, (System.Windows.Forms.MessageBoxOptions)8192 /*MB_TASKMODAL*/);
                this.Limpiar();
            }


        }

        private void CalculadoraThiagoTomasCorta2D_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Limpiar();
        }

        private void CbOperadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void TbOperador2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbOperador1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnDecConvert_Click(object sender, EventArgs e)
        {
            Numero numDec = new Numero();
            lbResultado.Text = numDec.BinarioDecimal(lbResultado.Text).ToString();
        }

        private void BtnBinConvert_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (int.TryParse(lbResultado.Text, out aux))
            {
                Numero numBin = new Numero();
                lbResultado.Text = numBin.DecimalBinario(lbResultado.Text);
                btnDecConvert.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error, solo se pueden transformar a binario numeros enteros", "Atencion!");
                this.Limpiar();
                
            }
            
        }

        private void LbResultado_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            lbResultado.Text = String.Empty;
            tbOperador1.Text = String.Empty;
            tbOperador2.Text = String.Empty;
            cbOperadores.SelectedItem = "+";
            cbOperadores.Text = "Operador";
            btnBinConvert.Enabled = false;
            btnDecConvert.Enabled = false;
            
        }
    }
}
