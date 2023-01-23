using System;
using System.Collections.Generic;

namespace Tienda.Data
{
    public partial class Sesiones
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string Sesion { get; set; }
        public bool? Activa { get; set; }

        public virtual AccountClient UsuarioNavigation { get; set; }
    }
}
