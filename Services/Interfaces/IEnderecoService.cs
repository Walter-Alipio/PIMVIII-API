using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface IEnderecoService
  {
    ReadEnderecoDto? BuscaPorId(int id);
    ReadEnderecoDto? CadastrarEndereco(CreateEnderecoDto enderecoDto);
  }
}