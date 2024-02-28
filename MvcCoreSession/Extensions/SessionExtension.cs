using MvcCoreSession.Helpers;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        //QUEREMOS UN METODO PARA RECUPERAR CUALQUIER OBJETO
        //HttpCOntext.Session.GetObjext(key) lo de abajo vaya

        public static T GetObject<T>(this ISession session, string key)
        {
            //NECESITAMOS RECUPERAR LOS DATOS QUE TENEMOS ALMACENADOS EN SESSION MEDIANTE KEY
            //RECUPERAMOS EL STRING JSON 
            string json = session.GetString(key);
            //QUE SUCEDE CUANDO RECUPERAMOS DE SESION ALGO QUE NO EXISTE?
            if (json == null)
            {
                //SI NO EXISTE LA KEY DEVOLVEMOS EL VALOR POR DEFECTO DEL OBJETO RECIBIDO(T)
                return default(T);
            }
            else
            {
                //RECUPERAMOS EL OBJETO QUE TENEMOS ALMACENADO DENTRO DE LA KEY
                T data = HelperJsonSession.DeserializeObject<T>(json);
                return data;
            }
        }

        //QUEREMOS UN METODO PARA ALMACENAR CUALQUIER OBJETO DENTRO DE session
        //HttpCOntext.Session.SetObjext(key, value)
        public static void SetObject(this ISession session, string key, object value)
        {
            //SERIALIZAMOS EL OBJETO A STRING JSON
            string data = HelperJsonSession.SerializeObject(value);
            //ALMACENAMOS EN SESSION EL STRING JSON
            session.SetString(key, data);
        }
    }
}
