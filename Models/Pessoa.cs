using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Models
{
  public class Pessoa
  {
    [Key]
    [Required]
    public int Id_Pessoa { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(256, ErrorMessage = "máximo de {1} carácteres")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Cpf { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Fk_Endereco { get; set; }
    public virtual Endereco? endereco { get; set; }
    public virtual List<Telefone>? Telefone { get; set; }
  }
}