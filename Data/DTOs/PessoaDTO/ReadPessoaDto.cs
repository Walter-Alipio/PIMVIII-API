using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DTOs.PessoaDTO
{
  public class ReadPessoaDto
  {
    public int Id_Pessoa { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public int Fk_Endereco { get; set; }
    public virtual Endereco? Endereco { get; set; }
    public virtual List<Telefone>? Telefone { get; set; }
  }
}