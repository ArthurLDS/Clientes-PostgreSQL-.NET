using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace WindowsFormsApplication1
{
    

    public class conexao
    {
        public static NpgsqlConnection conn = new NpgsqlConnection();

        public static void Conectar()
        {
            conn.ConnectionString = "Server=localhost;Port=5433;Database=postgres;User ID=postgres;Password=123456;Timeout=90;CommandTimeout=90;Pooling=true;";
            conn.Open();
        }

        public static DataTable RetornaSQL(string pSQL)
        {
           DataTable retorno = new DataTable();

           if  (conn.State != ConnectionState.Open)
                return new DataTable();

            // 2 - Comando para pegar as senhas
            Npgsql.NpgsqlCommand comando = new Npgsql.NpgsqlCommand();
            comando.Connection = conn;
            comando.CommandText = pSQL;

            // 3 - Adaptador para usar a conexão e os comandos para acessar o bando de dados
            Npgsql.NpgsqlDataAdapter adaptador = new Npgsql.NpgsqlDataAdapter();
            adaptador.SelectCommand = comando;
            adaptador.Fill(retorno);

            return retorno;
        }

        public static void Desconectar()
        {
            conn.Close();
        }

        public static void ExecutaSQL(string pSQL)
        {
            // 2 - Comando para pegar as senhas
            Npgsql.NpgsqlCommand comando = new Npgsql.NpgsqlCommand();
            comando.Connection = conn;
            comando.CommandText = pSQL;

            comando.ExecuteNonQuery();

        }
    }
}
