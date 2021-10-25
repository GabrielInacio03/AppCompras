using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CompraController
    {      
        public void Salvar(Model.Compra c)
        {
            try
            {
                CompraDao compraDao = new CompraDao();
                compraDao.Insert(c);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Excluir(int id)
        {
            try
            {
                CompraDao cdao = new CompraDao();
                cdao.Delete(id);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Model.Compra> BuscarTodos()
        {
            try
            {
                
                CompraDao cdao = new CompraDao();                
                List<Compra> compras = new List<Compra>();
                compras = cdao.Read();
                return compras;                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Compra BuscarPorId(int id)
        {
            try
            {
                CompraDao cdao = new CompraDao();
                Compra compra = new Compra();
                compra = BuscarPorId(id);
                return compra;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Model.ItemCompra> BuscarTodosItensId(int id)
        {
            try
            {
                CompraDao cdao = new CompraDao();
                List <Model.ItemCompra> itens = new List<Model.ItemCompra>();
                itens = cdao.BuscarTodosItensId(id);
                return itens;
            }
            catch (Exception)
            {

                throw;
            }
        }      
        public void ExcluirItemDaCompra(int id)
        {
            try
            {
                CompraDao cdao = new CompraDao();
                cdao.DeleteItemDaCompra(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateCompra(int id,float valor)
        {
            try
            {
                CompraDao cdao = new CompraDao();
                cdao.Update(id, valor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateCompraItem(Model.ItemCompra item, int id, float valor)
        {
            try
            {
                CompraDao cdao = new CompraDao();
                cdao.UpdateCompraItem(item, id, valor);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
