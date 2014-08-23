using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniPuan.FemClient
{
    public class FemHelper
    {
        public static List<Bolum> LisansBolumler()
        {
            var puanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19";
            var universiteTuru = "1,2,3,4";
            var gelenAralik = "BasariAralik|0|0";
            var yeniBolumlerGelsinmi = true;
            var gelenOgrenimTuru = "0";
            var gelenBurs = "0";
            var gelenOgrenimDili = "0";
            Fem.FemTercihWebServisSoapClient client = new Fem.FemTercihWebServisSoapClient();
            var bolumlerJson = client.GetLisansBolumler(puanTuru, universiteTuru, gelenAralik, yeniBolumlerGelsinmi, gelenOgrenimTuru, gelenBurs, gelenOgrenimDili);
            List<Bolum> bolumler = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Bolum>>(bolumlerJson);
            return bolumler;
        }
        public static List<Sehir> LisansSehirler(List<Bolum> bolumler)
        {
            var gelenPuanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19";
            var universiteTuru = "1,2,3,4";
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
        public static List<Universite> LisansUniversiteler(List<Bolum> bolumler, List<Sehir> sehirler)
        {
            var gelenPuanTuru = "2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19";
            var universiteTuru = "1,2,3,4";
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
