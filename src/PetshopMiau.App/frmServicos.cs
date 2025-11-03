using PetshopMiau.Core;
using PetshopMiau.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetshopMiau.App
{
    public partial class frmServicos : Form
    {
        private int _idServicoSelecionado = 0;

        public frmServicos()
        {
            InitializeComponent();
        }

        private void frmServicos_Load(object sender, EventArgs e)
        {
            CarregarServicos();
        }

        private void CarregarServicos()
        {
            using (var context = new PetshopContext())
            {
                dgvServicos.DataSource = context.Servicos.ToList();
            }

            if (dgvServicos.Columns.Count > 0)
            {
                dgvServicos.Columns["Id"].Visible = false;
                dgvServicos.Columns["Nome"].HeaderText = "Nome do Serviço";
                dgvServicos.Columns["Preco"].HeaderText = "Preço (R$)";


                dgvServicos.Columns["Preco"].DefaultCellStyle.Format = "C2";

                dgvServicos.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvServicos.Columns["Preco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void dgvServicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicos.SelectedRows.Count > 0)
            {
                DataGridViewRow linha = dgvServicos.SelectedRows[0];
                _idServicoSelecionado = Convert.ToInt32(linha.Cells["Id"].Value);

                txtNomeServico.Text = linha.Cells["Nome"].Value.ToString();
                numPreco.Value = Convert.ToDecimal(linha.Cells["Preco"].Value);
            }
        }

        private void btnNovoServico_Click(object sender, EventArgs e)
        {
            txtNomeServico.Text = "";
            numPreco.Value = 0;
            _idServicoSelecionado = 0;
            dgvServicos.ClearSelection();
            txtNomeServico.Focus();
        }

        private void btnExcluirServico_Click(object sender, EventArgs e)
        {
            if (_idServicoSelecionado > 0)
            {
                DialogResult res = MessageBox.Show("Tem certeza que deseja excluir este serviço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    using (var context = new PetshopContext())
                    {
                        var servicoParaExcluir = context.Servicos.Find(_idServicoSelecionado);
                        if (servicoParaExcluir != null)
                        {
                            context.Servicos.Remove(servicoParaExcluir);
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Serviço excluído com sucesso!");
                    CarregarServicos();
                    btnNovoServico_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Selecione um serviço para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalvarServico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeServico.Text))
            {
                MessageBox.Show("O nome do serviço não pode estar em branco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idServicoSelecionado == 0)
            {
                using (var context = new PetshopContext())
                {
                    var novoServico = new Servico
                    {
                        Nome = txtNomeServico.Text,
                        Preco = numPreco.Value
                    };
                    context.Servicos.Add(novoServico);
                    context.SaveChanges();
                }
                MessageBox.Show("Serviço salvo com sucesso!");
            }
            else
            {
                using (var context = new PetshopContext())
                {
                    var servicoExistente = context.Servicos.Find(_idServicoSelecionado);
                    if (servicoExistente != null)
                    {
                        servicoExistente.Nome = txtNomeServico.Text;
                        servicoExistente.Preco = numPreco.Value;
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Serviço atualizado com sucesso!");
            }

            CarregarServicos();
            btnNovoServico_Click(null, null);
        }

        private void txtNomeServico_TextChanged(object sender, EventArgs e)
        {

        }
    }
}