using Application.CQRS.Cars.Commands.Requests;
using Application.CQRS.Cars.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] AddCarRequest request) =>
        Ok(await sender.Send(request));

    [HttpGet]
    public async Task<IActionResult> getByPriceType([FromQuery] GetCarByPriceTypeRequest request)=>
        Ok(await sender.Send(request));

    [HttpGet("{id}")]
    public async Task<IActionResult>GetById(int id)=>
        Ok(await sender.Send(new GetByIdRequest { Id = id }));  


}
