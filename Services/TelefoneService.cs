using AutoMapper;
using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;

namespace Cadastro_Teleatendimento.Services
{
  public class TelefoneService : ITelefoneService
  {
    private IDatabaseObject<Telefone> _telefoneDAO;
    private IMapper _mapper;

    public TelefoneService(IDatabaseObject<Telefone> telefoneDAO, IMapper mapper)
    {
      _telefoneDAO = telefoneDAO;
      _mapper = mapper;
    }

    public Result AlteraTelefone(int id, UpdateTelefoneDto telefoneDto)
    {
      Telefone telefone = _mapper.Map<Telefone>(telefoneDto);
      if (telefone == null)
        return Result.Fail("Dados obrigatórios");

      var resultado = _telefoneDAO.Altere(id, telefone);
      if (!resultado)
        return Result.Fail("Falha ao atualizar dados.");

      return Result.Ok();
    }

    //Get by Id
    public ReadTelefoneDto? BuscaTelefonePorId(int id)
    {
      Telefone? telefone = _telefoneDAO.BuscaPorId(id);
      if (telefone == null)
        return null;

      return _mapper.Map<ReadTelefoneDto>(telefone);
    }
    //Post
    public ReadTelefoneDto? CadastraTelefone(CreateTelefoneDto telefoneDto)
    {
      Telefone? telefone = _mapper.Map<Telefone>(telefoneDto);
      if (telefone.DDD == 0 && telefone.Numero == 0 && telefone.Fk_Tipo == 0)
        return null;


      bool retsultado = _telefoneDAO.Insira(telefone);
      if (!retsultado)
        return null;
      var fone = _telefoneDAO.UltimoInsert();
      return _mapper.Map<ReadTelefoneDto>(fone);
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