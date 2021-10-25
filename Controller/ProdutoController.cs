using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProdutoController
    {
        private bool Validar(Produto p)
        {
            //return n1.Nome != null;
            return !string.IsNullOrEmpty(p.Descricao);
        }
        public void Salvar(Produto p)
        {
            try
            {
                if (!Validar(p))
                {
                    throw new Exception("Não foi possível enviar as informações");
                }
                ProdutoDao pdao = new ProdutoDao();
                pdao.Insert(p);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Produto> BuscarTodos()
        {
            try
            {
                ProdutoDao pdao = new ProdutoDao();
                return pdao.Read();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Produto BuscarPorId(int id)
        {
            ProdutoDao pdao = new ProdutoDao();
            return pdao.BuscarPorId(id);            
        }
        public void Excluir(int id)
        {
            try
            {
                ProdutoDao pdao = new ProdutoDao();
                pdao.Delete(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
