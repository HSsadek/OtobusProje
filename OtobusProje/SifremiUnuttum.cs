using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusProje
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
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
            else
            {





                string KullanıcıAdı = textBox1.Text.Trim();

                string E_MailAdresi = textBox2.Text;





                DbConn db = new DbConn();
                if (db.conn.State == ConnectionState.Closed)
                {
                    db.conn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Personel WHERE KullaniciAdi = '" + KullanıcıAdı + "'AND E_Mail = '" + E_MailAdresi + "'", db.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                Random rn = new Random();
                int kod = rn.Next(100000, 999999);

                string başlık = "Onaylama Kodu";
                string içerik = "Şifrenizin sıfırlanması yönünde bir talep aldık " + "\n" + "Aşağıdaki sıfırlama kodunu girin :" + "\n" + kod;
                if (dr.Read())
                {
                    MailMessage eposta = new MailMessage();
                    eposta.From = new MailAddress("otobusbiletotomasyonu@hotmail.com");
                    eposta.To.Add(new MailAddress(textBox2.Text.Trim()));
                    eposta.Subject = başlık;
                    eposta.Body = içerik;
                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential("otobusbiletotomasyonu@hotmail.com", "otobus1230bilet");
                    smtp.Host = "smtp.outlook.com";
                    smtp.EnableSsl = true;
                    smtp.Port = 587;

                    try
                    {
                        MessageBox.Show("lütfen bir az bekleyin");
                        smtp.Send(eposta);
                        OnaylamaKodu onaylamaKodu = new OnaylamaKodu(kod, E_MailAdresi);
                        onaylamaKodu.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İnternet bağlantınızı kontrol edin ");
                    }
                }
                else
                {
                    MessageBox.Show("girdiğiniz bilgilere ait kullanıcı bulunmamaktadır");
                }
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Giris giris = new Giris();
            giris.Show();
        }
    }
}
