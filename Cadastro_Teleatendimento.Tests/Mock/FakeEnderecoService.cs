using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Tests.Mock
{
  public class FakeEnderecoService : IEnderecoService
  {
    private List<Endereco> _enderecos = new List<Endereco>
      {
        new Endereco()
        {
          IdEndereco = 1,
          Cep = 0123456,
          Logradouro = "Rua Tamoios",
          Numero = 154,
          Bairro = "Amélias",
          Cidade = "Terezina",
          Estado = "Piauí"
        },
        new Endereco()
        {
          IdEndereco = 2,
          Cep = 6540321,
          Logradouro = "Rua Pimentas",
          Numero = 154,
          Bairro = "Malaguetas",
          Cidade = "Salsinha",
          Estado = "Tempero"
        }
      };
    public ReadEnderecoDto? BuscaPorId(int id)
    {
      Endereco? endereco = _enderecos.FirstOrDefault(item => item.IdEndereco == id);
      if (endereco == null) return null;

      return new ReadEnderecoDto()
      {
        IdEndereco = 1,
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
      if (String.IsNullOrEmpty(enderecoDto.Logradouro) || String.IsNullOrEmpty(enderecoDto.Bairro) || String.IsNullOrEmpty(enderecoDto.Cidade) || String.IsNullOrEmpty(enderecoDto.Estado))
        return null;

      return new ReadEnderecoDto()
      {
        IdEndereco = 1,
        Cep = enderecoDto.Cep,
        Logradouro = enderecoDto.Logradouro,
        Numero = enderecoDto.Numero,
        Bairro = enderecoDto.Bairro,
        Cidade = enderecoDto.Cidade,
        Estado = enderecoDto.Estado
      };
    }
  }
}