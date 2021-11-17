using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace crudukk
{
    public partial class DansCSCRUD : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\CRUD Database\CrudUKK.mdb");

        int count = 0;

        public DansCSCRUD()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into CrudUKK (Nama,Stok,Harga,Kategori,Kode) values('" + textBoxNama.Text + "','" + textBoxStok.Text + "','" + textBoxHarga.Text + "','" + textBoxKategori.Text + "' ,'" + textboxkode.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHarga.Text = "";
            textBoxKategori.Text = "";
            textboxkode.Text = "";
            MessageBox.Show("Udah Nambah 1 Nih!");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CrudUKK";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            string query = "delete from CrudUKK where ID=" + textBoxID.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxID.Text = "";
            MessageBox.Show("Suka Banget ya Hapusin Barang...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            string query = "update CrudUKK set Nama='" + textBoxNama.Text + "' ,Stok='" + textBoxStok.Text + "' ,Harga='" + textBoxHarga.Text + "' ,Kategori='" + textBoxKategori.Text + "' ,Kode= '"+textboxkode.Text+"' where ID=" + textBoxID.Text + "";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxID.Text = "";
            textBoxNama.Text = "";
            textBoxStok.Text = "";
            textBoxHarga.Text = "";
            textBoxKategori.Text = "";
            textboxkode.Text = "";
            MessageBox.Show("Udah Keedit ini bang");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CrudUKK where Kategori='" + textBoxCari.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            con.Close();


            if (count == 0)
            {
                MessageBox.Show("Gaada Bos");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
