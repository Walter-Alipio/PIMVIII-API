using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using FluentResults;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface IPessoaService
  {
    ReadPessoaDto? BuscaCpf(Int64 cpf);
    ReadPessoaDto? BuscaPorId(int id);
    ReadPessoaDto? CadastraPessoa(CreatePessoaDto pessoaDto);
    Result AlteraDadosPessoa(UpdatePessoaDto pessoaDto);
    Result ExcluiPessoa(Int64 Cpf);
    Result ValidaCpf(string cpf);
  }
}