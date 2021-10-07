using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Compra
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public float ValorTot { get; set; }
        public int CodCliente { get; set; }

    }
}
