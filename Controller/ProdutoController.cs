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
        private bool Validar(Produto p)
        {
            //return n1.Nome != null;
            return !string.IsNullOrEmpty(p.Descricao);
        }
    }
}
