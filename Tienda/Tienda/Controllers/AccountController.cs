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
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MensajeError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensajeError))]
    public class AccountController : TiendaBaseController<BUserAccount>
    {
        BUserAccount BUserAccount;
        public AccountController(ExamenContext context) : base(context)
        {
            BUserAccount = new BUserAccount(context);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Login(Usuario usuario) {
            return ResponseHttp<string>(BUserAccount.Autentica(usuario));
        }

        [HttpPut("LogOut")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public IActionResult EndSesion(Usuario usuario)
        {
            return ResponseHttp<bool>(BUserAccount.CierraSesion(usuario));
        }

        [HttpPost("SesionActiva")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult SesionActiva(Usuario usuario)
        {
            return ResponseHttp<bool>(BUserAccount.SesionActiva(usuario));
        }

    }
}
