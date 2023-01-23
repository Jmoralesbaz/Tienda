using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Bussiness
{
    public class BUserAccount : Base, IAcciones
    {
        public BUserAccount(ExamenContext context) : base(context)
        {
        }

        public Respuesta<bool> CierraSesion(Usuario usuario)
        {
            var r = new Respuesta<bool>() { Codigo = 200, Datos = true };
            var usuarioBd = examenContext.AccountClient.Where(w => w.Usuario == usuario.User).FirstOrDefault();
            if (usuarioBd != null)
            {
                var updateUser = examenContext.Sesiones.Where(w => w.Sesion == usuario.Pwd && w.Usuario == usuarioBd.Id && (w.Activa ?? false)).FirstOrDefault();
                if ( updateUser is null)
                {
                    r.Codigo = 404;
                    r.DescripcionError = "La sesion no es valida, verificalo";
                    r.Datos = true;
                }
                else {

                    updateUser.Activa = false;
                    examenContext.Sesiones.Update(updateUser);
                    if (examenContext.SaveChanges() == 0){
                        r.Codigo = 404;
                        r.DescripcionError = "No se pudo cerrar la sesion, intentalo mas tarde";
                    }
                }
            }
            else
            {
                r.Codigo = 400;
                r.DescripcionError = "El usuario no es valido";
            }
            return r;
        }
        public Respuesta<bool> SesionActiva(Usuario usuario) {
            var r = new Respuesta<bool>() { Codigo = 200, Datos=true };
            var usuarioBd = examenContext.AccountClient.Where(w => w.Usuario == usuario.User).FirstOrDefault();
            if (usuarioBd != null){
                if (examenContext.Sesiones.Where(w => w.Sesion == usuario.Pwd && w.Usuario == usuarioBd.Id && (w.Activa ?? false)).FirstOrDefault() is null) {
                    r.Codigo = 404;
                    r.DescripcionError = "La sesion no es valida, verificalo";
                    r.Datos = true;
                }
            }
            else {
                r.Codigo = 400;
                r.DescripcionError = "El usuario no es valido";
            }            
            return r;
        }
        public Respuesta<string> Autentica(Usuario usuario) {
            var r = new Respuesta<string>() { Codigo = 200 };
            var usuarioBd = examenContext.AccountClient.Where(w => w.Usuario == usuario.User && w.Clave == usuario.Pwd).FirstOrDefault();
            if ( usuarioBd != null)
            {

                if (examenContext.Sesiones.Where(w => w.Usuario == usuarioBd.Id).FirstOrDefault() is null)
                {
                    string key = Guid.NewGuid().ToString();
                    examenContext.Sesiones.Add(new Sesiones { Activa=true, Sesion=key, Usuario=usuarioBd.Id });
                    if (examenContext.SaveChanges() > 0)
                    {
                        r.Datos = key;
                    }
                    else {
                        r.Codigo = 404;
                        r.DescripcionError = "No se pudo crear la sesion por el momento, intentalo m as tarde";
                    }
                }
                else {
                    r.Codigo = 400;
                    r.DescripcionError = "Usuario cuenta con una sesion activa";
                }
            }
            else {
                r.Codigo = 401;
                r.DescripcionError = "Usuario o contraseña no validos";
            }
            return r;
        }

        public Respuesta<TSalida> ListarId<TSalida, TEntrada>(TEntrada id)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSalida> ListarTodo<TSalida>()
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSalida> Crear<TSalida, TEntidad>(TEntidad entidad)
        {
            throw new NotImplementedException();
        }

        public Respuesta<TSalida> Actualizar<TSalida, TEntidad>(TEntidad entidad)
        {
            throw new NotImplementedException();
        }
    }
}
