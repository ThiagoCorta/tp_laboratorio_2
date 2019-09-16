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

        /// <summary>
        /// Instancia la calculadora y ambos operadores, consigue los valores de las textbox y valida lo necesario para poder operar.
        /// habilita el boton de convertir a binario y calcula la operacion y la escribe en el lbl de resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                btnDecConvert.Enabled = false;
            }
            else
            {

                MessageBox.Show("Error verifique los campos.", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions)8192 /*MB_TASKMODAL*/);
                this.Limpiar();
            }


        }

        /// <summary>
        /// Centra el windows form a la pantalla.
        /// Limpia todos los campos para dejarlo de forma correcta.
        /// Defino los tabindex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculadoraThiagoTomasCorta2D_Load(object sender, EventArgs e)
        {
            tbOperador1.TabIndex = 0;
            cbOperadores.TabIndex = 1;
            tbOperador2.TabIndex = 2;
            btnOperar.TabIndex = 3;
            btnBinConvert.TabIndex = 4;
            btnDecConvert.TabIndex = 5;
            btnLimpiar.TabIndex = 6;
            btnCerrar.TabIndex = 7;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            this.Limpiar();
        }

        private void CbOperadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cierra el forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Limpia los campos y setea todo de cero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Instancia un numero decimal, consigue el resultado que se quiere pasar a DEC y lo muestra en pantalla.
        /// Habilita el boton de convertir a binario y se desactiva el boton de convertir a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDecConvert_Click(object sender, EventArgs e)
        {
            Numero numDec = new Numero();
            lbResultado.Text = numDec.BinarioDecimal(lbResultado.Text).ToString();
            btnDecConvert.Enabled = false;
            btnBinConvert.Enabled = true;
        }

        /// <summary>
        /// Convierte de decimal a binario
        /// Se desactiva el boton para convertir a binario y se activa el de convertir a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBinConvert_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (int.TryParse(lbResultado.Text, out aux))
            {
                Numero numBin = new Numero();
                lbResultado.Text = numBin.DecimalBinario(lbResultado.Text);
                btnDecConvert.Enabled = true;
                btnBinConvert.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error, solo se pueden transformar a binario numeros enteros", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, (MessageBoxOptions)8192 /*MB_TASKMODAL*/);
                this.Limpiar();
                
            }
            
        }

        private void LbResultado_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// Deshabilita los botones de convertir a binario y a decimal.
        /// </summary>
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
