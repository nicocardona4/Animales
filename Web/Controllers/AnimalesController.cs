using Microsoft.AspNetCore.Mvc;
using DOMINIO;
using System.Security.Cryptography.X509Certificates;

namespace Web.Controllers
{
    public class AnimalesController : Controller
    {
        [HttpGet]
        public IActionResult AltaBovino()
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            return View(new Bovino());
        }

        [HttpPost]
        public IActionResult ProcesarAltaBovino(Bovino b) 
        {
            try
            {
                //Animal a = b as Animal;
                //if (a == null) throw new Exception("Animal no válido");
                Sistema.Instancia.AltaAnimal(b);
                ViewBag.Exito = "Bovino agregado correctamente";
                return View("AltaBovino", new Bovino());

            }catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View("AltaBovino", b);
            }

        }

        [HttpGet]
        public IActionResult AnimalesPorPesoYTipo()
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            ViewBag.Animales = new List<Animal>();
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarAnimalesPorPesoYTipo(string tipo, double peso)
        {
            ViewBag.Animales = Sistema.Instancia.AnimalPorPesoYTipo(peso,tipo);
            return View("AnimalesPorPesoYTipo");
        }
    }
}
