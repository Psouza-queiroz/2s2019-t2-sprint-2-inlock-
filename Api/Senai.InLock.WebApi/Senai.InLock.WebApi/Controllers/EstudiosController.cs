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
    public class EstudiosController : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();

        [HttpGet]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Listar()
        {
            return Ok(EstudioRepository.Listar());
        }


        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Tá errado aí hein: " + ex.Message });
            }
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult BuscarPorid(int id)
        {
            Estudios Estudio = EstudioRepository.BuscarPorId(id);
            if (Estudio == null)
                return NotFound();
            return Ok(Estudio);
        }


        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Atualizar(Estudios estudio)
        {
            try
            {
                Estudios EventosBuscados = EstudioRepository.BuscarPorId(estudio.EstudioId);
                if (EventosBuscados == null)
                    return NotFound();
                EstudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Erro ao Atualizar" });
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Deletar(int id)
        {
            EstudioRepository.Deletar(id);
            return Ok();
        }

    }
}