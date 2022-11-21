using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Teleatendimento.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PessoaController : ControllerBase
  {
    private IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
      _pessoaService = pessoaService;
    }

    [HttpPost]
    public IActionResult CadastraPessoa([FromBody] CreatePessoaDto pessoaDto)
    {
      ReadPessoaDto? readDto = _pessoaService.CadastraPessoa(pessoaDto);

      if (readDto == null) return BadRequest();

      return CreatedAtAction(nameof(BuscaPorId), new { Id = readDto.IdPessoa }, readDto);
    }

    [HttpGet("{Id}")]
    public IActionResult BuscaPorId(int id)
    {
      ReadPessoaDto? readDto = _pessoaService.BuscaPorId(id);

      return readDto == null ? NotFound() : Ok(readDto);
    }

    [HttpGet]
    public IActionResult BuscaPessoa([FromQuery] int? cpf)
    {
      List<ReadPessoaDto>? pessoas = _pessoaService.BuscaPessoas(cpf);

      return pessoas == null ? NotFound() : Ok(pessoas);
    }
  }
}