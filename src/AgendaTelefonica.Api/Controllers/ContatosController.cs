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
    [Route("contatos")]
    public class ContatosController : BaseController
    {
        private readonly IService<ContatosRequestContratos, ContatosResponseContratos, long> _contatosService;
        public ContatosController(
            IService<ContatosRequestContratos, ContatosResponseContratos, long> contatosService)
        {
            _contatosService = contatosService;
        }

        /// <summary>
        /// cria um novo usuario dentro do idUsuario logado
        /// </summary>
        /// <param name="contrato"></param>
        /// <returns></returns>
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

        /// <summary>
        /// vai tentar obter todos os contato vinculado ao idUsuario caso esteja logado
        /// </summary>
        /// <returns>vai retorna todos os contatos vinculado ao idUsuario logado</returns>
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

        /// <summary>
        /// vai tentar obter o contato pelo id que estar vinculado ao idUsuario logado
        /// </summary>
        /// <param name="id">id que sera atualizado</param>
        /// <returns>vai retorna o contatos que foi cadastrado com aquele id dentro do idUsuario logado</returns>
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

        /// <summary>
        /// vai atualizar o id que estja vinculado ao idUsuario logado
        /// </summary>
        /// <param name="id">id que vai ser atualizado</param>
        /// <param name="contrato">os dados que irao ser atualizado</param>
        /// <returns>retornar um contato atualizado caso esteja logado</returns>
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

        /// <summary>
        /// vai deletar o id cadastrado dentro do idUsuario logado
        /// </summary>
        /// <param name="id">id do contato a ser deletado</param>
        /// <returns>vai retorna que foi bem sucedido mas nao ha nada para amostrar </returns><summary>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>vai retorna que foi bem sucedido mas nao ha nada para amostrar</returns> <summary>
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