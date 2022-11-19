using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{

  public class TelefoneTipoService : ITelefoneTipoService
  {
    private TipoDAO _tipoDAO;
    public TelefoneTipoService(TipoDAO tipoDAO)
    {
      _tipoDAO = tipoDAO;
    }

    public ReadTipoDto? cadastraTelefoneTipo(CreateTipoDto createTipoDto)
    {
      TelefoneTipo tipoTel = new TelefoneTipo()
      {
        Tipo = createTipoDto.Tipo
      };

      if (String.IsNullOrEmpty(tipoTel.Tipo))
        return null;

      _tipoDAO.Insira(tipoTel);

      return new ReadTipoDto()
      {
        IdTelefoneTipo = tipoTel.IdTelefoneTipo,
        Tipo = tipoTel.Tipo
      };
    }

    public ReadTipoDto? TelefoneTipoPorId(int id)
    {
      TelefoneTipo? tipoTel = _tipoDAO.consulta(id);
      if (tipoTel == null)
        return null;

      return new ReadTipoDto()
      {
        IdTelefoneTipo = tipoTel.IdTelefoneTipo,
        Tipo = tipoTel.Tipo
      };
    }
  }
}