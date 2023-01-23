using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Entitys
{
    public class ClienteArticuloDetalle
    {
      //  public int Id { get; set; }
        public int Cliente { get; set; }
        public int Articulo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
