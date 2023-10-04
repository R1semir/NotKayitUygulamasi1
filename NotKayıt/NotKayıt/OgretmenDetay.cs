using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NotKayıt
{
    public partial class OgretmenDetay : Form
    {
        public OgretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source
                                                    =DESKTOP-BJO2DGU\SQLEXPRESS;
                                                    Initial Catalog=DbNotKayıt;Integrated Security=True");

        private void OgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Count(DURUM) From TBLDERS where DURUM='True' Group By DURUM", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblGecenSayısı.Text = dr[0].ToString();
            }
            dr.Close();

            SqlCommand komut2 = new SqlCommand("Select Count(DURUM) From TBLDERS where DURUM='False' Group By DURUM", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblKalanSayısı.Text = dr2[0].ToString();
            }
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS(OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.Add("@p1", SqlDbType.Char).Value = msknumara.Text;
            komut.Parameters.Add("@p2", SqlDbType.VarChar).Value = txAd.Text;
            komut.Parameters.Add("@p3", SqlDbType.VarChar).Value = txSoyad.Text;
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txS1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txS2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txS3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double s1, s2, s3, sinifortalama;
            string durum;
            s1 = Convert.ToDouble(txS1.Text);
            s2 = Convert.ToDouble(txS2.Text);
            s3 = Convert.ToDouble(txS3.Text);
            sinifortalama = (s1 + s2 + s3) / 3;
            if (sinifortalama >= 50)
            {
                durum = "True";

            }
            else
            {

                durum = "False";

            }
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update TBLDERS set OGRS1=@P1,OGRS2=@P2,OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 where OGRNUMARA=@p6", baglanti);
            komutGuncelle.Parameters.Add("@P1", SqlDbType.TinyInt).Value = txS1.Text;
            komutGuncelle.Parameters.Add("@P2", SqlDbType.TinyInt).Value = txS2.Text;
            komutGuncelle.Parameters.Add("@P3", SqlDbType.TinyInt).Value = txS3.Text;
            komutGuncelle.Parameters.Add("@P5", SqlDbType.Bit).Value = durum;
            komutGuncelle.Parameters.Add("@P6", SqlDbType.Char).Value = msknumara.Text;
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            baglanti.Open();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
