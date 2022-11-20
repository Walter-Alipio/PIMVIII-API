using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO
{
  public class ReadTelefoneDto
  {
    public int IdTelefone { get; set; }

    public int Numero { get; set; }

    public int DDD { get; set; }

    public int IdTelefoneTipo { get; set; }
    public virtual TelefoneTipo? Tipo { get; set; }
  }
}