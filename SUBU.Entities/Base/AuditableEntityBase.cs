using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUBU.Entities.Base;

public class AuditableEntityBase<T> : EntityBase<T>
{
	[Column(TypeName = "timestamp with time zone")]
	[Required]
	public DateTime InsertedDate { get; set; }

	[Required]
	public int InsertedBy { get; set; }

	[Column(TypeName = "timestamp with time zone")]
	public DateTime? UpdatedDate { get; set; }

	public int? UpdatedBy { get; set; }

	[Required]
	public bool IsActive { get; set; } = true;

	[Required]
	public bool IsDeleted { get; set; }
}
