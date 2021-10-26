using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public class CompraDao : Dao
    {
        public void UpdateCompraItem(Model.Compra compra, int id, float valor)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                sql.CommandText = "PROC_U_UpdateCompraItem";
                sql.Parameters.AddWithValue("@id", id);
                sql.Parameters.AddWithValue("@valor", valor);
                sql.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@items";
                param.SqlDbType = System.Data.SqlDbType.Structured;
                param.Value = preencherDataTable(compra.listaItens);
                sql.Parameters.Add(param);


                sql.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(int id, float valor)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                sql.CommandText = "PROC_U_UpdateCompra";
                sql.Parameters.AddWithValue("@id", id);
                sql.Parameters.AddWithValue("@valor", valor);
                sql.CommandType = System.Data.CommandType.StoredProcedure;

                sql.ExecuteNonQuery();
                conexao.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Insert(Compra compra)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                sql.CommandText = "PROC_I_InserirCompra";               
                sql.CommandType = System.Data.CommandType.StoredProcedure;


                sql.Parameters.Add(new SqlParameter("@datacomp", compra.Data));
                sql.Parameters.Add(new SqlParameter("@valortot", compra.ValorTot));
                sql.Parameters.Add(new SqlParameter("@codcliente", compra.CodCliente));                
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@items";
                param.SqlDbType = System.Data.SqlDbType.Structured;
                param.Value = preencherDataTable(compra.listaItens);
                sql.Parameters.Add(param);
            

                sql.ExecuteNonQuery();
                conexao.Close();

                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Compra BuscarPorId(int id)
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();
            Compra compra = new Compra();
            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarCompraPorCodigo";
            sql.Parameters.AddWithValue("@id", id);
            sql.CommandType = System.Data.CommandType.StoredProcedure;

            using (SqlDataReader reader = sql.ExecuteReader())
            {
                if (reader.Read())
                {
                    compra.Id = (int)reader["codigo"];
                    compra.Data = DateTime.Parse(reader["datacomp"].ToString()).ToString("dd-MM-yyyy");
                    compra.ValorTot = float.Parse(reader["valortot"].ToString());
                    compra.CodCliente = (int)reader["codcliente"];
                    compra.Ativo = (int)reader["ativo"];                 

                }
            }
            conexao.Close();
            return compra;
        }
        public List<Model.ItemCompra> BuscarTodosItensId(int id)
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            List<ItemCompra> itens = new List<ItemCompra>();

            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarTodosItensId";
            sql.Parameters.AddWithValue("@id", id);
            sql.CommandType = System.Data.CommandType.StoredProcedure;

            
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                            
                while (reader.Read())
                {
                    Model.ItemCompra item = new Model.ItemCompra();

                    item.Id = (int)reader["codigo"];
                    item.CodCompra = (int)reader["codcompra"];
                    item.CodProduto = (int)reader["codproduto"];
                    item.Qtd = (int)reader["qtd"];
                    item.SubTotal = float.Parse(reader["subtot"].ToString());
                    item.Ativo = reader["ativo"].ToString() != null ? int.Parse(reader["ativo"].ToString()) : item.Ativo;
                    if (item.Ativo == 1)
                    {
                        item.AtivoString = "Ativo";
                        itens.Add(item);
                    }                   
                }
               
                         
                
            }
            conexao.Close();
            return itens;
        }        
        public void DeleteItemDaCompra(int id)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                SqlParameter param = new SqlParameter();
                sql.CommandText = "PROC_D_DeletarItemCompra";
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
        public void Delete(int id)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
                conexao.Open();

                SqlCommand sql = conexao.CreateCommand();
                SqlParameter param = new SqlParameter();
                sql.CommandText = "PROC_D_DeletarCompra";
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
        private DataTable preencherDataTable(List<ItemCompra> listaItens)
        {
            try
            {
                DataTable tabela = new DataTable();
                tabela.TableName = "ITEMS";
                tabela.Columns.Add("codigo");
                tabela.Columns.Add("codcompra");
                tabela.Columns.Add("codproduto");
                tabela.Columns.Add("qtd");
                tabela.Columns.Add("subtot",typeof(float));
                tabela.Columns.Add("ativo");

                foreach (ItemCompra item in listaItens)
                {
                    DataRow row = tabela.NewRow();
                    row["codigo"] = item.Id;
                    row["codcompra"] = item.CodCompra;
                    row["codproduto"] = item.CodProduto;
                    row["qtd"] = item.Qtd;
                    row["subtot"] = item.SubTotal ;
                    row["ativo"] = item.Ativo;
                    tabela.Rows.Add(row);
                }
                return tabela;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Compra> Read()
        {
            SqlConnection conexao = new SqlConnection(CONNECTION_STRING);
            conexao.Open();

            SqlCommand sql = conexao.CreateCommand();
            sql.CommandText = "PROC_S_BuscarTodosCompra";
            sql.CommandType = System.Data.CommandType.StoredProcedure;

            List<Model.Compra> compras = new List<Model.Compra>();

            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    Compra c = new Compra();
                    c.Id = (int)reader["codigo"];
                    if (reader["codcliente"].ToString() != null)
                    {
                        c.CodCliente = (int)reader["codcliente"];
                    }
                    if (reader["datacomp"].ToString() != null)
                    {
                        c.Data = DateTime.Parse(reader["datacomp"].ToString()).ToString("dd-MM-yyyy");
                    }
                    if (reader["valortot"].ToString() != null)
                    {
                        c.ValorTot = float.Parse(reader["valortot"].ToString());
                    }                   
                    
                    c.Ativo = reader["ativo"].ToString() != null ? int.Parse(reader["ativo"].ToString()) : c.Ativo;
                    if (c.Ativo == 1)
                    {
                        c.AtivoString = "Ativo";
                        compras.Add(c);
                    }
                                                           
                }
            }
           
            conexao.Close();
            return compras;
        }
                
    }
}
