
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetshopMiau.App
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

      
        private void pacotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPacotes telaPacotes = new frmPacotes();
            telaPacotes.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgenda telaAgenda = new frmAgenda();
            telaAgenda.Show();
        }

        private void financeiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCaixa telaCaixa = new frmCaixa();
            telaCaixa.Show();
        }

        private void servicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicos telaServicos = new frmServicos();
            telaServicos.ShowDialog();
        }

        private void relatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorios telaRelatorios = new frmRelatorios();
            telaRelatorios.ShowDialog();
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes telaClientes = new frmClientes();
            telaClientes.ShowDialog();
        }
    }
}
