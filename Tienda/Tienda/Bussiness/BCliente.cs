using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public class BCliente: Base, IAcciones
    {
        public BCliente(ExamenContext context) : base(context)
        {
        }

        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad)
        {
            Respuesta<TSalida> respuesta = new Respuesta<TSalida>() { Codigo = 204 };
            var clientes = (ClienteDetalle)(object)(entidad);
            if (examenContext.Clientes.Where(w => w.Id != clientes.Id && w.Nombre.Trim() == clientes.Nombre.Trim() && w.Apellidos.Trim() == clientes.Apellidos.Trim()).FirstOrDefault() is null)
            {
                try
                {
                    examenContext.Clientes.Update(new Clientes { Id=clientes.Id, Apellidos=clientes.Apellidos, Direccion=clientes.Direccion, Nombre=clientes.Nombre });
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
                respuesta.DescripcionError = "El cleinte ya existe, verificalo";
            }
            return respuesta;
        }

        public Respuesta<TSalida> Crear<TSalida, TEntidad>(TEntidad entidad)
        {
            Respuesta<TSalida> respuesta = new Respuesta<TSalida>() { Codigo = 201};
            var cliente = (Cliente)(object)(entidad);
            if (examenContext.Clientes.Where(w => w.Nombre.Trim() == cliente.Nombre.Trim() && w.Apellidos.ToLower() == cliente.Apellidos.ToString()).FirstOrDefault() is null)
            {
                try
                {
                    var cl = new Clientes { Apellidos = cliente.Apellidos, Direccion = cliente.Direccion, Nombre = cliente.Nombre };
                    examenContext.Clientes.Add(cl);
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
                respuesta.DescripcionError = "El cleinte ya existe, verificalo";
            }

            return respuesta;
        }

        public Respuesta<TSalida> ListarId<TSalida, TEntrada>(TEntrada id)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSalida> ListarTodo<TSalida>()
        {
            var r = new Respuesta<TSalida> { Codigo = 200 };
            try
            {
                r.Datos = (TSalida)(object)examenContext.Clientes.ToList().Select(s=>new ClienteDetalle { Apellidos = s.Apellidos, Direccion=s.Direccion, Id=s.Id, Nombre=s.Nombre }).ToList();
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
