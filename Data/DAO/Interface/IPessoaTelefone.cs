using Cadastro_Teleatendimento.Models;

namespace Cadastro_Teleatendimento.Data.DAO.Interface
{
  public interface IPessoaTelefone<T> : IDatabaseObject<T>
  {
    Pessoa? BuscaPorCpf(int cpf);
    bool CadastraTelefones(int Fk_Pessoa, int Fk_Telefone);
  }
}