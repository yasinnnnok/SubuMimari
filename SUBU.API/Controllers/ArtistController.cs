using Microsoft.AspNetCore.Mvc;
using SUBU.API.Controllers.diger;
using SUBU.Models;
using SUBU.Models.diger;
using SUBU.Services.EntityFramework.Managers;

namespace SUBU.API.Controllers;

//[Authorize]
[ApiController, Route("[controller]")]
//MyControllerBase->Data Result yapısı ekliyor.
public class ArtistController : MyControllerBase
{
    // private readonly ILogger<ArtistController> _logger;
    private readonly IArtistService _artistService;

    public ArtistController(ILogger<ArtistController> logger, IArtistService artistService)
    {
        //  _logger = logger;
        _artistService = artistService;
    }

    [HttpGet, Route(ControllerConstants.Route.List)]
    //Bu şekilde yazarsak swagger'da ne döenceğimizi belirtmiş oluyoruz.
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<IEnumerable<ArtistQuery>>))]
    public IActionResult List()
    {
        return Success(_artistService.ListAll());
    }


    [HttpGet, Route(ControllerConstants.Route.Find)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
    public IActionResult Find([FromQuery(Name = ControllerConstants.Params.Id)] int? id)
    {
        //id null geldiyse uyarı dönelim
        if (id == null)
            return Error(Messages.ParameterRequired);

        //kaydı bulalım
        ArtistQuery artist = _artistService.FindById(id.Value);

        //bu id li kayıt yoksa kayıt bulunamadı dönelim.
        if (artist == null)
            return NotFound(Messages.NotFound);
        //başarılı,kaydıda dönelim
        return Success(artist);
    }

	[HttpPost, Route(ControllerConstants.Route.Create)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
    public IActionResult Create([FromBody] ArtistCreate model)
    {
        var artist = _artistService.Create(model);
        return Success(artist, "Artist oluşturuldu.");
    }

    
	[HttpPut, Route(ControllerConstants.Route.Update)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<object>))]
    public IActionResult Update([FromQuery(Name = ControllerConstants.Params.Id)] int? id, [FromBody] ArtistUpdate model)
    {
        if (id == null)
            return Error(Messages.ParameterRequired);

        if (_artistService.FindById(id.Value) == null)
            return NotFound(Messages.NotFound);

        var artist = _artistService.Update(id.Value, model);
        return Success(artist, "Artist güncellendi.");
    }

	[HttpPatch, Route(ControllerConstants.Route.UpdateAlive)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<ArtistQuery>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<object>))]
    public IActionResult UpdateAlive([FromQuery(Name = ControllerConstants.Params.Id)] int? id, [FromBody] ArtistAliveUpdate model)
    {
        if (id == null)
            return Error(Messages.ParameterRequired);

        if (_artistService.FindById(id.Value) == null)
            return NotFound(Messages.NotFound);

        var artist = _artistService.Update(id.Value, model);
        return Success(artist, "Artist durum güncellendi.");
    }

	[HttpDelete, Route(ControllerConstants.Route.Remove)]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<object>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseResult<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseResult<object>))]
    public IActionResult Remove([FromQuery(Name = ControllerConstants.Params.Id)] int? id)
    {
        if (id == null)
            return Error(Messages.ParameterRequired);

        if (_artistService.FindById(id.Value) == null)
            return NotFound(Messages.NotFound);

        _artistService.Delete(id.Value);
        return Success("Artist silindi.");
    }
}
