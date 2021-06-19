using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulanık_Çamaşır_Makinesi
{
    public class Bulanık
    {
        Kural k;
        public Bulanık()
        {
            k = new Kural();
        }
      

       private List<string> hbulanık;
       private List<string> mbulanık;
       private List<string> kbulanık;
        private List<string> mandani;
        private List<string> duruladhız;
        private List<string> durulasüre;
        private List<string> duruladet;
        private string hass;
        private string mikk;
        private string kirr;
        private double hassaslık;
        private double miktar;
        private double kirlilik;

        public List<string> Hbulanık { get => hbulanık; set => hbulanık = value; }
        public List<string> Mbulanık { get => mbulanık; set => mbulanık = value; }
        public List<string> Kbulanık { get => kbulanık; set => kbulanık = value; }
        public List<string> Mandani { get => mandani; set => mandani = value; }
        public List<string> Duruladhız { get => duruladhız; set => duruladhız = value; }
        public List<string> Durulasüre { get => durulasüre; set => durulasüre = value; }
        public List<string> Duruladet { get => duruladet; set => duruladet = value; }
        public string Hass { get => hass; set => hass = value; }
        public string Mikk { get => mikk; set => mikk = value; }
        public string Kirr { get => kirr; set => kirr = value; }
        public double Hassaslık { get => hassaslık; set => hassaslık = value; }
        public double Miktar { get => miktar; set => miktar = value; }
        public double Kirlilik { get => kirlilik; set => kirlilik = value; }
        public double Hmandani { get => hmandani; set => hmandani = value; }
        public double Mmandani { get => mmandani; set => mmandani = value; }
        public double Kmandani { get => kmandani; set => kmandani = value; }
        public List<double> Listmandani { get => listmandani; set => listmandani = value; }
        public List<double> Listem { get => listem; set => listem = value; }
        public List<int> Renklendir { get => renklendir; set => renklendir = value; }

        public Bulanık(double hassaslık, double miktar, double kirlilik)
        {
            this.hassaslık = hassaslık;
            this.miktar = miktar;
            this.kirlilik = kirlilik;
            
        }
        public void bulanık(double has, double mik, double kir)//Bulanık Aralığını Bulma
        {

            Hbulanık = new List<string>();
            Mbulanık = new List<string>();
            Kbulanık = new List<string>();

            if ((has >= 0 && has <= 4))
            {
               Hass += "Sağlam ";
               Hbulanık.Add("Sağlam");
            }
            if ((has >= 3 && has <= 7))
            {

                Hass += "Orta ";
                Hbulanık.Add("Orta");
            }
            if ((has >= 5.5 && has <= 10))
            {

                Hass += "Hassas ";
                Hbulanık.Add("Hassas");
            }
            if ((mik >= 0 && mik <= 4))
            {
                Mikk += "Küçük ";
                Mbulanık.Add("Küçük");
            }
            if ((mik >= 3 && mik <= 7))
            {

                Mikk += "Orta ";
                Mbulanık.Add("Orta");
            }
            if ((mik >= 5.5 && mik <= 10))
            {

                Mikk += "Büyük ";
                Mbulanık.Add("Büyük");
            }
            if ((kir >= 0 && kir <= 4.5))
            {
                Kirr+= "Küçük ";
                Kbulanık.Add("Küçük");
            }
            if ((kir >= 3 && kir <= 7))
            {

                Kirr += "Orta ";
                Kbulanık.Add("Orta");
            }
            if ((kir >= 5.5 && kir <= 10))
            {

                Kirr += "Büyük ";
                Kbulanık.Add("Büyük");
            }
           
        }
        private List<int> renklendir;
        public void datarenk(List<string> gelen, List<string> bulanık1, List<string> bulanık2, List<string> bulanık3)
        {
            
            Mandani = new List<string>();
            Duruladhız = new List<string>();
            Durulasüre = new List<string>();
            Duruladet = new List<string>();
            Renklendir = new List<int>();
            Renklendir.Clear();
            for (int i = 0; i < gelen.Count; i++)
            {
               
                for (int a = 0; a < bulanık1.Count; a++)
                {
                    for (int b = 0; b < bulanık2.Count; b++)
                    {
                        for (int c = 0; c < bulanık3.Count; c++)
                        {


                            if (bulanık1[a].ToString() == gelen[i].ToString().Split('-')[1] && bulanık2[b].ToString() == gelen[i].ToString().Split('-')[2] && bulanık3[c].ToString() == gelen[i].ToString().Split('-')[3])
                            {
                               
                                Mandani.Add(bulanık1[a] + " " + bulanık2[b] + " " + bulanık3[c]);
                                Duruladhız.Add(gelen[i].ToString().Split('-')[4]);
                                Durulasüre.Add(gelen[i].ToString().Split('-')[5]);
                                Duruladet.Add(gelen[i].ToString().Split('-')[6]);
                                Renklendir.Add(i);
                            }


                        }
                    }
                }
                
            }
        }

       private double hmandani;
       private double mmandani;
       private double kmandani;
        public void hamandani(string a)//Hassaslık Mandani Hesaplama
        {
            if (a == "Sağlam")
            {
                if (Hassaslık >= 0 && Hassaslık <= 2)
                {
                    Hmandani = 1;
                }
                else if (Hassaslık > 2 && Hassaslık < 4)
                {
                    Hmandani = ((Hassaslık - 2) / (2 - 4)) + 1;
                }
                else if (Hassaslık == 4)
                {
                    Hmandani = 0;
                }

            }
            if (a == "Orta")
            {
                if (Hassaslık > 3 && Hassaslık < 5)
                {
                    Hmandani = ((hassaslık - 3) / (5 - 3));
                }
                else if (Hassaslık > 5 && Hassaslık < 7)
                {
                    Hmandani = ((Hassaslık - 5) / (5 - 7)) + 1;
                }
                else if (Hassaslık == 3 || Hassaslık == 7)
                {
                    Hmandani = 0;
                }
                else if (Hassaslık == 5)
                {
                    Hmandani = 1;
                }
            }
            if (a == "Hassas")
            {
                if (Hassaslık > 5.5 && Hassaslık < 8)
                {
                    Hmandani = ((Hassaslık - 5.5) / (8 - 5.5));

                }
                else if (Hassaslık >= 8 && Hassaslık <= 10)
                {
                    Hmandani = 1;
                }
                else if (Hassaslık == 5.5)
                {
                    Hmandani = 0;
                }
            }
        }
        public void mimandani(string a)//Miktar Mandani Hesaplma
        {
            if (a == "Küçük")
            {
                if (Miktar >= 0 && Miktar <= 2)
                {
                    Mmandani = 1;
                }
                else if (Miktar > 2 && Miktar < 4)
                {
                    Mmandani = ((Miktar - 2) / (2 - 4)) + 1;
                }
                else if (Miktar == 4)
                {
                    Mmandani = 0;
                }

            }
            if (a == "Orta")
            {
                if (Miktar > 3 && Miktar < 5)
                {
                    Mmandani = ((Miktar - 3) / (5 - 3));
                }
                else if (Miktar > 5 && Miktar < 7)
                {
                    Mmandani = ((Miktar - 5) / (5 - 7)) + 1;
                }
                else if (Miktar == 3 || Miktar == 7)
                {
                    Mmandani = 0;
                }
                else if (Miktar == 5)
                {
                    Mmandani = 1;
                }

            }
            if (a == "Büyük")
            {
                if (Miktar > 5.5 && Miktar < 8)
                {
                    Mmandani = ((Miktar - 5.5) / (8 - 5.5));

                }
                else if (Miktar >= 8 && Miktar <= 10)
                {
                    Mmandani = 1;
                }
                else if (Miktar == 5.5)
                {
                    Mmandani = 0;
                }
            }
        }
        public void kimandani(string a)//Kirlilik Mandani Hesaplama
        {
            if (a == "Küçük")
            {
                if (Kirlilik >= 0 && Kirlilik <= 2)
                {
                    Kmandani = 1;
                }
                else if (Kirlilik > 2 && Kirlilik < 4.5)
                {
                    Kmandani = ((Kirlilik - 2) / (2 - 4.5)) + 1;
                }
                else if (Kirlilik == 4.5)
                {
                    Mmandani = 0;
                }
            }
            if (a == "Orta")
            {
                if (Kirlilik > 3 && Kirlilik < 5)
                {
                    Kmandani = ((Kirlilik - 3) / (5 - 3));
                }
                else if (Kirlilik > 5 && Kirlilik < 7)
                {
                    Kmandani = ((Kirlilik - 5) / (5 - 7)) + 1;
                }
                else if (Kirlilik == 3 || Kirlilik == 7)
                {
                    Kmandani = 0;
                }
                else if (Kirlilik == 5)
                {
                    Kmandani = 1;
                }

            }
            if (a == "Büyük")
            {
                if (Kirlilik > 5.5 && Kirlilik < 8)
                {
                    Kmandani = ((Kirlilik - 5.5) / (8 - 5.5));

                }
                else if (Kirlilik >= 8 && Kirlilik <= 10)
                {
                    Kmandani = 1;
                }
                else if (Kirlilik == 5.5)
                {
                    Mmandani = 0;
                }

            }
        }
       private List<double> listmandani;
       private List<double> listem;
       public void mandanihesapla(List<string> gelen)
        {
            Listmandani = new List<double>();
            Listem = new List<double>();
            Listmandani.Clear();
            for (int i = 0; i < gelen.Count; i++)
            {
                string hasmandani = gelen[i].Split(' ')[0];
                string mikmandani = gelen[i].Split(' ')[1];
                string kirmandani = gelen[i].Split(' ')[2];

                hamandani(hasmandani);
                mimandani(mikmandani);
                kimandani(kirmandani);

                Listmandani.Add(Hmandani);
                Listmandani.Add(Mmandani);
                Listmandani.Add(Kmandani);

                Listmandani.Sort();
                Listem.Add(Listmandani[0]);
                Listmandani.Clear();
            }
        }

    }
}
