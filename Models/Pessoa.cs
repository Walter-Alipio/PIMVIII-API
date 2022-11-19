using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Models
{
  public class Pessoa
  {
    [Key]
    [Required]
    public int IdPessoa { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(256, ErrorMessage = "máximo de {1} carácteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Cpf { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int IdEndereco { get; set; }
    public virtual Endereco? endereco { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int IdTelefone { get; set; }
    public virtual List<Telefone>? telefones { get; set; }
  }
}