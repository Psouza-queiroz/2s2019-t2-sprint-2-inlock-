using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class Desafios1Controller : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();

        [HttpGet]
        public IActionResult ListarEstudioUsuario()
        {
            return Ok(EstudioRepository.ListarEstudioUsuario());
        }
    }
}