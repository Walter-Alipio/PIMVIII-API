using System.ComponentModel.DataAnnotations;
using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO
{
  public class CreateTelefoneDto
  {
    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int DDD { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public int Fk_Tipo { get; set; }
    public virtual TelefoneTipo? Tipo { get; set; }
  }
}