using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class Clientes
    {
        public Clientes()
        {
            ClienteConArticulos = new HashSet<ClienteConArticulos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        public virtual AccountClient AccountClient { get; set; }
        public virtual Ventas Ventas { get; set; }
        public virtual ICollection<ClienteConArticulos> ClienteConArticulos { get; set; }
    }
}
