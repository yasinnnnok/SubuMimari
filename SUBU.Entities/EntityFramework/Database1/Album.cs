using SUBU.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUBU.Entities.EntityFramework.Database1;

public class Album : EntityBase<int>
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
}
