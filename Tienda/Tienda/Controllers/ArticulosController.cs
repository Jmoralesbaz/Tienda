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

    //[EnableCors("AllowOrigin")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensajeError))]
    public class ArticulosController : TiendaBaseController<BArticulo>
    {
        public ArticulosController(ExamenContext context) : base(context)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DetalleArticulo>))]
        public IActionResult ListarTodo()
        {
            return ResponseHttp(Bussiness.ListarTodo<List<DetalleArticulo>>());
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Crear(Articulo cliente)
        {
            return ResponseHttp<int>(Bussiness.Crear<int, Articulo>(cliente));
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(int))]
        public IActionResult Actualizar(DetalleArticulo cliente)
        {
            return ResponseHttp<int>(Bussiness.Actualizar<int, DetalleArticulo>(cliente));
        }
    }
}
