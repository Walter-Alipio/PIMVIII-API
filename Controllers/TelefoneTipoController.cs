
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Services;
using Cadastro_Teleatendimento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Teleatendimento.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class telefoneTipoController : ControllerBase
  {
    private ITelefoneTipoService _tipoService;

    public telefoneTipoController(ITelefoneTipoService tipoService)
    {
      _tipoService = tipoService;
    }

    [HttpPost]
    public IActionResult CadastraTelefoneTipo([FromBody] CreateTipoDto createTipoDto)
    {
      ReadTipoDto? readTipoDto = _tipoService.cadastraTelefoneTipo(createTipoDto);

      if (readTipoDto == null) return BadRequest();

      return CreatedAtAction(nameof(telefoneTipoPorId), new { Id = readTipoDto.IdTelefoneTipo }, readTipoDto);
    }

    [HttpGet("{id}")]
    public IActionResult telefoneTipoPorId(int Id)
    {
      ReadTipoDto? readTipoDto = _tipoService.TelefoneTipoPorId(Id);

      return readTipoDto == null ? NotFound() : Ok(readTipoDto);
    }
  }

}