using System;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Services;
using Cadastro_Teleatendimento.Services.Interfaces;
using Xunit;

namespace Cadastro_Teleatendimento.Tests.ServicesTest
{
  public class TipoServicesTest
  {
    private ITelefoneTipoService _tipoService;
    public TipoServicesTest()
    {
      _tipoService = new TelefoneTipoService(new Data.TipoDAO());
    }

    [Fact]
    public void ParametroNuloRetornaNull()
    {
      //Arrange
      CreateTipoDto tipoDto = new() { Tipo = "" };
      //Act
      var result = _tipoService.cadastraTelefoneTipo(tipoDto);
      //Assert
      Assert.Null(result);
    }
    [Fact]
    public void ParametroValidoRetornaReadTipoDto()
    {
      //Arrange
      CreateTipoDto tipoDto = new() { Tipo = "celular" };
      //Act
      var result = _tipoService.cadastraTelefoneTipo(tipoDto);
      //Assert
      Assert.IsType<ReadTipoDto>(result);
    }

    [Fact]
    public void buscaPorIdInvalidoRetornaNull()
    {
      //Arrange
      //Act
      var result = _tipoService.TelefoneTipoPorId(0);
      //Assert
      Assert.Null(result);
    }

    [Fact]
    public void buscaPorIdInvalidoRetornaReadTipo()
    {
      //Arrange
      //Act
      var result = _tipoService.TelefoneTipoPorId(1);
      //Assert
      Assert.IsType<ReadTipoDto>(result);
    }
  }
}