using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class AccountClient
    {
        public AccountClient()
        {
            Sesiones = new HashSet<Sesiones>();
        }

        public int Id { get; set; }
        public int Cliente { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public bool? Activo { get; set; }

        public virtual Clientes ClienteNavigation { get; set; }
        public virtual ICollection<Sesiones> Sesiones { get; set; }
    }
}
