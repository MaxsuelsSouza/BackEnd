using System.Security.Authentication;
using AgendaTelefonica.Api.Contratos;
using AgendaTelefonica.Api.Contratos.Contatos;
using AgendaTelefonica.Api.Damain.Services.Interface;
using AgendaTelefonica.Api.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Api.Controllers
{
    [ApiController]
    [Route("meus contatos")]
    public class ContatosController : BaseController
    {
        private readonly IService<ContatosRequestContratos, ContatosResponseContratos, long> _contatosService;
        public ContatosController(
            IService<ContatosRequestContratos, ContatosResponseContratos, long> contatosService)
        {
            _contatosService = contatosService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Adicionar(
            ContatosRequestContratos contrato
            )
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Created("", await _contatosService.Adicionar(contrato, idUsuario));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(RetornarModBadRequest(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Obter()
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _contatosService.Obter(idUsuario));
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornaModelNotFound(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Obter(long id)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _contatosService.ObterPorId(id, idUsuario));
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornaModelNotFound(ex));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(RetornarModBadRequest(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(
            long id, ContatosRequestContratos contrato
            )
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                return Ok(await _contatosService.Atualizar(id, contrato, idUsuario));
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornaModelNotFound(ex));
            }
            catch (BadRequestException ex)
            {
                return BadRequest(RetornarModBadRequest(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(long id)
        {
            try
            {
                long idUsuario = ObterIdUsuarioLogado();
                await _contatosService.Deletar(id, idUsuario);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(RetornaModelNotFound(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}