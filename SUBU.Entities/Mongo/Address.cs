using MongoDB.Bson;
using SUBU.Entities.Base;

namespace SUBU.Entities.Mongo;


public class Address : EntityBase<ObjectId>
{
    public string Name { get; set; }
    public Location Location { get; set; }
}

public class Location
{
	public int X { get; set; }
	public int Y { get; set; }
}
