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

        }

        protected void adicionar_Click(object sender, EventArgs e)
        {            
            try
            {
                Model.Produto p = new Model.Produto();
                p.Descricao = descricao.Text;
                p.Valor = float.Parse(valor.Text);

                ProdutoController ctr = new ProdutoController();
                ctr.Salvar(p);
            }
            catch (Exception erro)
            {

                LabelErro.Text = erro.Message;
            }

        }
    }
}