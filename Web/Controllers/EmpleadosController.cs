using Microsoft.AspNetCore.Mvc;
using DOMINIO;
using System.Runtime.ConstrainedExecution;

namespace Web.Controllers
{
    public class EmpleadosController : Controller
              
    {
        Sistema sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarLogin (string usuario, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario)) throw new Exception("El nombre de usuario no puede ser vacío");
                if (string.IsNullOrEmpty(pass)) throw new Exception("La contraseña no puede ser vacía");

                Empleado emp = sistema.Login(usuario, pass);
                if (emp == null) throw new Exception("Usuario o contraseña incorrecto");
                HttpContext.Session.SetString("usuario", usuario);
                HttpContext.Session.SetString("rol", emp.GetTipo());
                return RedirectToAction("Index","Home");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
                return View("Login");
            }
        }

        [HttpGet]
        public IActionResult AltaEmpleado()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarAltaEmpleado (string nombre, string email, string password, int residente)
        {
            try
            {
                bool res = false;
                if (residente == 1) res = true;
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede ser vacío");
                if (string.IsNullOrEmpty(email)) throw new Exception("El email no puede ser vacío");
                if (string.IsNullOrEmpty(password)) throw new Exception("La contraseña no puede ser vacía");
                Empleado e = new Peon(res, email, password,nombre, DateTime.Today);
                if (e == null) throw new Exception("Empleado no puede ser nulo");
                sistema.AltaEmpleado(e);
                ViewBag.Exito = "Empleado creado con éxito";
                return View("AltaEmpleado");


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AltaEmpleado");
            }
        }

        [HttpGet]
        public IActionResult LogOut() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult VerPeon()
        {
            Empleado p= sistema.ObtenerPeonPorEmail(HttpContext.Session.GetString("usuario"));
            ViewBag.Peon = p;
            return View();
        }

        public IActionResult NoAuth()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            return View();
        }
    }
}
