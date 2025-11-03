namespace PetshopMiau.App
{
    partial class frmCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaixa));
            label1 = new Label();
            dtpDataCaixa = new DateTimePicker();
            groupBox1 = new GroupBox();
            btnConfirmarPagamento = new Button();
            dgvPagamentosPendentes = new DataGridView();
            panel1 = new Panel();
            label2 = new Label();
            lblTotalDoDia = new Label();
            groupBox2 = new GroupBox();
            dgvSangrias = new DataGridView();
            btnRegistrarSangria = new Button();
            txtDescricaoSangria = new TextBox();
            label4 = new Label();
            numValorSangria = new NumericUpDown();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagamentosPendentes).BeginInit();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSangrias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numValorSangria).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 38);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione o Dia:";
            // 
            // dtpDataCaixa
            // 
            dtpDataCaixa.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataCaixa.Format = DateTimePickerFormat.Short;
            dtpDataCaixa.Location = new Point(130, 32);
            dtpDataCaixa.Name = "dtpDataCaixa";
            dtpDataCaixa.Size = new Size(101, 23);
            dtpDataCaixa.TabIndex = 1;
            dtpDataCaixa.ValueChanged += dtpDataCaixa_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConfirmarPagamento);
            groupBox1.Controls.Add(dgvPagamentosPendentes);
            groupBox1.Location = new Point(34, 266);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(899, 403);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pagamentos Pendentes do Dia";
            // 
            // btnConfirmarPagamento
            // 
            btnConfirmarPagamento.Location = new Point(719, 365);
            btnConfirmarPagamento.Name = "btnConfirmarPagamento";
            btnConfirmarPagamento.Size = new Size(161, 23);
            btnConfirmarPagamento.TabIndex = 4;
            btnConfirmarPagamento.Text = "Confirmar Pagamento";
            btnConfirmarPagamento.UseVisualStyleBackColor = true;
            btnConfirmarPagamento.Click += btnConfirmarPagamento_Click;
            // 
            // dgvPagamentosPendentes
            // 
            dgvPagamentosPendentes.AllowUserToAddRows = false;
            dgvPagamentosPendentes.AllowUserToDeleteRows = false;
            dgvPagamentosPendentes.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvPagamentosPendentes.BorderStyle = BorderStyle.None;
            dgvPagamentosPendentes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPagamentosPendentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagamentosPendentes.Location = new Point(15, 22);
            dgvPagamentosPendentes.MultiSelect = false;
            dgvPagamentosPendentes.Name = "dgvPagamentosPendentes";
            dgvPagamentosPendentes.ReadOnly = true;
            dgvPagamentosPendentes.RowHeadersVisible = false;
            dgvPagamentosPendentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagamentosPendentes.Size = new Size(865, 337);
            dgvPagamentosPendentes.TabIndex = 3;
            dgvPagamentosPendentes.SelectionChanged += dgvPagamentosPendentes_SelectionChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblTotalDoDia);
            panel1.Location = new Point(557, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(376, 69);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 30);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 4;
            label2.Text = "Total do Caixa:";
            // 
            // lblTotalDoDia
            // 
            lblTotalDoDia.AutoSize = true;
            lblTotalDoDia.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalDoDia.Location = new Point(173, 20);
            lblTotalDoDia.Name = "lblTotalDoDia";
            lblTotalDoDia.Size = new Size(92, 32);
            lblTotalDoDia.TabIndex = 5;
            lblTotalDoDia.Text = "R$ 0,00";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvSangrias);
            groupBox2.Controls.Add(btnRegistrarSangria);
            groupBox2.Controls.Add(txtDescricaoSangria);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(numValorSangria);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(34, 95);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(899, 150);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registrar Sangria";
            // 
            // dgvSangrias
            // 
            dgvSangrias.AllowUserToAddRows = false;
            dgvSangrias.AllowUserToDeleteRows = false;
            dgvSangrias.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvSangrias.BorderStyle = BorderStyle.None;
            dgvSangrias.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvSangrias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSangrias.Location = new Point(444, 22);
            dgvSangrias.MultiSelect = false;
            dgvSangrias.Name = "dgvSangrias";
            dgvSangrias.ReadOnly = true;
            dgvSangrias.RowHeadersVisible = false;
            dgvSangrias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSangrias.Size = new Size(436, 113);
            dgvSangrias.TabIndex = 5;
            // 
            // btnRegistrarSangria
            // 
            btnRegistrarSangria.Location = new Point(268, 110);
            btnRegistrarSangria.Name = "btnRegistrarSangria";
            btnRegistrarSangria.Size = new Size(140, 23);
            btnRegistrarSangria.TabIndex = 4;
            btnRegistrarSangria.Text = "Registrar Sangria";
            btnRegistrarSangria.UseVisualStyleBackColor = true;
            btnRegistrarSangria.Click += btnRegistrarSangria_Click;
            // 
            // txtDescricaoSangria
            // 
            txtDescricaoSangria.BackColor = Color.FromArgb(255, 254, 249);
            txtDescricaoSangria.Location = new Point(15, 49);
            txtDescricaoSangria.Name = "txtDescricaoSangria";
            txtDescricaoSangria.Size = new Size(393, 23);
            txtDescricaoSangria.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 22);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 2;
            label4.Text = "Descrição:";
            // 
            // numValorSangria
            // 
            numValorSangria.BackColor = Color.FromArgb(255, 254, 249);
            numValorSangria.DecimalPlaces = 2;
            numValorSangria.Location = new Point(16, 112);
            numValorSangria.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numValorSangria.Name = "numValorSangria";
            numValorSangria.Size = new Size(134, 23);
            numValorSangria.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 85);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 0;
            label3.Text = "Valor (R$):";
            label3.Click += label3_Click;
            // 
            // frmCaixa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 249, 236);
            ClientSize = new Size(954, 681);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(dtpDataCaixa);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCaixa";
            Text = "Controle de Caixa";
            Load += frmCaixa_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagamentosPendentes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSangrias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numValorSangria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDataCaixa;
        private GroupBox groupBox1;
        private Button btnConfirmarPagamento;
        private DataGridView dgvPagamentosPendentes;
        private Panel panel1;
        private Label label2;
        private Label lblTotalDoDia;
        private GroupBox groupBox2;
        private Button btnRegistrarSangria;
        private TextBox txtDescricaoSangria;
        private Label label4;
        private NumericUpDown numValorSangria;
        private Label label3;
        private DataGridView dgvSangrias;
    }
}