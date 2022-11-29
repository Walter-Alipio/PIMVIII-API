using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Data.DTOs.PessoaDTO
{
  public class CreatePessoaDto
  {
    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(256, ErrorMessage = "máximo de {1} carácteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(11, ErrorMessage = "O campo deve ter {1} carácteres")]
    [MinLength(11, ErrorMessage = "O campo deve ter {1} carácteres")]
    public string? Cpf { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Fk_Endereco { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public List<int>? Telefones { get; set; }

  }
}