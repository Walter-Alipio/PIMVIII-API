
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface ITelefoneService
  {
    ReadTelefoneDto? CadastraTelefone(CreateTelefoneDto telefoneDto);
    ReadTelefoneDto? BuscaTelefonePorId(int id);
  }
}