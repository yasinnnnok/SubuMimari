using SUBU.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SUBU.Entities.EntityFramework.Database1
{
    public class Artist : EntityBase<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public bool? IsAlive { get; set; }
    }
}
