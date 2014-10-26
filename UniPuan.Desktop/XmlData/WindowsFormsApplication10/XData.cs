using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication10
{
    public class XData
    {
        static string path = @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\dt.xml";
        static string pathData = @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\Data.xml";
        static string pathCity = @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\City.xml";
        static string pathFaculty = @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\YeniFaculty.xml";
        static string pathDep = @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\Department.xml";
        static string pathYCity = @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\YeniCity.xml";
        public static void UniversityTransfer()
        {

            var doc = XDocument.Load(path);
            var xd = doc.Element("University").Elements("University").Elements("UniversityName");
            var dcm = XDocument.Load(pathYCity);
            var cty = dcm.Element("Data").Elements("City");
            string city=null;
            int i = 1;
            List<XElement> yeniElements = new List<XElement>();
            foreach (var item in xd)
            {
                //foreach (var ci in cty)
                //{
                //    var dc = item.Where(t => (t.Value.Contains(ci.Element("Name").Value)));
                //    if (dc != null)
                //    { city = ci.Element("Id").Value; }
                //}
                var xu = new XElement("University",
                          new XElement("Id", i),
                          new XElement("Name", item.Value),
                          new XElement("CityId",city),
                          new XElement("UniTypeId", "")
                          );
                yeniElements.Add(xu);
            }
            XDocument xdoc = new XDocument(new XElement("Data", yeniElements));
            xdoc.Save(@"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\YeniUni.xml");
        }
       
        public static void FacultyTransfer()
        {
            var doc = XDocument.Load(pathData);
            var dc = doc.Element("dataroot").Elements("University").Elements("DepartmentName").Where(t=> (t.Value.Contains("Fakültesi")) || (t.Value.Contains("Yüksekokulu")));
            int i = 1;
            
            List<XElement> faculty = new List<XElement>();
            foreach(var item in dc )
            {
                string lisansId = "1";
                if(item.Value.Contains("Yüksekokul")) 
                    lisansId="2";

                if(!faculty.Exists(t=>t.Element("Name").Value==item.Value))
                {
                  
                        var xf = new XElement("Faculty",
                      new XElement("Id", i),
                      new XElement("Name", item.Value),
                      new XElement("LisansId", lisansId)
                      );
                    faculty.Add(xf);
                } i++;
            
                }
            XDocument xdo = new XDocument(new XElement("Data", faculty));
            xdo.Save(@"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\YeniFaculty.xml");
        }
        
        public static void DepartmentTransfer()
        {
            var doc = XDocument.Load(pathData);
            var df = XDocument.Load(pathFaculty);
            var dp = XDocument.Load(pathDep);
            var dc = doc.Element("dataroot").Elements("University").Elements("DepartmentName");
            var fa = df.Element("Data").Elements("Faculty");
            var ds = dp.Element("dataroot").Elements("Department");
            string scoretype = null;
            int i = 1;
             List<XElement> department = new List<XElement>();
             string sonfakulte = null;
             foreach (var item in dc)
             {
                 if ((item.Value.Contains("Fakültesi") || (item.Value.Contains("Yüksekokulu"))))
                 {
                     foreach (var fc in fa)
                     {
                         if (fc.Element("Name").Value == item.Value)
                             sonfakulte =fc.Element("Id").Value ;
                     }
                 }
                 else
                 {
                     foreach (var dr in ds)
                     {
                         if (dr.Element("DepartmentName").Value == item.Value)
                             if (dr.Element("ScoreType").Value != null)
                             {
                                 scoretype = dr.Element("ScoreType").Value;
                             } }
                                 if (!department.Exists(t => t.Element("Name").Value == item.Value))
                                 {
                                     var xf = new XElement("Department",
                                       new XElement("Id", i),
                                       new XElement("Name", item.Value),
                                       //new XElement("ScoreId", scoretype),
                                       new XElement("FacultyId", sonfakulte)
                                       );
                                     department.Add(xf);
                                 }
                     }
                     i++;
                 }
             XDocument xdo = new XDocument(new XElement("Data", department));
             xdo.Save(@"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\YeniDepartment.xml");
        }
        public static void CityTransfer()
        {
            var xdoc = XDocument.Load(pathCity);
            var xd = xdoc.Element("dataroot").Elements("City").Elements("CityName");
            int i = 1;
            List<XElement> city = new List<XElement>();
            foreach(var item in xd)
            {
                var xu = new XElement("City",
                          new XElement("Id", i),
                          new XElement("Name", item.Value)
                          );
                city.Add(xu);
                i++;
            }            
            XDocument xo = new XDocument(new XElement("Data", city));
            xo.Save(@"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.Desktop\XmlData\WindowsFormsApplication10\YeniCity.xml");
        }
    }

}
