using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public decimal Importe { get; set; }
        public int TotalArticulos { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual Clientes ClienteNavigation { get; set; }
    }
}
