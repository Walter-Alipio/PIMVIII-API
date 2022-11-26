using AutoMapper;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{
  public class EnderecoService : IEnderecoService
  {
    private IDatabaseObject<Endereco> _enderecoDAO;
    private IMapper _mapper;

    public EnderecoService(IDatabaseObject<Endereco> enderecoDAO, IMapper mapper)
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

      if (String.IsNullOrEmpty(enderecoDto.Logradouro) || String.IsNullOrEmpty(enderecoDto.Bairro) || String.IsNullOrEmpty(enderecoDto.Cidade) || String.IsNullOrEmpty(enderecoDto.Estado))
        return null;
      enderecoDto.Logradouro.ToUpper();
      enderecoDto.Bairro.ToUpper();
      enderecoDto.Cidade.ToUpper();
      enderecoDto.Estado.ToUpper();

      Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

      var resultado = _enderecoDAO.Insira(endereco);
      if (!resultado)
        return null;

      var enderecoOk = _enderecoDAO.UltimoInsert();

      return _mapper.Map<ReadEnderecoDto>(enderecoOk);
    }
  }
}