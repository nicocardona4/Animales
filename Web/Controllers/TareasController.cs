using DOMINIO;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TareasController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == "Capataz" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            Empleado p = sistema.ObtenerPeonPorEmail(HttpContext.Session.GetString("usuario"));
            Peon pe = p as Peon;
            ViewBag.Tareas = pe.Tareas;
            ViewBag.Tareas.Sort();


            return View();
        }

        [HttpGet]
        public IActionResult CompletarTarea(int id)
        {
            if (HttpContext.Session.GetString("rol") == "Capataz" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            Empleado p = sistema.ObtenerPeonPorEmail(HttpContext.Session.GetString("usuario"));
            Peon pe = p as Peon;
            ViewBag.Tarea = pe.ObtenerTareaPorId(id);
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarCompletarTarea (int id, string comentario)
        {
            try
            {
                if (string.IsNullOrEmpty(comentario)) throw new Exception("El comentario no puede ser vacío");
                if (id <= 0) throw new Exception("El id es inválido");
                Empleado p = sistema.ObtenerPeonPorEmail(HttpContext.Session.GetString("usuario"));
                Peon pe = p as Peon;
                Tarea t = pe.ObtenerTareaPorId(id);
                if (t == null) throw new Exception("Tarea no encontrada");
                t.FinalizarTarea(comentario);
                TempData["Exito"] = "Tarea finalizada correctamente";
                return RedirectToAction("Listado");



            }
            catch (Exception ex) 
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Listado");
            }
        }

        [HttpGet]
        public IActionResult TareasPeon(string email)
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            ViewBag.Peon = sistema.ObtenerPeonPorEmail(email);
            return View();
        }

        [HttpGet]
        public IActionResult AsignarTarea()
        {
            if (HttpContext.Session.GetString("rol") == "Peon" || HttpContext.Session.GetString("rol") == null) return RedirectToAction("NoAuth", "Empleados");
            return View(new Tarea());
        }

        [HttpPost]
        public IActionResult ProcesarAsignarTarea(Tarea t, string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) throw new Exception("Email no puede ser vacío");
                t.Completada = false;
                sistema.AgregarTareaAPeon(email, t);
                ViewBag.Exito = "Tarea asignada correctamente a peon";
                return View("AsignarTarea", new Tarea());
            }catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("AsignarTarea",t);
            }

        }
    }
}



