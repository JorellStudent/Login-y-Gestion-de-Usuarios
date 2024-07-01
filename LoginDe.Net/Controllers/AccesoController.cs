using Microsoft.AspNetCore.Mvc;
using LoginDe.Net.Data;
using LoginDe.Net.Models;
using Microsoft.EntityFrameworkCore;
using LoginDe.Net.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace LoginDe.Net.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public AccesoController(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Registrarse(UsuarioVM modelo)
        {
            if (modelo.Password != modelo.ConfirmarPassword) {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();

            }
            Usuario usuario = new Usuario()
            {
                Nombre_Usuario = modelo.Nombre_Usuario,
                Nombre = modelo.Nombre,
                Apellido_Paterno = modelo.Apellido_Paterno,
                Apellido_Materno = modelo.Apellido_Materno,
                Correo = modelo.Correo,
                Password = modelo.Password,
            };

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();

            if(usuario.IdUsuario != 0) return RedirectToAction("Login", "Acceso");
            ViewData["Mensaje"] = "No se puede crear el usuario,error fatal";
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM modelo)
        {
            Usuario? usuario_encontrado = await _appDbContext.Usuarios
                                            .Where(u =>
                                            u.Nombre_Usuario == modelo.Nombre_Usuario &&
                                            u.Password == modelo.Password).FirstOrDefaultAsync();

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Nombre_Usuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    } 
}
