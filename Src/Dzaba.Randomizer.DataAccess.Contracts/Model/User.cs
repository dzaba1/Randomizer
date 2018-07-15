using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    public class User : IdentityUser<long>, INamedEntity<long>
    {
        public virtual ICollection<Randomization> Randomizations { get; set; }

        public virtual ICollection<EnvironmentUser> Environments { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }
        }
    }
}
