using Cadastro_Teleatendimento.Services.Interfaces;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Models;
using FluentResults;

namespace Cadastro_Teleatendimento.Tests.Mock
{
  class FakeTelefoneService : ITelefoneService
  {
    private List<Telefone> telefones = new()
    {
      new Telefone(){IdTelefone = 1, DDD = 011, Numero = 29966314, IdTelefoneTipo = 2}
    };
    public ReadTelefoneDto? BuscaTelefonePorId(int id)
    {
      Telefone? telefone = telefones.FirstOrDefault(item => item.IdTelefone == id);
      if (telefone == null) return null;

      return new ReadTelefoneDto()
      {
        IdTelefone = telefone.IdTelefone,
        DDD = telefone.DDD,
        Numero = telefone.Numero,
        IdTelefoneTipo = telefone.IdTelefone
      };
    }

    public ReadTelefoneDto? CadastraTelefone(CreateTelefoneDto telefoneDto)
    {

      if (telefoneDto.DDD == 0 || telefoneDto.Numero == 0 || telefoneDto.IdTelefoneTipo == 0)
        return null;

      return new ReadTelefoneDto()
      {
        DDD = telefoneDto.DDD,
        Numero = telefoneDto.Numero,
        IdTelefoneTipo = telefoneDto.IdTelefoneTipo,
        Tipo = telefoneDto.Tipo
      };
    }

    public Result validaTelefone(CreateTelefoneDto telefoneDto)
    {
      string dddString = telefoneDto.DDD.ToString();
      dddString = $"0{dddString}";
      if (dddString.Length != 3)
        return Result.Fail("O ddd deve ter 3 caracteres.");

      string telefoneString = telefoneDto.Numero.ToString();
      if (telefoneString.Length < 8 || telefoneString.Length > 9)
        return Result.Fail("O telefone deve ter no mínimo de 8 e máximo de 9 caracteres.");

      return Result.Ok();
    }
  }
}