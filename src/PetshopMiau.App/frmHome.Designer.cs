namespace PetshopMiau.App
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            pacotesToolStripMenuItem = new ToolStripMenuItem();
            servicosToolStripMenuItem = new ToolStripMenuItem();
            agendaToolStripMenuItem = new ToolStripMenuItem();
            financeiroToolStripMenuItem = new ToolStripMenuItem();
            relatoriosToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(255, 249, 219);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(803, 615);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(211, 178, 169);
            menuStrip1.Items.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, pacotesToolStripMenuItem, servicosToolStripMenuItem, agendaToolStripMenuItem, financeiroToolStripMenuItem, relatoriosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(803, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // pacotesToolStripMenuItem
            // 
            pacotesToolStripMenuItem.Name = "pacotesToolStripMenuItem";
            pacotesToolStripMenuItem.Size = new Size(60, 20);
            pacotesToolStripMenuItem.Text = "Pacotes";
            pacotesToolStripMenuItem.Click += PacotesToolStripMenuItem_Click;
            // 
            // servicosToolStripMenuItem
            // 
            servicosToolStripMenuItem.Name = "servicosToolStripMenuItem";
            servicosToolStripMenuItem.Size = new Size(62, 20);
            servicosToolStripMenuItem.Text = "Servicos";
            servicosToolStripMenuItem.Click += servicosToolStripMenuItem_Click;
            // 
            // agendaToolStripMenuItem
            // 
            agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            agendaToolStripMenuItem.Size = new Size(60, 20);
            agendaToolStripMenuItem.Text = "Agenda";
            agendaToolStripMenuItem.Click += AgendaToolStripMenuItem_Click;
            // 
            // financeiroToolStripMenuItem
            // 
            financeiroToolStripMenuItem.Name = "financeiroToolStripMenuItem";
            financeiroToolStripMenuItem.Size = new Size(74, 20);
            financeiroToolStripMenuItem.Text = "Financeiro";
            financeiroToolStripMenuItem.Click += financeiroToolStripMenuItem_Click;
            // 
            // relatoriosToolStripMenuItem
            // 
            relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            relatoriosToolStripMenuItem.Size = new Size(71, 20);
            relatoriosToolStripMenuItem.Text = "Relatorios";
            relatoriosToolStripMenuItem.Click += relatoriosToolStripMenuItem_Click;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(803, 615);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmHome";
            Text = "Home";
            WindowState = FormWindowState.Maximized;
            Load += frmHome_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgenda telaAgenda = new frmAgenda();
            telaAgenda.Show();
        }

        private void PacotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPacotes telaPacotes = new frmPacotes();
            telaPacotes.Show();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem pacotesToolStripMenuItem1;
        private ToolStripMenuItem entrarToolStripMenuItem;
        private ToolStripMenuItem pacotesToolStripMenuItem;
        private ToolStripMenuItem agendaToolStripMenuItem;
        private ToolStripMenuItem financeiroToolStripMenuItem;
        private ToolStripMenuItem servicosToolStripMenuItem;
        private ToolStripMenuItem relatoriosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
    }
}