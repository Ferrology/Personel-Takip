using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WinFormPersonelTakip
{
    public partial class Form1 : Form
    {

        static MongoClient client = new MongoClient("mongodb://localhost:27017");
        static IMongoDatabase db = client.GetDatabase("PersonlDb");
        static IMongoCollection<personeller> collection = db.GetCollection<personeller>("personeller");
       

        //private object dataGridView1;
        //DataGridView dataGridView1 = new DataGridView();
        // private object e;

        public void ReadAllDocument()
        {
          
            List<personeller> list = collection.AsQueryable().ToList<personeller>();

            dg.DataSource = list;
            textBox1.Text = dg.Rows[0].Cells[0].Value.ToString();
            // txtSicil.Text = dg.Rows[0].Cells[0].Value.ToString();
            // txtAd.Text = dg.Rows[0].Cells[1].Value.ToString();
            // txtSoyad.Text = dg.Rows[0].Cells[2].Value.ToString();
            //// radiobtnErkek.Text = dg.Rows[0].Cells[3].Value.ToString();
            // maskedDogumTarihi.Text = dg.Rows[0].Cells[4].Value.ToString();
            // nbbBirim.Text = dg.Rows[0].Cells[5].Value.ToString();
            // maskedCepTel.Text = dg.Rows[0].Cells[6].Value.ToString();
            // txtAdres.Text = dg.Rows[0].Cells[7].Value.ToString();

        }
        
        public Form1()
        {
            InitializeComponent();
            ReadAllDocument();

        }



       

         private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             textBox1.Text= dg.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSicil.Text = dg.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAd.Text = dg.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoyad.Text = dg.Rows[e.RowIndex].Cells[3].Value.ToString();
           // radiobtnErkek.Text = dg.Rows[e.RowIndex].Cells[3].Value.ToString();
            maskedDogumTarihi.Text = dg.Rows[e.RowIndex].Cells[4].Value.ToString();
            nbbBirim.Text = dg.Rows[e.RowIndex].Cells[5].Value.ToString();
           // maskedCepTel.Text = dg.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtAdres.Text = dg.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            int sicil = int.Parse(txtSicil.Text);
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            //string cinsiyet = radiobtnErkek.Text;
            DateTime dogumTarihi = DateTime.Parse(maskedDogumTarihi.Text);
            string birim = nbbBirim.Text;
            string cepTel = maskedCepTel.Text;

            string adres = txtAdres.Text;

            personeller s = new personeller(sicil, ad, soyad,  dogumTarihi, birim, cepTel, adres);
            collection.InsertOne(s);
            ReadAllDocument();

            /*
            var filter = Builders<personeller>.Filter.Empty;
            var count = collection.CountDocuments(filter);
            textBox2.Text = count.ToString();

            */
        }

       

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            int sicil = int.Parse(txtSicil.Text);
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            //string cinsiyet = radiobtnErkek.Text;
            DateTime dogumTarihi = DateTime.Parse(maskedDogumTarihi.Text);
            string birim = nbbBirim.Text;
            string cepTel = maskedCepTel.Text;
            string adres = txtAdres.Text;

             var updateDef = Builders<personeller>.Update.Set("sicil", sicil)
                                                         .Set("ad", ad)
                                                         .Set("soyad", soyad)
                                                         .Set("dogumTarihi", dogumTarihi)
                                                         .Set("cepTel", cepTel)
                                                         .Set("adres",adres);
                                                         
             
            collection.UpdateOne(s => s.Id == ObjectId.Parse(textBox1.Text), updateDef);
            ReadAllDocument();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(textBox1.Text));
            ReadAllDocument();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            //string name = txtAra.Text;
            //List<personeller> list = collection.AsQueryable().Where(x =>  x.ad.Contains(name)).ToList();
            //dg.DataSource = list;

            //int count = dg.Rows.Count;
            //textBox2.Text = count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string name = txtAra.Text;
            List<personeller> list = collection.AsQueryable().Where(x => x.ad.Contains(name)).ToList();
            dg.DataSource = list;

            int count = dg.Rows.Count;
            textBox2.Text = count.ToString();

            Console.WriteLine("Hello");
        }

     
        /*
private void btnToplu_Click(object sender, EventArgs e)
{
var rnd = new Random();
var personellerList = new List<personeller>();

for (int i = 0; i < 1000000; i++)
{
int sicil = rnd.Next(1000000, 9999999);
string ad = "Ad" + rnd.Next(1000, 9999);
string soyad = "Soyad" + rnd.Next(1000, 9999);
DateTime dogumTarihi = new DateTime(rnd.Next(1950, 2010), rnd.Next(1, 12), rnd.Next(1, 28));
string birim = "Birim" + rnd.Next(1, 10);
string cepTel = "05" + rnd.Next(10000000, 99999999);
string adres = "Adres" + rnd.Next(1000, 9999);

personeller s = new personeller(sicil, ad, soyad, dogumTarihi, birim, cepTel, adres);
personellerList.Add(s);
}

collection.InsertMany(personellerList);
ReadAllDocument();
}
*/
        /*  private void textBox2_TextChanged(object sender, EventArgs e)
          {
              var filter = Builders<personeller>.Filter.Empty;
              var count =  collection.CountDocuments(filter);
              textBox2.Text = count.ToString();
            //  int count = dg.Rows.Count;
            //  textBox2.Text = count.ToString();


          }*/


    }
}
