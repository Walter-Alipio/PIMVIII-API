using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using FluentResults;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface IEnderecoService
  {
    Result AlteraEndereco(int id, UpdateEnderecoDto enderecoDto);
    ReadEnderecoDto? BuscaPorId(int id);
    ReadEnderecoDto? CadastrarEndereco(CreateEnderecoDto enderecoDto);
  }
}