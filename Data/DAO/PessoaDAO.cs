using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.PessoaDTO;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data.DAO
{
  public class PessoaDAO : IPessoaTelefone<Pessoa>
  {
    public bool Altere(int id, Pessoa item)
    {
      throw new NotImplementedException();
    }

    public Pessoa? BuscaPorId(int id)
    {
      throw new NotImplementedException();
    }

    public bool Exclua(int id)
    {
      throw new NotImplementedException();
    }

    public bool Insira(Pessoa item)
    {
      int result = 0;
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

      return (result != 0 ? true : false);
    }

    public bool CadastraTelefones(int Fk_Pessoa, int Fk_Telefone)
    {
      int result = 0;
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

      return (result != 0 ? true : false);

    }

    public Pessoa? UltimoInsert()
    {
      Pessoa tel;
      var query =
      @"SELECT Id_Pessoa, Nome, Cpf, 
        [dbo].Endereco.Id_Endereco, [dbo].[Endereco].Logradouro,
        [dbo].Endereco.Numero, [dbo].Endereco.Bairro, [dbo].Endereco.Cep,
        [dbo].[Endereco].Cidade, [dbo].Endereco.Estado
      FROM [dbo].[Pessoa]
        INNER JOIN [dbo].Endereco ON Fk_Endereco = Id_Endereco

      WHERE Id_Pessoa = (SELECT MAX(Id_Pessoa) FROM [dbo].[Pessoa]);";

      using (var connection = new SqlFactory().SqlConnection())
      {
        var resultado = connection.Query<PessoaDatabaseDto>(query);
        tel = converteParaPessoa(resultado);
      }

      return tel;
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