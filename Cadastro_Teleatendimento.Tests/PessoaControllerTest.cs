using Cadastro_Teleatendimento.Controllers;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using Cadastro_Teleatendimento.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Cadastro_Teleatendimento.Tests
{
  public class PessoaControllerTest
  {
    private IPessoaService _pessoaService;
    private PessoaController _pessoaController;

    public PessoaControllerTest()
    {
      _pessoaService = new FakePessoaService();
      _pessoaController = new PessoaController(_pessoaService);
    }

    [Fact]
    public void CadastraPessoaRetornaCreated()
    {
      //Arrange
      CreatePessoaDto pessoaDto = new CreatePessoaDto()
      {
        Nome = "Catarina",
        Cpf = 123654789,
        IdEndereco = 1,
        IdTelefone = 1
      };
      //Act
      var resultado = _pessoaController.CadastraPessoa(pessoaDto);
      //Assert
      Assert.IsType<CreatedAtActionResult>(resultado);
    }

    [Fact]
    public void BuscaPessoaPorIdRetornaOk()
    {
      //Arrange
      //Act
      var resultado = _pessoaController.BuscaPorId(1);
      //Assert
      Assert.IsType<OkObjectResult>(resultado);
    }

    [Fact]
    public void BuscaPessoaPorCpfdRetornaOk()
    {
      //Arrange
      //Act
      var resultado = _pessoaController.BuscaPessoa(123654789);
      //Assert
      Assert.IsType<OkObjectResult>(resultado);
    }
  }
}