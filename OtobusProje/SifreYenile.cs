using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusProje
{
    public partial class SifreYenile : Form
    {
        public SifreYenile()
        {
            InitializeComponent();
        }





        string E_MilAdresi;

        public SifreYenile(string E_MailAdresi)
        {
            InitializeComponent();
            this.E_MilAdresi = E_MailAdresi;

        }






        private void button1_Click(object sender, EventArgs e)
        {





            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                label4.Show();
                label5.Show();
            }
            else if (textBox1.Text.Length == 0)
            {
                label4.Show();
            }
            else if (textBox2.Text.Length == 0)
            {
                label5.Show();
            }
            else if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Şifreler birbirine uymuyor");

            }
            else if (textBox1.Text == textBox2.Text)
            {






                string yenisifre = textBox1.Text.ToString().Trim();

                DbConn db = new DbConn();

                try
                {
                    db.connect();
                    string sql = "UPDATE Personel SET Sifre = @yenisifre WHERE E_Mail = @Email";
                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    cmd.Parameters.AddWithValue("@yenisifre", yenisifre);
                    cmd.Parameters.AddWithValue("@Email", E_MilAdresi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    db.Disconnect();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Şifre başarlı bir şekilde değiştirildi");
                        this.Hide();
                        Giris giris = new Giris();
                        giris.Show();
                    }
                    else
                    {
                        MessageBox.Show("Hiçbir kayıt güncellenmedi. Email bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (db.conn != null && db.conn.State == ConnectionState.Open)
                    {
                        db.Disconnect();
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}
