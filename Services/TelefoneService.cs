using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;

namespace Cadastro_Teleatendimento.Services
{
  public class TelefoneService : ITelefoneService
  {
    private TelefoneDAO _telefoneDAO;

    public TelefoneService(TelefoneDAO telefoneDAO)
    {
      _telefoneDAO = telefoneDAO;
    }

    public ReadTelefoneDto? BuscaTelefonePorId(int id)
    {
      throw new NotImplementedException();
    }

    public ReadTelefoneDto? CadastraTelefone(CreateTelefoneDto telefoneDto)
    {
      Telefone telefone = new Telefone()
      {
        DDD = telefoneDto.DDD,
        Numero = telefoneDto.Numero,
        IdTelefoneTipo = telefoneDto.IdTelefoneTipo
      };

      System.Console.WriteLine($"DDD: {telefone.DDD},Fone: {telefone.Numero},Id:{telefone.IdTelefoneTipo}");
      if (telefone.DDD == 0 && telefone.Numero == 0 && telefone.IdTelefoneTipo == 0)
        return null;


      try
      {
        _telefoneDAO.Insira(telefone);
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return null;
      }

      return new ReadTelefoneDto()
      {
        IdTelefone = telefone.IdTelefone,
        DDD = telefone.DDD,
        Numero = telefone.Numero,
        IdTelefoneTipo = telefone.IdTelefoneTipo
      };
    }
  }
}