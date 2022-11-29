using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DAO.Interface
{
  public interface IPessoaTelefone<T>
  {
    Pessoa? BuscaPorCpf(Int64 cpf);
    bool CadastraTelefones(int Fk_Pessoa, int Fk_Telefone);
    bool Insira(T item);
    bool Altere(T item);
    bool Exclua(int id);
  }
}