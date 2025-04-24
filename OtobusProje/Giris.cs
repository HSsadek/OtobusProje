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

namespace OtobusProje
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;

            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KullanıcAdı = textBox1.Text;
            string Sifre = textBox2.Text;

            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                label5.Show();
                label4.Show();
            }

            else if (textBox1.Text.Length == 0)
            {
                label4.Show();
            }
            else if (textBox2.Text.Length == 0)
            {
                label5.Show();
            }
            else
            {

                DbConn db = new DbConn();


                if (db.conn.State == ConnectionState.Closed)
                {
                    db.conn.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM Personel WHERE KullaniciAdi = '" + KullanıcAdı + "'AND Sifre = '" + Sifre + "'", db.conn);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    this.Hide();
                    girişbekle girişbekle = new girişbekle();
                    girişbekle.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalıdır");
                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
