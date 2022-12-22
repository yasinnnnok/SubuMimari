using MongoDB.Bson;
using SUBU.Entities.Base;

namespace SUBU.Entities.Mongo;

public class Category : EntityBase<ObjectId>
{
    public string Name { get; set; }
    public int ProductCount { get; set; }
    public string Description { get; set; }
    //public string Description2 { get; set; }
}
