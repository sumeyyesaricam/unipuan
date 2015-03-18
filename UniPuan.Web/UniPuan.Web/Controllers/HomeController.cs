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

        public UniModel GetModel(Guid? SelectedPuan, string boxuni, string boxcity, string boxdep, string searchd)
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
                Unitypes = listunitype,
                SelectedDepartments = listsec,
                SelectedCities = listsct,
                SelectedUniversities = listsun
            };
            return uniViewModel;
        }
        public ActionResult SelectList(Guid? SelectedPuan, string boxuni, string boxcity, string boxdep, string searchd)
        {
            var uniViewModel = GetModel(SelectedPuan,  boxuni,  boxcity,  boxdep,  searchd);
            return View(uniViewModel);
        }
        [HttpPost]
        public ActionResult SelectList(UniModel model, string bootstrap_duallistbox_selected_list_ddlDepartments, string bootstrap_duallistbox_selected_list_ddlCities)
        {
            return View(model);
        }
        public ActionResult GetCities(string id)
        {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));
            UniPuanEntities1 uni = new UniPuanEntities1();
            var cities = (from c in uni.UP_ST_CITY
                          where
                          c.UP_ST_DEPARTMENT.Count(d => idList.Contains(d.DEPARTMENTID)) > 0
                          select new CityData() { CITYID = c.CITYID, CITYNAME = c.CITYNAME }).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUniversities(string id)
        {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));
            UniPuanEntities1 uni = new UniPuanEntities1();
            //var universities= uni.UP_ST_UNIVERSITY.Where(d=> d.CITYID.ToString()==id).ToList();
            var unies = (from u in uni.UP_ST_UNIVERSITY
                         where
                         u.UP_ST_DEPARTMENT.Count(d => idList.Contains(d.DEPARTMENTID)) > 0
                         select new UniData() { UNIVERSITYID = u.UNIVERSITYID, UNIVERSITYNAME = u.UNIVERSITYNAME }).ToList();
            return Json(unies, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUnies(string id)
        {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));
            UniPuanEntities1 uni = new UniPuanEntities1();
            var universities = (from u in uni.UP_ST_UNIVERSITY
                                where
                                idList.Contains(u.CITYID)
                select new UniData() { UNIVERSITYID = u.UNIVERSITYID, UNIVERSITYNAME = u.UNIVERSITYNAME }).ToList();
            return Json(universities, JsonRequestBehavior.AllowGet);
        }
        public class CityData
        {
            public int CITYID { get; set; }
            public string CITYNAME { get; set; }
        }
        public class UniData
        {
            public int UNIVERSITYID { get; set; }
            public string UNIVERSITYNAME { get; set; }
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult AnaSayfa()
        {
            return View();
        }
        public ActionResult TercihYap(Guid? SelectedPuan, string boxuni, string boxcity, string boxdep, string searchd)
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
                    Unitypes = listunitype,
                    SelectedDepartments = listsec,
                    SelectedCities = listsct,
                    SelectedUniversities = listsun
                };
                return View(uniViewModel);
        }
        public ActionResult Sonuclar()
        {
            return View();
        }
        public ActionResult Ulasım()
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