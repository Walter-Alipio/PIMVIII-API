using AutoMapper;
using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Profiles
{
  public class EnderecoProfile : Profile
  {
    public EnderecoProfile()
    {
      CreateMap<CreateEnderecoDto, Endereco>().ForMember(e => e.Cep, opts => opts.MapFrom(dto => Convert.ToInt32(dto.Cep)));
      CreateMap<UpdateEnderecoDto, Endereco>().ForMember(e => e.Cep, opts => opts.MapFrom(dto => Convert.ToInt32(dto.Cep)));
      CreateMap<Endereco, ReadEnderecoDto>();
    }
  }
}