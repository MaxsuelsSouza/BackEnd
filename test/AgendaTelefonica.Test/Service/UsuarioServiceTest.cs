using AgendaTelefonica.Api.Damain.Repository.Classes;
using AgendaTelefonica.Api.Damain.Services.Classe;
using AutoMapper;
using Moq;
using Xunit;

namespace AgendaTelefonica.Test.Service
{
    public class UsuarioServiceTest
    {
        private readonly Mock<TokenService> _tokenService = new Mock<TokenService>();
        private readonly Mock<UsuarioRepository> _userRepository = new Mock<UsuarioRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

        [Fact]
        public async void DeveCriarUmUsuario()
        {
            // // Arrange
            // var usuarioRequest = new UsuarioRequestContrato
            // { Email = "maxsuel@gmail.com", Senha = "123" };

            // var idUsuario = 1;

            // var Service = new UsuarioService(
            //     _userRepository.Object,
            //     _mapper.Object,
            //     _tokenService.Object
            //     );

            // // Act
            // var response = await Service.Adicionar(usuarioRequest, idUsuario);

            // // Assert
            // Assert.Equal(expected: idUsuario, response.Id);
        }

        [Fact]
        public async void DeveRetornarUsuarioAtualizado()
        {
            //     // Arrange
            //     long id = 1;
            //     var usuarioRequest = new UsuarioRequestContrato
            //     { Email = "maxsuel@gmail.com", Senha = "123" };

            //     long idUsuario = 1;

            //     var usuarioRetornado = new UsuarioResponseContrato
            //     { Id = id, Email = "maxsuel@gmail.com", Senha = "123" };


            //     _userRepository.Setup(repo => repo.Atualizar(id)).ReturnsAsync(usuarioRetornado);

            //     var usuarioService = new UsuarioService(_userRepository.Object, _mapper.Object, _tokenService.Object);

            //     var resultado = await usuarioService.Atualizar(id, usuarioRequest, idUsuario);

            //     // Assert
            //     Assert.NotNull(resultado);
        }

        [Fact]
        public async void DeveObterUmUsuarioAutenticado()
        {
            // // Arrange
            // var usuarioRequest = new UsuarioLoginRequestContrato
            // {
            //     Email = "maxsuel@gmail.com",
            //     Senha = "123" // Senha de exemplo
            // };

            // var usuarioResponse = new UsuarioResponseContrato
            // {
            //     Id = 1,
            //     Email = "maxsuel@gmail.com",
            //     Senha = "16vg4s6v416s8v4s6d184bgh"
            // };


            // _tokenService.Setup(ts => ts.GerarToken(It.IsAny<Usuario>())).Returns("tokenDeExemplo");

            // var usuarioService = new UsuarioService(_userRepository.Object, _mapper.Object, _tokenService.Object);

            // // Act
            // var resultado = await usuarioService.Autenticar(usuarioRequest);

            // // Assert
            // Assert.NotNull(resultado);
            // Assert.Equal(usuarioResponse.Id, resultado.Id);
            // Assert.Equal(usuarioResponse.Email, resultado.Email);

        }
    }
}


