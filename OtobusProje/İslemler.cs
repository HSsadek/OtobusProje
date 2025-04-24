using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusProje
{
    public partial class İslemler : Form
    {
        public İslemler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BiletEkle biletekle = new BiletEkle();
            biletekle.TopLevel = false;
            panel1.Controls.Add(biletekle);
            biletekle.BringToFront();
            biletekle.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult siginout = MessageBox.Show("oturumu kaptmak istedeğinden eminmisiniz !!", "Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (siginout == DialogResult.Yes)
            {
                this.Hide();
                Giris giris = new Giris();
                giris.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeferEkle seferEkle = new SeferEkle();
            seferEkle.TopLevel = false;
            panel1.Controls.Add(seferEkle);
            seferEkle.BringToFront();
            seferEkle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();


            BİletGoruntule biletgoruntule = new BİletGoruntule();

            biletgoruntule.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();


            SeferGoruntule seferGoruntule = new SeferGoruntule();
            seferGoruntule.Show();
        }
    }
}
