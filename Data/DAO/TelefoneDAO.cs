
using AutoMapper;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Data.DTOs.TelefoneDTO;
using Cadastro_Teleatendimento.Factory;
using Cadastro_Teleatendimento.Models;
using Dapper;

namespace Cadastro_Teleatendimento.Data
{
  public class TelefoneDAO : IDatabaseObject<Telefone>
  {
    private IMapper _mapper;

    public TelefoneDAO(IMapper mapper)
    {
      _mapper = mapper;
    }

    public bool Altere(int id, Telefone item)
    {
      throw new NotImplementedException();
    }

    public Telefone? BuscaPorId(int id)
    {
      Telefone tel;
      var query =
        @"SELECT * 
          FROM [dbo].[Telefone] 
          INNER JOIN [dbo].Telefone_Tipo ON Fk_Tipo = Id_Tipo WHERE Id_Telefone = @IdTel;";
      var parametro = new { IdTel = id };

      using (var connection = new SqlFactory().SqlConnection())
      {
        var resultado = connection.Query<TelDatabaseDto>(query, parametro);

        tel = converteParaTelefone(resultado);
      }

      return tel;
    }

    public bool Exclua(int id)
    {
      throw new NotImplementedException();
    }

    public bool Insira(Telefone item)
    {
      int result = 0;
      string query =
      @"INSERT INTO [atendimentoDB].[dbo].[Telefone]
        VALUES
        (
          @numeroTelefone,
          @dddTelefone,
          @fkTipo
        )
       ";
      var parametro = new
      {
        numeroTelefone = item.Numero,
        dddTelefone = item.DDD,
        fkTipo = item.Fk_Tipo
      };

      using (var connection = new SqlFactory().SqlConnection())
      {
        result = connection.Execute(query, parametro);
      }

      return (result != 0 ? true : false);
    }

    public Telefone? UltimoInsert()
    {
      Telefone tel;
      var query =
      @"SELECT * FROM [dbo].[Telefone]
        INNER JOIN [dbo].Telefone_Tipo on Fk_Tipo = Id_Tipo
        WHERE Id_Telefone = (SELECT MAX(Id_Telefone) FROM [dbo].[Telefone])";

      using (var connection = new SqlFactory().SqlConnection())
      {
        var resultado = connection.Query<TelDatabaseDto>(query);
        tel = converteParaTelefone(resultado);
      }

      return tel;
    }

    private Telefone converteParaTelefone(IEnumerable<TelDatabaseDto> resultado)
    {
      var novoTel = resultado.First();
      return new Telefone()
      {
        Id_Telefone = novoTel.Id_Telefone,
        DDD = novoTel.DDD,
        Numero = novoTel.Numero,
        Fk_Tipo = novoTel.Fk_Tipo,
        Tipo = new TelefoneTipo() { Id_Tipo = novoTel.Id_Tipo, Tipo = novoTel.Tipo }
      };
    }
  }

}