using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JXBankOtomasyonProje
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        
         
        SqlConnection con = new SqlConnection(BaglanClass.connectionString);
        private void Reset()
        {
            txtTc.Text = "";
            txtSifre.Text = "";
            txtTel.Text = "";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTc.Text) || string.IsNullOrWhiteSpace(txtSifre.Text) || string.IsNullOrWhiteSpace(txtTel.Text))
            {
                MessageBox.Show("Lütfen Alanları Eksiksiz Doldurunuz!", "Şifre Unutma İşlemi Hatası");
                return false;
            }

            if (txtTc.Text.Length != 11 || !IsNumeric(txtTc.Text))
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli ve sadece sayılardan oluşmalıdır!", "Şifre Unutma İşlemi Hatası");
                return false;
            }

            if (txtTel.Text.Length != 10 || !IsNumeric(txtTel.Text))
            {
                MessageBox.Show("Telefon Numarası 10 haneli ve sadece sayılardan oluşmalıdır!", "Şifre Unutma İşlemi Hatası");
                return false;
            }

            if (txtSifre.Text.Length < 6)
            {
                MessageBox.Show("En az 6 karakterden oluşan bir şifre belirleyiniz!", "Şifre Unutma İşlemi Hatası");
                return false;
            }

            return true;
        }

        private bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                Reset();
                return;
            }

            try
            {
                con.Open();
                SqlCommand komut = new SqlCommand("UPDATE kullaniciBilgileri SET sifre = @p1 WHERE tcNo = @p2 AND telefon = @p3", con);
                komut.Parameters.AddWithValue("@p1", txtSifre.Text);
                komut.Parameters.AddWithValue("@p2", txtTc.Text);
                komut.Parameters.AddWithValue("@p3", txtTel.Text);

                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre değiştirme işlemi yapıldı.", "Müşteri Şifre Unutma İşlemi", MessageBoxButtons.OK);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Şifre değiştirme işlemi yapılamadı!", "Müşteri Şifre Unutma İşlemi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Şifre Unutma İşlemi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Giris form1 = new Giris();
            form1.Show();
            this.Hide();
        }
    }
}
