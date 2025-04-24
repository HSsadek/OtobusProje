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
    public partial class OnaylamaKodu : Form
    {
        public OnaylamaKodu()
        {
            InitializeComponent();
        }




        int kod;
        string E_MailAdresi;
        public OnaylamaKodu(int kod, string E_MailAdresi)
        {
            InitializeComponent();
            this.kod = kod;
            this.E_MailAdresi = E_MailAdresi;
        }






        private void button1_Click(object sender, EventArgs e)
        {




            int girilenkod;

            if (textBox1.Text.Length != 0)
            {
                girilenkod = int.Parse(textBox1.Text);

                if (girilenkod == kod)
                {
                    this.Hide();
                    SifreYenile sifreYenile = new SifreYenile(E_MailAdresi);
                    sifreYenile.Show();

                }
                else
                {
                    MessageBox.Show("kod hatalıdır ");
                }

            }
            else
            {
                MessageBox.Show("lütfen kodu girin");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
