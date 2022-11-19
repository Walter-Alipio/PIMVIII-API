using Cadastro_Teleatendimento.Controllers;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Cadastro_Teleatendimento.Tests
{
  public class telefoneTipoControllerTest
  {
    private ITelefoneTipoService _tipoService;
    private telefoneTipoController _tipoController;

    public telefoneTipoControllerTest()
    {
      _tipoService = new fakeTelefoneTipoService();
      _tipoController = new telefoneTipoController(_tipoService);
    }
    [Fact]
    public void CadastraTipoRetornaBadRequest()
    {
      //Arrange
      CreateTipoDto createTipoDto = new CreateTipoDto();
      //Act
      var result = _tipoController.CadastraTelefoneTipo(createTipoDto);
      //Assert
      Assert.IsType<BadRequestResult>(result);
    }
    [Fact]
    public void CadastraTipoRetornaOk()
    {
      //Arrange
      CreateTipoDto createTipoDto = new CreateTipoDto() { Tipo = "fixo" };
      //Act
      var result = _tipoController.CadastraTelefoneTipo(createTipoDto);
      //Assert
      Assert.IsType<CreatedAtActionResult>(result);
    }
    [Fact]
    public void TipoPorIdRetornaNotFound()
    {
      //Arrange
      //Act
      var result = _tipoController.telefoneTipoPorId(0);
      //Assert
      Assert.IsType<NotFoundResult>(result);
    }
    [Fact]
    public void TipoPorIdRetornaOk()
    {
      //Arrange
      //Act
      var result = _tipoController.telefoneTipoPorId(1);
      //Assert
      Assert.IsType<OkObjectResult>(result);
    }
  }

  public class fakeTelefoneTipoService : ITelefoneTipoService
  {
    private List<ReadTipoDto> _tiposDto = new List<ReadTipoDto>
      {
        new ReadTipoDto(){ Tipo = "móvel", IdTelefoneTipo = 1},
        new ReadTipoDto(){ Tipo = "fixo", IdTelefoneTipo = 2}
      };
    public ReadTipoDto? cadastraTelefoneTipo(CreateTipoDto createTipoDto)
    {
      if (String.IsNullOrEmpty(createTipoDto.Tipo))
        return null;

      return new ReadTipoDto() { IdTelefoneTipo = 1, Tipo = "movel" };
    }

    public ReadTipoDto? TelefoneTipoPorId(int id)
    {
      ReadTipoDto? readTipoDto = _tiposDto.FirstOrDefault(tipo => tipo.IdTelefoneTipo == id);
      if (readTipoDto == null)
        return null;

      return readTipoDto;
    }
  }
}