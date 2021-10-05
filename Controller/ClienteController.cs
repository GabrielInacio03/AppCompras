using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ClienteController
    {
        private bool Validar(Cliente c)
        {
            return !string.IsNullOrEmpty(c.Nome);
        }
        public void Salvar(Cliente c)
        {
            try
            {
                if (!Validar(c))
                {
                    throw new Exception("Não foi possível enviar as informações");
                }
              
                ClienteDao cdao = new ClienteDao();
                cdao.Insert(c);
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void BuscarTodos(Cliente c)
        {
            try
            {
                ClienteDao cdao = new ClienteDao();
                cdao.Read(c);
            }
            catch (Exception)
            {

                throw;
            }            
        }
            
    }
}
