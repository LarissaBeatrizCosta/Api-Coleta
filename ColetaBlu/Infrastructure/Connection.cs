using Dapper;
using MySql.Data.MySqlClient;

namespace ColetaBlu.Infrastructure
{
    public class Connection // teste
    {
        protected string connectionString = "Server=localhost;Database=coleta_blu;User=root;Password=root;";
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        protected async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }

    }
}
