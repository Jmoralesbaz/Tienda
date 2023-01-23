using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public class BArticulosTienda : Base, IAcciones
    {
        public BArticulosTienda(ExamenContext context) : base(context)
        {
        }

        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad)
        {
            var r = new Respuesta<TSalida>() { Codigo = 204 };

            var c = (TiendaArticulo)(object)entidad;
            if (examenContext.Tiendas.Where(w => w.Id == c.Tienda).FirstOrDefault() != null)
            {
                var d = examenContext.ArticulosEnTiendas.Where(w => w.Tiendas == c.Tienda).ToList();
                if (d.Count > 0)
                {
                    examenContext.ArticulosEnTiendas.RemoveRange(d);
                    examenContext.SaveChanges();
                }
                examenContext.ArticulosEnTiendas.AddRange(c.Articulos.Select(s => new ArticulosEnTiendas { Articulo = s, Tiendas = c.Tienda, Fecha = new DateTime() }));
                if (examenContext.SaveChanges() == 0)
                {
                    r.Codigo = 404;
                    r.DescripcionError = "No se pudo crear la informacion, intentalo m as tarde";
                }
            }
            else
            {
                r.Codigo = 404;
                r.DescripcionError = "No existe la tienda, verificalo porfavor";
            }
            return r;
        }

        public Respuesta<TSalida> Crear<TSalida, TEntidad>(TEntidad entidad)
        {
            var r = new Respuesta<TSalida>() { Codigo = 201 };
            var c = (TiendaArticulo)(object)entidad;
            if (examenContext.Tiendas.Where(w => w.Id == c.Tienda).FirstOrDefault() != null)
            {
                examenContext.ArticulosEnTiendas.AddRange(c.Articulos.Select(s => new ArticulosEnTiendas { Articulo = s, Tiendas = c.Tienda, Fecha = new DateTime() }));
                if (examenContext.SaveChanges() == 0)
                {
                    r.Codigo = 404;
                    r.DescripcionError = "No se pudo crear la informacion, intentalo m as tarde";
                }
            }
            else
            {
                r.Codigo = 404;
                r.DescripcionError = "No existe la tienda, verificalo porfavor";
            }
            return r;
        }

        public Respuesta<TSalida> ListarId<TSalida, TEntrada>(TEntrada id)
        {
            var r = new Respuesta<TSalida>() { Codigo = 200 };
            try
            {
                int i = (int)(object)id;
                var datos = examenContext.ArticulosEnTiendas.Where(w => w.Tiendas == i).ToList();
                if (datos.Any())
                {
                    r.Datos = (TSalida)(object)datos.Select(s=>new TiendaArticuloDetalles {  Tienda=s.Tiendas, Articulo=s.Articulo, Fecha=s.Fecha  }).ToList();
                }
                else
                {
                    r.Codigo = 404;
                    r.DescripcionError = "No hay datos asociados al cliente " + id;
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
