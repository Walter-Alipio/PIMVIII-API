using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface IPessoaService
  {
    ReadPessoaDto? BuscaCpf(int cpf);
    ReadPessoaDto? BuscaPorId(int id);
    ReadPessoaDto? CadastraPessoa(CreatePessoaDto pessoaDto);
  }
}