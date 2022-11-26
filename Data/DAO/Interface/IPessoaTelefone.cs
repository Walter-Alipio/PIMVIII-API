namespace Cadastro_Teleatendimento.Data.DAO.Interface
{
  public interface IPessoaTelefone<T> : IDatabaseObject<T>
  {
    public bool CadastraTelefones(int Fk_Pessoa, int Fk_Telefone);
  }
}