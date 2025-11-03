using Microsoft.EntityFrameworkCore;
using PetshopMiau.Core;
using PetshopMiau.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetshopMiau.App
{
    public partial class frmAgenda : Form
    {
     
        private int _idAgendamentoSelecionado = 0;

        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CarregarComboBoxes();
           
            CarregarAgendamentosDoDia();
        }

        #region Métodos de Carregamento e ComboBoxes

        private void CarregarComboBoxes()
        {
            using (var context = new PetshopContext())
            {
                var listaClientes = context.Clientes
                    .OrderBy(c => c.Nome)
                    .Select(c => new { c.Id, c.Nome })
                    .ToList();

                if (listaClientes.Any())
                {
                    cmbCliente.DataSource = listaClientes;
                    cmbCliente.DisplayMember = "Nome";
                    cmbCliente.ValueMember = "Id";
                }
                else
                {
                    cmbCliente.DataSource = null;
                }

                var listaServicos = context.Servicos.OrderBy(s => s.Nome).ToList();
                if (listaServicos.Any())
                {
                    cmbServico.DataSource = listaServicos;
                    cmbServico.DisplayMember = "Nome";
                    cmbServico.ValueMember = "Id";
                }
                else
                {
                    cmbServico.DataSource = null;
                }
            }

            cmbCliente.SelectedIndex = -1;
            cmbServico.SelectedIndex = -1;
            cmbPet.DataSource = null;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || !(cmbCliente.SelectedValue is int idClienteSelecionado))
            {
                cmbPet.DataSource = null;
                return;
            }

            using (var context = new PetshopContext())
            {
                var listaPets = context.Pets
                    .Where(p => p.ClienteId == idClienteSelecionado)
                    .OrderBy(p => p.Nome)
                    .ToList();

                if (listaPets.Any())
                {
                    cmbPet.DataSource = listaPets;
                    cmbPet.DisplayMember = "Nome";
                    cmbPet.ValueMember = "Id";
                }
                else
                {
                    cmbPet.DataSource = null;
                }
            }
        }

        private void CarregarAgendamentosDoDia()
        {
            DateTime dataSelecionada = dtpDataAgenda.Value.Date;
            using (var context = new PetshopContext())
            {
                var agendamentosDoDia = context.Agendamentos
                    .Include(a => a.Pet.Cliente)
                    .Include(a => a.Servico)
                    .Where(a => a.DataHora.Date == dataSelecionada)
                    .OrderBy(a => a.DataHora)
                    .Select(a => new
                    {
                        Id = a.Id,
                        Horario = a.DataHora.ToString("HH:mm"),
                        Cliente = a.Pet.Cliente.Nome,
                        Pet = a.Pet.Nome,
                        Servico = a.Servico.Nome,
                        Pacote = a.ClientePacoteId.HasValue ? "Sim" : "Não",
                        Observacoes = a.Observacoes, // <<< ADICIONADO AQUI
                        Status = a.Status.ToString()
                    })
                    .ToList();
                dgvAgendamentos.DataSource = agendamentosDoDia;
            }

            ConfigurarGradeAgendamentos(); // Chama a configuração
            _idAgendamentoSelecionado = 0;
            dgvAgendamentos.ClearSelection();
        }

        // Método para configurar a grade (ou coloque este bloco dentro do CarregarAgendamentosDoDia)
        private void ConfigurarGradeAgendamentos()
        {
            if (dgvAgendamentos.Columns.Count > 0)
            {
                dgvAgendamentos.Columns["Id"].Visible = false;
                dgvAgendamentos.Columns["Horario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvAgendamentos.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAgendamentos.Columns["Pet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAgendamentos.Columns["Servico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAgendamentos.Columns["Pacote"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // --- CONFIGURAÇÃO DA NOVA COLUNA ---
                dgvAgendamentos.Columns["Observacoes"].HeaderText = "Observações";
                dgvAgendamentos.Columns["Observacoes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Ou .AllCells, como preferir
                                                                                                           // --- FIM DA CONFIGURAÇÃO ---

                dgvAgendamentos.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        #endregion

        #region Eventos dos Controles

        // Evento que não faz nada quando a data muda (a pesquisa é pelo botão)
        private void dtpDataAgenda_ValueChanged(object sender, EventArgs e)
        {
            // Intencionalmente vazio para forçar o uso do botão
        }

        // Evento do botão Pesquisar ao lado da data
        private void btnPesquisarData_Click(object sender, EventArgs e)
        {
            CarregarAgendamentosDoDia();
        }

        // Evento chamado quando a seleção na grade muda
        private void dgvAgendamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgendamentos.SelectedRows.Count > 0)
            {
                _idAgendamentoSelecionado = Convert.ToInt32(dgvAgendamentos.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                _idAgendamentoSelecionado = 0;
            }
        }

        private async void btnSalvarAgendamento_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || cmbPet.SelectedValue == null || cmbServico.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione o cliente, o pet e o serviço.", "Dados incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteId = (int)cmbCliente.SelectedValue;
            int servicoId = (int)cmbServico.SelectedValue;
            bool usarPacote = checkBox1.Checked;

            DateTime dataDoAgendamento = dtpDataAgenda.Value.Date;
            DateTime horaDoAgendamento = dtpHorario.Value;
            DateTime dataHoraCompleta = dataDoAgendamento.AddHours(horaDoAgendamento.Hour).AddMinutes(horaDoAgendamento.Minute);

            using (var context = new PetshopContext())
            {
                var servicoSelecionado = await context.Servicos.FindAsync(servicoId);
                if (servicoSelecionado == null) return;

                ClientePacote pacoteParaUsar = null;
                int? clientePacoteIdParaSalvar = null;
                decimal valorCobradoFinal = servicoSelecionado.Preco;
                StatusPagamento statusPagamentoInicial = StatusPagamento.Pendente;

                if (usarPacote)
                {
                    pacoteParaUsar = await context.ClientesPacotes
                        .Include(cp => cp.Pacote)
                        .Where(cp => cp.ClienteId == clienteId &&
                                     cp.Pacote.ServicoId == servicoId &&
                                     cp.SessoesDisponiveis > 0 &&
                                     cp.DataVencimento >= DateTime.Now.Date)
                        .OrderBy(cp => cp.DataVencimento)
                        .FirstOrDefaultAsync();

                    if (pacoteParaUsar == null)
                    {
                        MessageBox.Show("Cliente não possui pacote ativo e válido para este serviço.", "Pacote não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        valorCobradoFinal = 0;
                        statusPagamentoInicial = StatusPagamento.Pago;
                        clientePacoteIdParaSalvar = pacoteParaUsar.Id;

                        pacoteParaUsar.SessoesDisponiveis--;
                        context.ClientesPacotes.Update(pacoteParaUsar);
                    }
                }

                var novoAgendamento = new Agendamento
                {
                    DataHora = dataHoraCompleta,
                    PetId = (int)cmbPet.SelectedValue,
                    ServicoId = servicoId,
                    ValorCobrado = valorCobradoFinal,
                    Observacoes = txtObsAgendamento.Text,
                    Status = StatusAgendamento.Agendado,
                    Pagamento = statusPagamentoInicial,
                    ClientePacoteId = clientePacoteIdParaSalvar
                };

                context.Agendamentos.Add(novoAgendamento);

                try
                {
                    await context.SaveChangesAsync();
                    MessageBox.Show("Agendamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarAgendamentosDoDia();
                    LimparCamposNovoAgendamento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar agendamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnCancelarAgendamento_Click(object sender, EventArgs e)
        {
            if (_idAgendamentoSelecionado == 0)
            {
                MessageBox.Show("Por favor, selecione um agendamento na lista para cancelar.", "Nenhum agendamento selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Tem certeza que deseja cancelar este agendamento?", "Confirmar Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                using (var context = new PetshopContext())
                {
                    var agendamentoParaCancelar = await context.Agendamentos
                                                        .Include(a => a.ClientePacote) // Inclui o pacote associado
                                                        .FirstOrDefaultAsync(a => a.Id == _idAgendamentoSelecionado);

                    if (agendamentoParaCancelar == null)
                    {
                        MessageBox.Show("Agendamento não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _idAgendamentoSelecionado = 0;
                        return;
                    }

                    if (agendamentoParaCancelar.Status == StatusAgendamento.Cancelado)
                    {
                        MessageBox.Show("Este agendamento já está cancelado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    agendamentoParaCancelar.Status = StatusAgendamento.Cancelado;
                    context.Agendamentos.Update(agendamentoParaCancelar);

                    // Devolve a sessão se for de um pacote
                    if (agendamentoParaCancelar.ClientePacoteId.HasValue)
                    {
                        var pacoteUsado = await context.ClientesPacotes.FindAsync(agendamentoParaCancelar.ClientePacoteId.Value);
                        if (pacoteUsado != null)
                        {
                            pacoteUsado.SessoesDisponiveis++;
                            context.ClientesPacotes.Update(pacoteUsado);
                            // Opcional: Avisar o usuário sobre a devolução
                            // MessageBox.Show("Uma sessão do pacote foi devolvida ao cliente.", "Sessão Devolvida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    try
                    {
                        await context.SaveChangesAsync();
                        MessageBox.Show("Agendamento cancelado com sucesso!", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregarAgendamentosDoDia();
                        _idAgendamentoSelecionado = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao cancelar o agendamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimparCamposNovoAgendamento()
        {
            cmbCliente.SelectedIndex = -1;
            cmbPet.DataSource = null; // Limpa pets
            cmbPet.SelectedIndex = -1; // Garante que não há pet selecionado
            cmbServico.SelectedIndex = -1;
            txtObsAgendamento.Text = "";
            checkBox1.Checked = false; // Desmarca o checkbox de pacote
            dtpHorario.Value = DateTime.Now; // Reseta a hora para a atual (opcional)
        }

        #endregion
        private async void btnConcluirAgendamento_Click(object sender, EventArgs e)
        {
            
            if (_idAgendamentoSelecionado == 0)
            {
                MessageBox.Show("Por favor, selecione um agendamento na lista para marcar como concluído.", "Nenhum agendamento selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            DialogResult confirmacao = MessageBox.Show("Marcar este agendamento como concluído?", "Confirmar Conclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                using (var context = new PetshopContext())
                {
                  
                    var agendamentoParaConcluir = await context.Agendamentos.FindAsync(_idAgendamentoSelecionado);

                    if (agendamentoParaConcluir == null)
                    {
                        MessageBox.Show("Agendamento não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _idAgendamentoSelecionado = 0; 
                        return;
                    }

                  
                    if (agendamentoParaConcluir.Status == StatusAgendamento.Concluido)
                    {
                        MessageBox.Show("Este agendamento já está marcado como concluído.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (agendamentoParaConcluir.Status == StatusAgendamento.Cancelado)
                    {
                        MessageBox.Show("Não é possível concluir um agendamento cancelado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

               
                    agendamentoParaConcluir.Status = StatusAgendamento.Concluido;
                    context.Agendamentos.Update(agendamentoParaConcluir); 

                    try
                    {
                        await context.SaveChangesAsync(); 
                        MessageBox.Show("Agendamento marcado como concluído!", "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregarAgendamentosDoDia(); 
                        _idAgendamentoSelecionado = 0; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar o status do agendamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}