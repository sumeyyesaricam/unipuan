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
    }
}