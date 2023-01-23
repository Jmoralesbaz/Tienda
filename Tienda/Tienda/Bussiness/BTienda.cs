using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public class BTienda : Base, IAcciones
    {
        public BTienda(ExamenContext context) : base(context)
        {
        }

        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad)
        {
            Respuesta<TSalida> respuesta = new Respuesta<TSalida>() { Codigo = 204 };
            var entidad2 = (TiendaDetalle)(object)(entidad);
            if (examenContext.Tiendas.Where(w => w.Id != entidad2.Id && w.Sucursal.Trim() == entidad2.Sucursal.Trim()).FirstOrDefault() is null)
            {
                try
                {
                    examenContext.Tiendas.Update(new Tiendas { Direccion=entidad2.Direccion, Sucursal=entidad2.Sucursal, Id=entidad2.Id });
                    var i = examenContext.SaveChanges();
                    if (i > 0)
                    {
                        respuesta.Datos = (TSalida)(object)i;
                    }
                    else
                    {
                        respuesta.Codigo = 404;
                        respuesta.DescripcionError = "No se pudo guardar la informacion, intentalo mas tarde";
                    }
                }
                catch (Exception ex)
                {

                    respuesta.Codigo = 500;
                    respuesta.DescripcionError = "Error interno, intentalo mas tarde";
                }
            }
            else
            {
                respuesta.Codigo = 400;
                respuesta.DescripcionError = "La tienda ya existe, verificalo";
            }
           return respuesta;
        }

        public Respuesta<TSalida> Crear<TSalida, TEntidad>(TEntidad entidad)
        {
            Respuesta<TSalida> respuesta = new Respuesta<TSalida>() { Codigo = 201 };
            var entidad2 = (TiendaView)(object)(entidad);
            if (examenContext.Tiendas.Where(w => w.Sucursal.Trim() == entidad2.Sucursal.Trim()).FirstOrDefault() is null)
            {
                try
                {
                    var cl = new Tiendas { Sucursal = entidad2.Sucursal, Direccion = entidad2.Direccion };
                    examenContext.Tiendas.Add(cl);
                    var i = examenContext.SaveChanges();
                    if (i > 0)
                    {
                        respuesta.Datos = (TSalida)(object)cl.Id;
                    }
                    else
                    {
                        respuesta.Codigo = 404;
                        respuesta.DescripcionError = "No se pudo guardar la informacion, intentalo mas tarde";
                    }
                }
                catch (Exception ex)
                {

                    respuesta.Codigo = 500;
                    respuesta.DescripcionError = "Error interno, intentalo mas tarde";
                }
            }
            else
            {
                respuesta.Codigo = 400;
                respuesta.DescripcionError = "La tienda ya existe, verificalo";
            }

            return respuesta;
        }

        public Respuesta<TSalida> ListarId<TSalida, TEntrada>(TEntrada id)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSalida> ListarTodo<TSalida>()
        {
            var r = new Respuesta<TSalida>{ Codigo = 200 };
            try
            {
                r.Datos = (TSalida)(object)examenContext.Tiendas.ToList().Select(s => new TiendaDetalle { Direccion = s.Direccion, Id = s.Id, Sucursal = s.Sucursal }).ToList();
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

