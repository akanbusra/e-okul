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
namespace E_OKUL_PROJE
{
    public partial class FrmSınavNot : Form
    {
        public FrmSınavNot()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen f = new FrmOgretmen();
            f.Show();
            this.Hide();
        }

        DataSet1TableAdapters.TBL_NOTLARTableAdapter ds = new DataSet1TableAdapters.TBL_NOTLARTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtid.Text));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSınavNot_Load(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_dersler", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbders .DisplayMember = "DERSAD";      //ne görmek istiyorum
            cmbders.ValueMember = "DERSID";        //kulupler tablomda nasıl tutuluyor
            cmbders.DataSource = dt;
            bgl.Close();
        }

        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            notid=int.Parse( dataGridView1.Rows[secilen].Cells[0].Value.ToString());
            txtid.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsnv1 .Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsnv2 .Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsnv3 .Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtproje .Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            txtort.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtdurum .Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
          //  cmbders.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        int snv1, snv2, snv3, proje;

        private void button2_Click(object sender, EventArgs e)
        {
            ds.güncelle(byte.Parse(cmbders.SelectedValue.ToString()), int.Parse(txtid.Text),byte.Parse(snv1.ToString()), byte.Parse(snv2.ToString()), byte.Parse(snv3.ToString()), byte.Parse(proje.ToString()),decimal.Parse(txtort.Text),bool.Parse(txtdurum.Text),int.Parse(txtid.Text));
            MessageBox.Show("bilgilr güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        double ortalama;
        private void btnlhesapla_Click(object sender, EventArgs e)
        {
            snv1 = Convert.ToInt16(txtsnv1.Text);
            snv2 = Convert.ToInt16(txtsnv2.Text);
            snv3 = Convert.ToInt16(txtsnv3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama = (snv1 + snv2 + snv3 + proje) / 4;
            txtort.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text ="true";
            }
            else
            {
                txtdurum.Text = "false";
            }





        }
    }
}
