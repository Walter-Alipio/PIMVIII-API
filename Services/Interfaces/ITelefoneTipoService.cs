using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using FluentResults;

namespace Cadastro_Teleatendimento.Services.Interfaces
{
  public interface ITelefoneTipoService
  {
    Result AlteraTelefoneTipo(int id, UpdateTipoDto tipoDto);
    ReadTipoDto? cadastraTelefoneTipo(CreateTipoDto createTipoDto);
    ReadTipoDto? TelefoneTipoPorId(int id);
  }

}