using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Api.Contratos.Usuario;
using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Damain.Repository.Interfaces;
using AgendaTelefonica.Api.Damain.Services.Interface;
using AgendaTelefonica.Api.Exception;
using AgendaTelefonica.Api.Libs;
using AutoMapper;

namespace AgendaTelefonica.Api.Damain.Services.Classe
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            TokenService tokenService
            )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UsuarioResponseContrato> Adicionar(
            UsuarioRequestContrato entidade,
            long idUsuario
             )
        {
            var usuario = _mapper.Map<Usuario>(entidade);

            usuario.Senha = GeraHashSenha(usuario.Senha);

            Usuario usuarioMod = new Usuario(
                entidade.Email
            );

            ValidacaoUser.Validation(usuarioMod);

            usuario = await _usuarioRepository.Adicionar(usuario);

            return _mapper.Map<UsuarioResponseContrato>(usuario);
        }

        private string GeraHashSenha(string senha)
        {
            string hashSenha;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
                byte[] bytesHashSenha = sha256.ComputeHash(bytesSenha);
                hashSenha = BitConverter.ToString(bytesHashSenha).Replace("-", "").Replace("-", "").ToLower();
            }
            return hashSenha;
        }

        public async Task<UsuarioResponseContrato> Atualizar(
            long id,
            UsuarioRequestContrato entidade,
            long idUsuario
            )
        {
            _ = await Obter(id) ?? throw new NotFoundException("Usuario nao encontrado");

            var usuario = _mapper.Map<Usuario>(entidade);
            usuario.Id = id;
            usuario.Senha = GeraHashSenha(entidade.Senha);



            usuario = await _usuarioRepository.Atualizar(usuario);

            return _mapper.Map<UsuarioResponseContrato>(usuario);
        }

        public async Task<UsuarioLoginResponseContrato> Autenticar(
            UsuarioLoginRequestContrato usuarioLoginRequestContrato
            )
        {
            UsuarioResponseContrato usuario = await ObterPorEmail(usuarioLoginRequestContrato.Email);

            var hashSenha = GeraHashSenha(usuarioLoginRequestContrato.Senha);

            if (usuario is null || usuario.Senha != hashSenha)
            {
                throw new AuthenticationException("Usuário ou senha inválida.");
            }
            return new UsuarioLoginResponseContrato
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Token = _tokenService.GerarToken(_mapper.Map<Usuario>(usuario))
            };
        }

        public async Task Deletar(long id, long idUsuario)
        {
            var usuario = await _usuarioRepository.ObterPorId(id)
            ?? throw new NotFoundException("Usuario nao encontrado.");

            await _usuarioRepository.Deletar(_mapper.Map<Usuario>(usuario));
        }

        public async Task<IEnumerable<UsuarioResponseContrato>> Obter(long idUsuario)
        {
            var usuarios = await _usuarioRepository.Obter();
            return usuarios.Select(usuario => _mapper.Map<UsuarioResponseContrato>(usuario));
        }

        public async Task<UsuarioResponseContrato> ObterPorId(long id, long idUsuario)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);
            return _mapper.Map<UsuarioResponseContrato>(usuario);
        }

        public async Task<UsuarioResponseContrato> ObterPorEmail(string email)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(email);
            return _mapper.Map<UsuarioResponseContrato>(usuario);
        }
    }
}