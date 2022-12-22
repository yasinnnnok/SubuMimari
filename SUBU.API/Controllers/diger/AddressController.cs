using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUBU.Core.Extensions;
using SUBU.Entities.Mongo;
using SUBU.Models;
using SUBU.Models.diger;
using SUBU.Services.Mongo.Managers;
using System.Security.Claims;

namespace SUBU.API.Controllers.diger;


[NonController, ApiController, Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _AddressService;

    public AddressController(IAddressService AddressService)
    {
        _AddressService = AddressService;
    }

    [HttpGet, Route(ControllerConstants.Route.List)]
    public IActionResult Get()
    {
        return Ok(_AddressService.List());
    }


    [HttpPost, Route(ControllerConstants.Route.Create)]
    public IActionResult Create([FromBody] AddressCreate model)
    {
        return Ok(_AddressService.Create(
            new Address
            {
                Name = model.Name,
                //Location = model.Location
            }));
    }
}