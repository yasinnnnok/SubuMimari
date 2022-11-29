using System.ComponentModel.DataAnnotations;

namespace SUBU.Models
{
    public class SongCreate
    {
        [Required]
        public string Title { get; set; }
        public int? Duration { get; set; }

        [Required]
        public int AlbumId { get; set; }
    }


    //Controllerda Geri dönüş modeli. (Response modeli-ilişkisiz modeller )
    public class SongQuery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Duration { get; set; }
        public int AlbumId { get; set; }
    }
}