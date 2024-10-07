using Microsoft.AspNetCore.Mvc;
using Api.Funcionalidades.Usuario;
using System.Collections.Generic;

namespace Api.Funcionalidades.Usuario;
    
    [Route("api/[controller]")]

    [ApiController] 
    public class UsuarioEndpoints : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioEndpoints(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpPost("usuario")]
        public IActionResult CreateUser([FromBody] UsuarioCommandDto usuarioDto)
        {
            if (string.IsNullOrWhiteSpace(usuarioDto.Email) || string.IsNullOrWhiteSpace(usuarioDto.Pass))
            {
                return BadRequest("El email y la contraseña no pueden ser vacíos o nulos.");
            }

            _usuarioServices.CreateUser(usuarioDto);

            var createdUser = new UsuarioQueryDto
            {
                Email = usuarioDto.Email,
                Pass=usuarioDto.Pass,
                Estado = usuarioDto.Estado
            };

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.IdUsuario }, createdUser);
        }

        [HttpGet("usuarios")]
        public ActionResult<List<UsuarioQueryDto>> GetUsers()
        {
            var usuarios = _usuarioServices.GetUser();
            return Ok(usuarios);
        }


        [HttpGet("usuario/{id}")]
        public ActionResult<UsuarioQueryDto> GetUser(int id)
        {
            try
            {
                var usuario = _usuarioServices.GetUser(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("usuario/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UsuarioCommandDto usuarioDto)
        {
            try
            {
                if (!string.IsNullOrEmpty(usuarioDto.Nombre)) // Asumiendo que el nombre no puede modificarse
                {
                    return BadRequest("El nombre no puede ser modificado.");
                }

                _usuarioServices.UpdateUser(id, usuarioDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("usuario/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _usuarioServices.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

