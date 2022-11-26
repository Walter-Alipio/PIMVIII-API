using AutoMapper;
using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{
  public class EnderecoService : IEnderecoService
  {
    private EnderecoDAO _enderecoDAO;
    private IMapper _mapper;

    public EnderecoService(EnderecoDAO enderecoDAO, IMapper mapper = null)
    {
      _enderecoDAO = enderecoDAO;
      _mapper = mapper;
    }

    public ReadEnderecoDto? BuscaPorId(int id)
    {
      Endereco? endereco = _enderecoDAO.BuscaPorId(id);
      if (endereco == null) return null;

      return _mapper.Map<ReadEnderecoDto>(endereco);
    }

    public ReadEnderecoDto? CadastrarEndereco(CreateEnderecoDto enderecoDto)
    {
      Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

      if (String.IsNullOrEmpty(endereco.Logradouro) || String.IsNullOrEmpty(endereco.Bairro) || String.IsNullOrEmpty(endereco.Cidade) || String.IsNullOrEmpty(endereco.Estado))
        return null;
      endereco.Logradouro.ToUpper();
      endereco.Bairro.ToUpper();
      endereco.Cidade.ToUpper();
      endereco.Estado.ToUpper();

      var resultado = _enderecoDAO.Insira(endereco);
      if (!resultado)
        return null;
      var enderecoOk = _enderecoDAO.UltimoInsert();

      return _mapper.Map<ReadEnderecoDto>(enderecoOk);
    }
  }
}