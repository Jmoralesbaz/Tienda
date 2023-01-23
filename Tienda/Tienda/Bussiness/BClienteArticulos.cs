using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public class BClienteArticulos : Base, IAcciones
    {
        public BClienteArticulos(ExamenContext context) : base(context)
        {
        }

        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad)
        {
            var r = new Respuesta<TSalida>() { Codigo = 204 };

            var c = (ClienteArticulo)(object)entidad;
            if (examenContext.Clientes.Where(w => w.Id == c.Cliente).FirstOrDefault() != null)
            {
                var d = examenContext.ClienteConArticulos.Where(w => w.Cliente == c.Cliente).ToList();
                if (d.Count>0)
                {
                    examenContext.ClienteConArticulos.RemoveRange(d);
                    examenContext.SaveChanges();
                }
                examenContext.ClienteConArticulos.AddRange(c.Articulos.Select(s => new ClienteConArticulos { Articulo = s, Cliente = c.Cliente, Fecha = new DateTime() }));
                if (examenContext.SaveChanges() == 0)
                {
                    r.Codigo = 404;
                    r.DescripcionError = "No se pudo crear la informacion, intentalo m as tarde";
                }
            }
            else
            {
                r.Codigo = 404;
                r.DescripcionError = "No existe el cleinte, verificalo porfavor";
            }
            return r;
        }

        public Respuesta<TSalida> Crear<TSalida, TEntidad>(TEntidad entidad)
        {
            var r = new Respuesta<TSalida>() { Codigo = 201 };
            var c = (ClienteArticulo)(object)entidad;
            if (examenContext.Clientes.Where(w=>w.Id == c.Cliente).FirstOrDefault() != null) {
                examenContext.ClienteConArticulos.AddRange(c.Articulos.Select(s=>new ClienteConArticulos { Articulo = s, Cliente=c.Cliente, Fecha = new DateTime() }));
                if (examenContext.SaveChanges() == 0) {
                    r.Codigo = 404;
                    r.DescripcionError = "No se pudo crear la informacion, intentalo m as tarde";
                }
            }
            else
            {
                r.Codigo = 404;
                r.DescripcionError = "No existe el cleinte, verificalo porfavor";
            }
            return r;
        }

        public Respuesta<TSalida> ListarId<TSalida, TEntrada>(TEntrada id)
        {
            var r = new Respuesta<TSalida>() { Codigo=200 };
            try
            {
                int i = (int)(object)id;
                var datos = examenContext.ClienteConArticulos.Where(w => w.Cliente == i).ToList();
                if (datos.Any())
                {
                    r.Datos = (TSalida)(object)datos.Select(s=>new ClienteArticuloDetalle { Fecha=s.Fecha, Articulo=s.Articulo, Cliente=s.Cliente }).ToList();
                }
                else {
                    r.Codigo = 404;
                    r.DescripcionError = "No hay datos asociados al cliente "+id;
                }
            }
            catch (Exception)
            {

                r.Codigo = 500;
                r.DescripcionError = "Error interno, intentalo mas tarde";
            }
            return r;
        }

        public Respuesta<TSalida> ListarTodo<TSalida>()
        {
            throw new NotImplementedException();
        }
    }
}
