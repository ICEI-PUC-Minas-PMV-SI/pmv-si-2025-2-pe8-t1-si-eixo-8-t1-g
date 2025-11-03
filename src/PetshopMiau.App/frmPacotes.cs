using PetshopMiau.Core;
using PetshopMiau.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PetshopMiau.App
{

    public partial class frmPacotes : Form
    {

        private int _idPacoteSelecionado = 0;


        public frmPacotes()
        {
            InitializeComponent();
        }

        private void frmPacotes_Load(object sender, EventArgs e)
        {
            CarregarServicosComboBox();
            CarregarPacotesGrid();
        }

        private void CarregarServicosComboBox()
        {
            using (var context = new PetshopContext())
            {
                var servicos = context.Servicos.OrderBy(s => s.Nome).ToList();
                cmbServico.DataSource = servicos;
                cmbServico.DisplayMember = "Nome";
                cmbServico.ValueMember = "Id";
                cmbServico.SelectedIndex = -1;
            }
        }

        private void CarregarPacotesGrid()
        {
            using (var context = new PetshopContext())
            {

                var pacotes = context.Pacotes
                    .Include(p => p.Servico)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        ServicoNome = p.Servico.Nome,
                        ServicoId = p.ServicoId,
                        QuantidadeSessoes = p.QuantidadeSessoes,
                        PrecoTotal = p.PrecoTotal,
                        ValidadeEmDias = p.ValidadeEmDias
                    })
                    .ToList();

                dgvPacotes.DataSource = pacotes;
            }

            if (dgvPacotes.Columns.Count > 0)
            {
                dgvPacotes.Columns["Id"].Visible = false;
                dgvPacotes.Columns["ServicoId"].Visible = false;

                dgvPacotes.Columns["Nome"].HeaderText = "Nome do Pacote";
                dgvPacotes.Columns["ServicoNome"].HeaderText = "Serviço";
                dgvPacotes.Columns["QuantidadeSessoes"].HeaderText = "Sessões";
                dgvPacotes.Columns["PrecoTotal"].HeaderText = "Preço Total";
                dgvPacotes.Columns["ValidadeEmDias"].HeaderText = "Validade (Dias)";

                dgvPacotes.Columns["PrecoTotal"].DefaultCellStyle.Format = "C2";

                dgvPacotes.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPacotes.Columns["ServicoNome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dgvPacotes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPacotes.SelectedRows.Count > 0)
            {
                DataGridViewRow linha = dgvPacotes.SelectedRows[0];
                _idPacoteSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

                txtNomePacote.Text = linha.Cells["Nome"].Value.ToString();
                cmbServico.SelectedValue = Convert.ToInt32(linha.Cells["ServicoId"].Value);
                numPrecoTotal.Value = Convert.ToDecimal(linha.Cells["PrecoTotal"].Value);
                numQuantidadeSessoes.Value = Convert.ToDecimal(linha.Cells["QuantidadeSessoes"].Value);
                numValidadeDias.Value = Convert.ToDecimal(linha.Cells["ValidadeEmDias"].Value);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNomePacote.Text = "";
            cmbServico.SelectedIndex = -1;
            numPrecoTotal.Value = 0;
            numQuantidadeSessoes.Value = 0;
            numValidadeDias.Value = 0;
            _idPacoteSelecionado = 0;
            dgvPacotes.ClearSelection();
            txtNomePacote.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_idPacoteSelecionado > 0)
            {
                DialogResult res = MessageBox.Show("Tem certeza que deseja excluir este pacote?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    using (var context = new PetshopContext())
                    {

                        bool emUso = context.ClientesPacotes.Any(cp => cp.PacoteId == _idPacoteSelecionado);
                        if (emUso)
                        {
                            MessageBox.Show("Este pacote não pode ser excluído pois já foi adquirido por um ou mais clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var pacoteParaExcluir = context.Pacotes.Find(_idPacoteSelecionado);
                        if (pacoteParaExcluir != null)
                        {
                            context.Pacotes.Remove(pacoteParaExcluir);
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Pacote excluído com sucesso!");
                    CarregarPacotesGrid();
                    btnNovo_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Selecione um pacote para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomePacote.Text))
            {
                MessageBox.Show("O nome do pacote não pode estar em branco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbServico.SelectedValue == null)
            {
                MessageBox.Show("Selecione um serviço para vincular ao pacote.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idPacoteSelecionado == 0)
            {
                using (var context = new PetshopContext())
                {
                    var novoPacote = new Pacote
                    {
                        Nome = txtNomePacote.Text,
                        ServicoId = (int)cmbServico.SelectedValue,
                        PrecoTotal = numPrecoTotal.Value,
                        QuantidadeSessoes = (int)numQuantidadeSessoes.Value,
                        ValidadeEmDias = (int)numValidadeDias.Value
                    };
                    context.Pacotes.Add(novoPacote);
                    context.SaveChanges();
                }
                MessageBox.Show("Pacote salvo com sucesso!");
            }
            else
            {
                using (var context = new PetshopContext())
                {
                    var pacoteExistente = context.Pacotes.Find(_idPacoteSelecionado);
                    if (pacoteExistente != null)
                    {
                        pacoteExistente.Nome = txtNomePacote.Text;
                        pacoteExistente.ServicoId = (int)cmbServico.SelectedValue;
                        pacoteExistente.PrecoTotal = numPrecoTotal.Value;
                        pacoteExistente.QuantidadeSessoes = (int)numQuantidadeSessoes.Value;
                        pacoteExistente.ValidadeEmDias = (int)numValidadeDias.Value;
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Pacote atualizado com sucesso!");
            }

            CarregarPacotesGrid();
            btnNovo_Click(null, null);
        }


        private void btnSalvarPacote_Click(object sender, EventArgs e)
        {
            btnSalvar_Click(sender, e);
        }

        private void btnNovoPacote_Click(object sender, EventArgs e)
        {
            btnNovo_Click(sender, e);
        }

        private void btnExcluirPacote_Click(object sender, EventArgs e)
        {
            btnExcluir_Click(sender, e);
        }

        private void numValidadeDias_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label_Click_1(object sender, EventArgs e)
        {

        }

        private void numPrecoTotal_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}