using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Bussiness;
using Tienda.Data;
using Tienda.Entitys;

namespace Tienda.Controllers
{
//    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensajeError))]
    public class ClienteArticulosController : TiendaBaseController<BClienteArticulos>
    {
        public ClienteArticulosController(ExamenContext context) : base(context)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<ClienteArticuloDetalle>))]
        public IActionResult Listar(int cliente)
        {
            return ResponseHttp(Bussiness.ListarId<List<ClienteArticuloDetalle>, int>(cliente));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public IActionResult Crear(ClienteArticulo cliente)
        {
            return ResponseHttp<int>(Bussiness.Crear<int, ClienteArticulo>(cliente));
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(int))]
        public IActionResult Actualizar(ClienteArticulo cliente)
        {
            return ResponseHttp<int>(Bussiness.Actualizar<int, ClienteArticulo>(cliente));
        }
    }
}
