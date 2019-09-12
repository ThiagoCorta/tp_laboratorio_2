namespace MiCalculadora
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnDecConvert = new System.Windows.Forms.Button();
            this.btnBinConvert = new System.Windows.Forms.Button();
            this.tbOperador1 = new System.Windows.Forms.TextBox();
            this.tbOperador2 = new System.Windows.Forms.TextBox();
            this.cbOperadores = new System.Windows.Forms.ComboBox();
            this.lbResultado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(32, 180);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(197, 65);
            this.btnOperar.TabIndex = 2;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(244, 180);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(197, 65);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(456, 180);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(197, 65);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // btnDecConvert
            // 
            this.btnDecConvert.Location = new System.Drawing.Point(349, 274);
            this.btnDecConvert.Name = "btnDecConvert";
            this.btnDecConvert.Size = new System.Drawing.Size(304, 65);
            this.btnDecConvert.TabIndex = 8;
            this.btnDecConvert.Text = "Convertir a decimal";
            this.btnDecConvert.UseVisualStyleBackColor = true;
            this.btnDecConvert.Click += new System.EventHandler(this.BtnDecConvert_Click);
            // 
            // btnBinConvert
            // 
            this.btnBinConvert.Location = new System.Drawing.Point(32, 274);
            this.btnBinConvert.Name = "btnBinConvert";
            this.btnBinConvert.Size = new System.Drawing.Size(304, 65);
            this.btnBinConvert.TabIndex = 9;
            this.btnBinConvert.Text = "Convertir a binario";
            this.btnBinConvert.UseVisualStyleBackColor = true;
            this.btnBinConvert.Click += new System.EventHandler(this.BtnBinConvert_Click);
            // 
            // tbOperador1
            // 
            this.tbOperador1.Location = new System.Drawing.Point(32, 86);
            this.tbOperador1.Multiline = true;
            this.tbOperador1.Name = "tbOperador1";
            this.tbOperador1.Size = new System.Drawing.Size(197, 66);
            this.tbOperador1.TabIndex = 10;
            this.tbOperador1.TextChanged += new System.EventHandler(this.TbOperador1_TextChanged);
            // 
            // tbOperador2
            // 
            this.tbOperador2.Location = new System.Drawing.Point(456, 86);
            this.tbOperador2.Multiline = true;
            this.tbOperador2.Name = "tbOperador2";
            this.tbOperador2.Size = new System.Drawing.Size(197, 66);
            this.tbOperador2.TabIndex = 11;
            this.tbOperador2.TextChanged += new System.EventHandler(this.TbOperador2_TextChanged);
            // 
            // cbOperadores
            // 
            this.cbOperadores.AutoCompleteCustomSource.AddRange(new string[] {
            "+",
            "-",
            "*",
            "/"});
            this.cbOperadores.FormattingEnabled = true;
            this.cbOperadores.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cbOperadores.Location = new System.Drawing.Point(244, 86);
            this.cbOperadores.Name = "cbOperadores";
            this.cbOperadores.Size = new System.Drawing.Size(197, 28);
            this.cbOperadores.TabIndex = 14;
            this.cbOperadores.Text = "Operador";
            this.cbOperadores.SelectedIndexChanged += new System.EventHandler(this.CbOperadores_SelectedIndexChanged);
            // 
            // lbResultado
            // 
            this.lbResultado.AutoSize = true;
            this.lbResultado.Font = new System.Drawing.Font("Arial", 10F);
            this.lbResultado.Location = new System.Drawing.Point(447, 23);
            this.lbResultado.Name = "lbResultado";
            this.lbResultado.Size = new System.Drawing.Size(42, 23);
            this.lbResultado.TabIndex = 15;
            this.lbResultado.Text = "";
            this.lbResultado.Click += new System.EventHandler(this.LbResultado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Resultado : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbResultado);
            this.Controls.Add(this.cbOperadores);
            this.Controls.Add(this.tbOperador2);
            this.Controls.Add(this.tbOperador1);
            this.Controls.Add(this.btnBinConvert);
            this.Controls.Add(this.btnDecConvert);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.Name = "Form1";
            this.Text = "Calculadora Thiago Tomas Corta 2D";
            this.Load += new System.EventHandler(this.CalculadoraThiagoTomasCorta2D_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnDecConvert;
        private System.Windows.Forms.Button btnBinConvert;
        private System.Windows.Forms.TextBox tbOperador1;
        private System.Windows.Forms.TextBox tbOperador2;
        private System.Windows.Forms.ComboBox cbOperadores;
        private System.Windows.Forms.Label lbResultado;
        private System.Windows.Forms.Label label1;
    }
}

