using System.ComponentModel.DataAnnotations;

namespace SUBU.Models
{
    //Query->Listelemelerde kullanıyoruz.
    public class ArtistQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool? IsAlive { get; set; }
        //eksta property ekiyoruz. enum,date string dönmemiz istenebilir. 
        public string IsAliveStr
        {
            get
            {
                if (IsAlive == null)
                    return null;

                return IsAlive.Value ? "Yaşıyor" : "Ölü";
            }
        }
    }

    //Createlerde kullanmak için
    public class ArtistCreate
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
    }

    //Update için
    public class ArtistUpdate
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public bool? IsAlive { get; set; }
    }

    public class ArtistAliveUpdate
    {
        public bool? IsAlive { get; set; }
    }
}
