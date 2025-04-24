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
    public partial class SeferGoruntule : Form
    {
        public SeferGoruntule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DbConn dbConn = new DbConn();
                dbConn.conn.Open();
                string deleteQuery = "DELETE FROM BiletListesi WHERE İD = @id";
                SqlCommand command = new SqlCommand(deleteQuery, dbConn.conn);
                command.Parameters.AddWithValue("@id", listView1.SelectedItems[0].Text);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sefer başarıyla iptaledildi");
                }
                else
                {
                    MessageBox.Show("iptal etme işlemi gerçekleştirilemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            foreach (ListViewItem seçilen in listView1.SelectedItems)
            {
                seçilen.Remove();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            İslemler islemler = new İslemler();
            islemler.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            İslemler islemler = new İslemler();
            islemler.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SeferGoruntule_Load(object sender, EventArgs e)
        {
            DbConn dbConn = new DbConn();
            string query = "SELECT * FROM SeferListesi";
            {
                SqlCommand command = new SqlCommand(query, dbConn.conn);
                SqlDataReader reader;
                try
                {
                    dbConn.conn.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["İD"].ToString());
                        item.SubItems.Add(reader["Aracİd"].ToString());
                        item.SubItems.Add(reader["AracTürü"].ToString());
                        item.SubItems.Add(reader["SeferTarihi"].ToString());
                        item.SubItems.Add(reader["SeferSaati"].ToString());
                        item.SubItems.Add(reader["Nereden"].ToString());
                        item.SubItems.Add(reader["Nereye"].ToString());
                        item.SubItems.Add(reader["SoforAdı"].ToString());
                        item.SubItems.Add(reader["SoforTelNo"].ToString());
                        listView1.Items.Add(item);


                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri getirme hatası: " + ex.Message);
                }
            }

        }
    }
}
