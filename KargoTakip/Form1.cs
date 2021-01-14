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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int kontrol = 0;
       public static string girismail;
        string girisifre;
        private static void button3_ClickExtracted()
        {
          
        }
        private void button5_Click(object sender, EventArgs e)
        {
            kayit frm2 = new kayit();
            frm2.Show();


            this.Height = 274;
            panel2.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Height = 522;

            panel2.Visible = true;
            

            try
            {

                OleDbConnection con;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kargotakip.accdb");
                con.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM gonderi_takip WHERE takip_no ='" + textBox1.Text + "'", con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                con.Close();


            }
            catch (Exception)
            {

                kontrol += 1;
                if (kontrol == 4)
                {
                    Application.Exit();
                }
                MessageBox.Show(" Kod Yanlış ! /n 3 kere yanlış kod girerseniz güvenlik sebebiyle program sonlandırılacaktır ");
            }


        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
          
           
       string kontrolmail = textBox2.Text;
            string kontrolsifre = textBox3.Text;
            OleDbConnection con;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kargotakip.accdb");
            con.Open();
            OleDbCommand okuma = new OleDbCommand();
            okuma.Connection = con;
            okuma.CommandText = "SELECT * FROM uyeler WHERE mail= '" + textBox2.Text + "'";
            OleDbDataReader reader = okuma.ExecuteReader();
            while (reader.Read())
            {
                girismail = reader["mail"].ToString();
                girisifre = reader["sifre"].ToString();
                
            }
            con.Close();
         //   MessageBox.Show(girismail,girisifre);
            if (girismail ==kontrolmail&& girisifre==kontrolsifre)
            {
                this.Hide();
                musteri mstr = new musteri();
                mstr.Show();
            }
            else
            {
                label18.Text ="lütfen üye olunuz";
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();


            string kontrolname = textBox5.Text;
            string kontrolsifre = textBox4.Text;
         
            OleDbConnection con;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=kargotakip.accdb");
            con.Open();
            OleDbCommand okuma = new OleDbCommand();
            okuma.Connection = con;
            okuma.CommandText = "SELECT * FROM admin WHERE username= '" + textBox5.Text + "'";
            OleDbDataReader reader = okuma.ExecuteReader();
            while (reader.Read())
            {
                girismail = reader["username"].ToString();
                girisifre = reader["password"].ToString();

            }
            con.Close();
           
            if (girismail == kontrolname && girisifre == kontrolsifre)
            {
                this.Hide();
                admin adm = new admin();
                adm.Show();
            }
            else
            {
                label18.Text = "lütfen üye olunuz";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
