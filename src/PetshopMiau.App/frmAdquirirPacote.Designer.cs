namespace PetshopMiau.App
{
    partial class frmAdquirirPacote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdquirirPacote));
            label1 = new Label();
            cmbPacotesDisponiveis = new ComboBox();
            btnConfirmarAquisicao = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione o Pacote";
            // 
            // cmbPacotesDisponiveis
            // 
            cmbPacotesDisponiveis.BackColor = Color.FromArgb(255, 254, 249);
            cmbPacotesDisponiveis.FormattingEnabled = true;
            cmbPacotesDisponiveis.Location = new Point(31, 61);
            cmbPacotesDisponiveis.Name = "cmbPacotesDisponiveis";
            cmbPacotesDisponiveis.Size = new Size(234, 23);
            cmbPacotesDisponiveis.TabIndex = 1;
            cmbPacotesDisponiveis.SelectionChangeCommitted += cmbPacotesDisponiveis_SelectedIndexChanged;
            // 
            // btnConfirmarAquisicao
            // 
            btnConfirmarAquisicao.Location = new Point(205, 108);
            btnConfirmarAquisicao.Name = "btnConfirmarAquisicao";
            btnConfirmarAquisicao.Size = new Size(75, 23);
            btnConfirmarAquisicao.TabIndex = 2;
            btnConfirmarAquisicao.Text = "Confirmar";
            btnConfirmarAquisicao.UseVisualStyleBackColor = true;
            btnConfirmarAquisicao.Click += btnConfirmarAquisicao_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(124, 108);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // frmAdquirirPacote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 249, 236);
            ClientSize = new Size(292, 143);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmarAquisicao);
            Controls.Add(cmbPacotesDisponiveis);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAdquirirPacote";
            Text = "frmAdquirirPacote";
            Load += frmAdquirirPacote_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbPacotesDisponiveis;
        private Button btnConfirmarAquisicao;
        private Button btnCancelar;
    }
}