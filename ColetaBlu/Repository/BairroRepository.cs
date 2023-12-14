using ColetaBlu.Contracts.Repository;
using ColetaBlu.Entity;
using ColetaBlu.Infrastructure;
using Dapper;

namespace ColetaBlu.Repository
{
    public class BairroRepository : Connection, IBairro
    {
        public async Task<IEnumerable<BairroEntity>> Get()
        {
                string sql = "SELECT * FROM bairro ";
                return await GetConnection().QueryAsync<BairroEntity>(sql);
            
        }

    }
}
