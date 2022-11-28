using System.Data.SqlTypes;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data.DAO
{
  public class PessoaDAO : IPessoaTelefone<Pessoa>
  {

    public bool Altere(Pessoa pessoa)
    {
      int result = 0;
      try
      {
        var query =
      @"
        UPDATE [dbo].Pessoa
        SET Nome = @Nome, Cpf = @Cpf, Fk_Endereco = @FkEndereco
        WHERE Id_Pessoa = @IdPessoa;
      ";
        var parametro =
        new
        {
          Nome = pessoa.Nome,
          Cpf = pessoa.Cpf,
          FkEndereco = pessoa.Fk_Endereco,
          IdPessoa = pessoa.Id_Pessoa
        };
        using (var connection = new SqlFactory().SqlConnection())
        {
          result = connection.Execute(query, parametro);
        }
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
      }
      return (result != 0 ? true : false);
    }

    public Pessoa? BuscaPorCpf(int Cpf)
    {
      Pessoa? pessoa;
      var query =
        @"SELECT * 
          FROM [dbo].[Pessoa] 
          WHERE Cpf = @cpf;";
      var parametro = new { cpf = Cpf };
      try
      {
        using (var connection = new SqlFactory().SqlConnection())
        {
          IEnumerable<Pessoa>? resultado;

          resultado = connection.Query<Pessoa>(query, parametro);
          pessoa = resultado.SingleOrDefault();
          if (pessoa == null) return null;
        }
        pessoa.endereco = BuscaEndereco(pessoa.Fk_Endereco);
        pessoa.Telefone = BuscaTelefone(pessoa.Id_Pessoa);
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return null;
      }
      return pessoa;
    }
    public bool Exclua(int id)
    {
      int result = 0;
      try
      {
        var query =
             @"
              DELETE FROM [dbo].Pessoa_Telefone WHERE Fk_Pessoa = @IdPessoa;
              DELETE FROM [dbo].Pessoa WHERE Id_Pessoa = @IdPessoa;
            ";
        var parametro = new { IdPessoa = id };

        using (var connection = new SqlFactory().SqlConnection())
        {
          result = connection.Execute(query, parametro);
        }
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("");
        System.Console.WriteLine(e.StackTrace);
      }
      return (result != 0 ? true : false);
    }
    public bool Insira(Pessoa item)
    {
      int result = 0;
      try
      {
        string query =
        @"INSERT INTO [atendimentoDB].[dbo].[Pessoa]
          VALUES
          (
            @nome,
            @cpf,
            @fkEndereco
          )
        ";
        var parametro = new
        {
          nome = item.Nome,
          cpf = item.Cpf,
          fkEndereco = item.Fk_Endereco
        };

        using (var connection = new SqlFactory().SqlConnection())
        {
          result = connection.Execute(query, parametro);
        }
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("");
        System.Console.WriteLine(e.StackTrace);
      }


      return (result != 0 ? true : false);
    }
    public bool CadastraTelefones(int Fk_Pessoa, int Fk_Telefone)
    {
      int result = 0;
      try
      {
        string query =
        @"INSERT INTO [atendimentoDB].[dbo].[Pessoa_Telefone]
          VALUES
          (
            @idPessoa,
            @idTelefone
          )
         ";
        var parametro = new
        {
          idPessoa = Fk_Pessoa,
          idTelefone = Fk_Telefone
        };

        using (var connection = new SqlFactory().SqlConnection())
        {
          result = connection.Execute(query, parametro);
        }

      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine("");
        System.Console.WriteLine(e.StackTrace);
      }

      return (result != 0 ? true : false);
    }


    private List<Telefone>? BuscaTelefone(int Id_Pessoa)
    {
      try
      {
        List<Telefone> telefones;
        var query =
          @"
        SELECT 
            [dbo].[Telefone].Id_Telefone,
            [dbo].[Telefone].[DDD],
            [dbo].[Telefone].[Numero],
            [dbo].Telefone.Fk_Tipo,
            [dbo].Telefone_Tipo.Id_Tipo,
            [dbo].[Telefone_Tipo].[Tipo]
        FROM [dbo].[Pessoa_Telefone]
            INNER JOIN  [dbo].[Telefone] ON Id_Telefone = Fk_Telefone
            INNER JOIN [dbo].[Telefone_Tipo] ON Id_Tipo = Fk_Tipo
        WHERE Fk_Pessoa = @IdPessoa;
        ";

        var parametro = new { IdPessoa = Id_Pessoa };

        using (var connection = new SqlFactory().SqlConnection())
        {
          var resultado = connection.Query<TelDatabaseDto>(query, parametro);

          telefones = converteParaListaTelefone(resultado);
        }
        return telefones;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return null;
      }

    }
    private List<Telefone> converteParaListaTelefone(IEnumerable<TelDatabaseDto> resultado)
    {
      List<Telefone> telefones = new();
      foreach (var item in resultado)
      {
        telefones.Add(
          new Telefone()
          {
            Id_Telefone = item.Id_Telefone,
            DDD = item.DDD,
            Fk_Tipo = item.Fk_Tipo,
            Numero = item.Numero,
            Tipo = new TelefoneTipo() { Id_Tipo = item.Id_Tipo, Tipo = item.Tipo }
          }
        );
      }
      return telefones;
    }
    private Endereco? BuscaEndereco(int Id_Endereco)
    {
      try
      {
        Endereco endereco;
        var query =
        @"
        SELECT * FROM [dbo].[Endereco] WHERE Id_Endereco = @IdEnd;
      ";
        var parametro = new { IdEnd = Id_Endereco };

        using (var connection = new SqlFactory().SqlConnection())
        {
          var resultado = connection.Query<Endereco>(query, parametro);

          endereco = resultado.First();
        }

        return endereco;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.StackTrace);
        return null;
      }
    }
    private Pessoa converteParaPessoa(IEnumerable<PessoaDatabaseDto> resultado)
    {
      var pessoa = resultado.FirstOrDefault();

      return new Pessoa()
      {
        Id_Pessoa = pessoa.Id_Pessoa,
        Nome = pessoa.Nome,
        Cpf = pessoa.Cpf,
        Fk_Endereco = pessoa.Id_Endereco,
        endereco = new Endereco()
        {
          Id_Endereco = pessoa.Id_Endereco,
          Logradouro = pessoa.Logradouro,
          Numero = pessoa.Numero,
          Cep = pessoa.Cep,
          Bairro = pessoa.Bairro,
          Cidade = pessoa.Cidade,
          Estado = pessoa.Estado
        }
      };
    }
  }

}