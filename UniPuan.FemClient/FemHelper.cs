using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            get { return @"D:\WheIS\Personel\Sumeyye\UniPuan\Source\trunk\UniPuan.FemClient\Data\"; }
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
        public static List<SonuclarSurrogate> Puan(List<Bolum> bolumler, List<Sehir> sehirler, List<Universite> universiteler)
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
            var puanlar = Puan(bolumler, sehirler, universiteler);
            List<XElement> xscore = new List<XElement>();
            foreach (var puan in puanlar)
            {
                if (puan.ProgramKodu != null)
                {


                    xscore.Add(new XElement("Score",
                        new XElement("Id", puan.ProgramKodu),
                         new XElement("UniversityName", new XCData(puan.UniversiteAdi.Trim()),
                         new XElement("DepartmentName", new XCData(puan.BolumAdi.Trim()),
                         new XElement("Quotas", new XCData(puan.Kontenjan.ToString())),
                         new XElement("Condition", new XCData((puan.OzelKosullar != null ? puan.OzelKosullar.Trim() : "")),
                         new XElement("ScoreType", new XCData(puan.PuanTuru.Trim()),
                             new XElement("ScoreMin", new XCData(puan.EnKucukPuan.ToString()),
                                 new XElement("Order", new XCData(puan.BasariSirasi.ToString())
                             )
                        )))))));
                }
            }
            XDocument xdoc = new XDocument(new XElement("Data", xscore));
            xdoc.Save(DataPath + (lisans ? "Lisans" : "OnLisans") + @"_Score.xml");
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
    }
}
