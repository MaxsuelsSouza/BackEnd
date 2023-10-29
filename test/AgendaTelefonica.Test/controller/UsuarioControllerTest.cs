using AgendaTelefonica.Api.Controllers;
using AgendaTelefonica.Api.Damain.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AgendaTelefonica.Test.controller
{
    public class UsuarioControllerTest
    {
        private readonly Mock<IUsuarioService> _serviceUsuario = new Mock<IUsuarioService>();

        [Fact]
        public async void DeveObterTodosUsuarios()
        {
            //Arrange
            var usuariosController = new UsuarioController(
                _serviceUsuario.Object);

            //Act
            var resultadoController = await usuariosController.Obter();

            //Assert
            Assert.IsType<OkObjectResult>(resultadoController);
        }
        //UNICO TESTE QUE SOUBE FAZER, OS OUTROS FALHARAM OU NEM FUCIONARAM
    }
}