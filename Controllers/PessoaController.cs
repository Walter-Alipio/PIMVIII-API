using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using FluentResults;
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
      Result cpfValido = _pessoaService.ValidaCpf(pessoaDto.Cpf!);

      if (cpfValido.IsFailed) return BadRequest(cpfValido.Errors.FirstOrDefault());


      ReadPessoaDto? readDto = _pessoaService.CadastraPessoa(pessoaDto);

      if (readDto == null) return BadRequest();

      return CreatedAtAction(nameof(BuscaPorId), new { Id = readDto.Id_Pessoa }, readDto);
    }

    private IActionResult BuscaPorId(int id)
    {
      ReadPessoaDto? readDto = _pessoaService.BuscaPorId(id);

      return readDto == null ? NotFound() : Ok(readDto);
    }

    [HttpGet("{cpf}")]
    public IActionResult BuscaPessoa(int cpf)
    {

      ReadPessoaDto? pessoas = _pessoaService.BuscaCpf(cpf);

      return pessoas == null ? NotFound() : Ok(pessoas);
    }

    [HttpPut]
    public IActionResult AltereDadosPessoa([FromBody] UpdatePessoaDto pessoaDto)
    {
      Result cpfValido = _pessoaService.ValidaCpf(pessoaDto.Cpf!);

      if (cpfValido.IsFailed) return BadRequest(cpfValido.Errors.FirstOrDefault());

      Result resultado = _pessoaService.AlteraDadosPessoa(pessoaDto);

      return resultado.IsFailed ? NotFound() : NoContent();
    }

    [HttpDelete("{cpf}")]
    public IActionResult ExcluiPessoa(int cpf)
    {
      Result resultado = _pessoaService.ExcluiPessoa(cpf);

      return resultado.IsFailed ? NotFound() : NoContent();
    }
  }
}