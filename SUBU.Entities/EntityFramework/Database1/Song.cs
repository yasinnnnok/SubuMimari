using SUBU.Entities.Base;

namespace SUBU.Entities.EntityFramework.Database1
{
    public class Song : EntityBase<int>
    {
        public string Title { get; set; }
        public int? Duration { get; set; }

        //Burada Album ve AlbumId yi girdiğinde otomatik ForeignKey yapıyor aslında.//Navigation Property
        //Ama biz yyinede ForeignKey belirtebilriz.
        public int AlbumId { get; set; }
                
        //[ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }


        
    }
}
