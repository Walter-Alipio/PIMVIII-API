using AutoMapper;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Profiles
{
  public class PessoaProfile : Profile
  {
    public PessoaProfile()
    {
      CreateMap<CreatePessoaDto, Pessoa>()
        .ForSourceMember(x => x.Telefones, opt => opt.DoNotValidate());
      CreateMap<UpdatePessoaDto, Pessoa>()
        .ForSourceMember(x => x.Telefones, opt => opt.DoNotValidate());
      CreateMap<Pessoa, ReadPessoaDto>();
    }
  }
}