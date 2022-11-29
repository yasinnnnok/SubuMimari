using Microsoft.AspNetCore.Mvc;
using SUBU.Models;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers
{
    //[Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArtistController : MyControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistService _artistService;

        public ArtistController(ILogger<ArtistController> logger, IArtistService artistService)
        {
            _logger = logger;
            _artistService = artistService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<IEnumerable<ArtistQuery>>))]
        public IActionResult List()
        {
            return Success(_artistService.ListAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
        public IActionResult Find(int? id)
        {
            if (id == null)
                return Error(Messages.ParameterRequired);

            ArtistQuery artist = _artistService.FindById(id.Value);

            if (artist == null)
                return NotFound(Messages.NotFound);

            return Success(artist);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
        public IActionResult Create([FromBody]ArtistCreate model)
        {
            var artist = _artistService.Create(model);
            return Success(artist, "Artist oluşturuldu.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<object>))]
        public IActionResult Update(int? id, [FromBody] ArtistUpdate model)
        {
            if (id == null)
                return Error(Messages.ParameterRequired);

            if(_artistService.FindById(id.Value) == null)
                return NotFound(Messages.NotFound);

            var artist = _artistService.Update(id.Value, model);
            return Success(artist, "Artist güncellendi.");
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<object>))]
        public IActionResult UpdateAlive(int? id, [FromBody] ArtistAliveUpdate model)
        {
            if (id == null)
                return Error(Messages.ParameterRequired);

            if (_artistService.FindById(id.Value) == null)
                return NotFound(Messages.NotFound);

            var artist = _artistService.Update(id.Value, model);
            return Success(artist, "Artist durum güncellendi.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<object>))]
        public IActionResult Remove(int? id)
        {
            if (id == null)
                return Error(Messages.ParameterRequired);

            if (_artistService.FindById(id.Value) == null)
                return NotFound(Messages.NotFound);

            _artistService.Delete(id.Value);
            return Success("Artist silindi.");
        }
    }
}
