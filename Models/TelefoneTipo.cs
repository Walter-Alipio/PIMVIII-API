using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Models
{
  public class TelefoneTipo
  {
    [Key]
    [Required]
    public int Id_Tipo { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(10, ErrorMessage = "máximo de {1} carácteres")]
    public string? Tipo { get; set; }
  }
}