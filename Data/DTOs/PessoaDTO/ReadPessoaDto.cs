using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DTOs.PessoaDTO
{
  public class ReadPessoaDto
  {
    public int IdPessoa { get; set; }
    public string? Nome { get; set; }
    public int Cpf { get; set; }
    public int IdEndereco { get; set; }
    public virtual Endereco? Endereco { get; set; }
    public int IdTelefone { get; set; }
    public virtual List<Telefone>? Telefones { get; set; }
  }
}