using Microsoft.EntityFrameworkCore;
using PetshopMiau.Core;
using PetshopMiau.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PetshopMiau.App
{
    public partial class frmClientes : Form
    {
        private int _idClienteSelecionado = 0;
        private int _idPetSelecionado = 0;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CarregarClientes();
            cbmPorte.Items.Add("Pequeno");
            cbmPorte.Items.Add("M�dio");
            cbmPorte.Items.Add("Grande");


            dtpDataInicio.Value = DateTime.Now.AddMonths(-1);
            dtpDataFim.Value = DateTime.Now;
        }

        #region Metodos de Carregamento


        private void CarregarClientes(string filtro = "")
        {
            try
            {
                using (var context = new PetshopContext())
                {
                    var query = context.Clientes.AsQueryable();

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query = query.Where(c => c.Nome.Contains(filtro));
                    }

                    var listaParaExibicao = query
                        .Select(c => new ClienteViewModel
                        {
                            Id = c.Id,
                            Nome = c.Nome,
                            Telefone = c.Telefone,
                            Endereco = c.Endereco
                        })
                        .OrderBy(c => c.Nome).ToList();

                    dgvClientes.DataSource = listaParaExibicao;
                }

                if (dgvClientes.Columns.Count > 0)
                {
                    dgvClientes.Columns["Id"].Visible = false;
                    dgvClientes.Columns["Nome"].HeaderText = "Nome do Cliente";
                    dgvClientes.Columns["Telefone"].HeaderText = "Telefone de Contato";
                    dgvClientes.Columns["Endereco"].HeaderText = "Endereço";
                    dgvClientes.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvClientes.Columns["Endereco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarPetsDoCliente(int idDoCliente)
        {
            dgvPets.DataSource = null;
            using (var context = new PetshopContext())
            {
                var listaPets = context.Pets.Where(pet => pet.ClienteId == idDoCliente).OrderBy(p => p.Nome).ToList();
                dgvPets.DataSource = listaPets;
            }

            if (dgvPets.Columns.Count > 0)
            {
                dgvPets.Columns["Id"].Visible = false;
                dgvPets.Columns["ClienteId"].Visible = false;
                if (dgvPets.Columns.Contains("Cliente"))
                {
                    dgvPets.Columns["Cliente"].Visible = false;
                }
                dgvPets.Columns["Nome"].HeaderText = "Nome do Pet";
                dgvPets.Columns["Especie"].HeaderText = "Esp�cie";
                dgvPets.Columns["Raca"].HeaderText = "Ra�a";
                dgvPets.Columns["Porte"].HeaderText = "Porte";
                dgvPets.Columns["DataNascimento"].HeaderText = "Nascimento";
                dgvPets.Columns["Observacoes"].HeaderText = "Observa��es";
                dgvPets.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPets.Columns["Observacoes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void CarregarPacotesDoCliente(int idDoCliente)
        {
            dgvPacotesCliente.DataSource = null;
            using (var context = new PetshopContext())
            {
                var listaPacotes = context.ClientesPacotes
                    .Include(cp => cp.Pacote)
                    .Where(cp => cp.ClienteId == idDoCliente && cp.SessoesDisponiveis > 0)
                    .Select(cp => new
                    {
                        Id = cp.Id,
                        Pacote = cp.Pacote.Nome,
                        SessoesRestantes = cp.SessoesDisponiveis,
                        Aquisicao = cp.DataAquisicao.ToShortDateString(),
                        Vencimento = cp.DataVencimento.ToShortDateString()
                    })
                    .ToList();

                dgvPacotesCliente.DataSource = listaPacotes;

                if (dgvPacotesCliente.Columns.Count > 0)
                {
                    dgvPacotesCliente.Columns["Id"].Visible = false;
                    dgvPacotesCliente.Columns["Pacote"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvPacotesCliente.Columns["SessoesRestantes"].HeaderText = "Restantes";
                }
            }
        }

        private void CarregarHistoricoAgendamentos(int idDoCliente, DateTime? dataInicio = null, DateTime? dataFim = null)
        {
            dgvHistoricoAgendamentos.DataSource = null;
            using (var context = new PetshopContext())
            {
                var query = context.Agendamentos
                    .Include(a => a.Pet)
                    .Include(a => a.Servico)
                    .Where(a => a.Pet.ClienteId == idDoCliente);

                if (dataInicio.HasValue)
                    query = query.Where(a => a.DataHora.Date >= dataInicio.Value.Date);

                if (dataFim.HasValue)
                    query = query.Where(a => a.DataHora.Date <= dataFim.Value.Date);

                var historicoAgendamentos = query
                    .OrderByDescending(a => a.DataHora)
                    .Select(a => new
                    {
                        Id = a.Id,
                        Data = a.DataHora.Date.ToShortDateString(),
                        Horario = a.DataHora.ToString("HH:mm"),
                        Pet = a.Pet.Nome,
                        Servico = a.Servico.Nome,
                        Status = a.Status.ToString(),
                        Pacote = a.ClientePacoteId.HasValue ? "Sim" : "Não",
                        Observacoes = a.Observacoes
                    })
                    .ToList();

                dgvHistoricoAgendamentos.DataSource = historicoAgendamentos;

                if (dgvHistoricoAgendamentos.Columns.Count > 0)
                {
                    dgvHistoricoAgendamentos.Columns["Id"].Visible = false;
                    dgvHistoricoAgendamentos.Columns["Data"].HeaderText = "Data";
                    dgvHistoricoAgendamentos.Columns["Horario"].HeaderText = "Horário";
                    dgvHistoricoAgendamentos.Columns["Pet"].HeaderText = "Pet";
                    dgvHistoricoAgendamentos.Columns["Servico"].HeaderText = "Serviço";
                    dgvHistoricoAgendamentos.Columns["Status"].HeaderText = "Status";
                    dgvHistoricoAgendamentos.Columns["Pacote"].HeaderText = "Pacote";
                    dgvHistoricoAgendamentos.Columns["Observacoes"].HeaderText = "Observações";

                    dgvHistoricoAgendamentos.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHistoricoAgendamentos.Columns["Horario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHistoricoAgendamentos.Columns["Pet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHistoricoAgendamentos.Columns["Servico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvHistoricoAgendamentos.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHistoricoAgendamentos.Columns["Pacote"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHistoricoAgendamentos.Columns["Observacoes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
        #endregion

        #region Eventos de Clientes
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) { MessageBox.Show("O nome do cliente � obrigat�rio."); return; }

            if (_idClienteSelecionado == 0)
            {
                using (var context = new PetshopContext())
                {
                    var novoCliente = new Cliente { Nome = txtNome.Text, Telefone = txtTelefone.Text, Endereco = txtEndereco.Text };
                    context.Clientes.Add(novoCliente);
                    context.SaveChanges();
                }
                MessageBox.Show("Cliente novo salvo com sucesso!");
            }
            else
            {
                using (var context = new PetshopContext())
                {
                    var clienteExistente = context.Clientes.Find(_idClienteSelecionado);
                    if (clienteExistente != null)
                    {
                        clienteExistente.Nome = txtNome.Text;
                        clienteExistente.Telefone = txtTelefone.Text;
                        clienteExistente.Endereco = txtEndereco.Text;
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Cliente atualizado com sucesso!");
            }
            CarregarClientes();
            btnNovo_Click(null, null);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEndereco.Text = "";
            _idClienteSelecionado = 0;
            dgvClientes.ClearSelection();
            txtNome.Focus();

            dgvPacotesCliente.DataSource = null;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idClienteSelecionado > 0)
            {
                DialogResult resultado = MessageBox.Show("Excluir um cliente tamb�m excluir� todos os seus pets, pacotes e agendamentos. Deseja continuar?", "Confirma��o de Exclus�o", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    using (var context = new PetshopContext())
                    {
                   
                        var clienteParaExcluir = context.Clientes
                                                    .Include(c => c.Pets)
                                                    .Include(c => c.PacotesAdquiridos)
                                                    .FirstOrDefault(c => c.Id == _idClienteSelecionado);
                        if (clienteParaExcluir != null)
                        {
                            context.Clientes.Remove(clienteParaExcluir);
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Cliente exclu�do com sucesso!");
                    CarregarClientes();
                    btnNovo_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow linha = dgvClientes.SelectedRows[0];
                _idClienteSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

                txtNome.Text = linha.Cells["Nome"].Value.ToString();
                txtTelefone.Text = linha.Cells["Telefone"].Value.ToString();
                txtEndereco.Text = linha.Cells["Endereco"].Value.ToString();

                lblNomeClientePets.Text = "Pets de: " + txtNome.Text;
                lblNomeClienteHistorico.Text = "Histórico de agendamentos de: " + txtNome.Text;
                CarregarPetsDoCliente(_idClienteSelecionado);
                CarregarPacotesDoCliente(_idClienteSelecionado);
                CarregarHistoricoAgendamentos(_idClienteSelecionado);
                btnNovoPet_Click(null, null);
            }
            else
            {
                _idClienteSelecionado = 0;
                dgvPets.DataSource = null;
                dgvPacotesCliente.DataSource = null;
                dgvHistoricoAgendamentos.DataSource = null;
                lblNomeClientePets.Text = "Pets de: --";
                lblNomeClienteHistorico.Text = "Histórico de agendamentos de: --";
                btnNovoPet_Click(null, null);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregarClientes(txtPesquisaCliente.Text);
        }


        private void btnAdquirirPacote_Click(object sender, EventArgs e)
        {
            if (_idClienteSelecionado == 0)
            {

                MessageBox.Show("Selecione um cliente primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmAdquirirPacote telaAquisicao = new frmAdquirirPacote(_idClienteSelecionado);
            telaAquisicao.ShowDialog();


            if (telaAquisicao.PacoteAdquiridoComSucesso)
            {
                CarregarPacotesDoCliente(_idClienteSelecionado);
            }
        }
        #endregion

        #region Eventos de Pets

        private void btnSalvarPet_Click(object sender, EventArgs e)
        {
            if (_idClienteSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPetNome.Text)) { MessageBox.Show("O nome do pet � obrigat�rio."); return; }

            if (_idPetSelecionado == 0)
            {
                using (var context = new PetshopContext())
                {
                    var novoPet = new Pet
                    {
                        Nome = txtPetNome.Text,
                        Especie = txtPetEspecie.Text,
                        Raca = txtPetRaca.Text,
                        Porte = cbmPorte.SelectedItem?.ToString(),
                        DataNascimento = dtpDataNascimento.Value.Date,
                        Observacoes = txtPetObservacoes.Text,
                        ClienteId = _idClienteSelecionado
                    };
                    context.Pets.Add(novoPet);
                    context.SaveChanges();
                }
                MessageBox.Show("Pet salvo com sucesso!");
            }
            else
            {
                using (var context = new PetshopContext())
                {
                    var petExistente = context.Pets.Find(_idPetSelecionado);
                    if (petExistente != null)
                    {
                        petExistente.Nome = txtPetNome.Text;
                        petExistente.Especie = txtPetEspecie.Text;
                        petExistente.Raca = txtPetRaca.Text;
                        petExistente.Porte = cbmPorte.SelectedItem?.ToString();
                        petExistente.DataNascimento = dtpDataNascimento.Value.Date;
                        petExistente.Observacoes = txtPetObservacoes.Text;
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Pet atualizado com sucesso!");
            }
            CarregarPetsDoCliente(_idClienteSelecionado);
            btnNovoPet_Click(null, null);
        }

        private void btnNovoPet_Click(object sender, EventArgs e)
        {
            txtPetNome.Text = "";
            txtPetEspecie.Text = "";
            txtPetRaca.Text = "";
            cbmPorte.SelectedIndex = -1;
            dtpDataNascimento.Value = DateTime.Now;
            txtPetObservacoes.Text = "";
            _idPetSelecionado = 0;
            dgvPets.ClearSelection();
            // txtPetNome.Focus(); // Pode causar erro se a tab n�o estiver vis�vel
        }

        private void btnExcluirPet_Click(object sender, EventArgs e)
        {
            if (_idPetSelecionado > 0)
            {
                DialogResult res = MessageBox.Show("Tem certeza que deseja excluir este pet?", "Confirma��o", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    using (var context = new PetshopContext())
                    {
                        var petParaExcluir = context.Pets.Find(_idPetSelecionado);
                        if (petParaExcluir != null)
                        {
                            context.Pets.Remove(petParaExcluir);
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Pet exclu�do com sucesso!");
                    CarregarPetsDoCliente(_idClienteSelecionado);
                    btnNovoPet_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Selecione um pet para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPets_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count > 0)
            {
                DataGridViewRow linha = dgvPets.SelectedRows[0];
                _idPetSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

                txtPetNome.Text = linha.Cells["Nome"].Value.ToString();
                txtPetEspecie.Text = linha.Cells["Especie"].Value.ToString();
                txtPetRaca.Text = linha.Cells["Raca"].Value.ToString();

                cbmPorte.SelectedItem = linha.Cells["Porte"].Value?.ToString();
                if (linha.Cells["DataNascimento"].Value != null && linha.Cells["DataNascimento"].Value != DBNull.Value)
                {
                    dtpDataNascimento.Value = Convert.ToDateTime(linha.Cells["DataNascimento"].Value);
                }

                txtPetObservacoes.Text = linha.Cells["Observacoes"].Value.ToString();
            }
            else
            {
                _idPetSelecionado = 0;
            }
        }
        #endregion

        #region Menus de Navegacao


       


        private void controleDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCaixa telaCaixa = new frmCaixa();
            telaCaixa.ShowDialog();
        }



        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void btnFiltrarHistorico_Click(object sender, EventArgs e)
        {
            if (_idClienteSelecionado > 0)
            {
                CarregarHistoricoAgendamentos(_idClienteSelecionado, dtpDataInicio.Value, dtpDataFim.Value);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void lblNomeClientePets_Click(object sender, EventArgs e)
        {

        }

        private void txtPetRaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}