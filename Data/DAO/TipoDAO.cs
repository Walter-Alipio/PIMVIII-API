using System.Data;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data.DAO
{
  public class TipoDAO : IDatabaseObject<TelefoneTipo>
  {
    public bool Altere(int id, TelefoneTipo tipo)
    {
      int result = 0;
      try
      {
        var query =
        @"
          UPDATE [dbo].Telefone_Tipo
          SET Tipo = @Tipo
          WHERE Id_Tipo = @IdTipo;
        ";
        var parametro = new { Tipo = tipo.Tipo, IdTipo = id };
        using (var connection = new SqlFactory().SqlConnection())
        {
          result = connection.Execute(query, parametro);
        }
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(" ");
        System.Console.WriteLine(e.StackTrace);
      }

      return (result != 0 ? true : false);
    }

    public TelefoneTipo? BuscaPorId(int id)
    {
      IEnumerable<TelefoneTipo>? tipos;
      try
      {
        var query =
       @"SELECT * FROM [atendimentoDB].[dbo].[Telefone_Tipo] WHERE Id_Tipo = @IdTipo";
        var parametro = new { IdTipo = id };

        using (var connection = new SqlFactory().SqlConnection())
        {
          tipos = connection.Query<TelefoneTipo>(query, parametro);
        }

        return tipos.First();
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("");
        System.Console.WriteLine(e.StackTrace);
        return null;
      }
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

      using (var connection = new SqlFactory().SqlConnection())
      {
        result = connection.Execute(query, parametro);
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