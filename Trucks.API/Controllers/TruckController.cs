using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trucks.Application.CreateTruck;
using Trucks.Application.DeleteTruck;

namespace Trucks.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TruckController(IMediator _mediator) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateTruck([FromBody] CreateTruckCommand command)
    {
        var result = await _mediator.Send(command);
        
        if(result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);            
    }
  
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTruck(Guid id)
    {
        var result = await _mediator.Send(new DeleteTruckCommand(id));
        
        if(result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);            
    }

}
