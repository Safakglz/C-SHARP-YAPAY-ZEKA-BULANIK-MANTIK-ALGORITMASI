using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace Bulanık_Çamaşır_Makinesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable tablo = new DataTable();
        Kural k = new Kural();
        private void Form1_Load(object sender, EventArgs e)//DataGridview e Verileri Çekme
        {
            button2.Enabled = false;
            button3.Enabled = false;
            k.DosyadanOku();
            tablo.Columns.Add("No", typeof(int));
            tablo.Columns.Add("Hassaslık", typeof(string));
            tablo.Columns.Add("Miktar", typeof(string));
            tablo.Columns.Add("Kirlilik", typeof(string));
            tablo.Columns.Add("Dönüş Hızı", typeof(string));
            tablo.Columns.Add("Süre", typeof(string));
            tablo.Columns.Add("Deterjan", typeof(string));
            
            for (int i = 0; i < k.L.Count; i++)
            {

                tablo.Rows.Add(k.L[i].Split('-')[0], k.L[i].Split('-')[1], k.L[i].Split('-')[2], k.L[i].Split('-')[3], k.L[i].Split('-')[4], k.L[i].Split('-')[5], k.L[i].Split('-')[6]);
                dataGridView1.DataSource = tablo;
            }
            
            dataGridView1.ClearSelection();
            dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Monotype Corsiva", 12);

        }

        Bulanık bn;
        public void renklendir()//Renkleri Seç
        {
            for (int i = 0; i < bn.Renklendir.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                renk.BackColor = Color.Aquamarine;
                renk.ForeColor = Color.DimGray;
                dataGridView1.Rows[bn.Renklendir[i]].DefaultCellStyle = renk;
            }
        }
        public void datagridsıfırla()//Datagrid ilk anına dönder
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }
        private void button1_Click(object sender, EventArgs e)//Bulanıklaştırma Datagridview de Kuralları Gösterme
        {
            
            datagridsıfırla();
            button1.Enabled = false;
            button2.Enabled = true;
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            bn = new Bulanık(Convert.ToDouble(numericUpDown1.Value), Convert.ToDouble(numericUpDown2.Value), Convert.ToDouble(numericUpDown3.Value));
            bn.bulanık(bn.Hassaslık,bn.Miktar,bn.Kirlilik);
            label4.Text = bn.Hass;
            label5.Text = bn.Mikk;
            label6.Text = bn.Kirr;
            bn.datarenk(k.L, bn.Hbulanık, bn.Mbulanık, bn.Kbulanık);
            renklendir();
            
        }
        
        private void button2_Click(object sender, EventArgs e)//Mandani Hesaplama
        {
            button2.Enabled = false;
            button3.Enabled = true;
            listBox1.Items.Clear();
            bn.mandanihesapla(bn.Mandani);
            foreach (var item in bn.Listem)
            {
                listBox1.Items.Add(item);
            }
            
        }
        private void button3_Click(object sender, EventArgs e)//Durulaştırma hesapalama
        {
            
            Durulaştır d = new Durulaştır();
            button3.Enabled = false;
            button1.Enabled = true;

            d.durula(bn.Listem,bn.Duruladhız,bn.Durulasüre,bn.Duruladet);

            textBox1.Text = d.Hesapla(d.Sonuclistdön).ToString();
            d.Dönüshızıcentroid(d.Xicinmax);
            textBox4.Text= d.centroidhesap(d.Gercek).ToString();

            textBox2.Text = d.Hesapla(d.Sonuclistsüre).ToString();
            d.Sürecentroid(d.Xicinmax);
            textBox6.Text= d.centroidhesap(d.Gercek).ToString();
            
            textBox3.Text = d.Hesapla(d.Sonuclistdet).ToString();
            d.Deterjancentroid(d.Xicinmax);
            textBox5.Text = d.centroidhesap(d.Gercek).ToString();
        }

        private void renk1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Aquamarine;
            btn.ForeColor = Color.DimGray;
        }

        private void renk2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DimGray;
            btn.ForeColor = Color.Aquamarine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       }
}
