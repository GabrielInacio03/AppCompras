using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaCompra.View.Compra
{
    public partial class CompraView : System.Web.UI.Page
    {
        public static class Global
        {
            public static int codigoCompra;            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Model.Compra> compras = new List<Model.Compra>();
                Model.Compra c = new Model.Compra();
                CompraController cController = new CompraController();
                c.NomeCliente = BuscarPorCliente(c.CodCliente);

                compras = cController.BuscarTodos();

                RepeaterCompras.DataSource = compras;
                RepeaterCompras.DataBind();



            }
        }
        protected string BuscarPorCliente(int id)
        {
            try
            {
                Controller.ClienteController pesquisar = new Controller.ClienteController();
                Model.Cliente cliente = new Model.Cliente();
                cliente = pesquisar.BuscarPorId(id);
                return cliente.Nome;
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected List<Model.ItemCompra> BuscarItensCompra(int id)
        {
            try
            {
                CompraController pesquisar = new CompraController();
                List<Model.ItemCompra> itens = new List<Model.ItemCompra>();
                itens = pesquisar.BuscarTodosItensId(id);            
                      
                return itens;
            }
            catch (Exception)
            {

                throw;
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

        protected void RepeaterCompras_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                Model.Compra c = new Model.Compra();
                Model.ItemCompra i = new Model.ItemCompra();
                List<Model.Compra> compras = new List<Model.Compra>();
                CompraController cController = new CompraController();
                DropDownList drop = (DropDownList)e.Item.FindControl("ddlproduto");
                TextBox valor = (TextBox)e.Item.FindControl("qtds");
                Repeater r = (Repeater)e.Item.FindControl("RepeaterListaItens");
                Repeater rc = (Repeater)e.Item.FindControl("RepeaterCompras");

                if (e.CommandName.ToString() == "Excluir")
                {
                    string codigoComp = e.CommandArgument.ToString();
                   

                    c = compras.Where(x => x.Id == int.Parse(codigoComp)).FirstOrDefault();
                    cController.Excluir(int.Parse(codigoComp));
                    compras.Remove(c);

                    RepeaterCompras.DataSource = compras;
                    RepeaterCompras.DataBind();
                }
                else if(e.CommandName.ToString() == "Editar")
                {
                    string codigoItem = e.CommandArgument.ToString();
                    //Repeater r = (Repeater)e.Item.FindControl("RepeaterListaItens");
                    List<Model.ItemCompra> listaItem = BuscarItensCompra(int.Parse(codigoItem));
                    Model.Compra compra = new Model.Compra();
                    CompraController compraItem = new CompraController();


                    float valorTotalNovo = listaItem.Sum(x => x.SubTotal + compra.ValorTot);
                    compraItem.UpdateCompra(int.Parse(codigoItem), valorTotalNovo);

                    if (i.Ativo == 0)
                    {                        
                        
                        compraItem.UpdateCompraItem(i, int.Parse(codigoItem), valorTotalNovo);                        
                    }


                }
                else
                {
                    string codigoItem = e.CommandArgument.ToString();
                    List<Model.ItemCompra> itemListaCompra = BuscarItensCompra(int.Parse(codigoItem));
                    

                    Guid g = Guid.NewGuid();
                    i.CodCompra = int.Parse(codigoItem);
                    i.GuidCod = g;
                    i.CodProduto = int.Parse(drop.Text);
                    i.Qtd = int.Parse(valor.Text);                   

                    float valorProduto = BuscarValor(i.CodProduto);

                    i.SubTotal = valorProduto * i.Qtd;
                   

                    itemListaCompra.Add(i);
                    r.DataSource = itemListaCompra;
                    r.DataBind();




                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
         CRIAR FUNÇÃO QUE TENHA COMO RETORNO UMA LISTA DOS ITENS ADICIONADOS NA COMPRA
         
         */
        
        protected void RepeaterCompras_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                List<Model.Produto> produtos = new List<Model.Produto>();
                ProdutoController pController = new ProdutoController();
                produtos = pController.BuscarTodos();


                Repeater r = (Repeater)e.Item.FindControl("RepeaterListaItens");
                Repeater rc = (Repeater)e.Item.FindControl("RepeaterCompras");
                DropDownList drop = (DropDownList)e.Item.FindControl("ddlproduto");
                //Model.Compra compra = new Model.Compra();
                Model.Compra compra = new Model.Compra();
                List<Model.Compra> compras = new List<Model.Compra>();
                compra.Id = int.Parse(((Label)e.Item.FindControl("lbcodigo")).Text);


                produtos.Insert(0, new Model.Produto() { Id = 0, Descricao = "Selecione um Produto" });
               
                List<Model.ItemCompra> listaItens = BuscarItensCompra(compra.Id);
              
                r.DataSource = listaItens;
                r.DataBind();

                drop.DataSource = produtos;
                drop.DataBind();

                //------------------------


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void RepeaterListaItens_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string codigoItem = e.CommandArgument.ToString();
                Repeater r = (Repeater)e.Item.FindControl("RepeaterListaItens");
                List<Model.ItemCompra> listaItem = BuscarItensCompra(int.Parse(codigoItem));
                List<Model.ItemCompra> listaItemApagados = new List<Model.ItemCompra>();
                Model.ItemCompra item = new Model.ItemCompra();
                CompraController compraItem = new CompraController();

                item = listaItem.Where(x => x.Id.ToString() == int.Parse(codigoItem).ToString()).FirstOrDefault();
                listaItemApagados.Add(item);
                listaItem.Remove(item);
                compraItem.ExcluirItemDaCompra(int.Parse(codigoItem));
            
         
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}