using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    public class ArticulosTiendaController : TiendaBaseController<BArticulosTienda>
    {
        public ArticulosTiendaController(ExamenContext context) : base(context)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<TiendaArticuloDetalles>))]
        public IActionResult Listar(int tienda)
        {
            return ResponseHttp(Bussiness.ListarId<List<TiendaArticuloDetalles>,int>(tienda));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public IActionResult Crear(TiendaArticulo cliente)
        {
            return ResponseHttp<int>(Bussiness.Crear<int, TiendaArticulo>(cliente));
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(int))]
        public IActionResult Actualizar(TiendaArticuloDetalles cliente)
        {
            return ResponseHttp<int>(Bussiness.Actualizar<int, TiendaArticuloDetalles>(cliente));
        }
    }
}
