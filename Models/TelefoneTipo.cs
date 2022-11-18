using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Models
{
  class TelefoneTipo
  {
    [Key]
    [Required]
    public int IdTelefoneTipo { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string? Tipo { get; set; }
  }
}