using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXBankOtomasyonProje
{
    public partial class Acilis : Form
    {
        public Acilis()
        {
            InitializeComponent();
        }

        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP++;
            guna2ProgressBar1.Value = startP;
            if (guna2ProgressBar1.Value == 100)
            {
                guna2ProgressBar1.Value = 0;
                timer1.Stop();
                Giris form1 = new Giris();
                form1.Show();
                this.Hide();
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
