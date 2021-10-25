using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public class ClienteDao : Dao
    {
        public void Insert(Cliente cliente) 
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                SqlParameter param = new SqlParameter();
                sql.CommandText = "PROC_I_InserirCliente";
                sql.Parameters.Add(new SqlParameter("@nome", cliente.Nome));
                sql.Parameters.Add(new SqlParameter("@datanasc", cliente.DataNasc));
                sql.Parameters.Add(new SqlParameter("@endereco", cliente.Endereco));
                sql.Parameters.Add(new SqlParameter("@ativo", cliente.Ativo));
                sql.CommandType = System.Data.CommandType.StoredProcedure;

                sql.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }    
        public void Delete(int id)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                SqlParameter param = new SqlParameter();
                sql.CommandText = "PROC_D_DeletarCliente";
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
        public List<Cliente> Read()
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarTodosCliente";
            sql.CommandType = System.Data.CommandType.Text;

            List<Cliente> clientes = new List<Cliente>();

            using (SqlDataReader reader = sql.ExecuteReader())
            {                
                while (reader.Read())
                {
                    Cliente c = new Cliente();
                    c.Id = (int)reader["codigo"];
                    c.Nome = reader["nome"].ToString();
                    c.DataNasc = DateTime.Parse(reader["datanasc"].ToString()).ToString("dd-MM-yyyy");
                    c.Endereco = reader["endereco"].ToString();
                    c.Ativo = reader["ativo"].ToString() != null ? int.Parse(reader["ativo"].ToString()) : c.Ativo;
                    if (c.Ativo == 1)
                    {
                        c.AtivoString = "Ativo";
                        clientes.Add(c);
                    }                    
                }
            }

            conexao.Close();
            return clientes;
        }
        public Cliente BuscarPorId(int id)
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();
            Cliente cliente = new Cliente();
            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarClientePorCodigo";
            sql.Parameters.AddWithValue("@id", id);
            sql.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = sql.ExecuteReader())
            {
                if (reader.Read())
                {
                    cliente.Id = (int)reader["codigo"];
                    cliente.Nome = reader["nome"].ToString();

                }
            }
            conexao.Close();
            return cliente;
        }
        public void Update(Cliente cliente, int id)
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            SqlCommand sql = conexao.CreateCommand();
            //sql.CommandText = "UPDATE cliente SET  nome='" + @nome + "' WHERE codigo='@id'";
            sql.CommandType = System.Data.CommandType.Text;


            conexao.Close();
        }       
    }
}
