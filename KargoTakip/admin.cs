using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace KargoTakip
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        int i = 0;
        private static OleDbConnection GetBaglanti()
        {
            string baglantiyolu = "provider=microsoft.ace.oledb.12.0;data source=" + Application.StartupPath + "\\kargotakip.accdb";
            OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
            return baglanti;
        }
        private void admin_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;

            OleDbConnection baglanti = GetBaglanti();
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM destek", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;

            textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dataGridView1.Columns[2].Width = 400;
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (i<dataGridView1.RowCount-1)
            {

                textBox1.Text = dataGridView1.Rows[i+1].Cells[1].Value.ToString();
                richTextBox1.Text = dataGridView1.Rows[i+1].Cells[2].Value.ToString();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            OleDbConnection baglanti = GetBaglanti();
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT takip_no FROM gonderi_takip", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            OleDbConnection baglanti = GetBaglanti();
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM uyeler", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buton2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = GetBaglanti();
            baglanti.Open();
            OleDbCommand kaydet = new OleDbCommand("update gonderi_takip set durum='" + comboBox2.Text + "' where takip_no= '" +comboBox1.Text + "'", baglanti);

            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Durum Güncellendi!");
            buton2();


        }
      public void buton2()
        {
            comboBox1.Items.Clear();
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            OleDbConnection baglanti = GetBaglanti();
            baglanti.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT takip_no,durum FROM gonderi_takip", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            OleDbCommand okuma = new OleDbCommand();
            okuma.Connection = baglanti;
            okuma.CommandText = "SELECT * FROM gonderi_takip";
            OleDbDataReader reader = okuma.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["takip_no"]);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

           
            if (i>=0)
            {
                if (i==0)
                {
                    textBox1.Text = dataGridView1.Rows[i ].Cells[1].Value.ToString();
                    richTextBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                }
                else
                {
                    textBox1.Text = dataGridView1.Rows[i - 1].Cells[1].Value.ToString();
                    richTextBox1.Text = dataGridView1.Rows[i - 1].Cells[2].Value.ToString();
                }
            }
        }
    }
}
