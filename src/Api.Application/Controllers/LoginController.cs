﻿using Domain.Dtos;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    [HttpGet]
    public async Task<object> Login([FromBody] LoginDto login, [FromServices] ILoginService service)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      if (login == null)
        return BadRequest();

      try
      {
        var result = await service.FindByLogin(login);
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