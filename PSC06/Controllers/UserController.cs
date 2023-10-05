using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PSC06.Models;
using PSC06.Models.TableViewModel;
using PSC06.Models.ViewModel;

namespace PSC06.Controllers
{
    public class UserController : Controller
    {
        // GET: Query
        public ActionResult Query()
        {
            List<UserTableViewModel> lst = null;

            using (DBAutosEntities db =  new DBAutosEntities())
            {
                // SELECT * FROM USER WHERE IDESTATUS = 1
                lst = (from d in db.USERs
                       where d.idEstatus == 1
                       orderby d.Email

                       select new UserTableViewModel
                       {
                           _Email = d.Email,
                           _Id = d.ID,
                           _Edad = d.Edad
                       }).ToList();
            }

            return View(lst);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddUserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBAutosEntities())
            {
                USER oUser = new USER();
                oUser.idEstatus = 1;
                oUser.Email = model.Email;
                oUser.Nombre = model.Nombre;
                //oUser.Edad = model.Edad;
                oUser.PassWord = model.Password;

                db.USERs.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }
    }
}