using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.Contracts.Dal
{
    public interface IUserDal
    {
        Task<long> CreateAsync(string name, string password);
    }
}
