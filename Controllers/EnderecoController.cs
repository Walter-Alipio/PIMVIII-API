using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Teleatendimento.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EnderecoController : ControllerBase
  {
    private IEnderecoService _enderecoService;

    public EnderecoController(IEnderecoService enderecoService)
    {
      _enderecoService = enderecoService;
    }

    [HttpPost]
    public IActionResult CadastrarEndereco(CreateEnderecoDto enderecoDto)
    {
      ReadEnderecoDto? readDto = _enderecoService.CadastrarEndereco(enderecoDto);
      if (readDto == null) return BadRequest();

      return CreatedAtAction(nameof(BuscaPorId), new { Id = readDto.IdEndereco }, enderecoDto);
    }

    [HttpGet("{id}")]
    public IActionResult BuscaPorId(int id)
    {
      ReadEnderecoDto? readDto = _enderecoService.BuscaPorId(id);

      return readDto == null ? NotFound() : Ok(readDto);
    }
  }
}