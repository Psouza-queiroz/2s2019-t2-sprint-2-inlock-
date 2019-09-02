using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository JogoRepository = new JogoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(JogoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogos jogos)
        {
            try
            {
                JogoRepository.Cadastrar(jogos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest( new { mensagem = "Erro ao Cadastrar!" + ex.Message });
            }
        }
    }
}