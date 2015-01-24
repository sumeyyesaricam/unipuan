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

        public ActionResult Index(Guid? SelectedDepartment, Guid? SelectedCity, Guid? SelectedUni, string txtDepartment, string txtCity, string txtUni)
        {
            UniPuanEntities1 uni = new UniPuanEntities1();
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
                   //Selected = dep.IsSelected
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
                   //Selected = dep.IsSelected
               };
               listuni.Add(selectList);
           }
           UniModel uniViewModel = new UniModel()
           {
               Departments = listdep,
               Cities = listcity,
               Universities = listuni
           };
           return View(uniViewModel);
        }

      [HttpPost]
      public string Index(IEnumerable<string> selectedCities)
      {
    if (selectedCities == null)
    {
        return "No cities are selected";
    }
    else
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("You selected – " + string.Join(",", selectedCities));
        return sb.ToString();
    }
       }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}