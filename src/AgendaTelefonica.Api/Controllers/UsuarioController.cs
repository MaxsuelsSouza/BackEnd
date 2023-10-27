using System.Security.Authentication;
using AgendaTelefonica.Api.Contratos.Contatos;
using AgendaTelefonica.Api.Contratos.Usuario;
using AgendaTelefonica.Api.Damain.Services.Interface;
using AgendaTelefonica.Api.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar(
            UsuarioRequestContrato contrato
            )
        {
            try
            {
                return Ok(await _usuarioService.Autenticar(contrato));
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(RetornaModelUnauthorized(ex));
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Adicionar(
            UsuarioRequestContrato contrato
            )
        {
            try
            {
                return Created("", await _usuarioService.Adicionar(contrato, 0));
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Obter()
        {
            try
            {
                return Ok(await _usuarioService.Obter(0));
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
                return Ok(await _usuarioService.ObterPorId(id, 0));
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

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(
            long id, UsuarioRequestContrato contrato
            )
        {
            try
            {
                return Ok(await _usuarioService.Atualizar(id, contrato, 0));
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
                await _usuarioService.Deletar(id, 0);
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