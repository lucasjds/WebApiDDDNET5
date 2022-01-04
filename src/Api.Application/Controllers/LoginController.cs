using Domain.Entities;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
  public class LoginController : ControllerBase
  {
    public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService service)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      if (userEntity == null)
        return BadRequest();

      try
      {
        var result = await service.FindByLogin(userEntity);
        if (result != null)
          return Ok(result);
        return NotFound();
      }
      catch(ArgumentException e)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

      }
    }
  }
}
