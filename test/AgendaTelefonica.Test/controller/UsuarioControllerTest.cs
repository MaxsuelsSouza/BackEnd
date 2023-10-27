using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using AgendaTelefonica.Api.Contratos.Usuario;
using AgendaTelefonica.Api.Controllers;
using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Damain.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

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

        [Fact]
        public async void DeveObterTodosUsuariosPorId()
        {
            //Arrange




            //Act


            //Assert

        }

        [Fact]
        public async void DeveAdicionarUsuarios()
        {
            //Arrange


            //Act


            //Assert

        }

    }

    internal class ContatoLoginRequestContrato
    {
        public ContatoLoginRequestContrato()
        {
        }
    }
}