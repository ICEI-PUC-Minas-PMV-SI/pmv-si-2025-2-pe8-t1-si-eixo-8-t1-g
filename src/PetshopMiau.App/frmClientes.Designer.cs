namespace PetshopMiau.App
{
    partial class frmClientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox3 = new GroupBox();
            btnAdquirirPacote = new Button();
            dgvPacotesCliente = new DataGridView();
            btnPesquisar = new Button();
            txtPesquisaCliente = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            txtEndereco = new TextBox();
            btnSalvar = new Button();
            txtTelefone = new TextBox();
            txtNome = new TextBox();
            btnExcluir = new Button();
            labelEndereco = new Label();
            btnNovo = new Button();
            labelTelefone = new Label();
            labelNome = new Label();
            dgvClientes = new DataGridView();
            tabPage2 = new TabPage();
            btnSalvarPet = new Button();
            btnExcluirPet = new Button();
            btnNovoPet = new Button();
            dgvPets = new DataGridView();
            groupBox2 = new GroupBox();
            dtpDataNascimento = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            cbmPorte = new ComboBox();
            txtPetObservacoes = new TextBox();
            txtPetRaca = new TextBox();
            txtPetEspecie = new TextBox();
            txtPetNome = new TextBox();
            labelPetObservacoes = new Label();
            labelPetRaca = new Label();
            labelPetNome = new Label();
            labelPetEspecie = new Label();
            lblNomeClientePets = new Label();
            tabPage3 = new TabPage();
            btnFiltrarHistorico = new Button();
            dtpDataFim = new DateTimePicker();
            dtpDataInicio = new DateTimePicker();
            lblDataFim = new Label();
            lblDataInicio = new Label();
            dgvHistoricoAgendamentos = new DataGridView();
            lblNomeClienteHistorico = new Label();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacotesCliente).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPets).BeginInit();
            groupBox2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAgendamentos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1069, 693);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(252, 249, 236);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(btnPesquisar);
            tabPage1.Controls.Add(txtPesquisaCliente);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(dgvClientes);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1061, 665);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados do cliente";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox3.BackColor = Color.FromArgb(252, 249, 236);
            groupBox3.Controls.Add(btnAdquirirPacote);
            groupBox3.Controls.Add(dgvPacotesCliente);
            groupBox3.Location = new Point(658, 26);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(383, 171);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pacotes Adquiridos";
            // 
            // btnAdquirirPacote
            // 
            btnAdquirirPacote.BackColor = Color.FromArgb(191, 158, 149);
            btnAdquirirPacote.FlatStyle = FlatStyle.System;
            btnAdquirirPacote.Location = new Point(268, 142);
            btnAdquirirPacote.Name = "btnAdquirirPacote";
            btnAdquirirPacote.Size = new Size(109, 23);
            btnAdquirirPacote.TabIndex = 3;
            btnAdquirirPacote.Text = "Adquirir Pacote";
            btnAdquirirPacote.UseVisualStyleBackColor = false;
            btnAdquirirPacote.Click += btnAdquirirPacote_Click;
            // 
            // dgvPacotesCliente
            // 
            dgvPacotesCliente.AllowUserToAddRows = false;
            dgvPacotesCliente.AllowUserToDeleteRows = false;
            dgvPacotesCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPacotesCliente.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvPacotesCliente.BorderStyle = BorderStyle.None;
            dgvPacotesCliente.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPacotesCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacotesCliente.Location = new Point(6, 21);
            dgvPacotesCliente.MultiSelect = false;
            dgvPacotesCliente.Name = "dgvPacotesCliente";
            dgvPacotesCliente.ReadOnly = true;
            dgvPacotesCliente.RowHeadersVisible = false;
            dgvPacotesCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacotesCliente.Size = new Size(371, 115);
            dgvPacotesCliente.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.FromArgb(191, 158, 149);
            btnPesquisar.FlatStyle = FlatStyle.System;
            btnPesquisar.Location = new Point(556, 224);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(85, 23);
            btnPesquisar.TabIndex = 4;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtPesquisaCliente
            // 
            txtPesquisaCliente.BackColor = Color.FromArgb(255, 254, 249);
            txtPesquisaCliente.Location = new Point(150, 225);
            txtPesquisaCliente.Name = "txtPesquisaCliente";
            txtPesquisaCliente.Size = new Size(400, 23);
            txtPesquisaCliente.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 229);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 2;
            label3.Text = "Pesquisar por Nome:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtEndereco);
            groupBox1.Controls.Add(btnSalvar);
            groupBox1.Controls.Add(txtTelefone);
            groupBox1.Controls.Add(txtNome);
            groupBox1.Controls.Add(btnExcluir);
            groupBox1.Controls.Add(labelEndereco);
            groupBox1.Controls.Add(btnNovo);
            groupBox1.Controls.Add(labelTelefone);
            groupBox1.Controls.Add(labelNome);
            groupBox1.Location = new Point(27, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 171);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados do Cliente";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtEndereco
            // 
            txtEndereco.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEndereco.BackColor = Color.FromArgb(255, 254, 249);
            txtEndereco.Location = new Point(15, 98);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(589, 23);
            txtEndereco.TabIndex = 5;
            txtEndereco.TextChanged += txtEndereco_TextChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.BackColor = Color.FromArgb(191, 158, 149);
            btnSalvar.FlatStyle = FlatStyle.System;
            btnSalvar.Location = new Point(529, 142);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtTelefone
            // 
            txtTelefone.BackColor = Color.FromArgb(255, 254, 249);
            txtTelefone.Location = new Point(448, 45);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(146, 23);
            txtTelefone.TabIndex = 4;
            // 
            // txtNome
            // 
            txtNome.BackColor = Color.FromArgb(255, 254, 249);
            txtNome.Location = new Point(15, 44);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(427, 23);
            txtNome.TabIndex = 3;
            txtNome.TextChanged += txtNome_TextChanged;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.BackColor = Color.FromArgb(191, 158, 149);
            btnExcluir.FlatStyle = FlatStyle.System;
            btnExcluir.Location = new Point(448, 142);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // labelEndereco
            // 
            labelEndereco.AutoSize = true;
            labelEndereco.Location = new Point(15, 80);
            labelEndereco.Name = "labelEndereco";
            labelEndereco.Size = new Size(56, 15);
            labelEndereco.TabIndex = 2;
            labelEndereco.Text = "Endereço";
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.FromArgb(191, 158, 149);
            btnNovo.FlatStyle = FlatStyle.System;
            btnNovo.Location = new Point(367, 142);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // labelTelefone
            // 
            labelTelefone.AutoSize = true;
            labelTelefone.Location = new Point(448, 27);
            labelTelefone.Name = "labelTelefone";
            labelTelefone.Size = new Size(52, 15);
            labelTelefone.TabIndex = 1;
            labelTelefone.Text = "Telefone";
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(15, 26);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(40, 15);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.GridColor = Color.FromArgb(232, 228, 216);
            dgvClientes.Location = new Point(27, 254);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(1014, 394);
            dgvClientes.TabIndex = 1;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(252, 249, 236);
            tabPage2.Controls.Add(btnSalvarPet);
            tabPage2.Controls.Add(btnExcluirPet);
            tabPage2.Controls.Add(btnNovoPet);
            tabPage2.Controls.Add(dgvPets);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(lblNomeClientePets);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1061, 665);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Pets do cliente";
            // 
            // btnSalvarPet
            // 
            btnSalvarPet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvarPet.BackColor = Color.FromArgb(191, 158, 149);
            btnSalvarPet.FlatStyle = FlatStyle.System;
            btnSalvarPet.Font = new Font("Segoe UI", 9F);
            btnSalvarPet.Location = new Point(946, 591);
            btnSalvarPet.Name = "btnSalvarPet";
            btnSalvarPet.Size = new Size(75, 23);
            btnSalvarPet.TabIndex = 5;
            btnSalvarPet.Text = "Salvar Pet";
            btnSalvarPet.UseVisualStyleBackColor = false;
            btnSalvarPet.Click += btnSalvarPet_Click;
            // 
            // btnExcluirPet
            // 
            btnExcluirPet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluirPet.BackColor = Color.FromArgb(191, 158, 149);
            btnExcluirPet.FlatStyle = FlatStyle.System;
            btnExcluirPet.Font = new Font("Segoe UI", 9F);
            btnExcluirPet.Location = new Point(865, 591);
            btnExcluirPet.Name = "btnExcluirPet";
            btnExcluirPet.Size = new Size(75, 23);
            btnExcluirPet.TabIndex = 4;
            btnExcluirPet.Text = "Excluir Pet";
            btnExcluirPet.UseVisualStyleBackColor = false;
            btnExcluirPet.Click += btnExcluirPet_Click;
            // 
            // btnNovoPet
            // 
            btnNovoPet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNovoPet.BackColor = Color.FromArgb(191, 158, 149);
            btnNovoPet.FlatStyle = FlatStyle.System;
            btnNovoPet.Font = new Font("Segoe UI", 9F);
            btnNovoPet.Location = new Point(784, 591);
            btnNovoPet.Name = "btnNovoPet";
            btnNovoPet.Size = new Size(75, 23);
            btnNovoPet.TabIndex = 3;
            btnNovoPet.Text = "Novo Pet";
            btnNovoPet.UseVisualStyleBackColor = false;
            btnNovoPet.Click += btnNovoPet_Click;
            // 
            // dgvPets
            // 
            dgvPets.AllowUserToAddRows = false;
            dgvPets.AllowUserToDeleteRows = false;
            dgvPets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPets.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvPets.BorderStyle = BorderStyle.None;
            dgvPets.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPets.Location = new Point(32, 217);
            dgvPets.MultiSelect = false;
            dgvPets.Name = "dgvPets";
            dgvPets.ReadOnly = true;
            dgvPets.RowHeadersVisible = false;
            dgvPets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPets.Size = new Size(989, 368);
            dgvPets.TabIndex = 2;
            dgvPets.SelectionChanged += dgvPets_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dtpDataNascimento);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(cbmPorte);
            groupBox2.Controls.Add(txtPetObservacoes);
            groupBox2.Controls.Add(txtPetRaca);
            groupBox2.Controls.Add(txtPetEspecie);
            groupBox2.Controls.Add(txtPetNome);
            groupBox2.Controls.Add(labelPetObservacoes);
            groupBox2.Controls.Add(labelPetRaca);
            groupBox2.Controls.Add(labelPetNome);
            groupBox2.Controls.Add(labelPetEspecie);
            groupBox2.Font = new Font("Segoe UI", 9F);
            groupBox2.Location = new Point(32, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(989, 132);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados do Pet";
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataNascimento.Format = DateTimePickerFormat.Short;
            dtpDataNascimento.Location = new Point(380, 92);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(125, 23);
            dtpDataNascimento.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(380, 74);
            label2.Name = "label2";
            label2.Size = new Size(112, 15);
            label2.TabIndex = 11;
            label2.Text = "Data de nascimento";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 74);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 10;
            label1.Text = "Porte";
            // 
            // cbmPorte
            // 
            cbmPorte.BackColor = Color.FromArgb(255, 254, 249);
            cbmPorte.FormattingEnabled = true;
            cbmPorte.Location = new Point(213, 92);
            cbmPorte.Name = "cbmPorte";
            cbmPorte.Size = new Size(151, 23);
            cbmPorte.TabIndex = 6;
            // 
            // txtPetObservacoes
            // 
            txtPetObservacoes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPetObservacoes.BackColor = Color.FromArgb(255, 254, 249);
            txtPetObservacoes.Location = new Point(521, 39);
            txtPetObservacoes.Multiline = true;
            txtPetObservacoes.Name = "txtPetObservacoes";
            txtPetObservacoes.Size = new Size(462, 76);
            txtPetObservacoes.TabIndex = 9;
            // 
            // txtPetRaca
            // 
            txtPetRaca.BackColor = Color.FromArgb(255, 254, 249);
            txtPetRaca.Location = new Point(6, 92);
            txtPetRaca.Name = "txtPetRaca";
            txtPetRaca.Size = new Size(188, 23);
            txtPetRaca.TabIndex = 8;
            txtPetRaca.TextChanged += txtPetRaca_TextChanged;
            // 
            // txtPetEspecie
            // 
            txtPetEspecie.BackColor = Color.FromArgb(255, 254, 249);
            txtPetEspecie.Location = new Point(380, 39);
            txtPetEspecie.Name = "txtPetEspecie";
            txtPetEspecie.Size = new Size(125, 23);
            txtPetEspecie.TabIndex = 7;
            // 
            // txtPetNome
            // 
            txtPetNome.BackColor = Color.FromArgb(255, 254, 249);
            txtPetNome.Location = new Point(6, 39);
            txtPetNome.Name = "txtPetNome";
            txtPetNome.Size = new Size(358, 23);
            txtPetNome.TabIndex = 6;
            // 
            // labelPetObservacoes
            // 
            labelPetObservacoes.AutoSize = true;
            labelPetObservacoes.Location = new Point(521, 21);
            labelPetObservacoes.Name = "labelPetObservacoes";
            labelPetObservacoes.Size = new Size(74, 15);
            labelPetObservacoes.TabIndex = 5;
            labelPetObservacoes.Text = "Observações";
            // 
            // labelPetRaca
            // 
            labelPetRaca.AutoSize = true;
            labelPetRaca.Location = new Point(6, 74);
            labelPetRaca.Name = "labelPetRaca";
            labelPetRaca.Size = new Size(32, 15);
            labelPetRaca.TabIndex = 2;
            labelPetRaca.Text = "Raça";
            // 
            // labelPetNome
            // 
            labelPetNome.AutoSize = true;
            labelPetNome.Location = new Point(6, 21);
            labelPetNome.Name = "labelPetNome";
            labelPetNome.Size = new Size(40, 15);
            labelPetNome.TabIndex = 3;
            labelPetNome.Text = "Nome";
            // 
            // labelPetEspecie
            // 
            labelPetEspecie.AutoSize = true;
            labelPetEspecie.Location = new Point(380, 22);
            labelPetEspecie.Name = "labelPetEspecie";
            labelPetEspecie.Size = new Size(46, 15);
            labelPetEspecie.TabIndex = 4;
            labelPetEspecie.Text = "Espécie";
            // 
            // lblNomeClientePets
            // 
            lblNomeClientePets.AutoSize = true;
            lblNomeClientePets.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblNomeClientePets.Location = new Point(26, 25);
            lblNomeClientePets.Name = "lblNomeClientePets";
            lblNomeClientePets.Size = new Size(96, 25);
            lblNomeClientePets.TabIndex = 0;
            lblNomeClientePets.Text = "Pets de --";
            lblNomeClientePets.Click += lblNomeClientePets_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(252, 249, 236);
            tabPage3.Controls.Add(btnFiltrarHistorico);
            tabPage3.Controls.Add(dtpDataFim);
            tabPage3.Controls.Add(dtpDataInicio);
            tabPage3.Controls.Add(lblDataFim);
            tabPage3.Controls.Add(lblDataInicio);
            tabPage3.Controls.Add(dgvHistoricoAgendamentos);
            tabPage3.Controls.Add(lblNomeClienteHistorico);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1061, 665);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Histórico de Agendamentos";
            tabPage3.Click += tabPage3_Click;
            // 
            // btnFiltrarHistorico
            // 
            btnFiltrarHistorico.BackColor = Color.FromArgb(191, 158, 149);
            btnFiltrarHistorico.FlatStyle = FlatStyle.System;
            btnFiltrarHistorico.Location = new Point(270, 92);
            btnFiltrarHistorico.Name = "btnFiltrarHistorico";
            btnFiltrarHistorico.Size = new Size(75, 23);
            btnFiltrarHistorico.TabIndex = 6;
            btnFiltrarHistorico.Text = "Filtrar";
            btnFiltrarHistorico.UseVisualStyleBackColor = false;
            btnFiltrarHistorico.Click += btnFiltrarHistorico_Click;
            // 
            // dtpDataFim
            // 
            dtpDataFim.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataFim.Format = DateTimePickerFormat.Short;
            dtpDataFim.Location = new Point(150, 92);
            dtpDataFim.Name = "dtpDataFim";
            dtpDataFim.Size = new Size(100, 23);
            dtpDataFim.TabIndex = 5;
            // 
            // dtpDataInicio
            // 
            dtpDataInicio.CalendarMonthBackground = Color.FromArgb(255, 254, 249);
            dtpDataInicio.Format = DateTimePickerFormat.Short;
            dtpDataInicio.Location = new Point(32, 92);
            dtpDataInicio.Name = "dtpDataInicio";
            dtpDataInicio.Size = new Size(100, 23);
            dtpDataInicio.TabIndex = 3;
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Location = new Point(150, 74);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(57, 15);
            lblDataFim.TabIndex = 4;
            lblDataFim.Text = "Data Fim:";
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Location = new Point(32, 74);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(66, 15);
            lblDataInicio.TabIndex = 2;
            lblDataInicio.Text = "Data Início:";
            // 
            // dgvHistoricoAgendamentos
            // 
            dgvHistoricoAgendamentos.AllowUserToAddRows = false;
            dgvHistoricoAgendamentos.AllowUserToDeleteRows = false;
            dgvHistoricoAgendamentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistoricoAgendamentos.BackgroundColor = Color.FromArgb(255, 254, 249);
            dgvHistoricoAgendamentos.BorderStyle = BorderStyle.None;
            dgvHistoricoAgendamentos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvHistoricoAgendamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoricoAgendamentos.Location = new Point(32, 130);
            dgvHistoricoAgendamentos.MultiSelect = false;
            dgvHistoricoAgendamentos.Name = "dgvHistoricoAgendamentos";
            dgvHistoricoAgendamentos.ReadOnly = true;
            dgvHistoricoAgendamentos.RowHeadersVisible = false;
            dgvHistoricoAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoricoAgendamentos.Size = new Size(989, 494);
            dgvHistoricoAgendamentos.TabIndex = 7;
            // 
            // lblNomeClienteHistorico
            // 
            lblNomeClienteHistorico.AutoSize = true;
            lblNomeClienteHistorico.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            lblNomeClienteHistorico.Location = new Point(26, 25);
            lblNomeClienteHistorico.Name = "lblNomeClienteHistorico";
            lblNomeClienteHistorico.Size = new Size(305, 25);
            lblNomeClienteHistorico.TabIndex = 0;
            lblNomeClienteHistorico.Text = "Histórico de agendamentos de --";
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 240, 240);
            ClientSize = new Size(1069, 693);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmClientes";
            Text = "Gestão de Clientes e Pets - Petshop Miau";
            Load += frmClientes_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPacotesCliente).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPets).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoricoAgendamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnFiltrarHistorico;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DataGridView dgvHistoricoAgendamentos;
        private System.Windows.Forms.Label lblNomeClienteHistorico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSalvarPet;
        private System.Windows.Forms.Button btnExcluirPet;
        private System.Windows.Forms.Button btnNovoPet;
        private System.Windows.Forms.DataGridView dgvPets;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPetObservacoes;
        private System.Windows.Forms.TextBox txtPetRaca;
        private System.Windows.Forms.TextBox txtPetEspecie;
        private System.Windows.Forms.TextBox txtPetNome;
        private System.Windows.Forms.Label labelPetObservacoes;
        private System.Windows.Forms.Label labelPetRaca;
        private System.Windows.Forms.Label labelPetNome;
        private System.Windows.Forms.Label labelPetEspecie;
        private System.Windows.Forms.Label lblNomeClientePets;
        private Label label1;
        private ComboBox cbmPorte;
        private Label label2;
        private DateTimePicker dtpDataNascimento;
        private Button btnPesquisar;
        private TextBox txtPesquisaCliente;
        private Label label3;
        private GroupBox groupBox3;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private DataGridView dgvPacotesCliente;
        private Button btnAdquirirPacote;
    }
}