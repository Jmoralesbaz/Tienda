using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class Articulos
    {
        public Articulos()
        {
            ArticulosEnTiendas = new HashSet<ArticulosEnTiendas>();
            ClienteConArticulos = new HashSet<ClienteConArticulos>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string Imagen { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<ArticulosEnTiendas> ArticulosEnTiendas { get; set; }
        public virtual ICollection<ClienteConArticulos> ClienteConArticulos { get; set; }
    }
}
