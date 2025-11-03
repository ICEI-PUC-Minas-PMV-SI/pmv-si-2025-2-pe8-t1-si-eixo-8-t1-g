namespace PetshopMiau.App
{
    partial class frmRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorios));
            label1 = new Label();
            lblDataInicio = new Label();
            lblDataFim = new Label();
            cmbTipoRelatorio = new ComboBox();
            dtpDataInicio = new DateTimePicker();
            dtpDataFim = new DateTimePicker();
            btnGerarRelatorio = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 62);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 0;
            label1.Text = "Tipo de Relatório:";
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Location = new Point(255, 142);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(66, 15);
            lblDataInicio.TabIndex = 1;
            lblDataInicio.Text = "Data Início:";
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Location = new Point(100, 142);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(57, 15);
            lblDataFim.TabIndex = 2;
            lblDataFim.Text = "Data Fim:";
            // 
            // cmbTipoRelatorio
            // 
            cmbTipoRelatorio.BackColor = Color.FromArgb(255, 254, 249);
            cmbTipoRelatorio.FormattingEnabled = true;
            cmbTipoRelatorio.Location = new Point(100, 90);
            cmbTipoRelatorio.Name = "cmbTipoRelatorio";
            cmbTipoRelatorio.Size = new Size(252, 23);
            cmbTipoRelatorio.TabIndex = 3;
            cmbTipoRelatorio.SelectedIndexChanged += cmbTipoRelatorio_SelectedIndexChanged;
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataInicio.Format = DateTimePickerFormat.Short;
            dtpDataInicio.Location = new Point(255, 170);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(97, 23);
            dtpDataInicio.TabIndex = 4;
            // 
            // dtpDataFim
            // 
            dtpDataFim.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataFim.Format = DateTimePickerFormat.Short;
            dtpDataFim.Location = new Point(103, 170);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.Size = new Size(97, 23);
            dtpDataFim.TabIndex = 5;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(336, 237);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(75, 23);
            btnGerarRelatorio.TabIndex = 6;
            btnGerarRelatorio.Text = "Gerar PDF";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // frmRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 249, 236);
            ClientSize = new Size(436, 283);
            Controls.Add(btnGerarRelatorio);
            Controls.Add(dtpDataFim);
            Controls.Add(dtpDataInicio);
            Controls.Add(cmbTipoRelatorio);
            Controls.Add(lblDataFim);
            Controls.Add(lblDataInicio);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRelatorios";
            Text = "frmRelatorios";
            Load += frmRelatorios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblDataInicio;
        private Label lblDataFim;
        private ComboBox cmbTipoRelatorio;
        private DateTimePicker dtpDataInicio;
        private DateTimePicker dtpDataFim;
        private Button btnGerarRelatorio;
    }
}