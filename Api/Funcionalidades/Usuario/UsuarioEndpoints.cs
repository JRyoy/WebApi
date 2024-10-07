using Microsoft.AspNetCore.Mvc;
using Carter;

namespace Api.Funcionalidades.Usuario;

[Route("api/[controller]")]
    [ApiController] 
    public class UsuarioEndpoints : ICarterModule
    {
       public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Crear Usuarios", async (IUsuarioServices usuarioServices,UsuarioCommandDto usuarioDto) =>
        {
            usuarioServices.CreateUser(usuarioDto);
            return Results.Created($"/usuarios/{usuarioDto.Email}", usuarioDto);
        });

        // Obtener un usuario por Id
        app.MapGet("/Obtener Usuarios/{id:int}", (IUsuarioServices usuarioServices,int id) =>
        {
            var usuario = usuarioServices.GetUser(id);
            if (usuario == null) return Results.NotFound($"Usuario con Id {id} no encontrado.");
            return Results.Ok(usuario);
        });

        // Obtener todos los usuarios
        app.MapGet("/Ver usuarios", (IUsuarioServices usuarioServices) =>
        {
            var usuarios = usuarioServices.GetUser();
            return Results.Ok(usuarios);
        });

        // Actualizar un usuario
        app.MapPut("/Modificar Usuarios/{id:int}", (IUsuarioServices usuarioServices,int id, UsuarioCommandDto usuarioDto) =>
        {
            usuarioServices.UpdateUser(id, usuarioDto);
            return Results.Ok($"Usuario con Id {id} actualizado.");
        });

        // Eliminar un usuario
        app.MapDelete("/Eliminar Usuarios/{id:int}", (IUsuarioServices usuarioServices,int id) =>
        {
            usuarioServices.DeleteUser(id);
            return Results.NoContent();
        });
    }
    }

