using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.Contracts.Dal
{
    public interface IEnvironmentDal
    {
        Task<Randomizer.Contracts.Environment[]> GetAllAsync();
        Task<Randomizer.Contracts.Environment> GetAsync(int id);
        Task<int> Create(string name, long creatorId);
    }
}
