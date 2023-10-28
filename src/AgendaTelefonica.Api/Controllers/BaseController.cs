using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Api.Contratos.Contatos
{
    /// <summary>
    /// vai ser usada para tratamento de erro na controller usuario e contatos
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        protected long ObterIdUsuarioLogado()
        {
            var id = HttpContext.User.FindFirst("id")?.Value;


            long.TryParse(id, out long idUsuario);
            return idUsuario;

        }

        protected ModelErroContrato RetornarModBadRequest(System.Exception ex)
        {
            return new ModelErroContrato
            {
                StatusCode = 400,
                TituloErro = "Bad request",
                MensageErro = ex.Message
            };
        }
        protected ModelErroContrato RetornaModelNotFound(System.Exception ex)
        {
            return new ModelErroContrato
            {
                StatusCode = 404,
                TituloErro = "NotFound",
                MensageErro = ex.Message
            };
        }
        protected ModelErroContrato RetornaModelUnauthorized(System.Exception ex)
        {
            return new ModelErroContrato
            {
                StatusCode = 401,
                TituloErro = "Unauthorized",
                MensageErro = ex.Message
            };
        }

    }
}