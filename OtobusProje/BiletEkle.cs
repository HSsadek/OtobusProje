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
    public partial class BiletEkle : Form
    {
        public BiletEkle()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            label5.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label16.Visible = false;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox8.Text = null;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0 && textBox3.Text.Length == 0 && textBox4.Text.Length == 0 && textBox5.Text.Length == 0 && textBox6.Text.Length == 0 && textBox8.Text.Length == 0 && comboBox1.SelectedIndex == -1 && comboBox2.SelectedIndex == -1 && comboBox3.SelectedIndex == -1 && textBox5.Text.Length == 0 && comboBox4.SelectedIndex == -1)
            {
                label2.Show();
                label6.Show();
                label8.Show();
                label11.Show();
                label7.Show();
                label16.Show();
                label27.Show();
                label24.Show();
                label22.Show();
                label18.Show();
                label17.Show();
                label13.Show();
            }
            else if (textBox1.Text.Length == 0)
            {
                label2.Show();
            }
            else if (textBox1.Text.Length != 11 && textBox1.Text.Length != 0)
            {
                label3.Show();
            }
            else if (textBox2.Text.Length == 0)
            {
                label6.Show();
            }
            else if (textBox3.Text.Length == 0)
            {
                label8.Show();
            }
            else if (textBox4.Text.Length == 0)
            {
                label11.Show();
            }
            else if (textBox5.Text.Length == 0)
            {
                label7.Show();
            }
            else if (textBox6.Text.Length == 0)
            {
                label17.Show();
            }
            else if (textBox8.Text.Length == 0)
            {
                label22.Show();
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                label16.Show();
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                label13.Show();
            }
            else if (comboBox3.SelectedIndex == -1)
            {
                label27.Show();
            }
            else if (textBox4.Text.Length == 0)
            {
                label24.Show();
            }
            else if (textBox5.Text.Length == 0)
            {
                label18.Show();
            }
            else if (textBox5.Text.Length != 0 && textBox5.Text.Length != 10)
            {
                label5.Show();
            }
            else
            {

                DbConn db = new DbConn();
                db.connect();
                string sql = "insert into BiletListesi (Adı,SoyAdı,TC_NO,Yaş,TelNo,Cinsiyet,Nerden,Nereye,Tarih,Saat,KoltukNO) values (@Adı,@SoyAdı,@TC_NO,@Yaş,@TelNo,@Cinsiyet,@Nerden,@Nereye,@Tarih,@Saat,@KoltukNO)";
                try
                {

                    SqlCommand cmd = new SqlCommand(sql, db.conn);


                    cmd.Parameters.AddWithValue("@Adı", textBox2.Text);
                    cmd.Parameters.AddWithValue("@SoyAdı", textBox3.Text);
                    cmd.Parameters.AddWithValue("@TC_NO", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Yaş", textBox4.Text);
                    cmd.Parameters.AddWithValue("@TelNo", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Cinsiyet", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Nerden", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Nereye", comboBox4.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tarih", dateTimePicker1.Text.ToString());
                    cmd.Parameters.AddWithValue("@Saat", textBox8.Text);
                    cmd.Parameters.AddWithValue("@KoltukNO", comboBox2.SelectedItem.ToString());


                    int rowsAffected = cmd.ExecuteNonQuery();


                    db.Disconnect();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("bilet başarılr bir şekilde oluşturuldu");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           label2.Visible = false;
            label3.Visible = false;

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
