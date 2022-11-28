using AutoMapper;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;

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
    //Put
    public Result AlteraEndereco(int id, UpdateEnderecoDto enderecoDto)
    {

      Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
      if (endereco == null)
        return Result.Fail("Dados obrigatórios");

      endereco.Logradouro!.ToUpper();
      endereco.Bairro!.ToUpper();
      endereco.Cidade!.ToUpper();
      endereco.Estado!.ToUpper();

      var resultado = _enderecoDAO.Altere(id, endereco);
      if (!resultado)
        return Result.Fail("Falha ao alterar dados.");

      return Result.Ok();
    }
    //Get by Id
    public ReadEnderecoDto? BuscaPorId(int id)
    {
      Endereco? endereco = _enderecoDAO.BuscaPorId(id);
      if (endereco == null) return null;

      ReadEnderecoDto readDto = _mapper.Map<ReadEnderecoDto>(endereco);
      if (readDto == null)
        return null;

      while (readDto.Cep!.Length < 8)
      {
        readDto.Cep = "0" + readDto.Cep;
      }
      return readDto;
    }
    //Post
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

      ReadEnderecoDto readDto = _mapper.Map<ReadEnderecoDto>(enderecoOk);
      while (readDto.Cep!.Length < 8)
      {
        readDto.Cep = "0" + readDto.Cep;
      }

      return readDto;
    }
  }
}