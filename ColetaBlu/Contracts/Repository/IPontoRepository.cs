using ColetaBlu.DTO;
using ColetaBlu.Entity;

namespace ColetaBlu.Contracts.Repository
{
    public interface IPontoRepository
    {
        Task Add(PontoDTO ponto);
        Task Update(PontoEntity ponto);
        Task Delete(int id);
        Task<PontoEntity> GetById(int id);
        Task<IEnumerable<PontoEntity>> Get();

        Task<PontoTokenDTO> LogIn(PontoLoginDTO ponto);
    }
}

