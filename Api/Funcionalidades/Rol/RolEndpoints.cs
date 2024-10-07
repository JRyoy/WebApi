namespace Api.Funcionalidades.Rol;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RolController : ControllerBase
{
    private readonly IRolServices _rolServices;

    public RolController(IRolServices rolServices)
    {
        _rolServices = rolServices;
    }

    [HttpPost]
    public IActionResult CreateRol([FromBody] RolCommandDto rolCommandDto)
    {
        _rolServices.CreateRol(rolCommandDto);
        return CreatedAtAction(nameof(GetRol), new { id = rolCommandDto.IdRol }, rolCommandDto);
    }

    [HttpGet]
    public IActionResult GetRols()
    {
        var roles = _rolServices.GetRol();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public IActionResult GetRol(int id)
    {
        var rol = _rolServices.GetRol(id);
        if (rol == null) return NotFound();
        return Ok(rol);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRol(int id, [FromBody] RolCommandDto rolCommandDto)
    {
        _rolServices.UpdateRol(id, rolCommandDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRol(int id)
    {
        _rolServices.DeleteRol(id);
        return NoContent();
    }
}
