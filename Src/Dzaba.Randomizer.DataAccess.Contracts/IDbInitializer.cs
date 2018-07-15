using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.Contracts
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
    }
}
