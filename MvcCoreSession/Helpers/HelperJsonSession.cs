using MvcCoreSession.Models;
using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        //INTERNAMENTE EXISTE UN METODO EN SESSION PARA TRABAJAR CON STRING NO CON BYTES
        //HttpContext.Session.GetString
        //HttpContext.Session.SetString
        //ALMACENAREMOS ONJETOS: { Nombre:"Mascotaa", Raza:"Perro" ...}
        //NECESITAMOS UN METODO PARA ALMACENAR EL OBJETO
        public static string SerializeObject<T>(T data)
        {
            //CONVERTIMOS EL OBJETO A STRING UTILIZANDO NEWTON
            string json = JsonConvert.SerializeObject(data);
            return json;          
        }

        //RECIBIREMOS UN STRING Y LO CONVERTIREMOS A CUALQUIER OBJETO(T)
        public static T DeserializeObject<T>(string data)
        {
            //MEDIANTE NEWTON DESERIALIZAMOS EL STRING
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
        

    }
}
