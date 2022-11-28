
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Services;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Teleatendimento.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TelefoneTipoController : ControllerBase
  {
    private ITelefoneTipoService _tipoService;

    public TelefoneTipoController(ITelefoneTipoService tipoService)
    {
      _tipoService = tipoService;
    }

    [HttpPost]
    public IActionResult CadastraTelefoneTipo([FromBody] CreateTipoDto createTipoDto)
    {
      ReadTipoDto? readTipoDto = _tipoService.cadastraTelefoneTipo(createTipoDto);

      if (readTipoDto == null) return BadRequest();

      return CreatedAtAction(nameof(TelefoneTipoPorId), new { Id = readTipoDto.Id_Tipo }, readTipoDto);
    }

    [HttpGet("{id}")]
    public IActionResult TelefoneTipoPorId(int Id)
    {
      ReadTipoDto? readTipoDto = _tipoService.TelefoneTipoPorId(Id);

      return readTipoDto == null ? NotFound() : Ok(readTipoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AlteraTelefoneTipo(int id, UpdateTipoDto tipoDto)
    {
      Result resultado = _tipoService.AlteraTelefoneTipo(id, tipoDto);

      return resultado.IsFailed ? NotFound() : NoContent();
    }
  }

}