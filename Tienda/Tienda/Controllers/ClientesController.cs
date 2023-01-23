using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
    public class ClientesController : TiendaBaseController<BCliente>
    {
        
        public ClientesController(ExamenContext context) : base(context)
        {
            
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<ClienteDetalle>))]
        public IActionResult ListarTodo()
        {
            return ResponseHttp(Bussiness.ListarTodo<List<ClienteDetalle>>());
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        public IActionResult Crear(Cliente cliente)
        {
            return ResponseHttp<int>(Bussiness.Crear<int,Cliente>(cliente));
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(int))]
        public IActionResult Actualizar(ClienteDetalle cliente)
        {
            return ResponseHttp<int>(Bussiness.Actualizar<int, ClienteDetalle>(cliente));
        }
    }
}
