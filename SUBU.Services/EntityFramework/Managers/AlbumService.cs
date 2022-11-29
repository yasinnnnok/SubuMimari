using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;

namespace SUBU.Services.EntityFramework.Managers
{
    public interface IAlbumService
    {
        Album Create(AlbumCreate model);
        AlbumQuery Find(int id);
        T Create<T>(AlbumCreate model);
        int Save();


        //bool IsNewAlbumNameEqualTest(string name);
        //Tuple<string, bool> IsNewAlbumNameEqualTest2(string name);
        //(string ErrorMessage, bool Valid) IsNewAlbumNameEqualTest3(string name);
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

        //metod : sadece gelen veriyi trufalse dönüyor
        //public bool IsNewAlbumNameEqualTest(string name)
        //{
        //    return name == "test" ? true : false;
        //}

        //public Tuple<string, bool> IsNewAlbumNameEqualTest2(string name)
        //{
        //    bool isNameTest = name == "test" ? true : false;
            
        //    Tuple<string, bool> result = 
        //        new Tuple<string, bool>("Albüm adı test olamaz", isNameTest);

        //    return result;
        //}

        //public (string ErrorMessage, bool Valid) IsNewAlbumNameEqualTest3(string name)
        //{
        //    bool valid = name == "test" ? false : true;

        //    (string ErrorMessage, bool Valid) result = ("Albüm adı test olamaz", valid);

        //    return result;
        //}

        //public IEnumerable<Album> GetTestData()
        //{
        //    //return _albumRepository.Queryable().Where(x => x.Name == "test");
        //    return _albumRepository.GetTestAlbum();
        //}

        public Album Create(AlbumCreate model)
        {
            //Album album = new Album();
            //album.Name = model.Name;
            //album.Description = model.Description;
            
            Album album = _albumRepository.Add(_mapper.Map<Album>(model));

            return album;
        }

        public T Create<T>(AlbumCreate model)
        {
            Album album = _albumRepository.Add(_mapper.Map<Album>(model));

            return _mapper.Map<T>(album);
        }

        public int Save()
        {
             return _albumRepository.Save();
        }

        public AlbumQuery Find(int id)
        {
            Album album = _albumRepository.Get(id);
            return _mapper.Map<AlbumQuery>(album);
        }
    }
}
