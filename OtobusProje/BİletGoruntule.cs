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
    public partial class BİletGoruntule : Form
    {
        public BİletGoruntule()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            İslemler islemler = new İslemler();
            islemler.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            İslemler islemler = new İslemler();
            islemler.Show();
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
                    MessageBox.Show("Bİlet başarıyla iptaledildi");
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

        private void BİletGoruntule_Load(object sender, EventArgs e)
        {

            DbConn dbConn = new DbConn();
            string query = "SELECT * FROM BiletListesi";
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
                        item.SubItems.Add(reader["Adı"].ToString());
                        item.SubItems.Add(reader["SoyAdı"].ToString());
                        item.SubItems.Add(reader["TC_NO"].ToString());
                        item.SubItems.Add(reader["Yaş"].ToString());
                        item.SubItems.Add(reader["TelNo"].ToString());
                        item.SubItems.Add(reader["Cinsiyet"].ToString());
                        item.SubItems.Add(reader["Nerden"].ToString());
                        item.SubItems.Add(reader["Nereye"].ToString());
                        item.SubItems.Add(reader["Tarih"].ToString());
                        item.SubItems.Add(reader["Saat"].ToString());
                        item.SubItems.Add(reader["KoltukNo"].ToString());
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
