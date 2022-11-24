using AutoMapper;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Profiles
{
  public class TelefoneTipoProfile : Profile
  {
    public TelefoneTipoProfile()
    {
      CreateMap<CreateTipoDto, TelefoneTipo>();
      CreateMap<TelefoneTipo, ReadTipoDto>();
    }
  }
}