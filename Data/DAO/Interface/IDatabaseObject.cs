namespace Cadastro_Teleatendimento.Data.DAO.Interface
{
  public interface IDatabaseObject<T>
  {
    bool Insira(T item);
    T? BuscaPorId(int id);
    bool Altere(int id, T item);
    bool Exclua(int id);
  }
}