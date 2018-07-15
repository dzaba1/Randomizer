using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    [Table("Environments")]
    public class Environment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<EnvironmentUser> Users { get; set; }
    }
}
