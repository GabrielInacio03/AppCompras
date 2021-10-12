using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ItemCompraController
    {
        public void Salvar(Model.ItemCompra i)
        {
            try
            {
                ItemCompraDao itemDao = new ItemCompraDao();
                itemDao.Insert(i);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
