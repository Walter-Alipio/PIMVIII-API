using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO
{
  public class CreateEnderecoDto
  {
    [Required(ErrorMessage = "Campo obrigatório!")]
    public string? Logradouro { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(8, ErrorMessage = "máximo de {1} carácteres")]
    [MinLength(8, ErrorMessage = "O campo deve ter {1} carácteres")]
    public string? Cep { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(50, ErrorMessage = "máximo de {1} carácteres")]
    public string? Bairro { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(30, ErrorMessage = "máximo de {1} carácteres")]
    public string? Cidade { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(20, ErrorMessage = "máximo de {1} carácteres")]
    public string? Estado { get; set; }
  }
}