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
    public partial class FrmKulupler : Form
    {
        public FrmKulupler()
        {
            InitializeComponent();
        }

        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        void LİSTELE()
        {
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM TBL_KULUPLER", bgl);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView1.DataSource = DT;
        }

        private void FrmKulupler_Load(object sender, EventArgs e)
        {
            LİSTELE();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LİSTELE();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand KOMUT = new SqlCommand("insert into tbl_kulupler (kulupad) VALUES (@p1)", bgl);
            KOMUT.Parameters.AddWithValue("@p1", txtkulupad.Text);
            KOMUT.ExecuteNonQuery();
            bgl.Close();
            LİSTELE();
            MessageBox.Show("KULÜP LİSTEYE EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand KOMUT = new SqlCommand("delete from tbl_kulupler where kulupıd=@p1", bgl);
            KOMUT.Parameters.AddWithValue("@p1", txtkulupıd.Text);
            KOMUT.ExecuteNonQuery();
            bgl.Close();
            LİSTELE();
            MessageBox.Show("KULÜP LİSTEDEN SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtkulupıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtkulupad .Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand KOMUT = new SqlCommand("update tbl_kulupler set kulupad=@p0 where kulupıd=@p1", bgl);
            KOMUT.Parameters.AddWithValue("@p0",txtkulupad.Text);
            KOMUT.Parameters.AddWithValue("@p1", txtkulupıd.Text);
            KOMUT.ExecuteNonQuery();
            bgl.Close();
            LİSTELE();
            MessageBox.Show("LİSTE GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmOgretmen FR = new FrmOgretmen();
            FR.Show();
            this.Hide();
        }
    }
}
