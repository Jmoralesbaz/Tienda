using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Entitys;

namespace Tienda.Controllers
{
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensajeError))]
    public class AccountController : ControllerBase
    {
       
    }
}
