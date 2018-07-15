using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    [Table("Entities")]
    public class Entity : INamedEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(64)]
        public string Name { get; set; }

        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<RandomizationEntity> Randomizations { get; set; }

        public virtual ICollection<Randomization> Wins { get; set; }
    }
}
