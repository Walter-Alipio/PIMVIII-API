using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Models
{
  public class Telefone
  {
    [Key]
    [Required]
    public int Id_Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int DDD { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Fk_Tipo { get; set; }
    public virtual TelefoneTipo? Tipo { get; set; }
  }
}