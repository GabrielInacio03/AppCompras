using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public class ProdutoDao : Dao
    {
        public void Insert(Produto produto)
        {           
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_I_InserirProduto";
            sql.CommandType = System.Data.CommandType.Text;

            SqlParameter param = new SqlParameter();
            sql.Parameters.Add(new SqlParameter("@descricao", produto.Descricao));
            sql.Parameters.Add(new SqlParameter("@valor", produto.Valor));
            sql.Parameters.Add(new SqlParameter("@ativo", produto.Ativo));
            sql.CommandType = System.Data.CommandType.StoredProcedure;

            sql.ExecuteNonQuery();
            conexao.Close();
        }        
        public List<Produto> Read()
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarTodosProduto";
            sql.CommandType = System.Data.CommandType.Text;

            List<Produto> produtos = new List<Produto>();

            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produto p = new Produto();
                    p.Id = (int)reader["codigo"];
                    p.Descricao = reader["descricao"].ToString();
                    p.Valor = float.Parse(reader["valor"].ToString());
                    p.Ativo = reader["ativo"].ToString() != null ? int.Parse(reader["ativo"].ToString()) : p.Ativo;
                    if (p.Ativo == 1)
                    {
                        p.AtivoString = "Ativo";
                        produtos.Add(p);
                    }
                    
                }
            }
            conexao.Close();
            return produtos;
        }
        public void Delete(int id)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                SqlParameter param = new SqlParameter();
                sql.CommandText = "PROC_D_DeletarProduto";
                sql.Parameters.AddWithValue("@id", id);
                sql.CommandType = System.Data.CommandType.StoredProcedure;

                sql.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Produto BuscarPorId(int id)
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();
            Produto produto = new Produto();
            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarProdutoPorCodigo";
            sql.Parameters.AddWithValue("@id", id);
            sql.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = sql.ExecuteReader())
            {
                if (reader.Read())
                {
                    produto.Id = (int)reader["codigo"];
                    produto.Descricao = reader["descricao"].ToString();
                    produto.Valor = float.Parse(reader["valor"].ToString());                    

                }
            }
            conexao.Close();
            return produto;
        }

        public void Update(Produto produto, int id)
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            SqlCommand sql = conexao.CreateCommand();
            //sql.CommandText = "UPDATE cliente SET  nome='" + @nome + "' WHERE codigo='@id'";
            sql.CommandType = System.Data.CommandType.Text;
        }
    }
}
