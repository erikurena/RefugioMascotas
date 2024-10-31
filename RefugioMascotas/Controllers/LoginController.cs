using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefugioMascotas.dbContext;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using RefugioMascotas.Models;
using Microsoft.AspNetCore.Authorization;

namespace RefugioMascotas.Controllers
{
  
    public class LoginController : Controller
    {
        private readonly dbRefugioContext _dbRefugioContext;
        public LoginController(dbRefugioContext contexto)
        {
            _dbRefugioContext = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string usuario, string password)
        {
            var loginUsuario = await _dbRefugioContext.empleados.FirstOrDefaultAsync(x => x.Nombre == usuario && x.Apellido == password);

            if (loginUsuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUsuario.IdEmpleado.ToString()),
                    new Claim(ClaimTypes.Name, loginUsuario.Nombre),
                    new Claim(ClaimTypes.Role, loginUsuario.Cargo!),
                    //new Claim(ClaimTypes.GivenName, usuario.f)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Error en la cuenta o contraseña";
                return View();
            }
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");
        }
    }
}
