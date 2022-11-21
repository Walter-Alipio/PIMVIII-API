namespace Cadastro_Teleatendimento.Data.DTOs.EnderecoDTO
{
  public class ReadEnderecoDto
  {
    public int IdEndereco { get; set; }
    public string? Logradouro { get; set; }

    public int Numero { get; set; }

    public int Cep { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }
    public string? Estado { get; set; }
  }
}