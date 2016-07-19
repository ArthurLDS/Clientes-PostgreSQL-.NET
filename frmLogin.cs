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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool ValidaTela()
        {
            //Verificando os campos
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                lblSit.Text = "Campo user está VAZIO!";
                return false;
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                lblSit.Text = "Campo senha está VAZIO!";
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string strUsuario = "";
            string strSenha = "";
            string sql = "";

            DataTable tabela = new DataTable();

            //Verificando os campos
            if (!ValidaTela())
                return;

            strUsuario = txtUser.Text;
            strSenha = txtSenha.Text;

            strUsuario = strUsuario.Replace("'", "");
            strSenha = strSenha.Replace("'", "");

            try
            {
                //1 - Conexão com banco de dados
                conexao.Conectar();
                
                // faz select
                sql = "SELECT * FROM usuarios WHERE login =  '" + strUsuario + "' AND senha = '" + strSenha + "'";
                tabela = conexao.RetornaSQL(sql);
                

                //Testanto se o usuario e a senha estão certas
                if (tabela.Rows.Count > 0)
                {
                    lblSit.ForeColor = Color.FromArgb(0, 128, 0);
                    lblSit.Text = "ACESSO PERMITIDO!";
                    MessageBox.Show("BEM-VINDO! " + txtUser.Text);//Mensagem na tela
                    this.Hide();

                    frmPrincipal frm = new frmPrincipal();//estanciando outro form
                    frm.ShowDialog(); //abrindo o form
                    this.Close(); //Encerra o form1
                }
                else
                {
                    lblSit.Text = "Usuário ou senha incorreto";
                }

                //Fecha conexão com banco de dados!!
                //conexao.Desconectar();
            }
            catch
            {
                lblSit.Text = "ERRO na conexão";
                MessageBox.Show("ERRO na conexão com banco de dados");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntar.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
