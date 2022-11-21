using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{
  public class EnderecoService : IEnderecoService
  {
    private EnderecoDAO _enderecoDAO;

    public EnderecoService(EnderecoDAO enderecoDAO)
    {
      _enderecoDAO = enderecoDAO;
    }

    public ReadEnderecoDto? BuscaPorId(int id)
    {
      Endereco? endereco = _enderecoDAO.BuscaPorId(id);
      if (endereco == null) return null;

      return new ReadEnderecoDto()
      {
        IdEndereco = endereco.IdEndereco,
        Cep = endereco.Cep,
        Logradouro = endereco.Logradouro,
        Numero = endereco.Numero,
        Bairro = endereco.Bairro,
        Cidade = endereco.Cidade,
        Estado = endereco.Estado
      };
    }

    public ReadEnderecoDto? CadastrarEndereco(CreateEnderecoDto enderecoDto)
    {
      Endereco endereco = new Endereco()
      {
        Cep = enderecoDto.Cep,
        Logradouro = enderecoDto.Logradouro,
        Numero = enderecoDto.Numero,
        Bairro = enderecoDto.Bairro,
        Cidade = enderecoDto.Cidade,
        Estado = enderecoDto.Estado
      };

      if (String.IsNullOrEmpty(endereco.Logradouro) || String.IsNullOrEmpty(endereco.Bairro) || String.IsNullOrEmpty(endereco.Cidade) || String.IsNullOrEmpty(endereco.Estado))
        return null;

      _enderecoDAO.Insira(endereco);
      return new ReadEnderecoDto()
      {
        IdEndereco = endereco.IdEndereco,
        Cep = endereco.Cep,
        Logradouro = endereco.Logradouro,
        Numero = endereco.Numero,
        Bairro = endereco.Bairro,
        Cidade = endereco.Cidade,
        Estado = endereco.Estado
      };
    }
  }
}