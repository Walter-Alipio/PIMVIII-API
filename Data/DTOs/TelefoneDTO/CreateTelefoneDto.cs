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
    public int IdTelefoneTipo { get; set; }
    public virtual TelefoneTipo? Tipo { get; set; }
  }
}