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
            return View();
        }
        public ActionResult SetDepartments(string id)
        {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));           
            UniPuanEntities1 uni = new UniPuanEntities1();
            var dep = (from c in uni.UP_ST_DEPARTMENT
                       where  
                             (idList.Contains(c.DEPARTMENTID)) 
                          select new DepartmentData() { DEPARTMENTID = c.DEPARTMENTID, DEPARTMENTNAME = c.DEPARTMENTNAME }).ToList();
            return Json(dep, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetCities(string id)
        {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));
            UniPuanEntities1 uni = new UniPuanEntities1();
            var cities = (from c in uni.UP_ST_CITY
                       where
                             (idList.Contains(c.CITYID))
                       select new CityData() { CITYID = c.CITYID, CITYNAME = c.CITYNAME }).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetUni(string id)
        {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));
            UniPuanEntities1 uni = new UniPuanEntities1();
            var univ = (from u in uni.UP_ST_UNIVERSITY
                       where
                             (idList.Contains(u.UNIVERSITYID))
                        select new UniData() { UNIVERSITYID = u.UNIVERSITYID, UNIVERSITYNAME = u.UNIVERSITYNAME }).ToList();
            return Json(univ, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCities(string id)
        {
            UniPuanEntities1 uni = new UniPuanEntities1();
            if(id!=null)
            {
                var idList = id.Split(',').Select(t => Convert.ToInt32(t));               
                var cities = (from c in uni.UP_ST_CITY
                              where
                              c.UP_ST_DEPARTMENT.Count(d => idList.Contains(d.DEPARTMENTID)) > 0
                              select new CityData() { CITYID = c.CITYID, CITYNAME = c.CITYNAME }).ToList();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var cities = (from c in uni.UP_ST_CITY                              
                              select new CityData() { CITYID = c.CITYID, CITYNAME = c.CITYNAME }).ToList();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }          
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
            UniPuanEntities1 uni = new UniPuanEntities1();
            if(id!=null)
            {
            var idList = id.Split(',').Select(t => Convert.ToInt32(t));       
            var universities = (from u in uni.UP_ST_UNIVERSITY
                                where
                                uni.UP_ST_UNIVERSITY.Count(d=>idList.Contains(u.CITYID))>0
                select new UniData() { UNIVERSITYID = u.UNIVERSITYID, UNIVERSITYNAME = u.UNIVERSITYNAME }).ToList();
            return Json(universities, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var universities = (from c in uni.UP_ST_UNIVERSITY
                              select new UniData() { UNIVERSITYID = c.UNIVERSITYID, UNIVERSITYNAME = c.UNIVERSITYNAME }).ToList();
                return Json(universities, JsonRequestBehavior.AllowGet);
            }         
        }
        public ActionResult SearchDep(string id)
        {
            UniPuanEntities1 dep = new UniPuanEntities1();
            var list = (from d in dep.UP_ST_DEPARTMENT
                        where
                        d.DEPARTMENTNAME.IndexOf(id)!=-1
                        select new DepartmentData() { DEPARTMENTID = d.DEPARTMENTID, DEPARTMENTNAME = d.DEPARTMENTNAME }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchCity(string id)
        {
            UniPuanEntities1 city = new UniPuanEntities1();
            var list = (from c in city.UP_ST_CITY
                        where
                        c.CITYNAME.IndexOf(id) != -1
                        select new CityData() { CITYID = c.CITYID, CITYNAME = c.CITYNAME }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchUni(string id)
        {
            UniPuanEntities1 uni = new UniPuanEntities1();
            var list = (from u in uni.UP_ST_UNIVERSITY
                        where
                        u.UNIVERSITYNAME.IndexOf(id) != -1
                        select new UniData() { UNIVERSITYID = u.UNIVERSITYID, UNIVERSITYNAME = u.UNIVERSITYNAME }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
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
        public class DepartmentData
        {
            public int DEPARTMENTID { get; set; }
            public string DEPARTMENTNAME { get; set; }
        }
        public ActionResult About()
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
                List<SelectListItem> listscoretype = new List<SelectListItem>();
                foreach (var type in uni.UP_ST_SCORETYPE)
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = type.SCORETYPENAME,
                        Value = type.SCORETYPEID.ToString(),
                    };
                    listscoretype.Add(selectList);
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
                    ScoreTypes = listscoretype,
                    SelectedDepartments = listsec,
                    SelectedCities = listsct,
                    SelectedUniversities = listsun
                };
                return View(uniViewModel);
        }
        public ActionResult Sonuclar()
        {
            UniPuanEntities1 uni = new UniPuanEntities1();
            List<ProgramData> listprgrm = new List<ProgramData>();
            foreach(var prgrm in uni.UP_ST_PROGRAM)
            {
                ProgramData program =new ProgramData()
                {
                 DEPARTMENTNAME=prgrm.DEPARTMENTNAME,
                UNIVERSITYNAME = prgrm.UNIVERSITYNAME,
                ORDERR = prgrm.ORDERR,
                SCORETYPE= prgrm.SCORETYPE,
                SCOREMIN = prgrm.SCOREMIN,
                QUOTAS = prgrm.QUOTAS
                };
                
                listprgrm.Add(program);
            }
            UniModel uniViewModel = new UniModel()
            {
                Programs=listprgrm,
            };
            return View(uniViewModel);
        }
        public ActionResult Ulasım()
        {
            return View();
        }
        public ActionResult Test()
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