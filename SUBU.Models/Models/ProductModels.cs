using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Models;


public class ProductQuery
{
    public int Id { get; set; }
    public string? Name { get; set; }
	public string? SerialNumber { get; set; }
	public string? Brand { get; set; }
	public string? Model { get; set; }
	public string? Category { get; set; }
	public bool State { get; set; }
}

public class ProductCreate
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

public class ProductUpdate
{
	[Required]
	public string? Name { get; set; }

	[Required]
	public string? SerialNumber { get; set; }
}