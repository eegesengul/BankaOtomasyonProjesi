using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXBankOtomasyonProje
{
    public partial class MusteriIslemleri : Form
    {
        public MusteriIslemleri()
        {
            InitializeComponent();
        }

        
         
        SqlConnection con = new SqlConnection(BaglanClass.connectionString);
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Giris form1 = new Giris();
            form1.Show();
            this.Hide();
        }

        private void MusteriIslemleri_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text = Giris.adSoyad;
            lblHesapNo.Text = Giris.mID.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBakiye.Text = Giris.mBakiye.ToString() + " TL ";
            HareketKaydet.kaydet(Giris.mID, "Bakiye görüntülendi.");
            DisplayAccountActivities();
        }

        private bool ValidateAmount(string amountText)
        {
            if (string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz!", "İşlem Hatası");
                return false;
            }

            if (!float.TryParse(amountText, out _))
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz!", "İşlem Hatası");
                return false;
            }

            return true;
        }


        private void DisplayAccountActivities()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand komut = new SqlCommand("select ID as 'İşlem ID', islem as 'İşlem Bilgisi', tarih as 'Tarih' from kullaniciHareketleri where musteriID=@p1", con);
                komut.Parameters.AddWithValue("@p1", Giris.mID);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                var ds = new DataSet();
                da.Fill(ds);
                guna2DataGridView1.DataSource = ds.Tables[0];

                if (guna2DataGridView1.Rows.Count > 0)
                {
                    int lastRowIndex = guna2DataGridView1.Rows.Count - 1;
                    guna2DataGridView1.FirstDisplayedScrollingRowIndex = lastRowIndex;
                    guna2DataGridView1.ClearSelection();
                    guna2DataGridView1.Rows[lastRowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void Reset()
        {
            txtEski.Text = "";
            txtYeni.Text = "";
            txtHesapNo.Text = "";
            txtMiktarCek.Text = "";
            txtMiktarHavale.Text = "";
            txtMiktarYatir.Text = "";
        }


        private void btnCek_Click(object sender, EventArgs e)
        {
            if (!ValidateAmount(txtMiktarCek.Text))
                return;

            float sayi = float.Parse(txtMiktarCek.Text);

            if (sayi > Giris.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye!", "Para Çekme İşlemi");
                return;
            }

            try
            {
                con.Open();
                SqlCommand komut = new SqlCommand("update kullaniciBilgileri set bakiye -= @p1 where ID = @p2", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Giris.mID);
                int sonuc = komut.ExecuteNonQuery();

                if (sonuc == 1)
                {
                    MessageBox.Show("Para çekme işlemi yapıldı.", "Müşteri Para Çekme İşlemi", MessageBoxButtons.OK);
                    Giris.mBakiye -= sayi;
                    HareketKaydet.kaydet(Giris.mID, (sayi + " TL Para çekim işlemi yapıldı."));
                    DisplayAccountActivities();
                }
                else
                {
                    MessageBox.Show("Para çekme işlemi yapılamadı!", "Müşteri Para Çekme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            Reset();
        }

        private void btnYatir_Click(object sender, EventArgs e)
        {
            if (!ValidateAmount(txtMiktarYatir.Text))
                return;

            float sayi = float.Parse(txtMiktarYatir.Text);

            if (sayi <= 5)
            {
                MessageBox.Show("5TL'den az para yatıramazsınız!", "Para Yatırma İşlemi Hatası");
                return;
            }

            try
            {
                con.Open();
                SqlCommand komut = new SqlCommand("update kullaniciBilgileri set bakiye += @p1 where ID = @p2", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Giris.mID);
                int sonuc = komut.ExecuteNonQuery();

                if (sonuc == 1)
                {
                    MessageBox.Show("Para yatırma işlemi yapıldı.", "Müşteri Para Yatırma İşlemi", MessageBoxButtons.OK);
                    Giris.mBakiye += sayi;
                    HareketKaydet.kaydet(Giris.mID, (sayi + " TL Para yatırma işlemi yapıldı."));
                    DisplayAccountActivities();
                }
                else
                {
                    MessageBox.Show("Para yatırma işlemi yapılamadı!", "Müşteri Para Yatırma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            Reset();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMiktarHavale.Text) || string.IsNullOrWhiteSpace(txtHesapNo.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Havale/EFT İşlemi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateAmount(txtMiktarHavale.Text))
                return;

            float sayi = float.Parse(txtMiktarHavale.Text);

            if (sayi > Giris.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye", "Havale/EFT İşlemi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sayi < 5)
            {
                MessageBox.Show("Lütfen 5 TL üzeri bir miktar giriniz!", "Havale/EFT İşlemi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand komut = new SqlCommand("update kullaniciBilgileri set bakiye= bakiye -  @p1 where ID= @p2", con);
            komut.Parameters.AddWithValue("@p1", sayi);
            komut.Parameters.AddWithValue("@p2", Giris.mID);

            SqlCommand komut2 = new SqlCommand("update kullaniciBilgileri set bakiye= bakiye +  @p3 where ID= @p4", con);
            komut2.Parameters.AddWithValue("@p3", sayi);
            komut2.Parameters.AddWithValue("@p4", txtHesapNo.Text);

            try
            {
                con.Open();
                int sonuc1 = komut2.ExecuteNonQuery();
                con.Close();

                if (sonuc1 == 1)
                {
                    con.Open();
                    komut.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Havale işlemi gerçekleştirildi", "Havale/EFT İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Giris.mBakiye -= sayi;

                    HareketKaydet.kaydet(Giris.mID, $"{sayi} TL Havale/EFT alıcıya gönderildi.");
                    HareketKaydet.kaydet(int.Parse(txtHesapNo.Text), $"{sayi} TL Havale/EFT göndericiden alındı.");
                    DisplayAccountActivities();
                }
                else
                {
                    MessageBox.Show("Alıcı Hesap No Hatalı!", "Havale/EFT Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            Reset();
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEski.Text) || string.IsNullOrWhiteSpace(txtYeni.Text))
            {
                MessageBox.Show("Lütfen eski ve yeni şifreyi giriniz!", "Şifre Değiştirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtYeni.Text.Length < 6)
            {
                MessageBox.Show("Lütfen yeni şifreniz en az 6 karakter uzunluğunda olsun!", "Şifre Değiştirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand komut = new SqlCommand("update kullaniciBilgileri set sifre = @p1 where ID = @p2 and sifre = @p3", con);
            komut.Parameters.AddWithValue("@p1", txtYeni.Text);
            komut.Parameters.AddWithValue("@p3", txtEski.Text);
            komut.Parameters.AddWithValue("@p2", Giris.mID);

            try
            {
                con.Open();
                int sonuc = komut.ExecuteNonQuery();
                con.Close();

                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre değiştirme işlemi gerçekleştirildi", "Şifre Değiştirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HareketKaydet.kaydet(Giris.mID, "Şifre değiştirme işlemi yapıldı");
                    DisplayAccountActivities();
                }
                else
                {
                    MessageBox.Show("Eski şifreniz uyuşmadı!", "Şifre Değiştirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            Reset();
        }

        
    }
}
