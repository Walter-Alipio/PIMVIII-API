using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data.DAO
{
  public class EnderecoDAO : IDatabaseObject<Endereco>
  {
    public bool Altere(int id, Endereco item)
    {
      throw new NotImplementedException();
    }

    public Endereco? BuscaPorId(int id)
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

    public bool Exclua(int id)
    {
      throw new NotImplementedException();
    }

    public bool Insira(Endereco item)
    {
      int result = 0;
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

      return (result != 0 ? true : false);
    }

    public Endereco? UltimoInsert()
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
  }
}