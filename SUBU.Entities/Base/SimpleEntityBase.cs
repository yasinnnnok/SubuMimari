using System.ComponentModel.DataAnnotations;

namespace SUBU.Entities.Base;

public class SimpleEntityBase<T> : EntityBase<T>
{
	[Required]
	public bool IsActive { get; set; } = true; //Default

	[Required]
	public bool IsDeleted { get; set; }
}
