using Cadastro_Teleatendimento.Controllers;
using Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO;
using Cadastro_Teleatendimento.Services.Interfaces;
using Cadastro_Teleatendimento.Tests.Mock;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Cadastro_Teleatendimento.Tests
{
  public class EnderecoControllerTest
  {
    private EnderecoController _enderecoController;
    private IEnderecoService _enderecoService;
    public EnderecoControllerTest()
    {
      _enderecoService = new FakeEnderecoService();
      _enderecoController = new EnderecoController(_enderecoService);
    }
    [Fact]
    public void CadastrarEnderecoRetornaBadRequest()
    {
      //Arrange
      CreateEnderecoDto enderecoDto = new CreateEnderecoDto();
      //Act
      var resultado = _enderecoController.CadastrarEndereco(enderecoDto);
      //Assert
      Assert.IsType<BadRequestResult>(resultado);
    }

    [Fact]
    public void CadastrarEnderecoRetornaCreated()
    {
      //Arrange
      CreateEnderecoDto enderecoDto = new CreateEnderecoDto()
      {
        Cep = 0123456,
        Logradouro = "Rua Tamoios",
        Numero = 154,
        Bairro = "Amélias",
        Cidade = "Terezina",
        Estado = "Piauí"
      };
      //Act
      var resultado = _enderecoController.CadastrarEndereco(enderecoDto);
      //Assert
      Assert.IsType<CreatedAtActionResult>(resultado);
    }
  }
}