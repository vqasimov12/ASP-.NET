using Microsoft.AspNetCore.Mvc;
using Web_intro.DTOs.CustomerDtos;
using Web_intro.Entities;
using Web_intro.Services;

namespace Web_intro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;


    [HttpPost]
    public IActionResult AddCustomer([FromBody] AddDTO customer)
    {
        var a = _customerService.Add(customer);
        return Ok(a);
    }

    [HttpGet]
    public IActionResult GetAllCustomer() => Ok(_customerService.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(string id) =>
        Ok(_customerService.Get(id));

    [HttpPut]
    public IActionResult Update()
    {
        //_customerService.
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(string id) => Ok(_customerService.Delete(id));


}
