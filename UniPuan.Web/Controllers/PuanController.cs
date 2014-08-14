using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniPuan.Web.Controllers
{
    public class PuanController : Controller
    {
        //
        // GET: /Puan/
        public ActionResult List()
        {
             
            return View(XData.UniList(new University()));
        }
	}
}