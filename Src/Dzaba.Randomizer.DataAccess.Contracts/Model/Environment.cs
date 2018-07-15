using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    [Table("Environments")]
    public class Environment : INamedEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<EnvironmentUser> Users { get; set; }

        public Randomizer.Contracts.Environment ToContract()
        {
            return new Randomizer.Contracts.Environment
            {
                Id = Id,
                Name = Name,
                Groups = Groups.ToGroupsNavigation(),
                Users = Users.Select(u => u.User).ToUsersNavigation()
            };
        }
    }
}
