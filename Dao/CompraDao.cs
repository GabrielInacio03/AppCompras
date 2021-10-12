using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public class CompraDao : Dao
    {
        public int Insert(Compra compra)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                sql.CommandText = "INSERT INTO compra(datacomp, valortot, codcliente) VALUES (@datacomp, @valortot, @codcliente);select SCOPE_IDENTITY (); ";
                sql.CommandType = System.Data.CommandType.Text;
                
                sql.Parameters.Add(new SqlParameter("@datacomp", compra.Data));
                sql.Parameters.Add(new SqlParameter("@valortot", compra.ValorTot));
                sql.Parameters.Add(new SqlParameter("@codcliente", compra.CodCliente));
                
                int resultado = int.Parse(sql.ExecuteScalar().ToString()); 
                                
                conexao.Close();

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(Compra Compra, int id) { }      
    }
}
