using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Bussiness;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[EnableCors("AllowOrigin")]
    public class TiendaBaseController<TBussiness>  : ControllerBase where TBussiness : IAcciones
    {
        protected ExamenContext Context;
        protected TBussiness Bussiness;
        public TiendaBaseController(ExamenContext context)
        {
            Context = context;
            Bussiness  = (TBussiness)Activator.CreateInstance(typeof(TBussiness),context);
        }
        protected IActionResult ResponseHttp<TRespuesta>(Respuesta<TRespuesta> respuestaGeneral)
        {
            IActionResult result;
            switch (respuestaGeneral.Codigo)
            {
                case 200:
                    result = Ok((object)respuestaGeneral.Datos);
                    break;
                case 201:
                    result = StatusCode(201);
                    break;
                case 204:
                    result = NoContent();
                    break;
                default:
                    result = StatusCode(respuestaGeneral.Codigo, new MensajeError { Id = respuestaGeneral.Codigo, Mensaje = respuestaGeneral.DescripcionError });
                    break;
            }
            return result;
        }
    }
}
