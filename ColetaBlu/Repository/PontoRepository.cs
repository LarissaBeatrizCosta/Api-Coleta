using ColetaBlu.Contracts.Repository;
using ColetaBlu.DTO;
using ColetaBlu.Entity;
using ColetaBlu.Infrastructure;
using Dapper;

namespace ColetaBlu.Repository // teste
{
    public class PontoRepository : Connection, IPontoRepository
    {
        public async Task Add(PontoDTO ponto)
        {
            string sql = @"
              INSERT INTO ponto_de_coleta (Name, Address, Number, Residue, bairro_Id, Role)
                VALUE (@Name, @Address, @Number, @Residue, @bairro_Id, @Role)";
            await Execute(sql, ponto);
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM ponto_de_coleta  WHERE Id= @id";
            await Execute(sql, new { id });
        }

        public async Task<IEnumerable<PontoEntity>> Get()
        {
            string sql = "SELECT * FROM ponto_de_coleta ";
            return await GetConnection().QueryAsync<PontoEntity>(sql);
        }

        public async Task<PontoEntity> GetById(int id)
        {
            string sql = "SELECT * FROM ponto_de_coleta  WHERE Id = @id";
            return await GetConnection().QueryFirstAsync<PontoEntity>(sql,new { id });
        }

        public async Task<PontoTokenDTO> LogIn(PontoLoginDTO ponto)
        {
            string sql = "SELECT * FROM ponto_de_coleta  WHERE Name = @Name AND Number = @Number";
            PontoEntity pontoLogin = await GetConnection().QueryFirstAsync<PontoEntity>(sql, ponto);
            return new PontoTokenDTO
            {
                Token = Authentication.GenerateToken(pontoLogin),
                Coletor = pontoLogin
            };
        }

        public async Task Update(PontoEntity ponto)
        {
            string sql = @"
            UPDATE ponto_de_coleta 
                   SET Name=@Name,  
                       Address=@Address, 
                       Number=@Number,
                       Residue=@Residue
                       bairrro_Id = @bairro_Id,
                       Role = @Role
            WHERE ID= @Id
                       
             ";
            await Execute(sql, ponto);
        }
    }
}
