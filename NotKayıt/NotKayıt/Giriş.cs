using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotKayıt
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciDetay frogrenci = new OgrenciDetay();
            frogrenci.numara = maskedTextBox1.Text;
            frogrenci.Show();
            
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111") 
            {
                OgretmenDetay frogretmen = new OgretmenDetay();
                frogretmen.Show();
            }
        }
        private void Giriş_Load(object sender, EventArgs e)
        {

        }
    }
}
