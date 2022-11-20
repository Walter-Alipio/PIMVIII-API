using Cadastro_Teleatendimento.Controllers;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Models;
using Cadastro_Teleatendimento.Services.Interfaces;
using Cadastro_Teleatendimento.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Cadastro_Teleatendimento.Tests
{
  public class TelefoneControllerTest
  {
    private ITelefoneService _telefoneService;
    private TelefoneController _telefoneController;

    public TelefoneControllerTest()
    {
      _telefoneService = new FakeTelefoneService();
      _telefoneController = new TelefoneController(_telefoneService);
    }

    [Fact]
    public void CadastraTelefoneRetornaBadRequest()
    {
      //Arrange
      CreateTelefoneDto telefoneDto = new CreateTelefoneDto();
      //Act
      var resultado = _telefoneController.CadastraTelefone(telefoneDto);
      //Assert
      Assert.IsType<BadRequestResult>(resultado);
    }

    [Fact]
    public void CadastraTelefoneRetornaCreated()
    {
      CreateTelefoneDto telefoneDto = new CreateTelefoneDto()
      {
        DDD = 011,
        Numero = 29956314,
        IdTelefoneTipo = 2
      };
      //Act
      var resultado = _telefoneController.CadastraTelefone(telefoneDto);
      //Assert
      Assert.IsType<CreatedAtActionResult>(resultado);
    }

    [Fact]
    public void BuscaTelefonePorIdRetornaNotFound()
    {
      //Arrange
      //Act
      var resultado = _telefoneController.BuscaTelefonePorId(0);
      //Assert
      Assert.IsType<NotFoundResult>(resultado);
    }

    [Fact]
    public void BuscaTelefonePorIdRetornaTelefone()
    {
      //Arrange
      //Act
      var resultado = _telefoneController.BuscaTelefonePorId(1);
      //Assert
      Assert.IsType<OkObjectResult>(resultado);
    }

  }
}