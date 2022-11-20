using Cadastro_Teleatendimento.Services.Interfaces;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;

namespace Cadastro_Teleatendimento.Tests.Mock
{
  public class FakeTelefoneTipoService : ITelefoneTipoService
  {
    private List<ReadTipoDto> _tiposDto = new List<ReadTipoDto>
      {
        new ReadTipoDto(){ Tipo = "móvel", IdTelefoneTipo = 1},
        new ReadTipoDto(){ Tipo = "fixo", IdTelefoneTipo = 2}
      };
    public ReadTipoDto? cadastraTelefoneTipo(CreateTipoDto createTipoDto)
    {
      if (String.IsNullOrEmpty(createTipoDto.Tipo))
        return null;

      return new ReadTipoDto() { IdTelefoneTipo = 1, Tipo = "movel" };
    }

    public ReadTipoDto? TelefoneTipoPorId(int id)
    {
      ReadTipoDto? readTipoDto = _tiposDto.FirstOrDefault(tipo => tipo.IdTelefoneTipo == id);
      if (readTipoDto == null)
        return null;

      return readTipoDto;
    }
  }
}