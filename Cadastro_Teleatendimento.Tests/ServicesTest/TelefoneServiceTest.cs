using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Services;
using Cadastro_Teleatendimento.Services.Interfaces;
using Xunit;

namespace Cadastro_Teleatendimento.Tests.ServicesTest
{
  public class TelefoneServiceTest
  {
    private ITelefoneService _telefoneService;

    public TelefoneServiceTest()
    {
      _telefoneService = new TelefoneService(new Data.TelefoneDAO());
    }

    [Fact]
    public void CadastraTelefoneRetornaNull()
    {
      //Arrange
      CreateTelefoneDto createDto = new CreateTelefoneDto();
      //Act
      var resultado = _telefoneService.CadastraTelefone(createDto);
      //Assert
      Assert.Null(resultado);
    }
    [Fact]
    public void CadastraTelefoneRetornaReadTelefone()
    {
      //Arrange
      CreateTelefoneDto createDto = new CreateTelefoneDto()
      {
        DDD = 012,
        Numero = 22665533,
        IdTelefoneTipo = 2
      };
      //Act
      var resultado = _telefoneService.CadastraTelefone(createDto);
      //Assert
      Assert.IsType<ReadTelefoneDto>(resultado);
    }
  }
}