using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Extensions;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

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
                    HttpContext.Session.SetString("nombre", "Kuajenkro");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "Datos almacenados correctamente";

                }else if (accion.ToLower() == "mostrar")
                {
                    ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
                    ViewData["HORA"] = HttpContext.Session.GetString("hora");
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public IActionResult SessionMascota(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Knekrer";
                    mascota.Raza = "Ratilla";
                    mascota.Edad = 333;
                    //Para almacenar el objeto en session debemos convertirlo a byte[]
                    byte[] data = HelperBinarySession.ObjectToByte(mascota);
                    //ALMACENAMOS EL OBJETO EN SESSION
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MENSAJE"] = "Datos almacenados correctamente";
                }else if (accion.ToLower() == "mostrar")
                {
                    //DEBEMOS RECUPERAR LOS BYTES DE SESION QUE REPRESENTAN EL OBJETO MASCOTA
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    //CONVERTIMOS LOS BYTE A NUESTRO OBJETO MASCOTA
                    Mascota mascota = (Mascota)HelperBinarySession.ByteToObject(data);
                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionCollection(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota {Nombre = "Pumba", Raza="Jabali", Edad= 14},
                        new Mascota {Nombre = "Rafiki", Raza="Mono", Edad= 18},
                        new Mascota {Nombre = "Olaf", Raza="Cosa", Edad= 8},
                        new Mascota {Nombre = "Nala", Raza="Leona", Edad= 12}
                    };
                    byte[] data = HelperBinarySession.ObjectToByte(mascotas);
                    HttpContext.Session.Set("MASCOTAS", data);
                    ViewData["MENSAJE"] = "Coleccion almacenada"; 
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTAS");
                    List<Mascota> mascotas = (List<Mascota>)HelperBinarySession.ByteToObject(data);
                    return View(mascotas);
                }
            }
            return View();
        }

        public IActionResult SessionMascotaJson(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota
                    {
                        Nombre = "Abu", Raza = "Monito", Edad = 15
                    };
                    //serializamos el objeto mediante json
                    string jsonMascota = HelperJsonSession.SerializeObject<Mascota>(mascota);
                    //Utilizamos los metodos string de session
                    HttpContext.Session.SetString("MASCOTA", jsonMascota);
                    ViewData["MENSAJE"] = "Mascota JSON almacenada";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    //extraemos el string que representa la mascota
                    string jsonMascota = HttpContext.Session.GetString("MASCOTA");
                    Mascota mascota = HelperJsonSession.DeserializeObject<Mascota>(jsonMascota);
                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaObject(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota
                    {
                         Nombre = "Knekro", Raza = "O rey", Edad = 1000
                    };
                    HttpContext.Session.SetObject("MASCOTAOBJECT", mascota);
                    ViewData["MENSAJE"] = "Mascota almacenada como Object!!!";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    Mascota mascota = HttpContext.Session.GetObject<Mascota>("MASCOTAOBJECT");
                    ViewData["MASCOTA"] = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionCollectionObject(string accion)
        {
            if(accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    
                }
                else if (accion.ToLower() == "mostrar")
                {
                    
                }
            }
            return View();
        }
    }
}
