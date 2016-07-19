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

    public partial class frmConsulta : Form 
    {

        public frmConsulta()
        {
            InitializeComponent();
        }
        public void TelaPrincipal()
        {
            this.Hide();
            frmPrincipal telaMain = new frmPrincipal();
            telaMain.ShowDialog();
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TelaPrincipal();
        }
        public bool ValidaCampo()
        {
            if (string.IsNullOrEmpty(txtPesquisa.Text))
            {
                lblSit.Text = "O campo acima não pode estar vazio";
                return false;
            }
            else
            {
                lblSit.Text = null;
                return true;
            }
        }
        
        public void btnPesquisar_Click(object sender, EventArgs e)
        {

            if (!ValidaCampo())
                return;

            string strNome = txtPesquisa.Text;
            DataTable tabela = new DataTable();

            

            try
            {
                // 1 - Conexão com banco de dados
                Npgsql.NpgsqlConnection conexao = new Npgsql.NpgsqlConnection();
                conexao.ConnectionString = "Server=localhost;Port=5433;Database=postgres;User ID=postgres;Password=123456;Timeout=90;CommandTimeout=90;Pooling=true;";
                conexao.Open();

                // 2 - Comando para pegar as senhas
                Npgsql.NpgsqlCommand comando = new Npgsql.NpgsqlCommand();
                comando.Connection = conexao;
                //o comando UPPER abaixo transforma tudo para letra maiusculas
                comando.CommandText = "SELECT * FROM clientes WHERE UPPER(nome) LIKE '%" + strNome.ToUpper() + "%'";

                // 3 - Adaptador para usar a conexão e os comandos para acessar o bando de dados
                Npgsql.NpgsqlDataAdapter adaptador = new Npgsql.NpgsqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(tabela);


                if(tabela.Rows.Count == 0)
                {
                    lblSit.Text = "Nenhum resultado encontrado!";
                    MessageBox.Show("Nada encontrado no banco de dados com esse nome, tente novamente.", "Nada encontrado!");
                }
                else
                {
                    dgvClientes.AutoGenerateColumns = true;
                    dgvClientes.DataSource = tabela;
                }
              
                //Fecha conexão com banco de dados!!
                conexao.Close();

            }
            catch
            {
                lblSit.Text = "ERRO na conexão";
                MessageBox.Show("ERRO na conexão com banco de dados");
            }
            

        }
        

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strNome = txtPesquisa.Text;
            DataTable tabela = new DataTable();

            try
            {
                // 1 - Conexão com banco de dados
                Npgsql.NpgsqlConnection conexao = new Npgsql.NpgsqlConnection();
                conexao.ConnectionString = "Server=localhost;Port=5433;Database=postgres;User ID=postgres;Password=123456;Timeout=90;CommandTimeout=90;Pooling=true;";
                conexao.Open();

                // 2 - Comando para pegar as senhas
                Npgsql.NpgsqlCommand comando = new Npgsql.NpgsqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "SELECT * FROM clientes";

                // 3 - Adaptador para usar a conexão e os comandos para acessar o bando de dados
                Npgsql.NpgsqlDataAdapter adaptador = new Npgsql.NpgsqlDataAdapter();

                adaptador.SelectCommand = comando;
                adaptador.Fill(tabela);

                /*if (tabela.Rows.Count == 0)
                {
                    lblSit.Text = "Nenhum resultado encontrado!";
                    MessageBox.Show("Nada encontrado no banco de dados, tente novamente.", "Nada encontrado!");
                }
                else
                {*/
                    dgvClientes.AutoGenerateColumns = true;
                    dgvClientes.DataSource = tabela;
                //}

                //Fecha conexão com banco de dados!!
                conexao.Close();
            }
            catch
            {
                lblSit.Text = "ERRO na conexão";
                MessageBox.Show("ERRO na conexão com banco de dados");
            }
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Software desenvolvido por Arthur Lima de Souza, estudante de sistmeas de informação pela FACCAT.", "Créditos");
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            frmCadastro telaMain = new frmCadastro();
            telaMain.ShowDialog();
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "";
            string strID = "";
            

            //Deve-se ativar a opção SelectionMode em FullRowSelect no datagridviw
            if(dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um LINHA!");
                return;
            }

            strID = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();

            // 1 - Conexão com banco de dados
            Npgsql.NpgsqlConnection conexao = new Npgsql.NpgsqlConnection();
            conexao.ConnectionString = "Server=localhost;Port=5433;Database=postgres;User ID=postgres;Password=123456;Timeout=90;CommandTimeout=90;Pooling=true;";
            conexao.Open();

            // 2 - Comando para pegar as senhas
            Npgsql.NpgsqlCommand comando = new Npgsql.NpgsqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "DELETE FROM clientes WHERE id = " + strID;

            comando.ExecuteNonQuery();

            //Atualiza a tabela
            btnPesquisar_Click(null, null);
            
        }
    }
}
