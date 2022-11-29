using System.ComponentModel.DataAnnotations;

namespace WebApplication1.UISample.Models
{
    public class ArtistQuery
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool? isAlive { get; set; }
        public string isAliveStr { get; set; }
    }

    public class ArtistCreate
    {
        [Required]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter")]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

    }

}
