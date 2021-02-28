using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_OKUL_PROJE
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulupler FR = new FrmKulupler();
            FR.Show();
            this.Hide();
        }

        private void btndersler_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void btnogrencı_Click(object sender, EventArgs e)
        {
            FrmOgrenciIşlemleri fr1 = new FrmOgrenciIşlemleri();
            fr1.Show();
            this.Hide();
        }

        private void btnsınav_Click(object sender, EventArgs e)
        {
            FrmSınavNot f = new FrmSınavNot ();
            f.Show();
            this.Hide();
        }
    }
}
