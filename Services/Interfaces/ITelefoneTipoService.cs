using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface ITelefoneTipoService
  {
    ReadTipoDto? cadastraTelefoneTipo(CreateTipoDto createTipoDto);
    ReadTipoDto? TelefoneTipoPorId(int id);
  }

}