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
            try
            {
                

                List<Model.Cliente> clientes = new List<Model.Cliente>();
                ClienteController controlador = new ClienteController();
                clientes = controlador.BuscarTodos();

                repeaterList.DataSource = clientes;
                repeaterList.DataBind();
            }
            catch (Exception erro)
            {

                LabelErro.Text = erro.Message;
            }
        }

        protected void enviar_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Cliente n1 = new Model.Cliente();
                n1.Nome = campoTexto1.Text;
                n1.Endereco = campoTexto2.Text;
                n1.DataNasc = campoTexto3.Text;
                n1.Ativo = 1;

                ClienteController ctr = new ClienteController();
                ctr.Salvar(n1);
            }
            catch (Exception erro)
            {
                LabelErro.Text = erro.Message;                
            }

        }       

        protected void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = new Button();
                int id = int.Parse(b.CommandName);

                ClienteController ctr = new ClienteController();
                ctr.Excluir(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void repeaterList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Model.Cliente cliente = new Model.Cliente();
            ClienteController ctr = new ClienteController();

            string id = e.CommandArgument.ToString();

            ctr.Excluir(int.Parse(id));
        }
    }
}