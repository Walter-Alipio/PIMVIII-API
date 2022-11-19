using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data
{
  public class TipoDAO
  {
    private List<TelefoneTipo> _tipos = new()
      {
        new TelefoneTipo() { IdTelefoneTipo = 1, Tipo = "celular" },
        new TelefoneTipo() { IdTelefoneTipo = 2, Tipo = "fixo" }
      };

    public void Insira(TelefoneTipo tipo)
    {
      tipo.IdTelefoneTipo = _tipos.Count() + 1;
      _tipos.Add(tipo);
    }

    public TelefoneTipo? consulta(int id)
    {
      TelefoneTipo? tipo = _tipos.FirstOrDefault(item => item.IdTelefoneTipo == id);

      return tipo == null ? null : tipo;
    }
  }
}