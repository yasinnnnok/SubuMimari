using SUBU.Entities.Base;

namespace SUBU.Entities.EntityFramework.Database1
{
    public class Song : EntityBase<int>
    {
        public string Title { get; set; }
        public int? Duration { get; set; }
        public int AlbumId { get; set; }

        //[ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }
    }
}
