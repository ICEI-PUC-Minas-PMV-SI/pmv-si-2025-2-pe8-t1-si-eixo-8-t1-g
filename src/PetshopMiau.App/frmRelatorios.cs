
using Microsoft.EntityFrameworkCore;
using PetshopMiau.Core;
using PetshopMiau.Data;
using QuestPDF.Fluent; 
using QuestPDF.Helpers;
using QuestPDF.Infrastructure; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PetshopMiau.App
{
    public partial class frmRelatorios : Form
    {
        private enum TipoRelatorioSelecionado
        {
            Nenhum,
            FaturamentoPeriodo,
            AgendamentosPeriodo,
            PacotesVendidosPeriodo,
            ClientesAtivos
        }

        public frmRelatorios()
        {
            InitializeComponent();
        }

        private void frmRelatorios_Load(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            cmbTipoRelatorio.Items.Clear();
            cmbTipoRelatorio.Items.Add(new RelatorioItem("Selecione...", TipoRelatorioSelecionado.Nenhum));
           
            cmbTipoRelatorio.Items.Add(new RelatorioItem("Fluxo de Caixa por Período", TipoRelatorioSelecionado.FaturamentoPeriodo));
            cmbTipoRelatorio.Items.Add(new RelatorioItem("Agendamentos por Período", TipoRelatorioSelecionado.AgendamentosPeriodo));
            cmbTipoRelatorio.Items.Add(new RelatorioItem("Pacotes Vendidos por Período", TipoRelatorioSelecionado.PacotesVendidosPeriodo));
            cmbTipoRelatorio.Items.Add(new RelatorioItem("Lista de Clientes Ativos", TipoRelatorioSelecionado.ClientesAtivos));

            cmbTipoRelatorio.DisplayMember = "Nome";
            cmbTipoRelatorio.ValueMember = "Tipo";
            cmbTipoRelatorio.SelectedIndex = 0;
            MostrarFiltrosPeriodo(false);
        }

        private class RelatorioItem
        {
            public string Nome { get; set; }
            public TipoRelatorioSelecionado Tipo { get; set; }
            public RelatorioItem(string nome, TipoRelatorioSelecionado tipo)
            {
                Nome = nome;
                Tipo = tipo;
            }
          
            public override string ToString() => Nome;
        }

        private void MostrarFiltrosPeriodo(bool mostrar)
        {
            lblDataInicio.Visible = mostrar;
            dtpDataInicio.Visible = mostrar;
            lblDataFim.Visible = mostrar;
            dtpDataFim.Visible = mostrar;
        }

        private void cmbTipoRelatorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoRelatorio.SelectedItem is RelatorioItem itemSelecionado)
            {
                switch (itemSelecionado.Tipo)
                {
                    case TipoRelatorioSelecionado.FaturamentoPeriodo:
                    case TipoRelatorioSelecionado.AgendamentosPeriodo:
                    case TipoRelatorioSelecionado.PacotesVendidosPeriodo:
                        MostrarFiltrosPeriodo(true);
                        break;
                    case TipoRelatorioSelecionado.ClientesAtivos:
                    case TipoRelatorioSelecionado.Nenhum:
                    default:
                        MostrarFiltrosPeriodo(false);
                        break;
                }
            }
            else
            {
                MostrarFiltrosPeriodo(false);
            }
        }

        private async void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (!(cmbTipoRelatorio.SelectedItem is RelatorioItem itemSelecionado) || itemSelecionado.Tipo == TipoRelatorioSelecionado.Nenhum)
            {
                MessageBox.Show("Por favor, selecione um tipo de relatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeArquivoSugerido = $"{itemSelecionado.Nome.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivos PDF (*.pdf)|*.pdf",
                Title = "Salvar Relatório PDF",
                FileName = nomeArquivoSugerido
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = saveFileDialog.FileName;
                Cursor = Cursors.WaitCursor;
                btnGerarRelatorio.Enabled = false;

                try
                {
                    DateTime dataInicio = dtpDataInicio.Value.Date;
                    DateTime dataFim = dtpDataFim.Value.Date.AddDays(1).AddTicks(-1);

                    Document document = null;
                    using (var context = new PetshopContext())
                    {
                        switch (itemSelecionado.Tipo)
                        {
                            case TipoRelatorioSelecionado.FaturamentoPeriodo:
                                document = await CriarRelatorioFaturamento(context, dataInicio, dataFim);
                                break;
                            case TipoRelatorioSelecionado.AgendamentosPeriodo:
                                document = await CriarRelatorioAgendamentos(context, dataInicio, dataFim);
                                break;
                            case TipoRelatorioSelecionado.PacotesVendidosPeriodo:
                                document = await CriarRelatorioPacotesVendidos(context, dataInicio, dataFim);
                                break;
                            case TipoRelatorioSelecionado.ClientesAtivos:
                                document = await CriarRelatorioClientesAtivos(context);
                                break;
                        }
                    }

                    if (document != null)
                    {
                        document.GeneratePdf(caminhoArquivo);
                        if (MessageBox.Show("Relatório gerado com sucesso!\nDeseja abrir o arquivo?", "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(caminhoArquivo) { UseShellExecute = true });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível gerar o relatório selecionado (método não implementado?).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao gerar o relatório:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    btnGerarRelatorio.Enabled = true;
                }
            }
        }

        

        private async Task<Document> CriarRelatorioFaturamento(PetshopContext context, DateTime inicio, DateTime fim)
        {
            var agendamentosPagos = await context.Agendamentos
                .Include(a => a.Pet.Cliente)
                .Include(a => a.Servico)
                .Where(a => a.Pagamento == StatusPagamento.Pago && a.DataPagamento >= inicio && a.DataPagamento <= fim && a.ValorCobrado > 0)
                .OrderBy(a => a.DataPagamento)
                .ToListAsync();

            var pacotesPagos = await context.ClientesPacotes
               .Include(cp => cp.Cliente)
               .Include(cp => cp.Pacote)
               .Where(cp => cp.DataAquisicao >= inicio && cp.DataAquisicao <= fim.Date)
               .OrderBy(cp => cp.DataAquisicao)
               .ToListAsync();

            var sangrias = await context.MovimentacoesCaixa
                .Where(m => m.Tipo == TipoMovimentacao.Sangria &&
                            m.DataHora >= inicio && m.DataHora <= fim)
                .OrderBy(m => m.DataHora)
                .ToListAsync();

            decimal totalAgendamentos = agendamentosPagos.Sum(a => a.ValorCobrado);
            decimal totalPacotes = pacotesPagos.Sum(cp => cp.Pacote.PrecoTotal);
            decimal totalEntradas = totalAgendamentos + totalPacotes;
            decimal totalSangrias = sangrias.Sum(s => s.Valor);
            decimal totalLiquido = totalEntradas - totalSangrias;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30f);
                    page.Header()
                        .Text($"Relatório de Fluxo de Caixa ({inicio:dd/MM/yyyy} - {fim:dd/MM/yyyy})")
                        .SemiBold().FontSize(16).AlignCenter();

                    page.Content()
                        .PaddingVertical(10f)
                        .Column(col =>
                        {
                           
                            col.Item().Text("Entradas:").Bold().FontSize(14);
                            
                            col.Item().PaddingTop(5f);

                            if (agendamentosPagos.Any())
                            {
                                col.Item().Text("Serviços Avulsos Pagos:").SemiBold();
                                col.Item().Table(table =>
                                { 
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1.5f); columns.RelativeColumn(4); columns.RelativeColumn(4); columns.RelativeColumn(2);
                                    });
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Data Pagto").Bold(); header.Cell().Text("Cliente").Bold(); header.Cell().Text("Serviço").Bold(); header.Cell().AlignRight().Text("Valor").Bold();
                                    });
                                    foreach (var ag in agendamentosPagos)
                                    {
                                        table.Cell().Text(ag.DataPagamento?.ToString("dd/MM/yy")); table.Cell().Text(ag.Pet.Cliente.Nome); table.Cell().Text(ag.Servico.Nome); table.Cell().AlignRight().Text($"{ag.ValorCobrado:C}");
                                    }
                                    table.Cell().ColumnSpan(3).AlignRight().Text("Subtotal Serviços:").Bold(); table.Cell().AlignRight().Text($"{totalAgendamentos:C}").Bold();
                                });
                                col.Item().PaddingTop(10f);
                            }

                            if (pacotesPagos.Any())
                            {
                                col.Item().Text("Pacotes Vendidos:").SemiBold();
                                col.Item().Table(table =>
                                { 
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1.5f); columns.RelativeColumn(4); columns.RelativeColumn(4); columns.RelativeColumn(2);
                                    });
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Data Aq.").Bold(); header.Cell().Text("Cliente").Bold(); header.Cell().Text("Pacote").Bold(); header.Cell().AlignRight().Text("Valor").Bold();
                                    });
                                    foreach (var cp in pacotesPagos)
                                    {
                                        table.Cell().Text(cp.DataAquisicao.ToString("dd/MM/yy")); table.Cell().Text(cp.Cliente.Nome); table.Cell().Text(cp.Pacote.Nome); table.Cell().AlignRight().Text($"{cp.Pacote.PrecoTotal:C}");
                                    }
                                    table.Cell().ColumnSpan(3).AlignRight().Text("Subtotal Pacotes:").Bold(); table.Cell().AlignRight().Text($"{totalPacotes:C}").Bold();
                                });
                                col.Item().PaddingTop(10f);
                            }
                            col.Item().AlignRight().Text($"Total de Entradas: {totalEntradas:C}").Bold().FontSize(12);
                            col.Item().PaddingTop(15f);

                            
                            col.Item().Text("Saídas (Sangrias):").Bold().FontSize(14);
                            
                            col.Item().PaddingTop(5f);

                            if (sangrias.Any())
                            {
                                col.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1.5f); columns.RelativeColumn(6); columns.RelativeColumn(2);
                                    });
                                    table.Header(header =>
                                    {
                                        header.Cell().Text("Data/Hora").Bold(); header.Cell().Text("Descrição").Bold(); header.Cell().AlignRight().Text("Valor").Bold();
                                    });
                                    foreach (var s in sangrias)
                                    {
                                        table.Cell().Text(s.DataHora.ToString("dd/MM/yy HH:mm")); table.Cell().Text(s.Descricao); table.Cell().AlignRight().Text($"{s.Valor:C}");
                                    }
                                    table.Cell().ColumnSpan(2).AlignRight().Text("Total Sangrias:").Bold(); table.Cell().AlignRight().Text($"{totalSangrias:C}").Bold();
                                });
                            }
                            else
                            {
                                col.Item().Text("Nenhuma sangria registrada no período.");
                            }
                            col.Item().PaddingTop(15f);

                            
                            col.Item().LineHorizontal(1f).LineColor(Colors.Grey.Medium);
                            col.Item().PaddingTop(5f).AlignRight().Text($"Total Líquido (Entradas - Sangrias): {totalLiquido:C}").Bold().FontSize(14);
                        });

                    page.Footer().AlignCenter().Text(x =>
                    { 
                        x.Span("Página "); x.CurrentPageNumber(); x.Span(" de "); x.TotalPages();
                    });
                });
            });
        }

        private async Task<Document> CriarRelatorioAgendamentos(PetshopContext context, DateTime inicio, DateTime fim)
        {
            var agendamentos = await context.Agendamentos
               .Include(a => a.Pet.Cliente)
               .Include(a => a.Servico)
               .Where(a => a.DataHora >= inicio && a.DataHora <= fim)
               .OrderBy(a => a.DataHora)
               .ToListAsync();

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30f); 
                    page.Header().Text($"Relatório de Agendamentos ({inicio:dd/MM/yyyy} - {fim:dd/MM/yyyy})").SemiBold().FontSize(16).AlignCenter();
                    page.Content().PaddingVertical(10f).Column(col =>
                    { 
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(2.5f); 
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(1.5f); 
                                columns.RelativeColumn(1);
                            });
                            table.Header(header =>
                            {
                                header.Cell().Text("Data/Hora").Bold();
                                header.Cell().Text("Cliente").Bold();
                                header.Cell().Text("Pet").Bold();
                                header.Cell().Text("Serviço").Bold();
                                header.Cell().Text("Status").Bold();
                                header.Cell().Text("Pacote").Bold();
                            });
                            foreach (var ag in agendamentos)
                            { 
                                table.Cell().Text(ag.DataHora.ToString("dd/MM/yy HH:mm"));
                                table.Cell().Text(ag.Pet.Cliente.Nome);
                                table.Cell().Text(ag.Pet.Nome);
                                table.Cell().Text(ag.Servico.Nome);
                                table.Cell().Text(ag.Status.ToString());
                                table.Cell().Text(ag.ClientePacoteId.HasValue ? "Sim" : "Não");
                            }
                        });
                        col.Item().PaddingTop(5f).AlignRight().Text($"Total de agendamentos: {agendamentos.Count}"); // CORRIGIDO: Adicionado 'f'
                    });
                    page.Footer().AlignCenter().Text(x =>
                    { 
                        x.Span("Página "); x.CurrentPageNumber(); x.Span(" de "); x.TotalPages();
                    });
                });
            });
        }

        private async Task<Document> CriarRelatorioPacotesVendidos(PetshopContext context, DateTime inicio, DateTime fim)
        {
            var pacotesVendidos = await context.ClientesPacotes
               .Include(cp => cp.Cliente)
               .Include(cp => cp.Pacote)
               .ThenInclude(p => p.Servico)
               .Where(cp => cp.DataAquisicao >= inicio && cp.DataAquisicao <= fim.Date)
               .OrderBy(cp => cp.DataAquisicao)
               .ToListAsync();

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30f); 
                    page.Header().Text($"Relatório de Pacotes Vendidos ({inicio:dd/MM/yyyy} - {fim:dd/MM/yyyy})").SemiBold().FontSize(16).AlignCenter();
                    page.Content().PaddingVertical(10f).Column(col =>
                    { 
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1.5f); 
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1.5f); 
                            });
                            table.Header(header =>
                            { 
                                header.Cell().Text("Data Aq.").Bold();
                                header.Cell().Text("Cliente").Bold();
                                header.Cell().Text("Pacote").Bold();
                                header.Cell().Text("Sessões").Bold();
                                header.Cell().AlignRight().Text("Preço").Bold();
                            });
                            foreach (var cp in pacotesVendidos)
                            { 
                                table.Cell().Text(cp.DataAquisicao.ToString("dd/MM/yy"));
                                table.Cell().Text(cp.Cliente.Nome);
                                table.Cell().Text($"{cp.Pacote.Nome} ({cp.Pacote.Servico.Nome})");
                                table.Cell().Text(cp.Pacote.QuantidadeSessoes.ToString());
                                table.Cell().AlignRight().Text($"{cp.Pacote.PrecoTotal:C}");
                            }
                        });
                        col.Item().PaddingTop(5f).AlignRight().Text($"Total de pacotes vendidos: {pacotesVendidos.Count}"); // CORRIGIDO: Adicionado 'f'
                        col.Item().PaddingTop(5f).AlignRight().Text($"Valor total vendido: {pacotesVendidos.Sum(cp => cp.Pacote.PrecoTotal):C}").Bold(); // CORRIGIDO: Adicionado 'f'
                    });
                    page.Footer().AlignCenter().Text(x =>
                    { 
                        x.Span("Página "); x.CurrentPageNumber(); x.Span(" de "); x.TotalPages();
                    });
                });
            });
        }

        private async Task<Document> CriarRelatorioClientesAtivos(PetshopContext context)
        {
            var clientes = await context.Clientes
                                   .OrderBy(c => c.Nome)
                                   .ToListAsync();

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30f); 
                    page.Header().Text($"Relatório de Clientes Ativos").SemiBold().FontSize(16).AlignCenter();
                    page.Content().PaddingVertical(10f).Column(col =>
                    {
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(4);
                            });
                            table.Header(header =>
                            { 
                                header.Cell().Text("Nome").Bold();
                                header.Cell().Text("Telefone").Bold();
                                header.Cell().Text("Endereço").Bold();
                            });
                            foreach (var cli in clientes)
                            {
                                table.Cell().Text(cli.Nome);
                                table.Cell().Text(cli.Telefone);
                                table.Cell().Text(cli.Endereco);
                            }
                        });
                        col.Item().PaddingTop(5f).AlignRight().Text($"Total de clientes: {clientes.Count}"); // CORRIGIDO: Adicionado 'f'
                    });
                    page.Footer().AlignCenter().Text(x =>
                    { 
                        x.Span("Página "); x.CurrentPageNumber(); x.Span(" de "); x.TotalPages();
                    });
                });
            });
        }

        private void lblDataInicio_Click(object sender, EventArgs e)
        {

        }
    }
}