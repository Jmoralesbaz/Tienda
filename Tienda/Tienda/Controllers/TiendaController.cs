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
    //[EnableCors("AllowOrigin")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensajeError))]
    public class TiendaController : TiendaBaseController<BTienda>
    {
        public TiendaController(ExamenContext context) : base(context)
        {
           
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<TiendaDetalle>))]
        public IActionResult ListarTodo()
        {
            return ResponseHttp(Bussiness.ListarTodo<List<TiendaDetalle>>());
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public IActionResult Crear(TiendaView tienda) {
            return ResponseHttp(Bussiness.Crear<int,TiendaView>(tienda));
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(int))]
        public IActionResult Actualizar(TiendaDetalle tiendas)
        {
            return ResponseHttp(Bussiness.Actualizar<int, TiendaDetalle>(tiendas));
        }
    }
}
