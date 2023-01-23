using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class Tiendas
    {
        public Tiendas()
        {
            ArticulosEnTiendas = new HashSet<ArticulosEnTiendas>();
        }

        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<ArticulosEnTiendas> ArticulosEnTiendas { get; set; }
    }
}
