using Microsoft.AspNetCore.Mvc;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        int numero = 1;
        public IActionResult Index()
        {
            this.numero += 1;
            ViewData["NUMERO"] = "El valor del numero es " + this.numero;
            return View();
        }

        //ACTION PARA VISUALIZAR DATOS EN SESION DE FORMA SIMPLE
        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    //Guardamos datos en session
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados correctamente";

                }else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }
    }
}
