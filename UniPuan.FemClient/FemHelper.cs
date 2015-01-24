using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniPuan.FemClient.Fem;

namespace UniPuan.FemClient
{
    // bu serviste başka veriler de var çekmek için
    //
    // nasıl :)
    public class FemHelper
    {
        public static string DataPath
        {
            get { return @"F:\WheIS\Projects\UniPuan\Source\trunk\UniPuan.FemClient\Data\"; }
        }
       
        public static List<Bolum> Bolum(bool lisans)
        {
            var puanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19"; // bunlar YGS1-YGS2 gibi veriler
            var universiteTuru = "1,2,3,4"; // bunlar DEVLET,OZEL,KIBRIS,YURTDISI
            var gelenAralik = "BasariAralik|0|0";
            var yeniBolumlerGelsinmi = true;
            var gelenOgrenimTuru = "0";
            var gelenBurs = "0";
            var gelenOgrenimDili = "0";
            Fem.FemTercihWebServisSoapClient client = new Fem.FemTercihWebServisSoapClient();
            var bolumlerJson = "";
            if (lisans)
                bolumlerJson = client.GetLisansBolumler(puanTuru, universiteTuru, gelenAralik, yeniBolumlerGelsinmi, gelenOgrenimTuru, gelenBurs, gelenOgrenimDili);
            else
                bolumlerJson = client.GetOnLisansBolumler(puanTuru, universiteTuru, gelenAralik, yeniBolumlerGelsinmi, gelenOgrenimTuru, gelenBurs, gelenOgrenimDili);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bolum>>(bolumlerJson);

        } 
        public static List<Sehir> Sehir(List<Bolum> bolumler)
        {
            var gelenPuanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19"; // bunlar YGS1-YGS2 gibi veriler
            var universiteTuru = "1,2,3,4"; // bunlar DEVLET,OZEL,KIBRIS,YURTDISI
            var gelenAralik = "BasariAralik|0|0";
            var yeniBolumlerGelsinmi = true;
            var gelenOgrenimTuru = "0";
            var gelenBurs = "0";
            var gelenOgrenimDili = "0";
            var gelenBolumler = string.Join(",", bolumler.Select(t => t.BolumId));

            Fem.FemTercihWebServisSoapClient client = new Fem.FemTercihWebServisSoapClient();
            var sehirlerJson = client.GetIllerByBolumler(gelenPuanTuru, universiteTuru, gelenAralik, yeniBolumlerGelsinmi, gelenOgrenimTuru, gelenBurs, gelenOgrenimDili, gelenBolumler);
            List<Sehir> sehirler = JsonConvert.DeserializeObject<List<Sehir>>(sehirlerJson);
            return sehirler;
        }
        public static List<Universite> Universite(List<Bolum> bolumler, List<Sehir> sehirler)
        {
            var gelenPuanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19"; // bunlar YGS1-YGS2 gibi veriler
            var universiteTuru = "1,2,3,4"; // bunlar DEVLET,OZEL,KIBRIS,YURTDISI
            var gelenAralik = "BasariAralik|0|0";
            var yeniBolumlerGelsinmi = true;
            var gelenOgrenimTuru = "0";
            var gelenBurs = "0";
            var gelenOgrenimDili = "0";
            var gelenBolumler = string.Join(",", bolumler.Select(t => t.BolumId));
            var gelenSehirler = string.Join(",", sehirler.Select(t => t.ilId));

            Fem.FemTercihWebServisSoapClient client = new Fem.FemTercihWebServisSoapClient();
            var universitelerJson = client.BolumeVeIleGoreUniversiteGetir(gelenPuanTuru, universiteTuru, gelenAralik, yeniBolumlerGelsinmi, gelenOgrenimTuru, gelenBurs, gelenOgrenimDili, gelenBolumler, gelenSehirler);
            List<Universite> universiteler = JsonConvert.DeserializeObject<List<Universite>>(universitelerJson);

            return universiteler;
        }
        public static List<SonuclarSurrogate> PuanLisans(List<Bolum> bolumler, List<Sehir> sehirler, List<Universite> universiteler)
        {
            var gelenPuanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19"; // bunlar YGS1-YGS2 gibi veriler
            var gelenUniversiteTuru = "1,2,3,4"; // bunlar DEVLET,OZEL,KIBRIS,YURTDISI
            var gelenAralik = "BasariAralik|0|0";
            var yeniBolumlerGelsinmi = true;
            var gelenOgrenimTuru = "0";
            var gelenBurs = "0";
            var gelenOgrenimDili = "0";
            var gelenBolumler = string.Join(",", bolumler.Select(t => t.BolumId));
            var gelenSehirler = string.Join(",", sehirler.Select(t => t.ilId));
            var gelenUniversiteler = string.Join(",", universiteler.Select(t => t.UNIVERSITEID));
            List<SonuclarSurrogate> sonuclar = new List<SonuclarSurrogate>();

            Fem.FemTercihWebServisSoapClient client = new Fem.FemTercihWebServisSoapClient();

            // Tümünü çekmek için
            //sonuclar = client.GetTercihSonuclar(gelenPuanTuru, gelenUniversiteTuru, gelenAralik, yeniBolumlerGelsinmi,
            //     gelenOgrenimTuru, gelenBurs, gelenOgrenimDili, gelenBolumler, gelenSehirler, gelenUniversiteler).ToList();

            foreach (var uni in universiteler)
            {
                gelenUniversiteler = uni.UNIVERSITEID;

                sonuclar.AddRange(client.GetTercihSonuclar(gelenPuanTuru, gelenUniversiteTuru, gelenAralik, yeniBolumlerGelsinmi,
                  gelenOgrenimTuru, gelenBurs, gelenOgrenimDili, gelenBolumler, gelenSehirler, gelenUniversiteler).ToList());

            }
            return sonuclar;

        }
        public static List<OnLisansSonuclarSurrogate> PuanOnLisans(List<Bolum> bolumler, List<Sehir> sehirler)
        {
            var gelenPuanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19"; // bunlar YGS1-YGS2 gibi veriler
            var gelenUniversiteTuru = "1,2,3,4"; // bunlar DEVLET,OZEL,KIBRIS,YURTDISI
            var gelenAralik = "BasariAralik|0|0";
            var yeniBolumlerGelsinmi = true;
            var gelenOgrenimTuru = "0";
            var gelenBurs = "0";
            var gelenOgrenimDili = "0";
            var gelenBolumler = string.Join(",", bolumler.Select(t => t.BolumId));
            var gelenSehirler = string.Join(",", sehirler.Select(t => t.ilId));
        
            List<OnLisansSonuclarSurrogate> sonuclar = new List<OnLisansSonuclarSurrogate>();

            Fem.FemTercihWebServisSoapClient client = new Fem.FemTercihWebServisSoapClient();
         //   sonuclar.AddRange(client.GetOnLisansTercihSonuclar(gelenPuanTuru, gelenUniversiteTuru, gelenAralik, yeniBolumlerGelsinmi,
         //gelenOgrenimTuru, gelenBurs, gelenOgrenimDili, gelenBolumler, gelenSehirler).ToList());
            foreach (var shr in sehirler)
            {
            sonuclar.AddRange(client.GetOnLisansTercihSonuclar(gelenPuanTuru, gelenUniversiteTuru, gelenAralik, yeniBolumlerGelsinmi,
         gelenOgrenimTuru, gelenBurs, gelenOgrenimDili, gelenBolumler, gelenSehirler).ToList());

            }
            return sonuclar;
        }

        public static void DataCal(bool lisans)
        {
            var bolumler = Bolum(lisans);
            BolumCal(lisans,bolumler);
        }
        public static void BolumCal(bool lisans, List<Bolum> bolumler)
        {
            List<XElement> xb = new List<XElement>();
            foreach (var b in bolumler)
            {
                xb.Add(new XElement("Department",
                    new XElement("Id", b.BolumId),
                     new XElement("Name", new XCData(b.BolumAdi.Trim()))
                    ));
            }
            XDocument xdoc = new XDocument(new XElement("Data", xb));
            xdoc.Save(DataPath + (lisans ? "Lisans" : "OnLisans") + @"_Department.xml");
            SehirCal(lisans,bolumler);
        }
        public static void SehirCal(bool lisans, List<Bolum> bolumler)
        {
            var sehirler = Sehir(bolumler);
            List<XElement> xb = new List<XElement>();
            foreach (var s in sehirler)
            {
                xb.Add(new XElement("City",
                    new XElement("Id", s.ilId),
                     new XElement("Name", new XCData(s.ilAdi.Trim()))
                    ));
            }
            XDocument xdoc = new XDocument(new XElement("Data", xb));
            xdoc.Save(DataPath + (lisans ? "Lisans" : "OnLisans") + @"_City.xml");
            UniversiteCal(lisans,bolumler, sehirler);
        }
        public static void UniversiteCal(bool lisans, List<Bolum> bolumler, List<Sehir> sehirler)
        {
            var universiteler = Universite(bolumler, sehirler);
            List<XElement> xuni = new List<XElement>();
            foreach (var uni in universiteler)
            {
                xuni.Add(new XElement("University",
                    new XElement("Id", uni.UNIVERSITEID),
                     new XElement("Name", new XCData(uni.Universitead.Trim()))
                    ));
            }
            XDocument xdoc = new XDocument(new XElement("Data", xuni));
            xdoc.Save(DataPath + (lisans ? "Lisans" : "OnLisans") + @"_University.xml");
            PuanCal(lisans,bolumler, sehirler, universiteler);
        }
        public static void PuanCal(bool lisans,List<Bolum> bolumler, List<Sehir> sehirler, List<Universite> universiteler)
        {
            // burayı sen devam edersin
            List<XElement> xscore = new List<XElement>();
            if(lisans)
            {
                var puanlar = PuanLisans(bolumler, sehirler, universiteler);
                foreach (var puan in puanlar)
                {
                    if (puan.ProgramKodu != null)
                    {
                        xscore.Add(new XElement("Score",
                            new XElement("Id", puan.ProgramKodu),
                             new XElement("UniversityName", new XCData(puan.UniversiteAdi.Trim())),
                             new XElement("DepartmentName", new XCData(puan.BolumAdi.Trim())),
                             new XElement("Quotas", new XCData(puan.Kontenjan.ToString())),
                             new XElement("Condition", new XCData((puan.OzelKosullar != null ? puan.OzelKosullar.Trim() : ""))),
                             new XElement("ScoreType", new XCData(puan.PuanTuru.Trim())),
                             new XElement("ScoreMin", new XCData(puan.EnKucukPuan.ToString())),
                             new XElement("Order", new XCData(puan.BasariSirasi.ToString()))
                             )
                        );
                    }
                }
            }
            else
            {
                var puanlar = PuanOnLisans(bolumler, sehirler);
                foreach (var puan in puanlar)
                {
                    if (puan.ProgramKodu != null)
                    {
                        xscore.Add(new XElement("Score",
                            new XElement("Id", puan.ProgramKodu),
                             new XElement("UniversityName", new XCData(puan.UniversiteAdi.Trim())),
                             new XElement("DepartmentCode", new XCData(puan.ProgramKodu.Trim())),
                             new XElement("DepartmentName", new XCData(puan.ProgramAdi.Trim())),
                             //new XElement("Quotas", new XCData(puan.Kontenjan.ToString())),
                             new XElement("Condition", new XCData((puan.OzelKosullar != null ? puan.OzelKosullar.Trim() : ""))),
                             new XElement("ScoreType", new XCData(puan.PuanTuru.Trim())),
                             new XElement("ScoreMin", new XCData(puan.EnKucukPuan.ToString()))
                             //new XElement("Order", new XCData(puan.BasariSirasi.ToString()))  
                           )
                        );
                    }
                }
            }           
            XDocument xdoc = new XDocument(new XElement("Data", xscore));
            xdoc.Save(DataPath + (lisans ? "Lisans" : "OnLisans") + @"_Score.xml");
        }
        public static void DataCalSql(bool lisans)
        {
            var bolumler = Bolum(lisans);
            BolumCalSql(lisans, bolumler);
            
        }
        public static void BolumCalSql(bool lisans, List<Bolum> bolumler)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=UniPuan;Integrated Security=True");
            baglanti.Open();
            foreach (var item in bolumler)
            {
                SqlCommand komut = new SqlCommand("INSERT INTO UP_ST_DEPARTMENT (DEPARTMENTID, DEPARTMENTNAME, SCORETYPE, EDUTYPE)" +
                " values (@DEPARTMENTID, @DEPARTMENTNAME, @SCORETYPE, @EDUTYPE)", baglanti);
                komut.Parameters.AddWithValue("@DEPARTMENTID", item.BolumId);
                komut.Parameters.AddWithValue("@DEPARTMENTNAME", item.BolumAdi);
                komut.Parameters.AddWithValue("@SCORETYPE", "0");
                komut.Parameters.AddWithValue("@EDUTYPE", "2");
                var sonuc = komut.ExecuteNonQuery();
              
            }
            baglanti.Close();
            foreach (var item in bolumler)
            {
                SehirCalSql(lisans, item);
            }
            
        }
        public static void SehirCalSql(bool lisans, Bolum bolum)
        {
            
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=UniPuan;Integrated Security=True");
            baglanti.Open();
            List<Bolum> bolumler = new List<FemClient.Bolum>();
            bolumler.Add(bolum);

            var city = Sehir(bolumler);
            foreach (var item in city)
            {
                SqlCommand komut = new SqlCommand("UP_SP_CITY_SAVE", baglanti);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@CITYID", item.ilId);
                komut.Parameters.AddWithValue("@CITYNAME", item.ilAdi);
                var sonuc = komut.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("INSERT into UP_ST_CITYDEPARTMENT (CITYID,DEPARTMENTID) values(@CITYID,@DEPARTMENTID)", baglanti);
                komut2.Parameters.AddWithValue("@CITYID", item.ilId);
                komut2.Parameters.AddWithValue("@DEPARTMENTID", bolum.BolumId);
                var sonuc2 = komut2.ExecuteNonQuery();
            }
            baglanti.Close();
            foreach (var item in city)
            {
                foreach (var blm in bolumler)
                {
                    UniversiteCalSql(lisans, blm, item);
                }
            }
        }
        public static void UniversiteCalSql(bool lisans, Bolum bolum,Sehir sehir)
        {         
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=UniPuan;Integrated Security=True");
            baglanti.Open();
            List<Bolum> bolumler = new List<FemClient.Bolum>();
            bolumler.Add(bolum);
            List<Sehir> sehirler = new List<FemClient.Sehir>();
            sehirler.Add(sehir);
            var universiteler = Universite(bolumler, sehirler);
            foreach (var item in universiteler)
            {
                SqlCommand komut = new SqlCommand("UP_SP_UNIVERSITY_SAVE", baglanti);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@UNIVERSITYID", item.UNIVERSITEID);
                komut.Parameters.AddWithValue("@UNIVERSITYNAME", item.Universitead);
                komut.Parameters.AddWithValue("@CITYID", sehir.ilId); 
                komut.Parameters.AddWithValue("@UNITYPEID", "2");
                var sonuc = komut.ExecuteNonQuery();
                
                SqlCommand komut1 = new SqlCommand("INSERT into UP_ST_UNIVERSITYDEPARTMENT (UNIVERSITYID,DEPARTMENTID) " +
              " values(@UNIVERSITYID,@DEPARTMENTID)", baglanti);
                komut1.Parameters.AddWithValue("@UNIVERSITYID", item.UNIVERSITEID);
                komut1.Parameters.AddWithValue("@DEPARTMENTID", bolum.BolumId);
                var sonuc1 = komut1.ExecuteNonQuery();
            }          
            baglanti.Close();
            PuanCalSql(lisans, bolumler, sehirler, universiteler);
        }
        public static void SehirCalSql2(bool lisans, List<Bolum> bolumler)
        {
            var sehirler = Sehir(bolumler);
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=UniPuan;Integrated Security=True");
            baglanti.Open();
            var city = Sehir(bolumler);
            foreach (var item in city)
            {
                SqlCommand komut = new SqlCommand("INSERT into UP_ST_CITY (CITYID,CITYNAME) values(@CITYID,@CITYNAME)", baglanti);
                komut.Parameters.AddWithValue("@CITYID", item.ilId);
                komut.Parameters.AddWithValue("@CITYNAME", item.ilAdi);
                var sonuc = komut.ExecuteNonQuery();
            }
            baglanti.Close();
            //UniversiteCalSql(lisans, bolumler, sehirler);
        }
        public static void UniversiteCalSql2(bool lisans, List<Bolum> bolumler, List<Sehir> sehirler)
        {
            // Üniveriste Department Tablosu oluştur aynı kayıtlar varsa .. yoksa Üniversite 
            var universiteler = Universite(bolumler, sehirler);
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=UniPuan;Integrated Security=True");
            baglanti.Open();
            var uni = Universite(bolumler,sehirler);
            foreach (var item in uni)
            {
                SqlCommand komut = new SqlCommand("INSERT into UP_ST_UNIVERSITY (UNIVERSITYID,UNIVERSITYNAME,CITYID,UNITYPEID) "+
               " values(@UNIVERSITYID,@UNIVERSITYNAME,@CITYID,@UNITYPEID)", baglanti);
                komut.Parameters.AddWithValue("@UNIVERSITYID", item.UNIVERSITEID);
                komut.Parameters.AddWithValue("@UNIVERSITYNAME", item.Universitead);
                komut.Parameters.AddWithValue("@CITYID", item.CITYID);
                komut.Parameters.AddWithValue("@UNITYPEID", item.UNITYPEID);
                var sonuc = komut.ExecuteNonQuery();
            }
            baglanti.Close();
            PuanCalSql(lisans, bolumler, sehirler, universiteler);
        }
      
