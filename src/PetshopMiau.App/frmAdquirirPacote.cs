using PetshopMiau.Core;
using PetshopMiau.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PetshopMiau.App
{
    public partial class frmAdquirirPacote : Form
    {
  
        private readonly int _clienteId;
        public bool PacoteAdquiridoComSucesso { get; private set; } = false;

        public frmAdquirirPacote(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
        }

        private void frmAdquirirPacote_Load(object sender, EventArgs e)
        {
            CarregarPacotesDisponiveis();
        }

        private void CarregarPacotesDisponiveis()
        {
            using (var context = new PetshopContext())
            {
                var pacotes = context.Pacotes
                    .Include(p => p.Servico)
                    .OrderBy(p => p.Nome)
                    .Select(p => new
                    {
                        Id = p.Id,
                        Display = $"{p.Nome} ({p.QuantidadeSessoes}x {p.Servico.Nome} - {p.PrecoTotal:C})"
                    })
                    .ToList();

                cmbPacotesDisponiveis.DataSource = pacotes;
                cmbPacotesDisponiveis.DisplayMember = "Display";
                cmbPacotesDisponiveis.ValueMember = "Id";
                cmbPacotesDisponiveis.SelectedIndex = -1;
            }
        }

        private void btnConfirmarAquisicao_Click(object sender, EventArgs e)
        {
            if (cmbPacotesDisponiveis.SelectedValue == null)
            {
                MessageBox.Show("Selecione um pacote.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pacoteIdSelecionado = (int)cmbPacotesDisponiveis.SelectedValue;

            using (var context = new PetshopContext())
            {
                var pacoteInfo = context.Pacotes.Find(pacoteIdSelecionado);
                if (pacoteInfo == null) return;

                var novaAquisicao = new ClientePacote
                {
                  
                    ClienteId = _clienteId,
                    PacoteId = pacoteIdSelecionado,
                    DataAquisicao = DateTime.Now.Date,
                    DataVencimento = DateTime.Now.Date.AddDays(pacoteInfo.ValidadeEmDias),
                    SessoesDisponiveis = pacoteInfo.QuantidadeSessoes
                };

                context.ClientesPacotes.Add(novaAquisicao);
                context.SaveChanges();

                PacoteAdquiridoComSucesso = true;
                MessageBox.Show("Pacote adquirido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
              
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPacotesDisponiveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPacotesDisponiveis.SelectedValue != null)
            {
                int pacoteIdSelecionado = (int)cmbPacotesDisponiveis.SelectedValue;
                using (var context = new PetshopContext())
                {
                    var pacote = context.Pacotes.Include(p => p.Servico).FirstOrDefault(p => p.Id == pacoteIdSelecionado);
                    if (pacote != null)
                    {
                     
                    }
                }
            }
            else
            {
               
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}