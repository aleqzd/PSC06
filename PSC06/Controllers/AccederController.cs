using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PSC06.Models;

namespace PSC06.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string password)
        {
            using (DBAutosEntities db = new DBAutosEntities())  // aqui abre la base de datos
            {   
                // aqui estamos utilizando Linq
                // y esto es lo mismo que decir --> SELECT * FROM USER WHERE EMAIL = usuario and Password = password and idestatus = 1
                var read = from d in db.USERs
                          where d.Email == usuario
                             && d.PassWord == password
                             && d.idEstatus == 1
                         select d;   // aqui procede a ejecutar el script de linq

                if (read.Count() > 0)  // aqui pregunta si tiene data el contenedor read
                {
                    Session["Usuario"] = read.First();   // aqui abre session con el nombre del usuario
                    return Content("1");   // esto sera usado en la vista con javascript
                }
                else
                {
                    return Content("Revisa usuario y password :(");  // esto sera usado en la vista con javascript
                }
            }
        }
    }
}