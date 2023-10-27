using AgendaTelefonica.Api.Contratos.Contatos;
using AgendaTelefonica.Api.Damain.Models;
using AgendaTelefonica.Api.Damain.Repository.Interfaces;
using AgendaTelefonica.Api.Damain.Services.Interface;
using AgendaTelefonica.Api.Exception;
using AutoMapper;

namespace AgendaTelefonica.Api.Damain.Services.Classe
{
    public class ContatosServices : IService<ContatosRequestContratos, ContatosResponseContratos, long>
    {

        private readonly IContatosRepository _contatosRepository;
        private readonly IMapper _mapper;
        public ContatosServices(
            IContatosRepository contatosRepository,
            IMapper mapper
            )
        {
            _contatosRepository = contatosRepository;
            _mapper = mapper;
        }


        public async Task<ContatosResponseContratos> Adicionar(
            ContatosRequestContratos entidade,
            long idUsuario)
        {
            Contatos contatos = _mapper.Map<Contatos>(entidade);
            contatos.IdUsuario = idUsuario;

            contatos = await _contatosRepository.Adicionar(contatos);

            return _mapper.Map<ContatosResponseContratos>(contatos);
        }

        public async Task<ContatosResponseContratos> Atualizar(
            long id,
            ContatosRequestContratos entidade,
            long idUsuario
            )
        {
            Contatos contatos = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            var atualizar = new Contatos(

                entidade.Numero,
                entidade.Email,
                entidade.Nota,
                entidade.Nome
            );
            contatos.Numero = atualizar.Numero;
            contatos.Email = atualizar.Email;
            contatos.Nota = atualizar.Nota;
            contatos.Nome = atualizar.Nome;

            contatos = await _contatosRepository.Atualizar(contatos);

            return _mapper.Map<ContatosResponseContratos>(contatos);
        }

        public async Task Deletar(long id, long idUsuario)
        {
            Contatos contatos = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);
            await _contatosRepository.Deletar(contatos);
        }

        public async Task<IEnumerable<ContatosResponseContratos>> Obter(long idUsuario)
        {
            var contatos = await _contatosRepository.ObterPorIdUsuario(idUsuario);
            return contatos.Select(contato => _mapper.Map<ContatosResponseContratos>(contato));
        }

        public async Task<ContatosResponseContratos> ObterPorId(long id, long idUsuario)
        {
            Contatos contatos = await ObterPorIdVinculadoAoIdUsuario(id, idUsuario);

            return _mapper.Map<ContatosResponseContratos>(contatos);
        }

        private async Task<Contatos> ObterPorIdVinculadoAoIdUsuario(long id, long idUsuario)
        {
            var contatos = await _contatosRepository.ObterPorId(id);
            if (contatos is null || contatos.IdUsuario != idUsuario)
            {
                throw new NotFoundException($"nao foi encontrado nenhum contato pelo id: {id}");
            }

            return contatos;
        }
    }
}