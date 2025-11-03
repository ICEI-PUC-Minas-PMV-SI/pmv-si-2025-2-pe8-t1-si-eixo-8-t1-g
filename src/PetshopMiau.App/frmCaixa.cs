using PetshopMiau.Core;
using PetshopMiau.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PetshopMiau.App
{
    public partial class frmCaixa : Form
    {
        private int _idAgendamentoSelecionado = 0;

        public frmCaixa()
        {
            InitializeComponent();
        }

        private void frmCaixa_Load(object sender, EventArgs e)
        {
            CarregarDadosDoDia();
        }

        private void dtpDataCaixa_ValueChanged(object sender, EventArgs e)
        {
            CarregarDadosDoDia();
        }

        private void CarregarDadosDoDia()
        {
            DateTime dataSelecionada = dtpDataCaixa.Value.Date;
            DateTime fimDoDiaSelecionado = dataSelecionada.AddDays(1).AddTicks(-1); // Final do dia

            using (var context = new PetshopContext())
            {
               
                var pagamentosPendentes = context.Agendamentos
                    .Include(a => a.Pet.Cliente)
                    .Include(a => a.Servico)
                    .Where(a => a.DataHora >= dataSelecionada && a.DataHora <= fimDoDiaSelecionado &&
                                a.Pagamento == StatusPagamento.Pendente &&
                                !a.ClientePacoteId.HasValue) 
                    .OrderBy(a => a.DataHora)
                    .Select(a => new
                    {
                        Id = a.Id,
                        Horario = a.DataHora.ToString("HH:mm"),
                        Cliente = a.Pet.Cliente.Nome,
                        Pet = a.Pet.Nome,
                        Servico = a.Servico.Nome,
                        Valor = a.ValorCobrado
                    })
                    .ToList();

                dgvPagamentosPendentes.DataSource = pagamentosPendentes;

               
                decimal totalAgendamentosPagos = context.Agendamentos
                    .Where(a => a.DataPagamento.HasValue &&
                                a.DataPagamento.Value.Date == dataSelecionada &&
                                !a.ClientePacoteId.HasValue)
                    .Sum(a => (decimal?)a.ValorCobrado) ?? 0;

                decimal totalPacotesAdquiridos = context.ClientesPacotes
                    .Include(cp => cp.Pacote)
                    .Where(cp => cp.DataAquisicao.Date == dataSelecionada)
                    .Sum(cp => (decimal?)cp.Pacote.PrecoTotal) ?? 0;

                decimal totalSangrias = context.MovimentacoesCaixa
                    .Where(m => m.Tipo == TipoMovimentacao.Sangria &&
                                m.DataHora >= dataSelecionada && m.DataHora <= fimDoDiaSelecionado)
                    .Sum(m => (decimal?)m.Valor) ?? 0;

                decimal totalEntradas = totalAgendamentosPagos + totalPacotesAdquiridos;
                decimal totalDoDia = totalEntradas - totalSangrias;

                lblTotalDoDia.Text = totalDoDia.ToString("C2");

             
                CarregarMovimentacoesDoDia(context, dataSelecionada, fimDoDiaSelecionado);
            }

            ConfigurarGradePagamentosPendentes(); 
            dgvPagamentosPendentes.ClearSelection();
            _idAgendamentoSelecionado = 0;

            
            if (dgvSangrias.DataSource != null)
            {
                dgvSangrias.ClearSelection();
            }
        }

        
        private void CarregarMovimentacoesDoDia(PetshopContext context, DateTime inicio, DateTime fim)
        {
            var movimentacoes = context.MovimentacoesCaixa
                .Where(m => m.Tipo == TipoMovimentacao.Sangria && 
                            m.DataHora >= inicio && m.DataHora <= fim)
                .OrderBy(m => m.DataHora)
                .Select(m => new
                {
                    Hora = m.DataHora.ToString("HH:mm"),
                    Descricao = m.Descricao,
                    Valor = m.Valor 
                })
                .ToList();

            dgvSangrias.DataSource = movimentacoes;
            ConfigurarGradeSangrias(); 
        }

       
        private void ConfigurarGradePagamentosPendentes()
        {
            if (dgvPagamentosPendentes.Columns.Count > 0)
            {
                dgvPagamentosPendentes.Columns["Id"].Visible = false;
                dgvPagamentosPendentes.Columns["Horario"].HeaderText = "Hora";
                dgvPagamentosPendentes.Columns["Horario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPagamentosPendentes.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPagamentosPendentes.Columns["Pet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPagamentosPendentes.Columns["Servico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPagamentosPendentes.Columns["Valor"].DefaultCellStyle.Format = "C2";
                dgvPagamentosPendentes.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

       
        private void ConfigurarGradeSangrias()
        {
           
            if (dgvSangrias.DataSource != null && dgvSangrias.Columns.Count > 0)
            {
                dgvSangrias.Columns["Hora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSangrias.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSangrias.Columns["Valor"].DefaultCellStyle.Format = "C2"; // Formato Moeda
                dgvSangrias.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
         
            else if (dgvSangrias.DataSource == null)
            {
                dgvSangrias.Columns.Clear();
            }
        }


        private void dgvPagamentosPendentes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagamentosPendentes.SelectedRows.Count > 0)
            {
                _idAgendamentoSelecionado = Convert.ToInt32(dgvPagamentosPendentes.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                _idAgendamentoSelecionado = 0;
            }
        }

        
        private void btnConfirmarPagamento_Click(object sender, EventArgs e)
        {
            if (_idAgendamentoSelecionado == 0)
            {
                MessageBox.Show("Por favor, selecione um serviço na lista para confirmar o pagamento.", "Nenhum item selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var context = new PetshopContext())
            {
                var agendamentoParaPagar = context.Agendamentos.Find(_idAgendamentoSelecionado);
                if (agendamentoParaPagar != null)
                {
                    if (agendamentoParaPagar.ClientePacoteId.HasValue)
                    {
                        MessageBox.Show("Agendamentos de pacote já são considerados pagos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (agendamentoParaPagar.Status != StatusAgendamento.Concluido)
                    {
                        if (MessageBox.Show("Este agendamento ainda não foi marcado como 'Concluído'. Deseja confirmar o pagamento mesmo assim?", "Confirmar Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    if (agendamentoParaPagar.Pagamento == StatusPagamento.Pago)
                    {
                        MessageBox.Show("Este agendamento já está pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    agendamentoParaPagar.Pagamento = StatusPagamento.Pago;
                    agendamentoParaPagar.DataPagamento = DateTime.Now;
                    context.SaveChanges();
                    MessageBox.Show("Pagamento confirmado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Agendamento não encontrado para confirmar pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CarregarDadosDoDia();
        }

       
        private void btnRegistrarSangria_Click(object sender, EventArgs e)
        {
            decimal valor = numValorSangria.Value;
            string descricao = txtDescricaoSangria.Text.Trim();

            if (valor <= 0)
            {
                MessageBox.Show("O valor da sangria deve ser maior que zero.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numValorSangria.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                descricao = "Sangria de caixa";
            }

            if (MessageBox.Show($"Confirma o registro de uma sangria de {valor:C}?", "Confirmar Sangria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var context = new PetshopContext())
                {
                    var novaSangria = new MovimentacaoCaixa
                    {
                        DataHora = DateTime.Now,
                        Tipo = TipoMovimentacao.Sangria,
                        Descricao = descricao,
                        Valor = valor
                    };

                    context.MovimentacoesCaixa.Add(novaSangria);

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Sangria registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        numValorSangria.Value = 0;
                        txtDescricaoSangria.Text = "";
                        CarregarDadosDoDia(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao registrar sangria: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}