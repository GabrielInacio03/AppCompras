﻿using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CompraController
    {      
        public int Salvar(Model.Compra c)
        {
            try
            {
                CompraDao compraDao = new CompraDao();
                return compraDao.Insert(c);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
