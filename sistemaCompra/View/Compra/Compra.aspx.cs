using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaCompra.View.Compra
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                List<Model.Produto> produtos = new List<Model.Produto>();
                List<Model.Cliente> clientes = new List<Model.Cliente>();

                ProdutoController pController = new ProdutoController();
                ClienteController cController = new ClienteController();

                produtos = pController.BuscarTodos();
                clientes = cController.BuscarTodos();

                produtos.Insert(0, new Model.Produto() { Id = 0, Descricao = "Selecione um Produto" });
                clientes.Insert(0, new Model.Cliente() { Id = 0, Nome = "Selecione um Cliente"});

                ddlproduto.DataSource = produtos;
                ddlproduto.DataBind();

                ddlcliente.DataSource = clientes;
                ddlcliente.DataBind();

                

            }
           


        }
        protected float BuscarValor(int id)
        {
            try
            {
                Controller.ProdutoController pesquisar = new Controller.ProdutoController();
                Model.Produto produto = new Model.Produto();
                produto = pesquisar.BuscarPorId(id);
                return produto.Valor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected List<ItemCompra> ListaItens()
        {
            try
            {
                List<ItemCompra> listaItens = new List<ItemCompra>();

                foreach (RepeaterItem item in repeaterItens.Items)
                {
                    ItemCompra i = new ItemCompra();
                    Label labelCodigo = (Label)item.FindControl("lbCodigo");
                    i.Id = int.Parse(labelCodigo.Text);

                    i.CodProduto = int.Parse(((Label)item.FindControl("lbCodProduto")).Text);
                    i.nomeProd = ((Label)item.FindControl("lbDescricao")).Text;

                    listaItens.Add(i);
                }
                return listaItens;
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Enviar_Click(object sender, EventArgs e)
        {
            try
            {
              
                List<ItemCompra> itens = ListaItens();
                ItemCompra item = new ItemCompra();
                Model.Produto produto = new Model.Produto();
                

                item.CodProduto = int.Parse(ddlproduto.SelectedValue);                
                item.nomeProd = ddlproduto.SelectedItem.Text;
                item.valorProd = BuscarValor(item.CodProduto);
                item.Qtd = int.Parse(qtds.Text);                                
                itens.Add(item);                               
               
                repeaterItens.DataSource = itens;                
                repeaterItens.DataBind();               

            }
            catch (Exception erro)
            {

                LabelErro.Text = erro.Message;
            }
        }        
        protected void finalizar_click(object sender, EventArgs e)
        {
            try
            {
                Model.Compra compra = new Model.Compra();
                DateTime diAtual = DateTime.Today;
                compra.Data = diAtual.ToString();
                compra.CodCliente = int.Parse(ddlcliente.SelectedValue);
                //compra.ValorTot = float.Parse(dllproduto.SelectedValue);
                
            }
            catch (Exception erro)
            {
                LabelErro.Text = erro.Message;                
            }            
            

        }
    }
}