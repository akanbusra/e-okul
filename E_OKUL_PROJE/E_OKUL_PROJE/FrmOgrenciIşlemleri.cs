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
    public partial class FrmOgrenciIşlemleri : Form
    {
        public FrmOgrenciIşlemleri()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void FrmOgrenciIşlemleri_Load(object sender, EventArgs e)
        {
          dataGridView1.DataSource=ds.OgrListeleme();

            //comboboxa kuluplerin id yerine isimlerini getirme
            bgl.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulupler", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulüp.DisplayMember = "KULUPAD";      //ne görmek istiyorum
            cmbkulüp.ValueMember = "KULUPID";        //kulupler tablomda nasıl tutuluyor
            cmbkulüp.DataSource = dt;
            bgl.Close();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrListeleme();
        }


        string c = "";
         
private void btnekle_Click(object sender, EventArgs e)
        {
    if (rdbtnkız.Checked == true)
    {
        c = "KIZ";
    }
    if (rdbtnerkek.Checked == true)
    {
        c = "ERKEK";
    }

    ds.OgrEkle(txtad.Text,txtsoyad.Text,byte.Parse(cmbkulüp.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci ekleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbkulüp_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txtid.Text = cmbkulüp.SelectedValue.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid .Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbkulüp.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            c = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            if (c=="KIZ")
            {
                rdbtnkız.Checked = true;
                rdbtnerkek.Checked = false;
            }
            if (c=="ERKEK")
            {
                rdbtnerkek.Checked = true;
                rdbtnkız.Checked = false;
            }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrSil(Convert.ToInt32(txtid.Text));
            MessageBox.Show("Öğrenci silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.OgrGüncelle(txtad.Text, txtsoyad.Text ,int.Parse(cmbkulüp.SelectedValue.ToString()), c ,int.Parse(txtid.Text));
            MessageBox.Show("Öğrenci güncelleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rdbtnkız_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnkız.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void rdbtnerkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnerkek .Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrBul(txtara.Text);
        }
    }
}
