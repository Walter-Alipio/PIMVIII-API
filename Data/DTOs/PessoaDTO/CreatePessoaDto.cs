using System.ComponentModel.DataAnnotations;
using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DTOs.PessoaDTO
{
  public class CreatePessoaDto
  {
    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(256, ErrorMessage = "máximo de {1} carácteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Cpf { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int IdEndereco { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int IdTelefone { get; set; }
  }
}