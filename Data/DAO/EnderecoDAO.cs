using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data
{
  public class EnderecoDAO
  {
    private List<Endereco> _enderecos = new List<Endereco>
      {
        new Endereco()
        {
          IdEndereco = 1,
          Cep = 0123456,
          Logradouro = "Rua Tamoios",
          Numero = 154,
          Bairro = "Amélias",
          Cidade = "Terezina",
          Estado = "Piauí"
        },
        new Endereco()
        {
          IdEndereco = 2,
          Cep = 6540321,
          Logradouro = "Rua Pimentas",
          Numero = 154,
          Bairro = "Malaguetas",
          Cidade = "Salsinha",
          Estado = "Tempero"
        }
      };

    public void Insira(Endereco endereco)
    {
      endereco.IdEndereco = _enderecos.Count() + 1;

      _enderecos.Add(endereco);
    }

    public Endereco? BuscaPorId(int id)
    {
      return _enderecos.FirstOrDefault(item => item.IdEndereco == id);
    }
  }
}