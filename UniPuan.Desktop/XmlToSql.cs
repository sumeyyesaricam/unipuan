using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;

namespace UniPuan.Desktop
{
   public class XmlToSql
    {
       static string pathYCity = @"C:\Users\serife\Desktop\hey\WindowsFormsApplication10\WindowsFormsApplication10\YeniCity.xml";
       public static void CitySql()
       {
           SqlConnection baglanti = new SqlConnection(@"Data Source=SUMEYYE;Initial Catalog=UniPuan;Integrated Security=True");
           baglanti.Open();
           
           var xdoc = XDocument.Load(pathYCity);
           var xd = xdoc.Element("City").Elements("Name");
           List<XElement> city = new List<XElement>();
           foreach (var item in xd)
           {
               SqlCommand komut = new SqlCommand("insert into City (NAME) values(@name)", baglanti);
               komut.Parameters.AddWithValue("@name", item.Value);
               var sonuc = komut.ExecuteNonQuery();
           }
       }
    }
}
