using System.ComponentModel.DataAnnotations;

namespace Cadastro_Teleatendimento.Data.DTOs.TelefoneTipoDTO
{
  public class ReadTipoDto
  {
    public int Id_Tipo { get; set; }
    public string? Tipo { get; set; }
  }
}