        public static void PuanCalSql(bool lisans, List<Bolum> bolumler, List<Sehir> sehirler, List<Universite> universiteler)
        {         
            SqlConnection baglanti = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=UniPuan;Integrated Security=True");
            baglanti.Open();
            List<XElement> xscore = new List<XElement>();
            if (lisans)
            {
                var puanlar = PuanLisans(bolumler, sehirler, universiteler);
                foreach (var item in puanlar)
                {
                    SqlCommand komut = new SqlCommand("INSERT into UP_ST_PROGRAM (PROGRAMID,UNIVERSITYNAME,DEPARTMENTNAME,QUOTAS,CONDITION,SCORETYPE,SCOREMIN,ORDERR) " +
             " values (@PROGRAMID,@UNIVERSITYNAME,@DEPARTMENTNAME,@QUOTAS,@CONDITION,@SCORETYPE,@SCOREMIN,@ORDERR)", baglanti);
                    komut.Parameters.AddWithValue("@PROGRAMID", item.ProgramKodu);
                    komut.Parameters.AddWithValue("@UNIVERSITYNAME", item.UniversiteAdi);
                    komut.Parameters.AddWithValue("@DEPARTMENTNAME", item.BolumAdi);
                    komut.Parameters.AddWithValue("@QUOTAS", item.Kontenjan.HasValue ? (object)item.Kontenjan : DBNull.Value);
                    komut.Parameters.AddWithValue("@CONDITION", item.OzelKosullar == null ? DBNull.Value : (object)item.OzelKosullar);
                    komut.Parameters.AddWithValue("@SCORETYPE", item.PuanTuru == null ? DBNull.Value : (object)item.PuanTuru);
                    komut.Parameters.AddWithValue("@SCOREMIN", item.EnKucukPuan.HasValue ? (object)item.EnKucukPuan : DBNull.Value);
                    komut.Parameters.AddWithValue("@ORDERR", item.BasariSirasi.HasValue ? (object)item.BasariSirasi : DBNull.Value);
                    var sonuc = komut.ExecuteNonQuery();
                }
            }
            else
            {
                var puanlar = PuanOnLisans(bolumler, sehirler);
                foreach (var item in puanlar)
                {
                    if (item.ProgramKodu != null)
                    {
                        SqlCommand komut = new SqlCommand("INSERT into UP_ST_SCORE (PROGRAMID,UNIVERSITYNAME,DEPARTMENTNAME,QUOTAS,CONDITION,SCORETYPE,SCOREMIN,ORDERR) " +
             " values(@PROGRAMID,@UNIVERSITYNAME,@DEPARTMENTNAME,@QUOTAS,@CONDITION,@SCORETYPE,@SCOREMIN,@ORDERR)", baglanti);
                        komut.Parameters.AddWithValue("@PROGRAMID", item.ProgramKodu);
                        komut.Parameters.AddWithValue("@UNIVERSITYNAME", item.UniversiteAdi);
                        komut.Parameters.AddWithValue("@DEPARTMENTNAME", item.ProgramAdi);
                        komut.Parameters.AddWithValue("@CONDITION", item.OzelKosullar);
                        komut.Parameters.AddWithValue("@SCORETYPE", item.PuanTuru);
                        komut.Parameters.AddWithValue("@SCOREMIN", item.EnKucukPuan);
                        var sonuc = komut.ExecuteNonQuery();
                    }
                }
            }
        }      

    }
     
    public class Bolum
    {
        public string BolumAdi { get; set; }
        public string BolumId { get; set; }
    }
    public class Sehir
    {
        public string ilAdi { get; set; }
        public string ilId { get; set; }
    }
    public class Universite
    {
        public string Universitead { get; set; }
        public string UNIVERSITEID { get; set; }
        public int CITYID { get; set; }
        public int UNITYPEID { get; set; }
    }
}
