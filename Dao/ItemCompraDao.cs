using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public class ItemCompraDao : Dao
    {
        public void Insert(ItemCompra itemCompra)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                sql.CommandText = "INSERT INTO itemCompra(codcompra,codproduto,qtd,subtot) VALUES (@codcompra,@codproduto,@qtd,@subtot)";
                sql.CommandType = System.Data.CommandType.Text;


                SqlParameter param = new SqlParameter();
                sql.Parameters.Add(new SqlParameter("@codcompra", itemCompra.CodCompra));
                sql.Parameters.Add(new SqlParameter("@codproduto", itemCompra.CodProduto));
                sql.Parameters.Add(new SqlParameter("@qtd", itemCompra.Qtd));
                sql.Parameters.Add(new SqlParameter("@subtot", itemCompra.SubTotal));

                sql.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(ItemCompra ItemCompra, int id) { }       
    }
}
