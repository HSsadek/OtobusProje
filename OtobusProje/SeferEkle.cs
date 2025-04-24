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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OtobusProje
{
    public partial class SeferEkle : Form
    {
        public SeferEkle()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            textBox9.Text = null;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label27.Visible = false; 

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label24.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label22.Visible = false;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            label18.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            label17.Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            label20.Visible = false;   
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {




            if (textBox6.Text.Length == 0 && textBox7.Text.Length == 0 && textBox8.Text.Length == 0 && textBox9.Text.Length == 0 && comboBox3.SelectedIndex == -1 && comboBox4.SelectedIndex == -1 && comboBox5.SelectedIndex == -1)
            {
                label27.Show();
                label24.Show(); 
                label22.Show();
                label18.Show();
                label17.Show();
                label13.Show();
                label20.Show();


            }
            else if (textBox6.Text.Length == 0)
            {
                label17.Show();
            }
            else if (textBox7.Text.Length == 0)
            {
                label13.Show();
            }
            else if (textBox8.Text.Length == 0)
            {
                label22.Show();
            }
            else if (textBox9.Text.Length == 0)
            {
                label20.Show();
            }
            else if (comboBox3.SelectedIndex == -1)
            {
                label27.Show();
            }
            else if (comboBox4.SelectedIndex == -1)
            {
                label24.Show();
            }
            else if (comboBox5.SelectedIndex == -1)
            {
                label18.Show();
            }
            else if (textBox9.Text.Length != 0 && textBox9.Text.Length != 10)
            {
                label5.Show();
            }
            else
            {
                DbConn db = new DbConn();
                db.connect();
                string sql = "insert into SeferListesi (Aracİd,AracTürü,SeferTarihi,SeferSaati,Nereden,Nereye,SoforAdı,SoforTelNo) values (@Aracİd,@AracTürü,@SeferTarihi,@SeferSaati,@Nereden,@Nereye,@SoforAdı,@SoforTelNo)";

                try
                {

                    SqlCommand cmd = new SqlCommand(sql, db.conn);
                    cmd.Parameters.AddWithValue("@Aracİd", textBox6.Text);
                    cmd.Parameters.AddWithValue("@AracTürü", comboBox5.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SeferTarihi", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@SeferSaati", textBox8.Text);
                    cmd.Parameters.AddWithValue("@Nereden", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Nereye", comboBox4.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SoforAdı", textBox7.Text);
                    cmd.Parameters.AddWithValue("@SoforTelNo", textBox9.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();


                    db.Disconnect();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sefer başarlı bir şekilde oluşturuldu");
                    }
                    else
                    {
                        MessageBox.Show("Bir hata oluştu");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("HATA OLUŞTU" + ex.Message);

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

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
