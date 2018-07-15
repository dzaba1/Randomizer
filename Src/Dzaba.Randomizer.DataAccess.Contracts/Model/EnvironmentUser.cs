using System.ComponentModel.DataAnnotations.Schema;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    [Table("EnvironmentUsers")]
    public class EnvironmentUser
    {
        public int EnvironmentId { get; set; }

        public virtual Environment Environment { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
