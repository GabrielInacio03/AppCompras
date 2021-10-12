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
        protected List<Model.Compra> ListaDeCompras()
        {
            try
            {
                List<Model.Compra> lCompra = new List<Model.Compra>();

                foreach (RepeaterItem item in RepeaterCentral.Items)
                {
                    Model.Compra c = new Model.Compra();

                    c.Id = int.Parse(((Label)item.FindControl("lbCodigo")).Text);
                    c.CodCliente = int.Parse(((Label)item.FindControl("lbCodigoCliente")).Text);
                    c.Data = ((Label)item.FindControl("lbData")).Text;
                    c.ValorTot = float.Parse(((Label)item.FindControl("lbValor")).Text);
                    lCompra.Add(c);
                  
                }
                return lCompra;
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
                    //Label labelCodigo = (Label)item.FindControl("lbCodigo");
                    //i.Id = int.Parse(labelCodigo.Text);

                    i.GuidCod = Guid.Parse(((Label)item.FindControl("lbCodigo")).Text);                    
                    i.CodProduto = int.Parse(((Label)item.FindControl("lbCodProduto")).Text);
                    i.NomeProd = ((Label)item.FindControl("lbDescricao")).Text;
                    i.ValorProd = float.Parse(((Label)item.FindControl("lbValor")).Text);
                    i.Qtd = int.Parse(((Label)item.FindControl("lbQtd")).Text);
                    i.SubTotal = float.Parse(((Label)item.FindControl("lbSubTotal")).Text);                   
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
                Model.Compra compra = new Model.Compra();

                Model.Produto produto = new Model.Produto();
                Guid g = Guid.NewGuid();

                item.GuidCod = g;
                item.CodProduto = int.Parse(ddlproduto.SelectedValue);                
                item.NomeProd = ddlproduto.SelectedItem.Text;
                item.ValorProd = BuscarValor(item.CodProduto);
                item.Qtd = int.Parse(qtds.Text);
                item.SubTotal = item.ValorProd * item.Qtd;
                compra.ValorTot = itens.Sum(x => x.SubTotal + compra.ValorTot);
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
                ItemCompra itensCompras = new ItemCompra();
                compra.CodCliente = int.Parse(ddlcliente.SelectedValue);             
                compra.Data = DateTime.Now.ToString("dd-MM-yyyy");

                List<ItemCompra> itens = ListaItens();
                List<Model.Compra> listaCompras = ListaDeCompras();

                compra.ValorTot = itens.Select(x => x.SubTotal).Sum();

                listaCompras.Add(compra);
                RepeaterCentral.DataSource = listaCompras;
                RepeaterCentral.DataBind();
                //chamando Controller
                CompraController ctrCompra = new CompraController();
                int r = ctrCompra.Salvar(compra);
                           


                itensCompras.CodCompra = r;
                itensCompras.CodProduto = ddlproduto.SelectedIndex;
                itensCompras.Qtd = int.Parse(qtds.Text);
                itensCompras.ValorProd = 7;
                itensCompras.SubTotal = itensCompras.ValorProd * itensCompras.Qtd;

                ItemCompraController ctrItem = new ItemCompraController();
                ctrItem.Salvar(itensCompras);

               
            }
            catch (Exception erro)
            {
                LabelErro.Text = erro.Message;                
            }            
            

        }

       
    }
}