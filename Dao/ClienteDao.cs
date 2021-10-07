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
                sql.CommandText = "Insert Into Cliente(nome, datanasc, endereco) VALUES (@nome, @datanasc, @endereco)";
                sql.CommandType = System.Data.CommandType.Text;

                SqlParameter param = new SqlParameter();
                param.Value = cliente.Nome;
                param.ParameterName = "@nome";
                sql.Parameters.Add(param);
                sql.Parameters.Add(new SqlParameter("@datanasc", cliente.DataNasc));
                sql.Parameters.Add(new SqlParameter("@endereco", cliente.Endereco));

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
            sql.CommandText = "SELECT * FROM Cliente";
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

                    clientes.Add(c);
                }
            }

            conexao.Close();
            return clientes;
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
