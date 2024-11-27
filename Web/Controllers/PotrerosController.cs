using DOMINIO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PotrerosController : Controller
    {
        [HttpGet]
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            ViewBag.Potreros = Sistema.Instancia.Potreros;
            ViewBag.Potreros.Sort();
            return View();
        }

        [HttpGet]
        public IActionResult AsignarAnimalAPotrero() 
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarAsignarAnimalAPotrero(int id, string codigo)
        {

            try
            {
                if (string.IsNullOrEmpty(codigo)) throw new Exception("Codigo no puede ser vacío");
                if (id <= 0) throw new Exception("Id incorrecto");
                Sistema.Instancia.AgregarAnimalAPotrero(id, codigo);
                ViewBag.Exito = "Animal asignado correctamente";
                return View("AsignarAnimalAPotrero");

            }catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AsignarAnimalAPotrero");
            }
        }
    }
}
