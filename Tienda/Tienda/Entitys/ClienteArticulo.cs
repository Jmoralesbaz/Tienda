using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Entitys
{
    public class ClienteArticulo
    {
        public int Cliente { get; set; }
        public List<int> Articulos { get; set; }
    }
}
