using System.Runtime.CompilerServices;
using AutoMapper;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Profiles
{
  public class TelefoneProfile : Profile
  {
    public TelefoneProfile()
    {
      CreateMap<CreateTelefoneDto, Telefone>();
      CreateMap<UpdateTelefoneDto, Telefone>();
      CreateMap<Telefone, ReadTelefoneDto>();
    }
  }
}