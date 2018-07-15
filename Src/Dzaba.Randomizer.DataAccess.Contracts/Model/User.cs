using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    public class User : IdentityUser<long>
    {
        public virtual ICollection<Randomization> Randomizations { get; set; }

        public virtual ICollection<EnvironmentUser> Environments { get; set; }
    }
}
