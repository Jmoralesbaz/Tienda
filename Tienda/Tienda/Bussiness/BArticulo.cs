using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public class BArticulo : Base, IAcciones
    {
        public BArticulo(ExamenContext context) : base(context)
        {
        }

        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad)
        {
            var r = new Respuesta<TSalida>() { Codigo = 204 };

            var a = (DetalleArticulo)(object)entidad;
            if (examenContext.Articulos.Where(w => w.Id != a.Id && w.Codigo.Trim() == a.Codigo).FirstOrDefault() is null)
            {
                
                examenContext.Articulos.Update(new Articulos { Codigo=a.Codigo, Descripcion=a.Descripcion,Id=a.Id, Imagen=a.Imagen, Precio=a.Precio, Stock=a.Stock  });
                if (examenContext.SaveChanges() == 0)
                {
                    r.Codigo = 404;
                    r.DescripcionError = "No se pudo actualizar la informacion, intentalo mas tarde";
                }
            }
            else
            {
                r.Codigo = 400;
                r.DescripcionError = "El codigo para el articulo ya existe";
            }
            return r;
        }

        public Respuesta<TSalida> Crear<TSalida, TEntidad>(TEntidad entidad)
        {
            var r = new Respuesta<TSalida>() { Codigo = 201 };

            var a = (Articulo)(object)entidad;
            if (examenContext.Articulos.Where(w => w.Codigo.Trim() == a.Codigo).FirstOrDefault() is null)
            {
                var b = new Articulos { Codigo = a.Codigo, Descripcion = a.Descripcion, Imagen = a.Imagen, Precio = a.Precio, Stock = a.Stock };
                examenContext.Articulos.Add(b);
                if (examenContext.SaveChanges() == 0) {
                    r.Codigo = 404;
                    r.DescripcionError = "No se pudo guardar la informacion, intentalo mas tarde";
                }
            }
            else {
                r.Codigo = 400;
                r.DescripcionError = "El codigo para el articulo ya existe";
            }

            return r;
        }

        public Respuesta<TSalida> ListarId<TSalida, TEntrada>(TEntrada id)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSalida> ListarTodo<TSalida>()
        {
            
            var r = new Respuesta<TSalida>() { Codigo = 200 };

            try
            {
                r.Datos = (TSalida)(object)examenContext.Articulos.ToList().Select(s => new DetalleArticulo { Codigo = s.Codigo, Descripcion = s.Descripcion, Imagen = s.Imagen, Precio = s.Precio, Stock = s.Stock, Id = s.Id }).ToList();
            }
            catch (Exception)
            {

                r.Codigo = 500;
                r.DescripcionError = "Error interno, intentalo mas tarde";
            }
            return r;
        }
    }
}
