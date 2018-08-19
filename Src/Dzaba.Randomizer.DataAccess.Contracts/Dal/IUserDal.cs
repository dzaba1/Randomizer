using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.Contracts.Dal
{
    public interface IUserDal
    {
        Task<long> CreateAsync(string email, string password);
    }
}
