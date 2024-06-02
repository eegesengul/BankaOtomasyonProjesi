using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;



namespace JXBankOtomasyonProje
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        
         
        SqlConnection con = new SqlConnection(BaglanClass.connectionString);
        public static string adSoyad = "";
        public static int mID = 0;
        public static float mBakiye = 0.0f;
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum su = new SifremiUnuttum();
            su.Show();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi = textBox1.Text;
            string parola = textBox2.Text;
            bool sonuc = false;
            bool yanlisKullaniciParola = false;
            bool durumSifir = false;

            if (radioButton1.Checked)
            {
                if (kAdi == "admin" && parola == "123")
                {
                    AdminIslemleri yi= new AdminIslemleri();
                    yi.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalý Kullanýcý Adý/TC veya Parola!", "Hatalý Giriþ Denemesi");
                }
            }
            else
            {
                con.Open();

                SqlCommand komut = new SqlCommand("select * from kullaniciBilgileri where tcno = @p1 and sifre = @p2", con);
                komut.Parameters.AddWithValue("@p1", kAdi);
                komut.Parameters.AddWithValue("@p2", parola);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["durum"].ToString() == "1")
                    {
                        adSoyad = dr["adSoyad"].ToString();
                        mID = int.Parse(dr["ID"].ToString());
                        mBakiye = float.Parse(dr["bakiye"].ToString());
                        sonuc = true;
                    }
                    else
                    {
                        durumSifir = true;
                    }
                }
                else
                {
                    yanlisKullaniciParola = true;
                }
                con.Close();

                if (sonuc)
                {
                    MusteriIslemleri mi = new MusteriIslemleri();
                    mi.Show();
                    this.Hide();
                }
                else if (yanlisKullaniciParola)
                {
                    MessageBox.Show("Hatalý Kullanýcý Adý/TC veya Parola!", "Hatalý Giriþ Denemesi");
                }
                else if (durumSifir)
                {
                    MessageBox.Show("Hesabýnýz aktif deðil. Lütfen yetkili ile iletiþime geçin.", "Hesap Durumu");
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
