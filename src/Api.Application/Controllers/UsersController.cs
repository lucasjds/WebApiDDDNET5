using Domain.Entities;
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
    private readonly IUserService _service;
    public UsersController(IUserService service)
    {
      _service = service;
    }

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

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserEntity userEntity)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        var result = await _service.Post(userEntity);
        if (result != null)
          return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
        return BadRequest();
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UserEntity userEntity)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        var result = await _service.Put(userEntity);
        if (result != null)
          return Ok(result);
        return BadRequest();
      }
      catch (ArgumentException ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

      }
    }

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
