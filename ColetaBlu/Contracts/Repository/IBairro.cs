using ColetaBlu.Entity;

namespace ColetaBlu.Contracts.Repository
{
    public interface IBairro
    {
        Task<IEnumerable<BairroEntity>> Get();
    }
}
