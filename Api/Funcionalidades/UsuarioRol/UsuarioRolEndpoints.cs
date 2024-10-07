using Api.Funcionalidades.Usuario;
using Api.Funcionalidades.Rol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Api.Migraciones;
using Entidades;
using static Api.Funcionalidades.UsuarioRol.UsuarioRolDto;
namespace Api.Funcionalidades.UsuarioRol;

[ApiController]
[Route("api/[controller]")]
public class UsuarioRolEndpoints : ControllerBase
{

        private readonly IUsuarioRolServices _usuarioRolServices;

        public UsuarioRolEndpoints(IUsuarioRolServices usuarioRolServices)
        {
            _usuarioRolServices = usuarioRolServices;
        }

        [HttpPost("{idRol}/usuario/{idUsuario}")]
        public IActionResult AgregarUsuarioRol(int idRol, int idUsuario)
        {
            try
            {
                var usuarioRolDto = new UsuarioRolCommandDto { IdUsuario = idUsuario, IdRol = idRol };
                _usuarioRolServices.AsignarRol(usuarioRolDto);
                return Ok("Rol asignado correctamente");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{idRol}/usuario/{idUsuario}")]
        public IActionResult EliminarUsuarioRol(int idRol, int idUsuario)
        {
            try
            {
                _usuarioRolServices.DeleteRoldelUsuario(idUsuario, idRol);
                return Ok("Rol eliminado correctamente");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("usuario/{idUsuario}/rol/{idRol}")]
        public IActionResult AgregarUsuarioRolReverso(int idUsuario, int idRol)
        {
            try
            {
                var usuarioRolDto = new UsuarioRolCommandDto { IdUsuario = idUsuario, IdRol = idRol };
                _usuarioRolServices.AsignarRol(usuarioRolDto);
                return Ok("Rol asignado correctamente");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("usuario/{idUsuario}/rol/{idRol}")]
        public IActionResult EliminarUsuarioRolReverso(int idUsuario, int idRol)
        {
            try
            {
                _usuarioRolServices.DeleteRoldelUsuario(idUsuario, idRol);
                return Ok("Rol eliminado correctamente");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }




