using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data.DAO
{
  public class EnderecoDAO : IDatabaseObject<Endereco>
  {
    public bool Altere(int id, Endereco endereco)
    {
      int result = 0;
      try
      {
        var query =
        @"
          UPDATE [dbo].[Endereco]
          SET Logradouro = @Logradouro, Numero = @Numero, Cep = @Cep, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado
          WHERE Id_Endereco = @Id;
        ";
        var parametro = new
        {
          Id = id,
          Logradouro = endereco.Logradouro,
          Numero = endereco.Numero,
          Cep = endereco.Cep,
          Bairro = endereco.Bairro,
          Cidade = endereco.Cidade,
          Estado = endereco.Estado
        };
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

    public Endereco? BuscaPorId(int id)
    {
      try
      {
        Endereco tel;
        var query =
          @"SELECT * 
          FROM [dbo].[Endereco] 
          WHERE Id_Endereco = @IdEnd;";
        var parametro = new { IdEnd = id };

        using (var connection = new SqlFactory().SqlConnection())
        {
          var resultado = connection.Query<Endereco>(query, parametro);

          tel = resultado.First();
        }

        return tel;
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(" ");
        System.Console.WriteLine(e.StackTrace);
        return null;
      }
    }

    public bool Exclua(int id)
    {
      throw new NotImplementedException();
    }

    public bool Insira(Endereco item)
    {
      int result = 0;
      try
      {
        string query =
          @"INSERT INTO [atendimentoDB].[dbo].[Endereco]
              VALUES
              (
                @logradouro,
                @numero,
                @cep,
                @bairro,
                @cidade,
                @estado
              )
          ";
        var parametro = new
        {
          @logradouro = item.Logradouro,
          @numero = item.Numero,
          @cep = item.Cep,
          @bairro = item.Bairro,
          @cidade = item.Cidade,
          @estado = item.Estado
        };

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

    public Endereco? UltimoInsert()
    {
      try
      {
        Endereco endereco;
        var query =
        @"SELECT * FROM [dbo].[Endereco]
          WHERE Id_Endereco = (SELECT MAX(Id_Endereco) FROM [dbo].[Endereco])";

        using (var connection = new SqlFactory().SqlConnection())
        {
          var resultado = connection.Query<Endereco>(query);
          endereco = resultado.First();
        }

        return endereco;
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(" ");
        System.Console.WriteLine(e.StackTrace);
        return null;
      }
    }
  }
}