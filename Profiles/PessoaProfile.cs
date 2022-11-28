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
        .ForSourceMember(x => x.Telefones, opt => opt.DoNotValidate())
        .ForMember(e => e.Cpf, opt => opt.MapFrom(dto => Convert.ToInt32(dto.Cpf)));
      CreateMap<UpdatePessoaDto, Pessoa>()
        .ForSourceMember(x => x.Telefones, opt => opt.DoNotValidate())
        .ForMember(e => e.Cpf, opt => opt.MapFrom(dto => Convert.ToInt32(dto.Cpf)));
      CreateMap<Pessoa, ReadPessoaDto>().ForMember(e => e.Cpf, opt => opt.MapFrom(pessoa => pessoa.Cpf.ToString()));
    }
  }
}