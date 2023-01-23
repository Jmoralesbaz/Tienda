using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public interface IAcciones
    {
        public Respuesta<TSalida> ListarId<TSalida,TEntrada>(TEntrada id);
        public Respuesta<TSalida> ListarTodo<TSalida>();
        public Respuesta<TSalida> Crear<TSalida,TEntidad>(TEntidad entidad);
        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad);        
    }
}
