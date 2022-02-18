using Api.Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Authorization;
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
    private readonly IUserService _service;
    public UsersController(IUserService service)
    {
      _service = service;
    }

    [Authorize("Bearer")]
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        return Ok(await _service.GetAll());
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }

    [Authorize("Bearer")]
    [HttpGet]
    [Route("{id}", Name = "GetWithId")]
    public async Task<ActionResult> Get(Guid id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        return Ok(await _service.Get(id));
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }

    [Authorize("Bearer")]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDto user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        var result = await _service.Post(user);
        if (result != null)
          return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
        return BadRequest();
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }

    [Authorize("Bearer")]
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UserDto user)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        var result = await _service.Put(user);
        if (result != null)
          return Ok(result);
        return BadRequest();
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }

    [Authorize("Bearer")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        return Ok(await _service.Delete(id));
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }
  }
}
