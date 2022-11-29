using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Ozet.Models
{
    public class AlbumCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
