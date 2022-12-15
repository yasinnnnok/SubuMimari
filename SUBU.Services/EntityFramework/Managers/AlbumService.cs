using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models.diger;
//En basit yapımız. SAVE siz hali.. Herşeyi kendimiz yazıyoruz. interfaceler metodlar vs.
//Daha çok özelleşitirilmişlerde bunu kullanıyoruz.
namespace SUBU.Services.EntityFramework.Managers
{
    public interface IAlbumService
    {
        Album Create(AlbumCreate model);
        AlbumQuery Find(int id);
        T Create<T>(AlbumCreate model);
        int Save();


        //bool IsNewAlbumNameEqualTest(string name);
     
        (string ErrorMessage, bool Valid) IsNewAlbumNameEqualTest3(string name);
        //IEnumerable<Album> GetTestData();
    }

    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        //metod : sadece gelen veriyi trufalse dönüyor.(Bu tür metodlar kullanarak kontrollermizi yaptıraabiliriz.)
        //public bool IsNewAlbumNameEqualTest(string name)
        //{
        //    return name == "test" ? true : false;
        //}

        

        //yeni tuplle kullanımı
         //geri dönüş tiplerimizi kullanabiliyoruz (string ErrorMessage, bool Valid) 
        public (string ErrorMessage, bool Valid) IsNewAlbumNameEqualTest3(string name)
        {
            bool valid = name == "test" ? false : true;

            (string ErrorMessage, bool Valid) result = ("Albüm adı test olamaz", valid);

            return result;
        }

        public IEnumerable<Album> GetTestData()
        {
           //Quarble metoduna eklemiştik. "Select * from" gibi.Direk kullanabiliriz. Ama komplex bir işlem ise metodu ayrıca ekleyebilriz.
            return _albumRepository.Queryable().Where(x => x.Name == "test");
           //ek metodda yazabiliriz.
            // return _albumRepository.GetTestAlbum();

        }

        public Album Create(AlbumCreate model)
        {
            //Album album = new Album();
            //album.Name = model.Name;
            //album.Description = model.Description;
            
            Album album = _albumRepository.Add(_mapper.Map<Album>(model));

            return album;
        }

        //Create in generic hali. Dönüş modeli ne geliyorsa ona çevir.
        public T Create<T>(AlbumCreate model)
        {
            Album album = _albumRepository.Add(_mapper.Map<Album>(model));

            return _mapper.Map<T>(album);
        }

        //Save işlemini ayırdık. Bir action içinde albume ve songa ekleme yapabilirz. Tek transciton olması için.
        public int Save()
        {
             return _albumRepository.Save();
        }

        //ALbumQuery dönecek ama DataAccess katmanına Album entitysini gönderecek.
        //Dönüş AlbumQuery olacağı için map liyoruz.
        public AlbumQuery Find(int id)
        {
            Album album = _albumRepository.Get(id);
            return _mapper.Map<AlbumQuery>(album);
        }
    }
}
