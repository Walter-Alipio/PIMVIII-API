using System.Collections.Generic;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Tests.Mock
{
  public class FakePessoaService : IPessoaService
  {
    private List<Pessoa> _pessoas = new List<Pessoa>
    {
     new Pessoa()
      {
        IdPessoa= 1,
        Nome = "Carlos",
        Cpf = 123654789,
        IdEndereco = 1,
        IdTelefone = 1
      }
    };
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
    private List<Telefone> _telefones = new()
    {
      new Telefone(){IdTelefone = 1, DDD = 011, Numero = 29966314, IdTelefoneTipo = 2}
    };

    public List<ReadPessoaDto>? BuscaPessoas(int? cpf)
    {
      Pessoa? pessoa = _pessoas.FirstOrDefault(item => item.Cpf == cpf);
      if (pessoa == null) return null;

      ReadPessoaDto readDto = new()
      {
        IdPessoa = pessoa.IdPessoa,
        Nome = pessoa.Nome,
        Cpf = pessoa.Cpf,
        IdEndereco = pessoa.IdEndereco,
        Endereco = _enderecos.FirstOrDefault(item => item.IdEndereco == pessoa.IdEndereco),
        IdTelefone = pessoa.IdTelefone,
        Telefones = _telefones.FindAll(item => item.IdTelefone == pessoa.IdTelefone)
      };

      List<ReadPessoaDto> pessoasDto = new();

      pessoasDto.Add(readDto);
      return pessoasDto;
    }

    public ReadPessoaDto? BuscaPorId(int id)
    {
      Pessoa? pessoa = _pessoas.FirstOrDefault(item => item.IdPessoa == id);
      if (pessoa == null) return null;

      return new ReadPessoaDto()
      {
        IdPessoa = pessoa.IdPessoa,
        Nome = pessoa.Nome,
        Cpf = pessoa.Cpf,
        IdEndereco = pessoa.IdEndereco,
        Endereco = _enderecos.FirstOrDefault(item => item.IdEndereco == pessoa.IdEndereco),
        IdTelefone = pessoa.IdTelefone,
        Telefones = _telefones.FindAll(item => item.IdTelefone == pessoa.IdTelefone)
      };
    }

    public ReadPessoaDto? CadastraPessoa(CreatePessoaDto pessoaDto)
    {
      if (String.IsNullOrEmpty(pessoaDto.Nome) || pessoaDto.Cpf == 0 || pessoaDto.IdEndereco == 0 || pessoaDto.IdTelefone == 0)
        return null;

      return new ReadPessoaDto()
      {
        Nome = pessoaDto.Nome,
        Cpf = pessoaDto.Cpf,
        IdEndereco = pessoaDto.IdEndereco,
        IdTelefone = pessoaDto.IdTelefone
      };
    }
  }
}