using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace sistemaCompra.View.Cliente
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Cliente n1 = new Model.Cliente();
                n1.Nome = campoTexto1.Text;
                n1.Endereco = campoTexto2.Text;
                n1.DataNasc = campoTexto3.Text;

                ClienteController ctr = new ClienteController();
                ctr.Salvar(n1);
            }
            catch (Exception erro)
            {
                LabelErro.Text = erro.Message;                
            }

        }
    }
}