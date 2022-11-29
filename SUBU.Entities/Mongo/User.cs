using MongoDB.Bson;
using SUBU.Entities.Base;

namespace SUBU.Entities.Mongo
{
    public class User : EntityBase<ObjectId>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
