
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using FluentResults;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface ITelefoneService
  {
    ReadTelefoneDto? CadastraTelefone(CreateTelefoneDto telefoneDto);
    ReadTelefoneDto? BuscaTelefonePorId(int id);
    Result validaTelefone(CreateTelefoneDto telefoneDto);
    Result AlteraTelefone(int id, UpdateTelefoneDto telefoneDto);
  }
}