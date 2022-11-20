using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data
{
  public class TelefoneDAO
  {
    private List<Telefone> _telefones = new();

    public void Insira(Telefone telefone)
    {
      telefone.IdTelefone = _telefones.Count() + 1;

      _telefones.Add(telefone);
    }
  }

}