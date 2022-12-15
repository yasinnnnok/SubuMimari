using System.ComponentModel.DataAnnotations;

namespace SUBU.Models.diger
{
    //Entityleri sadece DataAcces katmanı kullanır.
    //..Create leri UI katmanı controller'a parametre alırken kullanır.
    //..Query ise controllerda 

    //Controllerda entity kulanmıyoruz. Entitiyler modelere çevirmemiz lazım.Bu classlara mapliyoruz.
    public class AlbumCreate
    {
        [Display(Name = "Albüm adı")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [StringLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir.")]
        public string Name { get; set; }

        [Display(Name = "Albüm açıklama")]
        [StringLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir.")]
        public string Description { get; set; }
    }

    //Geri dönüş modeli.İLİŞKİSİZ MODELLER Parametre almayıp sadece contollerda bunu dönüyoruz.
    //Entityleri return edersek ilişkilerden dolayı JsonDeserialize hatası veriyor.
    public class AlbumQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //ilişki yok. Bunun için bu liste var diyoruz.
        public List<SongQuery> Songs { get; set; }
    }

    //Bu model Controllerda iki parametre almak istersen FromBody 2 tane kullanamazsın.
    //2 parametreyi birleştirmek için yapıldı.
    public class AlbumCreateWithSong
    {
        public AlbumCreate Album { get; set; }
        public SongCreate Song { get; set; }
    }
}