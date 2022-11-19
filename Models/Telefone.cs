using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Models
{
  public class Telefone
  {
    [Key]
    [Required]
    public int IdTelefone { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Number { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int DDD { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int IdTelefoneTipo { get; set; }
    public virtual TelefoneTipo? Tipo { get; set; }
  }
}