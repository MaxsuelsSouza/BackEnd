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
        /// <summary>
        /// fara a validaçao do campo email e senha, caso verdadeiro devolverar um token 
        /// </summary>
        /// <param name="contrato">o que ele espera receber para logar</param>
        /// <returns>devolverar o email e token caso usuario exista no banco de dados</returns>
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

        /// <summary>
        /// criarar um usuario novo
        /// </summary>
        /// <param name="contrato">o que ele espera receber para poder cadastrar um novo usuario</param>
        /// <returns></returns>
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
        /// <summary>
        /// irar obter todos os usuarios cadastrados
        /// </summary>
        /// <returns>devolverar uma lista de usuarios cadastrados</returns>
        [HttpGet]
        [Authorize]
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

        /// <summary>
        /// irar obter um usuario pelo seu id cadastrado
        /// </summary>
        /// <param name="id">indentificador do usuario</param>
        /// <returns>retornara o usuario pelo id fornecido</returns>
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

        /// <summary>
        /// atualizarar um usuario pelo id fornecido
        /// </summary>
        /// <param name="id">chave identificadora do usuario</param>
        /// <param name="contrato">o que ele espera receber para atualizar o usuario</param>
        /// <returns></returns>
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

        /// <summary>
        /// irar deletar o usuario pelo id fornecido 
        /// </summary>
        /// <param name="id">o que irar dizer qual usuario deverar ser deletado</param>
        /// <returns>retorna que foi bem sucedido mas nao tem nada para amostrar</returns>
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