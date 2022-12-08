using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;
using SUBU.Models.diger;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        // Service Unit Of Work Generic
        private readonly IAlbumServiceUow2 _albumService;


        public AlbumController(IAlbumServiceUow2 albumService, ISongService songService)
        {
            _albumService = albumService;
            _songService = songService;
        }

        // Service Base
        //private readonly IAlbumServiceBase _albumService;
        //public AlbumController(IAlbumServiceBase albumService, ISongService songService)
        //{
        //    _albumService = albumService;
        //    _songService = songService;
        //}

        // Service Quick
        //private readonly IAlbumServiceQuick _albumService;
        //public AlbumController(IAlbumServiceQuick albumService, ISongService songService)
        //{
        //    _albumService = albumService;
        //    _songService = songService;
        //}

        // Service Unit Of Work
        //private readonly IAlbumServiceUow _albumService;
        //public AlbumController(IAlbumServiceUow albumService, ISongService songService)
        //{
        //    _albumService = albumService;
        //    _songService = songService;
        //}



        [HttpGet]
        public IActionResult Get()
        {
            //Bana albumQuery olarak dön listeyi(Generic metod kullan)
            return Ok(_albumService.List<AlbumQuery>());
        }

        [HttpPost]
        public IActionResult Create([FromBody] AlbumCreate model)
        {

            //metod seviyesinde kontrol
            //if (_albumService.IsNewAlbumNameEqualTest(model.Name))

            //var result = _albumService.IsNewAlbumNameEqualTest3(model.Name);
            //if (result.Valid == false)
            //{

            //    ModelState.AddModelError(nameof(model.Name), result.ErrorMessage);
            //    return BadRequest(ModelState);
            //}


            // Service Base
            //
            //Album album = _albumService.Create(model);
            //_albumService.Save();


            // Service Quick
            //
            Album album = _albumService.Create(model);

            //Þarkýyýda parametre almak istersek. Yeni bir model yapabiliriz. AlbumCreateve SongCreate i barýndýran.
            Song song = _songService.Create(
                new SongCreate() { Title = "song", Duration = 100, AlbumId = album.Id });

            //return Created("", album); -
            //Burada Album entitysini dönmüyoruz. JsonSerialize yaparken hata veriyor. Entitylerde iliþkiler olduðu için döngüye giriyor.
            return Ok(_albumService.Find<AlbumQuery>(album.Id));
        }
    }
}