namespace Cadastro_Teleatendimento.Data.DTOs.PessoaDTO
{
  public class PessoaDatabaseDto
  {

    public int Id_Pessoa { get; set; }
    public string? Nome { get; set; }
    public int Cpf { get; set; }
    public int Id_Endereco { get; set; }
    public string? Logradouro { get; set; }
    public int Numero { get; set; }
    public int Cep { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
  }
}