using System.Data;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data.DAO
{
  public class TipoDAO : IDatabaseObject<TelefoneTipo>
  {
    private IDbConnection _connection;
    public TipoDAO()
    {
      _connection = new SqlFactory().SqlConnection();
    }
    public bool Altere(int id, TelefoneTipo tipo)
    {
      throw new NotImplementedException();
    }

    public TelefoneTipo? BuscaPorId(int id)
    {
      IEnumerable<TelefoneTipo>? tipos;
      var query =
        @"SELECT * FROM [atendimentoDB].[dbo].[Telefone_Tipo] WHERE Id_Tipo = @IdTipo";
      var parametro = new { IdTipo = id };

      using (_connection)
      {
        tipos = _connection.Query<TelefoneTipo>(query, parametro);
      }

      return tipos.First();
    }


    public bool Insira(TelefoneTipo tipo)
    {
      int result = 0;
      string query =
      @"INSERT INTO [atendimentoDB].[dbo].[Telefone_Tipo]
        VALUES
        (
          @tipoTelefone
        )
       ";
      var parametro = new { tipoTelefone = tipo.Tipo };

      using (_connection)
      {
        result = _connection.Execute(query, parametro);
      }

      return (result != 0 ? true : false);
    }

    public bool Exclua(int id)
    {
      throw new NotImplementedException();
    }

    public TelefoneTipo? UltimoInsert()
    {
      List<TelefoneTipo> tipos;
      var query =
      @"SELECT * FROM [dbo].[Telefone_Tipo] WHERE Id_Tipo = (SELECT MAX(Id_Tipo) FROM [dbo].[Telefone_Tipo])";

      using (var connection = new SqlFactory().SqlConnection())
      {
        tipos = connection.Query<TelefoneTipo>(query).ToList();
      }

      return tipos.First();
    }
  }
}