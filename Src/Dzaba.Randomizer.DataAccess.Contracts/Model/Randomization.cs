using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dzaba.Randomizer.DataAccess.Contracts.Model
{
    [Table("Randomizations")]
    public class Randomization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Long { get; set; }

        public DateTime TimeStamp { get; set; }

        public long IvokerId { get; set; }

        public virtual User Invoker { get; set; }

        public long WinnerId { get; set; }

        public virtual Entity Winner { get; set; }

        public virtual ICollection<RandomizationEntity> Entites { get; set; }
    }
}
