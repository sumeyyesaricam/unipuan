using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UniPuan;

namespace UniPuan
{
    public class XData
    {
        static string MainPath = @"C:\Users\serife\Desktop\svn\trunk\UniPuan.Desktop\Data\";
        static string PathLicense = MainPath + @"License.xml";
        static string PathFaculty = MainPath + @"Faculty.xml";
        static string PathCity = MainPath + @"City.xml";
        static string PathData = MainPath + @"Data.xml";
        static string PathDepartment = MainPath + @"Department.xml";
        static string PathUniType = MainPath + @"UniType.xml";
        static string PathUniversity = MainPath + @"University.xml";
        public static List<LicenseType> LicenseList()
        {
             var li = new List<LicenseType>();
            var xdoc = XDocument.Load(PathLicense);
            var xlis = xdoc.Element("Data").Elements("LicenseType");
            foreach (var xli in xlis)
            {
                LicenseType lic = new LicenseType();
                lic.Id = xli.Attribute("Id").Value;
                lic.Name = xli.Attribute("Name").Value;
                li.Add(lic);
            }
            li.Insert(0,new LicenseType() { Id = "0", Name = "Seçiniz" });
            return li;
        }
        public static List<ScoreType> ScoreList(ScoreType f)
        {
            var score = new List<ScoreType>();
            var xdoc = XDocument.Load(PathLicense);

            var xlist = xdoc.Element("Data").Elements("LicenseType").Where(t =>
                (f.LicenseId == null || t.Attribute("Id").Value == f.LicenseId)).ToList();
            foreach (var xlis in xlist)
            {
                var xfa = xlis.Elements("ScoreType");
                foreach (var fa in xfa)
                {
                    ScoreType scr = new ScoreType();
                    scr.Id = fa.Attribute("Id").Value;
                    scr.Name = fa.Attribute("Name").Value;
                    scr.LicenseId = xlis.Attribute("Id").Value;
                    score.Add(scr);
                }
            }
            score.Insert(0, new ScoreType() { Id = "0", Name = "Seçiniz" });
            return score;
        }
        public static List<UniType> TypeList()
        {
            List<UniType> uni = new List<UniType>();
            XDocument xdoc = XDocument.Load(PathUniType);
            var xuni = xdoc.Element("Data").Elements("UniType");
            foreach (var xni in xuni)
            {
                UniType utyp = new UniType();
                utyp.Id = xni.Attribute("Id").Value;
                utyp.Name = xni.Attribute("Name").Value;
                uni.Add(utyp);
            }
            uni.Insert(0, new UniType() { Id = "0", Name = "Seçiniz" });
            return uni;
        }
        public static List<Faculty> FacultyList(Filter f)
        {
            var fa = new List<Faculty>();
            var xdoc = XDocument.Load(PathFaculty);

            var liste = xdoc.Element("Data").Elements("FacultyType").Where(t =>
                (f.ScoreId == null || t.Attribute("ScoreTypeId").Value == f.ScoreId));

            foreach (var fc in liste)
            {
                Faculty fclty = new Faculty();
                fclty.Id = fc.Attribute("Id").Value;
                fclty.Name = fc.Attribute("Name").Value;
                fclty.ScoreId = fc.Attribute("ScoreTypeId").Value;
                fa.Add(fclty);
            }
            fa.Insert(0, new Faculty() { Id = "0", Name = "Seçiniz" });
            return fa;
        }
        public static List<Department> DepList(Department f)
        {
            var de = new List<Department>();
            var xdoc = XDocument.Load(PathDepartment);

            var xde = xdoc.Element("Data").Elements("DepartmentType").Where(t => 
                ((f.ScoreId == null || t.Attribute("ScoreId").Value == f.ScoreId) &&
                (f.FacultyId == null || t.Attribute("FacultyId").Value == f.FacultyId)));

            foreach (var fc in xde)
            {
                Department dp = new Department();
                dp.Id = fc.Attribute("Id").Value;
                dp.Name = fc.Attribute("Name").Value;
                dp.FacultyId = fc.Attribute("FacultyId").Value;
                dp.ScoreId = fc.Attribute("ScoreId").Value;
                de.Add(dp);
            }
            de.Insert(0, new Department() { Id = "0", Name = "Seçiniz" });
            return de;
        }
        public static List<City> CityList()
        {
            List<City> ci = new List<City>();
            var xdoc = XDocument.Load(PathCity);
            var xci = xdoc.Element("Data").Elements("City");
            foreach (var cit in xci)
            {
                City cty = new City();
                cty.Id = cit.Attribute("Id").Value;
                cty.Name = cit.Attribute("Name").Value;
                ci.Add(cty);
            }
            ci.Insert(0, new City() { Id = "0", Name = "Seçiniz" });
            return ci;
        }
        public static List<University> UniList(University f)
        {
            List<University> uni = new List<University>();
            var xdoc = XDocument.Load(PathUniversity);

            var xuni = xdoc.Element("Data").Elements("University").Where(
                t => ((f.CityTypeId == null || t.Attribute("CityId").Value == f.CityTypeId) &&
                (f.UniTypeId == null || t.Attribute("UniType").Value == f.UniTypeId)));

            foreach (var fc in xuni)
            {
                University unv = new University();
                unv.Id = fc.Attribute("Id").Value;
                unv.Name = fc.Attribute("Name").Value;
                unv.CityTypeId = fc.Attribute("CityId").Value;
                unv.UniTypeId = fc.Attribute("UniType").Value;
                uni.Add(unv);
            }
            uni.Insert(0, new University() { Id = "0", Name = "Seçiniz" });
            return uni;
        } 
        public static List<Data> DataList(Filter f)
        {
            List<Data> data = new List<Data>();
            var xdoc = XDocument.Load(PathData);
            var uni = xdoc.Element("Data").Elements("Department").Where(
                t => (f.FacultyId == null || (t.Attribute("FacultyId").Value == f.FacultyId)) &&
                    (f.UniId == null || (t.Attribute("UniId").Value == f.UniId)) &&
                    (f.DepartmentId == null || (t.Attribute("deType").Value == f.DepartmentId)) &&
                    (f.ScoreMin == null || Convert.ToInt32(t.Element("ScoreMin").Value) >= Convert.ToInt32(f.ScoreMin) || Convert.ToInt32(t.Element("ScoreMax").Value) >= Convert.ToInt32(f.ScoreMin)) &&
                    (f.ScoreMax == null || Convert.ToInt32(t.Element("ScoreMax").Value) <= Convert.ToInt32(f.ScoreMax) || Convert.ToInt32(t.Element("ScoreMin").Value) <= Convert.ToInt32(f.ScoreMax)) &&
                    (f.Order == null || Convert.ToInt32(t.Element("Order").Value) >= Convert.ToInt32(f.Order)) &&
                    (f.ScoreId==null || (t.Element("ScoreType").Value ==f.ScoreId)) &&
                    (f.UniTypeId == null || (t.Element("UniversityType").Value == f.UniTypeId)) &&
                     (f.CityId == null || (t.Element("City").Value == f.CityId)) &&
                     (f.License == null || (t.Element("License").Value == f.License))
                    );
            foreach (var fc in uni)
            {
                Data dt = new Data();
                dt.deType = fc.Attribute("deType").Value;
                dt.FacultyId = fc.Attribute("FacultyId").Value;
                dt.UniId = fc.Attribute("UniId").Value;
                dt.UniversityName = fc.Element("UniversityName").Value;
                dt.FacultyName = fc.Element("FacultyName").Value;
                dt.DepartmentName = fc.Element("DepartmentName").Value;
                dt.ScoreType = fc.Element("ScoreType").Value;
                dt.ScoreMin = fc.Element("ScoreMin").Value;
                dt.ScoreMax = fc.Element("ScoreMax").Value;
                dt.Order = fc.Element("Order").Value;
                dt.Quotas = fc.Element("Quotas").Value;
                dt.EducationType = fc.Element("EducationType").Value;
                data.Add(dt);
            }
            return data;

        }


    }
    
}
