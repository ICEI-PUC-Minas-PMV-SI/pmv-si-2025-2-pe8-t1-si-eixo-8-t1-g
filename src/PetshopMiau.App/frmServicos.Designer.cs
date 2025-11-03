namespace PetshopMiau.App
{
    partial class frmServicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicos));
            groupBox1 = new GroupBox();
            numPreco = new NumericUpDown();
            txtNomeServico = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dgvServicos = new DataGridView();
            btnNovoServico = new Button();
            btnExcluirServico = new Button();
            btnSalvarServico = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numPreco);
            groupBox1.Controls.Add(txtNomeServico);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(67, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(789, 137);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados do Serviço";
            // 
            // numPreco
            // 
            numPreco.BackColor = Color.FromArgb(255, 254, 249);
            numPreco.DecimalPlaces = 2;
            numPreco.Location = new Point(510, 73);
            numPreco.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPreco.Name = "numPreco";
            numPreco.Size = new Size(164, 23);
            numPreco.TabIndex = 3;
            // 
            // txtNomeServico
            // 
            txtNomeServico.BackColor = Color.FromArgb(255, 254, 249);
            txtNomeServico.Location = new Point(20, 73);
            txtNomeServico.Name = "txtNomeServico";
            txtNomeServico.Size = new Size(458, 23);
            txtNomeServico.TabIndex = 2;
            txtNomeServico.TextChanged += txtNomeServico_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(510, 45);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Preço (R$)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 45);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome do Serviço";
            // 
            // dgvServicos
            // 
            dgvServicos.AllowUserToAddRows = false;
            dgvServicos.AllowUserToDeleteRows = false;
            dgvServicos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvServicos.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvServicos.BorderStyle = BorderStyle.None;
            dgvServicos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvServicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicos.Location = new Point(67, 219);
            dgvServicos.MultiSelect = false;
            dgvServicos.Name = "dgvServicos";
            dgvServicos.ReadOnly = true;
            dgvServicos.RowHeadersVisible = false;
            dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicos.Size = new Size(789, 368);
            dgvServicos.TabIndex = 2;
            dgvServicos.SelectionChanged += dgvServicos_SelectionChanged;
            // 
            // btnNovoServico
            // 
            btnNovoServico.BackColor = Color.FromArgb(211, 178, 169);
            btnNovoServico.FlatStyle = FlatStyle.System;
            btnNovoServico.Location = new Point(622, 623);
            btnNovoServico.Name = "btnNovoServico";
            btnNovoServico.Size = new Size(75, 23);
            btnNovoServico.TabIndex = 3;
            btnNovoServico.Text = "Novo";
            btnNovoServico.UseVisualStyleBackColor = false;
            btnNovoServico.Click += btnNovoServico_Click;
            // 
            // btnExcluirServico
            // 
            btnExcluirServico.BackColor = Color.FromArgb(211, 178, 169);
            btnExcluirServico.FlatStyle = FlatStyle.System;
            btnExcluirServico.Location = new Point(703, 623);
            btnExcluirServico.Name = "btnExcluirServico";
            btnExcluirServico.Size = new Size(75, 23);
            btnExcluirServico.TabIndex = 4;
            btnExcluirServico.Text = "Excluir";
            btnExcluirServico.UseVisualStyleBackColor = false;
            btnExcluirServico.Click += btnExcluirServico_Click;
            // 
            // btnSalvarServico
            // 
            btnSalvarServico.BackColor = Color.FromArgb(211, 178, 169);
            btnSalvarServico.FlatStyle = FlatStyle.System;
            btnSalvarServico.Location = new Point(784, 623);
            btnSalvarServico.Name = "btnSalvarServico";
            btnSalvarServico.Size = new Size(75, 23);
            btnSalvarServico.TabIndex = 5;
            btnSalvarServico.Text = "Salvar";
            btnSalvarServico.UseVisualStyleBackColor = false;
            btnSalvarServico.Click += btnSalvarServico_Click;
            // 
            // frmServicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 249, 236);
            ClientSize = new Size(941, 668);
            Controls.Add(btnSalvarServico);
            Controls.Add(btnExcluirServico);
            Controls.Add(btnNovoServico);
            Controls.Add(dgvServicos);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServicos";
            Text = "Cadastro de Serviços";
            Load += frmServicos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvServicos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown numPreco;
        private TextBox txtNomeServico;
        private Label label2;
        private Label label1;
        private DataGridView dgvServicos;
        private Button btnNovoServico;
        private Button btnExcluirServico;
        private Button btnSalvarServico;
    }
}