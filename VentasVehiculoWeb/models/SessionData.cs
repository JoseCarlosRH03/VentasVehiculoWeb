using System;
using VentaVehiculoModelDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace VentasVehiculoWeb.models
{
    public class SessionData
    {
        public string session;
        public string GetSession(string name)
        {
            this.session = Convert.ToString(HttpContext.Current.Session[name]);
            return session;
        }

        public void SetSession(int id, string usernombre)
        {
            HttpContext.Current.Session["UserName"] = usernombre;
            HttpContext.Current.Session["Userid"] = id;
        }

        public void DestroySession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }
    }
}