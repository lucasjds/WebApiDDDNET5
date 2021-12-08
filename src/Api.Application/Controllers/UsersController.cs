using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult> GetAll([FromServices] IUserService service)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        return Ok(await service.GetAll());
      }
      catch(ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }
    
  }
}
