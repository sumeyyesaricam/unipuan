using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniPuan.Web.Models
{
    public class UniModel
    {
        public IEnumerable<string> SelectedCities { get; set; }
                 [DisplayName("Şehirler")]
        public IEnumerable<SelectListItem> Cities { get; set; }
                 public IEnumerable<string> SelectedDepartments { get; set; }
                 [DisplayName("Bölümler")]
                 public IEnumerable<SelectListItem> Departments { get; set; }
                 public IEnumerable<string> SelectedUniversities { get; set; }
                 [DisplayName("Üniversiteler")]
        public IEnumerable<SelectListItem> Universities { get; set; }
                 [DisplayName("Üniversite Türü")]
                 public IEnumerable<SelectListItem> Unitypes { get; set; }
                 [DisplayName("Puan Türü")]
                 public IEnumerable<SelectListItem> ScoreTypes { get; set; }
                 public IEnumerable<ProgramData> Programs { get; set; }
    }
    public class ProgramData
    {
        public int ID { get; set; }
            public string NAME { get; set; }
        public string DEPARTMENTNAME { get; set; }
        public string UNIVERSITYNAME { get; set; }
        public double? SCOREMIN { get; set; }
        public int? QUOTAS { get; set; }
        public double? ORDERR { get; set; }
        public string SCORETYPE { get; set; }
    }
}