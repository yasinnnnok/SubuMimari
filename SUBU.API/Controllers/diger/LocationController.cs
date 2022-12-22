using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SUBU.Core;
using SUBU.Models;
using SUBU.Models.diger;
using SUBU.Services.NoContext;

namespace SUBU.API.Controllers.diger;

//cache için
[NonController, ApiController, Route("[controller]")]
public class LocationController : MyControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IMemoryCache _memoryCache;

    public LocationController(ILocationService locationService, IMemoryCache memoryCache)
    {
        _locationService = locationService;
        _memoryCache = memoryCache;
    }

    [HttpGet, Route(ControllerConstants.Route.List)]
    [ResponseCache(Duration = 10, VaryByQueryKeys = new string[] { "id" })]
    //[ResponseCache(CacheProfileName = "TenSecond")]
    //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Get([FromRoute] int id)
    {
        //if (!_memoryCache.TryGetValue(CacheKeys.Weathers, out IEnumerable<WeatherForecast> weatherForecasts))
        //{
        //    weatherForecasts = _locationService.List();

        //MemoryCacheEntryOptions cacheEntryOptions
        //    = new MemoryCacheEntryOptions()
        //        .SetSlidingExpiration(TimeSpan.FromSeconds(10))
        //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
        //        .SetSize(1024);

        //    _memoryCache.Set(CacheKeys.Weathers, weatherForecasts, cacheEntryOptions);
        //}

        //return weatherForecasts;



        //var response = new ResponseResult<IEnumerable<WeatherForecast>>();
        //response.Success = true;
        //response.Messages.Add(Messages.DataListed);
        //response.Data = data;

        //return Ok(response);

        //BURADA şuan list dediğimize bakma içinde üretiyor.
        var data = _locationService.List();

        if (_locationService.IsExists("istanbul"))
        {
            return Error(Messages.CityIsExists);
        }
        else
        {
            return Success(data, Messages.DataListed, Messages.UserNotFound);
        }
    }

    [HttpDelete, Route(ControllerConstants.Route.Remove)]
    public IActionResult Remove([FromQuery(Name = ControllerConstants.Params.Id)] int id)
    {
        //_locationService.Remove();
        _memoryCache.Remove(CacheKeys.Weathers);

        return Ok();
    }
}
