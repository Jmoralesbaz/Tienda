using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Entitys
{
    public class Respuesta<T>
    {
        public int Codigo { get; set; }
        public bool ExisteError { get; set; }
        public string DescripcionError { get; set; }
        public T Datos { get; set; }
    }
}
