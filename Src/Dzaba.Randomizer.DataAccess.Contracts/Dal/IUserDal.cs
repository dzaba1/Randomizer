using Dzaba.Randomizer.DataAccess.Contracts.Model;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.Contracts.Dal
{
    public interface IUserDal
    {
        Task<User> CreateAsync(string email, string password);
        Task<User> GetUserByNameAsync(string name);
    }
}
