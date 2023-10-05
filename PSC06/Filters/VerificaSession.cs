using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PSC06.Models;
using PSC06.Controllers;

namespace PSC06.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var elUsuario = (USER)HttpContext.Current.Session["Usuario"];
            
            if (elUsuario == null)
            {
                if (filterContext.Controller is AccederController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceder/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccederController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}