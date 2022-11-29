namespace SUBU.DataAccess.Base.Mongo.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CollectionAttribute : Attribute
    {
        public string Name { get; set; }

        public CollectionAttribute(string name)
        {
            Name = name;
        }
    }
}
