using AutoMapper;
using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{

  public class TelefoneTipoService : ITelefoneTipoService
  {
    private IDatabaseObject<TelefoneTipo> _tipoDAO;
    private IMapper _mapper;
    public TelefoneTipoService(IDatabaseObject<TelefoneTipo> tipoDAO, IMapper mapper)
    {
      _tipoDAO = tipoDAO;
      _mapper = mapper;
    }

    public ReadTipoDto? cadastraTelefoneTipo(CreateTipoDto createTipoDto)
    {

      TelefoneTipo telefoneTipo = new TelefoneTipo() { Tipo = createTipoDto.Tipo?.ToUpper() };
      if (telefoneTipo == null)
        return null;

      telefoneTipo.Tipo?.ToUpper();

      var resultado = _tipoDAO.Insira(telefoneTipo);

      if (!resultado)
        return null;

      var tipo = BuscaUlitmoElemento();

      return _mapper.Map<ReadTipoDto>(tipo);
    }

    public ReadTipoDto? TelefoneTipoPorId(int id)
    {
      TelefoneTipo? tipoTel = _tipoDAO.BuscaPorId(id);
      if (tipoTel == null)
        return null;

      return _mapper.Map<ReadTipoDto>(tipoTel);
    }

    private TelefoneTipo? BuscaUlitmoElemento()
    {
      return _tipoDAO.UltimoInsert();
    }
  }
}