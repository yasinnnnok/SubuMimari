using SUBU.Entities.Base;
using SUBU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Entities.EntityFramework.Database1;

public class Product : EntityBase<int>
{
	[Required]
	public string? Name { get; set; }
	
	[Required]
	public string? SerialNumber { get; set; }
	public string? Brand { get; set; }
	public string? Model { get; set; }
	public string? Category { get; set; }
	public bool State { get; set; }
}
