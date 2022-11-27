using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using FluentResults;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface IPessoaService
  {
    ReadPessoaDto? BuscaCpf(int cpf);
    ReadPessoaDto? BuscaPorId(int id);
    ReadPessoaDto? CadastraPessoa(CreatePessoaDto pessoaDto);
    Result AlteraDadosPessoa(UpdatePessoaDto pessoaDto);
    Result ExcluiPessoa(int Cpf);
  }
}