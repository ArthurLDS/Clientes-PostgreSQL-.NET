using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
           
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GoTelaCadastro()
        {
            this.Hide();
            frmCadastro telaCadastro = new frmCadastro();
            telaCadastro.ShowDialog();
            this.Close();
        }


        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTelaCadastro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoTelaCadastro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsulta telaConsulta = new frmConsulta();
            telaConsulta.ShowDialog();
            this.Close();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsulta telaConsulta = new frmConsulta();
            telaConsulta.ShowDialog();
            this.Close();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software desenvolvido por Arthur Lima de Souza, estudante de sistmeas de informação pela FACCAT.", "Créditos");
        }
    }
}
