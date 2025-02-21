using Microsoft.AspNetCore.Mvc;
using Web_intro.DTOs.ShipperDTOs;
using Web_intro.Services;

namespace Web_intro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipperController(IShipperService shipperService) : ControllerBase
{
    private readonly IShipperService _shipperService = shipperService;

    [HttpGet]
    public IActionResult GetAll() => Ok(_shipperService.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok(_shipperService.GetShipper(id));

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id) => Ok(_shipperService.RemoveShipper(id));

    [HttpPost]
    public IActionResult Add([FromBody] AddShipperDTO addShipper) => Ok(_shipperService.AddShipper(addShipper));

}