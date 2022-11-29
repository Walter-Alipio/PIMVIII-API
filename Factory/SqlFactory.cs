using System.Data;
using Microsoft.Data.SqlClient;

namespace Cadastro_Teleatendimento.Factory
{
  public class SqlFactory
  {
    public IDbConnection SqlConnection()
    {
      return new SqlConnection(
        @"Data Source=localhost;Initial Catalog=atendimentoDB;
        Integrated Security=true; User=sa; Password=00a2855d183e5d52ec8e36fEE6cdeb50;
        Trusted_Connection=False; TrustServerCertificate=True;"
      );
    }
  }
}