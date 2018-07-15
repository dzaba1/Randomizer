using Microsoft.AspNetCore.Identity;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    public class Role : IdentityRole<long>, INamedEntity<long>
    {
    }
}
