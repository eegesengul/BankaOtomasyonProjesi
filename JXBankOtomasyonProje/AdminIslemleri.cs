
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JXBankOtomasyonProje
{
    public partial class AdminIslemleri : Form
    {
        public AdminIslemleri()
        {
            InitializeComponent();
            DisplayAccounts();
        }

         
         
        SqlConnection con = new SqlConnection(BaglanClass.connectionString);
        private void DisplayAccounts()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select ID as 'Müşteri No/ID', tcNo as 'TC Kimlik No', adSoyad as 'Ad Soyad', adres as 'Adres', telefon as 'Telefon No', bakiye as 'Bakiye', durum as 'Durum', cinsiyet as 'Cinsiyet', meslek as 'Meslek' from kullaniciBilgileri", con);
                SqlCommandBuilder builder = new SqlCommandBuilder();
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
                con.Close();
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Giris form1 = new Giris();
            form1.Show();
            this.Hide();
        }

        private void Reset()
        {
            txtTcNo.Text = "";
            txtAdSoyad.Text = "";
            txtAdres.Text = "";
            txtTel.Text = "";
            txtBakiye.Text = "";
            txtDurum.Text = "";
            txtCinsiyet.Text = "";
            txtMeslek.Text = "";
        }

        private bool ValidateInputs()
        {
            if (txtTcNo.Text == "" || txtAdSoyad.Text == "" || txtAdres.Text == "" || txtTel.Text == "" || txtBakiye.Text == "" || txtDurum.Text == "" || txtCinsiyet.Text == "" || txtMeslek.Text == "")
            {
                MessageBox.Show("Tüm Alanları Eksiksiz Doldurunuz!", "Müşteri Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtTcNo.Text, @"^\d{11}$"))
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli ve sadece sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtAdSoyad.Text, @"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$"))
            {
                MessageBox.Show("Ad Soyad kısmına sadece harfler boşluk girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtTel.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Telefon numarası 10 haneli ve sadece sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtBakiye.Text, out _))
            {
                MessageBox.Show("Bakiye alanına sadece sayısal değer giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDurum.Text != "0" && txtDurum.Text != "1")
            {
                MessageBox.Show("Durum alanına sadece 0 veya 1 girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool DoesRecordExist(string tcNo, string telefon, int currentId = 0)
        {
            try
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM kullaniciBilgileri WHERE (tcNo = @tcNo OR telefon = @telefon) AND ID != @currentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tcNo", tcNo);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@currentId", currentId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı kontrol hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; 
            }
            finally
            {
                con.Close();
            }
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            if (DoesRecordExist(txtTcNo.Text, txtTel.Text))
            {
                MessageBox.Show("Aynı TC Kimlik numarası veya telefon numarası ile başka bir kayıt zaten mevcut.", "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal bakiye = decimal.Parse(txtBakiye.Text);

                con.Open();
                SqlCommand komut = new SqlCommand("insert into kullaniciBilgileri(tcNo, adSoyad, adres, telefon, sifre, bakiye, durum, cinsiyet, meslek) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", con);
                komut.Parameters.AddWithValue("@p1", txtTcNo.Text);
                komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtAdres.Text);
                komut.Parameters.AddWithValue("@p4", txtTel.Text);
                komut.Parameters.AddWithValue("@p5", txtTcNo.Text);
                komut.Parameters.AddWithValue("@p6", bakiye);
                komut.Parameters.AddWithValue("@p7", txtDurum.Text);
                komut.Parameters.AddWithValue("@p8", txtCinsiyet.Text);
                komut.Parameters.AddWithValue("@p9", txtMeslek.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Yeni Müşteri Kaydı Oluşturuldu.", "Müşteri Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Müşteri Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }

            Reset();
            DisplayAccounts();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            if (DoesRecordExist(txtTcNo.Text, txtTel.Text, Key))
            {
                MessageBox.Show("Aynı TC Kimlik numarası veya telefon numarası ile başka bir kayıt zaten mevcut.", "Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal bakiye = decimal.Parse(txtBakiye.Text);

                con.Open();
                SqlCommand komut = new SqlCommand("update kullaniciBilgileri set tcNo=@p1, adSoyad=@p2, adres=@p3, telefon=@p4,bakiye=@p6, durum=@p7, cinsiyet=@p8, meslek=@p9 where ID=@p10", con);
                komut.Parameters.AddWithValue("@p1", txtTcNo.Text);
                komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtAdres.Text);
                komut.Parameters.AddWithValue("@p4", txtTel.Text);
                komut.Parameters.AddWithValue("@p6", bakiye);
                komut.Parameters.AddWithValue("@p7", txtDurum.Text);
                komut.Parameters.AddWithValue("@p8", txtCinsiyet.Text);
                komut.Parameters.AddWithValue("@p9", txtMeslek.Text);
                komut.Parameters.AddWithValue("@p10", Key);
                komut.ExecuteNonQuery();
                MessageBox.Show("Müşteri Bilgileri Güncellendi.", "Müşteri Bilgisi Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Müşteri Bilgisi Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }

            Reset();
            DisplayAccounts();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Lütfen Bir Hesap Seçiniz!", "Müşteri Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con.Open();

                
                SqlCommand hareketSilKomut = new SqlCommand("DELETE FROM kullaniciHareketleri WHERE musteriID = @p1", con);
                hareketSilKomut.Parameters.AddWithValue("@p1", Key);
                hareketSilKomut.ExecuteNonQuery();

                
                SqlCommand kullaniciSilKomut = new SqlCommand("DELETE FROM kullaniciBilgileri WHERE ID = @p1", con);
                kullaniciSilKomut.Parameters.AddWithValue("@p1", Key);
                kullaniciSilKomut.ExecuteNonQuery();

                MessageBox.Show("Müşteri ve ona ait hareket kayıtları silindi.", "Müşteri Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Müşteri Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }

            Reset();
            DisplayAccounts();
        }



        int Key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                txtTcNo.Text = row.Cells[1].Value.ToString();
                txtAdSoyad.Text = row.Cells[2].Value.ToString();
                txtAdres.Text = row.Cells[3].Value.ToString();
                txtTel.Text = row.Cells[4].Value.ToString();
                txtBakiye.Text = row.Cells[5].Value.ToString();
                txtDurum.Text = row.Cells[6].Value.ToString();
                txtCinsiyet.Text = row.Cells[7].Value.ToString();
                txtMeslek.Text = row.Cells[8].Value.ToString();
                if (txtTcNo.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(row.Cells[0].Value.ToString());
                }
            }
        }
    }
}
