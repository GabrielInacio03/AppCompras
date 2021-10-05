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
            sql.CommandText = "Insert Into Produto(descricao, valor) VALUES (@descricao, @valor)";
            sql.CommandType = System.Data.CommandType.Text;

            SqlParameter param = new SqlParameter();
            param.Value = produto.Descricao;
            param.ParameterName = "@descricao";
            sql.Parameters.Add(param);
            sql.Parameters.Add(new SqlParameter("@valor", produto.Valor));

            sql.ExecuteNonQuery();
            conexao.Close();
        }
        public void Update(Produto produto, int id) { }     
    }
}
