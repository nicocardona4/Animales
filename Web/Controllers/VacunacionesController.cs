using DOMINIO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VacunacionesController : Controller
    {
        [HttpGet]
        public IActionResult AltaVacunacion()
        {
            if (HttpContext.Session.GetString("rol") == "Capataz" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            return View();
        }
        [HttpPost]
        public IActionResult ProcesarAltaVacunacion(string codigo, string nombre) 
        {
            
            try 
            {
                if (string.IsNullOrEmpty(codigo)) throw new Exception("El código no puede ser vacío");
                if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede ser vacío");
                Vacuna v = Sistema.Instancia.ObtenerVacunaPorNombre(nombre);
                if (v == null) throw new Exception("Vacuna no encontrada");
                Vacunacion vc = Sistema.Instancia.AltaVacunacion(v);
                if (vc == null) throw new Exception("Vacunacion no encontrada");
                Sistema.Instancia.Vacunar(codigo, vc);
                ViewBag.Exito = $"Vacunación agregada correctamente, Vacuna contra {vc.Vacuna.Patogeno}";
                return View("AltaVacunacion");


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AltaVacunacion");
            }
        }
    }
}
