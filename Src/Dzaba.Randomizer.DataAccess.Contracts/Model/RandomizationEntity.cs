using System.ComponentModel.DataAnnotations.Schema;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    [Table("RandomizationEntities")]
    public class RandomizationEntity
    {
        public long EntityId { get; set; }

        public virtual Entity Entity { get; set; }

        public long RandomizationId { get; set; }

        public virtual Randomization Randomization { get; set; }
    }
}
