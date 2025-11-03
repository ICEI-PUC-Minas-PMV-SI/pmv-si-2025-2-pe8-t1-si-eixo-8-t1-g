namespace PetshopMiau.App
{
    partial class frmAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgenda));
            label1 = new Label();
            dtpDataAgenda = new DateTimePicker();
            dgvAgendamentos = new DataGridView();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            btnSalvarAgendamento = new Button();
            txtObsAgendamento = new TextBox();
            dtpHorario = new DateTimePicker();
            cmbServico = new ComboBox();
            cmbPet = new ComboBox();
            cmbCliente = new ComboBox();
            label6 = new Label();
            lblServico = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancelarAgendamento = new Button();
            btnPesquisarData = new Button();
            btnConcluirAgendamento = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAgendamentos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 29);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Selecione a Data:";
            // 
            // dtpDataAgenda
            // 
            dtpDataAgenda.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataAgenda.Format = DateTimePickerFormat.Short;
            dtpDataAgenda.Location = new Point(138, 25);
            dtpDataAgenda.Name = "dtpDataAgenda";
            dtpDataAgenda.Size = new Size(90, 23);
            dtpDataAgenda.TabIndex = 1;
            // 
            // dgvAgendamentos
            // 
            dgvAgendamentos.AllowUserToAddRows = false;
            dgvAgendamentos.AllowUserToDeleteRows = false;
            dgvAgendamentos.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvAgendamentos.BorderStyle = BorderStyle.None;
            dgvAgendamentos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAgendamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAgendamentos.Location = new Point(36, 229);
            dgvAgendamentos.MultiSelect = false;
            dgvAgendamentos.Name = "dgvAgendamentos";
            dgvAgendamentos.ReadOnly = true;
            dgvAgendamentos.RowHeadersVisible = false;
            dgvAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAgendamentos.Size = new Size(788, 312);
            dgvAgendamentos.TabIndex = 2;
            dgvAgendamentos.SelectionChanged += dgvAgendamentos_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(btnSalvarAgendamento);
            groupBox1.Controls.Add(txtObsAgendamento);
            groupBox1.Controls.Add(dtpHorario);
            groupBox1.Controls.Add(cmbServico);
            groupBox1.Controls.Add(cmbPet);
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblServico);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(36, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(788, 143);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Novo Agendamento";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.FromArgb(255, 254, 249);
            checkBox1.Location = new Point(705, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(62, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Pacote";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // btnSalvarAgendamento
            // 
            btnSalvarAgendamento.BackColor = Color.FromArgb(211, 178, 169);
            btnSalvarAgendamento.FlatStyle = FlatStyle.System;
            btnSalvarAgendamento.Location = new Point(592, 107);
            btnSalvarAgendamento.Name = "btnSalvarAgendamento";
            btnSalvarAgendamento.Size = new Size(175, 23);
            btnSalvarAgendamento.TabIndex = 10;
            btnSalvarAgendamento.Text = "Salvar Agendamento";
            btnSalvarAgendamento.UseVisualStyleBackColor = false;
            btnSalvarAgendamento.Click += btnSalvarAgendamento_Click;
            // 
            // txtObsAgendamento
            // 
            txtObsAgendamento.BackColor = Color.FromArgb(255, 254, 249);
            txtObsAgendamento.Location = new Point(171, 107);
            txtObsAgendamento.Multiline = true;
            txtObsAgendamento.Name = "txtObsAgendamento";
            txtObsAgendamento.Size = new Size(396, 23);
            txtObsAgendamento.TabIndex = 9;
            // 
            // dtpHorario
            // 
            dtpHorario.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpHorario.Format = DateTimePickerFormat.Time;
            dtpHorario.Location = new Point(20, 107);
            dtpHorario.Name = "dtpHorario";
            dtpHorario.ShowUpDown = true;
            dtpHorario.Size = new Size(123, 23);
            dtpHorario.TabIndex = 8;
            // 
            // cmbServico
            // 
            cmbServico.BackColor = Color.FromArgb(255, 254, 249);
            cmbServico.FormattingEnabled = true;
            cmbServico.Location = new Point(546, 54);
            cmbServico.Name = "cmbServico";
            cmbServico.Size = new Size(219, 23);
            cmbServico.TabIndex = 7;
            // 
            // cmbPet
            // 
            cmbPet.BackColor = Color.FromArgb(255, 254, 249);
            cmbPet.FormattingEnabled = true;
            cmbPet.Location = new Point(393, 54);
            cmbPet.Name = "cmbPet";
            cmbPet.Size = new Size(135, 23);
            cmbPet.TabIndex = 6;
            // 
            // cmbCliente
            // 
            cmbCliente.BackColor = Color.FromArgb(255, 254, 249);
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(20, 54);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(350, 23);
            cmbCliente.TabIndex = 5;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 80);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 4;
            label6.Text = "Hórario:";
            label6.Click += label6_Click;
            // 
            // lblServico
            // 
            lblServico.AutoSize = true;
            lblServico.Location = new Point(546, 29);
            lblServico.Name = "lblServico";
            lblServico.Size = new Size(48, 15);
            lblServico.TabIndex = 3;
            lblServico.Text = "Serviço:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(171, 80);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 2;
            label4.Text = "Observações";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 29);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 1;
            label3.Text = "Pet:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 29);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 0;
            label2.Text = "Cliente:";
            // 
            // btnCancelarAgendamento
            // 
            btnCancelarAgendamento.BackColor = Color.FromArgb(211, 178, 169);
            btnCancelarAgendamento.FlatStyle = FlatStyle.System;
            btnCancelarAgendamento.Location = new Point(509, 563);
            btnCancelarAgendamento.Name = "btnCancelarAgendamento";
            btnCancelarAgendamento.Size = new Size(156, 23);
            btnCancelarAgendamento.TabIndex = 4;
            btnCancelarAgendamento.Text = "Cancelar Agendamento";
            btnCancelarAgendamento.UseVisualStyleBackColor = false;
            btnCancelarAgendamento.Click += btnCancelarAgendamento_Click;
            // 
            // btnPesquisarData
            // 
            btnPesquisarData.BackColor = Color.FromArgb(211, 178, 169);
            btnPesquisarData.FlatAppearance.BorderColor = Color.FromArgb(211, 178, 169);
            btnPesquisarData.FlatStyle = FlatStyle.System;
            btnPesquisarData.Location = new Point(234, 25);
            btnPesquisarData.Name = "btnPesquisarData";
            btnPesquisarData.Size = new Size(75, 23);
            btnPesquisarData.TabIndex = 5;
            btnPesquisarData.Text = "Pesquisar";
            btnPesquisarData.UseVisualStyleBackColor = false;
            btnPesquisarData.Click += btnPesquisarData_Click;
            // 
            // btnConcluirAgendamento
            // 
            btnConcluirAgendamento.BackColor = SystemColors.ButtonFace;
            btnConcluirAgendamento.FlatStyle = FlatStyle.System;
            btnConcluirAgendamento.Location = new Point(671, 563);
            btnConcluirAgendamento.Name = "btnConcluirAgendamento";
            btnConcluirAgendamento.Size = new Size(153, 23);
            btnConcluirAgendamento.TabIndex = 6;
            btnConcluirAgendamento.Text = "Concluir Agendamento";
            btnConcluirAgendamento.UseVisualStyleBackColor = false;
            btnConcluirAgendamento.Click += btnConcluirAgendamento_Click;
            // 
            // frmAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 249, 236);
            ClientSize = new Size(868, 614);
            Controls.Add(btnConcluirAgendamento);
            Controls.Add(btnPesquisarData);
            Controls.Add(btnCancelarAgendamento);
            Controls.Add(groupBox1);
            Controls.Add(dgvAgendamentos);
            Controls.Add(dtpDataAgenda);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAgenda";
            Text = "Agenda de Atendimentos";
            Load += frmAgenda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAgendamentos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDataAgenda;
        private DataGridView dgvAgendamentos;
        private GroupBox groupBox1;
        private Label label6;
        private Label lblServico;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cmbPet;
        private ComboBox cmbCliente;
        private TextBox txtObsAgendamento;
        private DateTimePicker dtpHorario;
        private ComboBox cmbServico;
        private Button btnSalvarAgendamento;
        private CheckBox checkBox1;
        private Button btnCancelarAgendamento;
        private Button btnPesquisarData;
        private Button btnConcluirAgendamento;
    }
}