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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        public void kaydet()
        {
            string baglantiyolu = "provider=microsoft.ace.oledb.12.0;data source=" + Application.StartupPath + "\\kargotakip.accdb";
            OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
            baglanti.Open();
            string eklemekomutu = "insert into uyeler (mail,adsoyad,tcno,dogum_yili,sifre) values ('" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
            OleDbCommand komut = new OleDbCommand(eklemekomutu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üyeliğiniz Başarılı !");
            this.Close();


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Contains("@") && textBox6.Text.Contains(".com"))
            {

                if (textBox6.Text == textBox7.Text && textBox11.Text == textBox12.Text)
                {
                    kaydet();
                }
                else
                {
                    MessageBox.Show("lütfen şifre ve mail tekrarı alanlarını birbiriyle eşit yapınız");
                }
            }
            else
            {
                MessageBox.Show("lütfen mail adresini doğru giriniz");
            }
        }
    }
}
