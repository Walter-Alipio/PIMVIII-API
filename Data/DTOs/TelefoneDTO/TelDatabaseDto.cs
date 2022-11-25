namespace Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO
{
  public class TelDatabaseDto
  {
    public int Id_Telefone { get; set; }

    public int Numero { get; set; }

    public int DDD { get; set; }

    public int Fk_Tipo { get; set; }
    public int Id_Tipo { get; set; }
    public string? Tipo { get; set; }
  }
}