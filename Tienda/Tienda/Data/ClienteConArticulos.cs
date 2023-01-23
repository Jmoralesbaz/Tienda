using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class ClienteConArticulos
    {
        public int Cliente { get; set; }
        public int Articulo { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulos ArticuloNavigation { get; set; }
        public virtual Clientes ClienteNavigation { get; set; }
    }
}
