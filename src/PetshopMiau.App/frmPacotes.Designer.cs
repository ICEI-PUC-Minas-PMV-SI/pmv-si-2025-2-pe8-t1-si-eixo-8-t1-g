namespace PetshopMiau.App
{
    // Classe renomeada
    partial class frmPacotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacotes));
            groupBox1 = new GroupBox();
            numValidadeDias = new NumericUpDown();
            numQuantidadeSessoes = new NumericUpDown();
            numPrecoTotal = new NumericUpDown();
            cmbServico = new ComboBox();
            txtNomePacote = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvPacotes = new DataGridView();
            btnNovoPacote = new Button();
            btnExcluirPacote = new Button();
            btnSalvarPacote = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numValidadeDias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidadeSessoes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPacotes).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numValidadeDias);
            groupBox1.Controls.Add(numQuantidadeSessoes);
            groupBox1.Controls.Add(numPrecoTotal);
            groupBox1.Controls.Add(cmbServico);
            groupBox1.Controls.Add(txtNomePacote);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(22, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(855, 185);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados do Pacote";
            // 
            // numValidadeDias
            // 
            numValidadeDias.BackColor = Color.FromArgb(255, 254, 249);
            numValidadeDias.Location = new Point(224, 137);
            numValidadeDias.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numValidadeDias.Name = "numValidadeDias";
            numValidadeDias.Size = new Size(116, 23);
            numValidadeDias.TabIndex = 4;
            // 
            // numQuantidadeSessoes
            // 
            numQuantidadeSessoes.BackColor = Color.FromArgb(255, 254, 249);
            numQuantidadeSessoes.Location = new Point(58, 137);
            numQuantidadeSessoes.Name = "numQuantidadeSessoes";
            numQuantidadeSessoes.Size = new Size(114, 23);
            numQuantidadeSessoes.TabIndex = 3;
            // 
            // numPrecoTotal
            // 
            numPrecoTotal.BackColor = Color.FromArgb(255, 254, 249);
            numPrecoTotal.DecimalPlaces = 2;
            numPrecoTotal.Location = new Point(366, 137);
            numPrecoTotal.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrecoTotal.Name = "numPrecoTotal";
            numPrecoTotal.Size = new Size(102, 23);
            numPrecoTotal.TabIndex = 2;
            numPrecoTotal.ValueChanged += numPrecoTotal_ValueChanged_1;
            // 
            // cmbServico
            // 
            cmbServico.BackColor = Color.FromArgb(255, 254, 249);
            cmbServico.FormattingEnabled = true;
            cmbServico.Location = new Point(512, 137);
            cmbServico.Name = "cmbServico";
            cmbServico.Size = new Size(296, 23);
            cmbServico.TabIndex = 1;
            // 
            // txtNomePacote
            // 
            txtNomePacote.BackColor = Color.FromArgb(255, 254, 249);
            txtNomePacote.Location = new Point(58, 69);
            txtNomePacote.Name = "txtNomePacote";
            txtNomePacote.Size = new Size(750, 23);
            txtNomePacote.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(224, 108);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 5;
            label5.Text = "Validade (Dias)";
            label5.Click += label5_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 108);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 4;
            label4.Text = "Qtd. Sessões";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(366, 108);
            label.Name = "label";
            label.Size = new Size(66, 15);
            label.TabIndex = 3;
            label.Text = "Preço Total";
            label.Click += label_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(512, 108);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 2;
            label2.Text = "Serviço";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 41);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome do Pacote";
            // 
            // dgvPacotes
            // 
            dgvPacotes.AllowUserToAddRows = false;
            dgvPacotes.AllowUserToDeleteRows = false;
            dgvPacotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPacotes.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvPacotes.BorderStyle = BorderStyle.None;
            dgvPacotes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPacotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacotes.Location = new Point(22, 256);
            dgvPacotes.MultiSelect = false;
            dgvPacotes.Name = "dgvPacotes";
            dgvPacotes.ReadOnly = true;
            dgvPacotes.RowHeadersVisible = false;
            dgvPacotes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacotes.Size = new Size(855, 304);
            dgvPacotes.TabIndex = 3;
            dgvPacotes.SelectionChanged += dgvPacotes_SelectionChanged;
            // 
            // btnNovoPacote
            // 
            btnNovoPacote.Location = new Point(640, 592);
            btnNovoPacote.Name = "btnNovoPacote";
            btnNovoPacote.Size = new Size(75, 23);
            btnNovoPacote.TabIndex = 4;
            btnNovoPacote.Text = "Novo";
            btnNovoPacote.UseVisualStyleBackColor = true;
            btnNovoPacote.Click += btnNovoPacote_Click;
            // 
            // btnExcluirPacote
            // 
            btnExcluirPacote.Location = new Point(721, 592);
            btnExcluirPacote.Name = "btnExcluirPacote";
            btnExcluirPacote.Size = new Size(75, 23);
            btnExcluirPacote.TabIndex = 5;
            btnExcluirPacote.Text = "Excluir";
            btnExcluirPacote.UseVisualStyleBackColor = true;
            btnExcluirPacote.Click += btnExcluirPacote_Click;
            // 
            // btnSalvarPacote
            // 
            btnSalvarPacote.Location = new Point(802, 592);
            btnSalvarPacote.Name = "btnSalvarPacote";
            btnSalvarPacote.Size = new Size(75, 23);
            btnSalvarPacote.TabIndex = 6;
            btnSalvarPacote.Text = "Salvar";
            btnSalvarPacote.UseVisualStyleBackColor = true;
            btnSalvarPacote.Click += btnSalvarPacote_Click;
            // 
            // frmPacotes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 249, 236);
            ClientSize = new Size(911, 641);
            Controls.Add(btnSalvarPacote);
            Controls.Add(btnExcluirPacote);
            Controls.Add(btnNovoPacote);
            Controls.Add(dgvPacotes);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmPacotes";
            Text = "Cadastro de Pacotes";
            Load += frmPacotes_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numValidadeDias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidadeSessoes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecoTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPacotes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label;
        private Label label2;
        private Label label1;
        private NumericUpDown numValidadeDias;
        private NumericUpDown numQuantidadeSessoes;
        private NumericUpDown numPrecoTotal;
        private DataGridView dgvPacotes;
        private Button btnNovoPacote;
        private Button btnExcluirPacote;
        private Button btnSalvarPacote;
        private ComboBox cmbServico;
        private TextBox txtNomePacote;
    }
}