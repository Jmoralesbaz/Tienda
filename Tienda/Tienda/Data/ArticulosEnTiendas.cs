using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class ArticulosEnTiendas
    {
        public int Tiendas { get; set; }
        public int Articulo { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulos ArticuloNavigation { get; set; }
        public virtual Tiendas TiendasNavigation { get; set; }
    }
}
