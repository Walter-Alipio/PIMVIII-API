using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO
{
  public class ReadTipoDto
  {
    public int IdTelefoneTipo { get; set; }
    public string? Tipo { get; set; }
  }
}