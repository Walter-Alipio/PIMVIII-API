using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO
{
  public class UpdateTipoDto
  {
    [Required(ErrorMessage = "Campo obrigatório!")]
    [StringLength(10, ErrorMessage = "máximo de {1} carácteres")]
    public string? Tipo { get; set; }
  }
}