using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class UsuarioInfoActionFilter : IActionFilter {

    public void OnActionExecuting(ActionExecutingContext Context) {
        // Aquí obtienes los datos del usuario desde la sesión
        var Nombre = Context.HttpContext.Session.GetString("UsuarioNombre");
        var Rol = Context.HttpContext.Session.GetString("UsuarioRol");
        var Controlador = (Controller)Context.Controller;

        // Llenas ViewBag con los datos del usuario
        Controlador.ViewBag.UsuarioNombre = Nombre;
        Controlador.ViewBag.UsuarioRol = Rol;
    }

    public void OnActionExecuted(ActionExecutedContext Context) { }

}
