namespace SUBU.Models.diger;

public class AddressCreate
{
	public string Name { get; set; }
	public Location Location { get; set; }
}

public class Location
{
	public int X { get; set; }
	public int Y { get; set; }
}
