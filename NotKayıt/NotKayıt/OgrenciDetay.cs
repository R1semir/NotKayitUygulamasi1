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
    public partial class OgrenciDetay : Form
    {
        public OgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source
                                                    =DESKTOP-BJO2DGU\SQLEXPRESS;
                                                    Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void OgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
           

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * From TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblNumara.Text = dr[1].ToString();
                lblS1.Text = dr[4].ToString();
                lblS2.Text = dr[5].ToString();
                lblS3.Text = dr[6].ToString();
                lblOrtalama.Text = dr[7].ToString();
                lblDurum.Text = dr[8].ToString();
            }
            baglanti.Close();
            if (lblDurum.Text == "True")
            {
                lblDurum.Text = "Geçti";
            }
            else
            {
                lblDurum.Text = "Kaldı";
            }



        }
    }
}
