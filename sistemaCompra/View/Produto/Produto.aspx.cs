using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaCompra.View.Produto
{
    public partial class Produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                List<Model.Produto> produtos = new List<Model.Produto>();
                ProdutoController controlador = new ProdutoController();
                produtos = controlador.BuscarTodos();

                repeaterList.DataSource = produtos;
                repeaterList.DataBind();
            }
            catch (Exception erro)
            {

                LabelErro.Text = erro.Message;
            }
        }

        protected void adicionar_Click(object sender, EventArgs e)
        {            
            try
            {
                Model.Produto p = new Model.Produto();
                p.Descricao = descricao.Text;
                p.Valor = float.Parse(valor.Text);
                p.Ativo = 1;

                ProdutoController ctr = new ProdutoController();
                ctr.Salvar(p);
            }
            catch (Exception erro)
            {

                LabelErro.Text = erro.Message;
            }

        }

        protected void repeaterList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Model.Produto cliente = new Model.Produto();
            ProdutoController ctr = new ProdutoController();

            string id = e.CommandArgument.ToString();

            ctr.Excluir(int.Parse(id));
        }
    }
}