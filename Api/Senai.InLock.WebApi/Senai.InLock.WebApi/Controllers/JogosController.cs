using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Listar()
        {
            return Ok(JogoRepository.Listar());
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
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

        [HttpGet("{Id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult BucarPorId(int id )
        {
            Jogos Jogos = JogoRepository.BuscarPorId(id);
            if (Jogos == null)
                return NotFound();
            return Ok(Jogos);
        }

        [HttpPut("{Id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Atualizar(int id, Jogos jogos)
        {
            Jogos AtualizarJogo = JogoRepository.BuscarPorId(id);
                if(AtualizarJogo == null)
            {
                return NotFound();
            }
            jogos.JogoId = id;
            JogoRepository.Atualizar(jogos);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Deletar(int id)
        {
            JogoRepository.Deletar(id);
            return Ok();
        }
    }
}