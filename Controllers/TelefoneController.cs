using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Teleatendimento.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TelefoneController : ControllerBase
  {
    private ITelefoneService _telefoneService;
    public TelefoneController(ITelefoneService telefoneService)
    {
      _telefoneService = telefoneService;
    }

    [HttpPost]
    public IActionResult CadastraTelefone(CreateTelefoneDto telefoneDto)
    {
      Result resultado = _telefoneService.validaTelefone(telefoneDto);
      if (resultado.IsFailed) return BadRequest(resultado.Errors.FirstOrDefault());

      ReadTelefoneDto? readDto = _telefoneService.CadastraTelefone(telefoneDto);
      if (readDto == null) return BadRequest();

      return CreatedAtAction(nameof(BuscaTelefonePorId), new { Id = readDto.Id_Telefone }, readDto);
    }

    [HttpGet("{Id}")]
    public IActionResult BuscaTelefonePorId(int id)
    {
      ReadTelefoneDto? readDto = _telefoneService.BuscaTelefonePorId(id);

      return readDto == null ? NotFound() : Ok(readDto);
    }
  }
}