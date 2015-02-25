using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UniPuan.Web.Models;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
namespace UniPuan.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(Guid? SelectedPuan, string boxuni, string boxcity, string boxdep, string searchd)
        {
            UniPuanEntities1 uni = new UniPuanEntities1();
            ViewBag.SelectedPuan = new SelectList(uni.UP_ST_SCORETYPE, "SCORETYPEID", "SCORETYPENAME", SelectedPuan);
            List<SelectListItem> listunitype = new List<SelectListItem>();
            foreach (var type in uni.UP_ST_UNITYPE)
            {
                SelectListItem selectList = new SelectListItem()
                { 
                    Text = type.UNITYPENAME,
                    Value = type.UNITYPEID.ToString(),
                };
                listunitype.Add(selectList);
            }
            List<SelectListItem> listdep = new List<SelectListItem>();
            foreach (var dep in uni.UP_ST_DEPARTMENT)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = dep.DEPARTMENTNAME,
                    Value = dep.DEPARTMENTID.ToString(),
                    //Selected = dep.IsSelected
                };
                listdep.Add(selectList);
            }
           
           List<SelectListItem> listcity = new List<SelectListItem>();
           foreach (var city in uni.UP_ST_CITY)
           {
               SelectListItem selectList = new SelectListItem()
               {
                   Text = city.CITYNAME,
                   Value = city.CITYID.ToString(),
               };
               listcity.Add(selectList);
           }
           
           List<SelectListItem> listuni = new List<SelectListItem>();
           foreach (var univ in uni.UP_ST_UNIVERSITY)
           {
               SelectListItem selectList = new SelectListItem()
               {
                   Text = univ.UNIVERSITYNAME,
                   Value = univ.UNIVERSITYID.ToString(),
               };
               listuni.Add(selectList);
           }
           List<string> listsec = new List<string>();
           listsec.Add(boxdep);
               List<string> listsct = new List<string>();
               listsct.Add(boxcity);
               List<string> listsun = new List<string>();
               listsun.Add(boxuni);
           UniModel uniViewModel = new UniModel()
           {
               Departments = listdep,
               Cities = listcity,
               Universities = listuni,
               Unitypes=listunitype,
               SelectedDepartments = listsec,
               SelectedCities = listsct,
               SelectedUniversities = listsun
           };
           return View(uniViewModel);
        }       
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}