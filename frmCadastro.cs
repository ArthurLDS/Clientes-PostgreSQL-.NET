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
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }
        private bool ValidaTela()
        {
            //Verificando os campos
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblSit.Text = "O campo nome não pode estar vazio!";
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefone.Text))
            {
                lblSit.Text = "O campo telefone não pode estar vazio!";
                return false;
            }
            if (!(string.IsNullOrEmpty(txtTelefone.Text)))
            {
                lblSit.Text = "";

            }
            return true;
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int cont = 0;
            string sql = "";

            if (!ValidaTela())
                return;

            try
            {
                //Aqui vamos cadastrar o cliente!

                // 1 - Conexão com banco de dados
                //Npgsql.NpgsqlConnection conexao = new Npgsql.NpgsqlConnection();
                //conexao.ConnectionString = "Server=localhost;Port=5433;Database=postgres;User ID=postgres;Password=123456;Timeout=90;CommandTimeout=90;Pooling=true;";

                //conexao.Open();
                cont++;

                

                // 2 - Comando para pegar as senhas
                //Npgsql.NpgsqlCommand comando = new Npgsql.NpgsqlCommand();
                //comando.Connection = conexao;
                sql =  "INSERT INTO clientes (nome, telefone) VALUES ('" + txtNome.Text + "','" + txtTelefone.Text + "')";
                conexao.ExecutaSQL(sql);
                //comando.ExecuteNonQuery();


                lblSit.Text = "Cadastro efetuado com sucesso!";
                lblSit.ForeColor = Color.FromArgb(0, 128, 0);
                txtNome.Text = null;
                txtTelefone.Text = null;
            }
            catch
            {
                lblSit.Text = "ERRO na conexão!";
                if (cont == 0)
                {
                    MessageBox.Show("Erro na conexão com banco de dados!", "ERRO");
                }
                else
                {
                    MessageBox.Show("Erro ao inserir dados no banco de dados!", "ERRO");
                }

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal telaMain = new frmPrincipal();
            telaMain.ShowDialog();
            this.Close();
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software desenvolvido por Arthur Lima de Souza, estudante de sistmeas de informação pela FACCAT.", "Créditos");
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPrincipal telaMain = new frmPrincipal();
            telaMain.ShowDialog();
            this.Close();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConsulta telaConsulta = new frmConsulta();
            telaConsulta.ShowDialog();
            this.Close();
        }
    }
}
