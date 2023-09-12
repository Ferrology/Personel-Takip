using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;



namespace WinFormPersonelTakip
{
    class personeller
    {


        [BsonId]
       // [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("sicil")]
        public int sicil { get; set; }


        [BsonElement("ad")]
        public string ad { get; set; }


        [BsonElement("soyad")]
        public string soyad { get; set; }


      //  [BsonElement("cinsiyet")]
     //   public string cinsiyet { get; set; }

       
        [BsonElement("dogumTarihi")]
        public DateTime? dogumTarihi { get; set; }


        [BsonElement("birim")]
        public string birim { get; set; }


        [BsonElement("cepTel")]
        public string cepTel { get; set; }


        [BsonElement("adres")]
        public string Adres { get; set; }

        


     

        public personeller(int sicil, string ad, string soyad, DateTime dogumTarihi, string birim,string cepTel, string adres)

        {
            this.sicil = sicil;
            this.ad = ad;
            this.soyad = soyad;
        
            this.dogumTarihi = dogumTarihi;
            this.birim = birim;
            this.cepTel = cepTel;
            this.Adres = adres;
        }

        /*public personeller(Func<object, bool> p, string ad, string soyad, DateTime dogumTarihi, string birim, string cepTel, string adres)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.dogumTarihi = dogumTarihi;
            this.birim = birim;
            this.cepTel = cepTel;
            Adres = adres;
        }*/
    }
}
