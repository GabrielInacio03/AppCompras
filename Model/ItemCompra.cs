﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemCompra
    {
        public int Id { get; set; }
        public int CodCompra { get; set; }
        public int CodProduto { get; set; }
        public int Qtd { get; set; }
        public float SubTotal { get; set; }

        public string nomeProd { get; set; }    
        public float valorProd { get; set; }
       
        
    }
}
