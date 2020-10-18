using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Tolidi
{
    public partial class Book : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public Book()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);
       
        }

        private void bed_Click(object sender, EventArgs e)
        {
            double kharj = 0;
            double kol = 0;
            double par = 0;


            if (radioButton4.Checked == true)
            {
                kol = Convert.ToDouble(kolbed.Text);
                par = Convert.ToDouble(pardakhtbed.Text);
                kharj = kol - par;
            }
            if (radioButton5.Checked == true)
            {
                kol = 0 - Convert.ToDouble(kolbed.Text);
                par = 0 - Convert.ToDouble(pardakhtbed.Text);
                kharj = kol - par;
            }
            OleDbCommand myCommand = new OleDbCommand("INSERT INTO bedehkar (nam,kol,pardakht,mande,tarikh,tozih) VALUES (@nam,@kol,@pardakht,@mande,@tarikh,@tozih)", con);
            myCommand.Parameters.AddWithValue("@nam", combobed.Text);
            myCommand.Parameters.AddWithValue("@kol", kol.ToString());
            myCommand.Parameters.AddWithValue("@pardakht", par.ToString());
            myCommand.Parameters.AddWithValue("@mande", kharj.ToString());
            myCommand.Parameters.AddWithValue("@tarikh", tarikhbed.Text);
            myCommand.Parameters.AddWithValue("@tozih", sharhbed.Text);
            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ثبت شد.");

            kolbed.Text = "";
            pardakhtbed.Text = "";
            mandeh.Text = "";
            tarikhbed.Text = "";
            sharhbed.Text = "";
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM bedehkar WHERE nam='" + combobed.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView7.DataSource = ds.Tables[0].DefaultView;
            combobed.Text = "";

        }

        private void combobed_Leave(object sender, EventArgs e)
        {
            int i = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM bedehkar WHERE nam ='" + combobed.Text + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();

            }//end if
            con.Close();
            if (i > 0)
            {
                combobed.ForeColor = Color.Green;
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM bedehkar WHERE nam='" + combobed.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView7.DataSource = ds.Tables[0].DefaultView;

                OleDbDataAdapter dh = new OleDbDataAdapter("SELECT * FROM bedehkar WHERE nam='" + combobed.Text + "'", con);
                DataTable table = new DataTable();
                dh.Fill(table);
                double kharj = 0;
                foreach (DataRow row in table.Rows)
                {
                    kharj = kharj + Convert.ToDouble(row["mande"].ToString());
                }
                label42.Text = kharj.ToString();
            }
            else
            {
                combobed.ForeColor = Color.Red;
                dataGridView7.DataSource = null;
            }
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            combobed.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();
            kolbed.Text = dataGridView7.CurrentRow.Cells[2].Value.ToString();
            pardakhtbed.Text = dataGridView7.CurrentRow.Cells[3].Value.ToString();
            mandeh.Text = dataGridView7.CurrentRow.Cells[4].Value.ToString();
            tarikhbed.Text = dataGridView7.CurrentRow.Cells[5].Value.ToString();
            sharhbed.Text = dataGridView7.CurrentRow.Cells[6].Value.ToString();
        }
        public void bes()
        {
            combobed.Items.Clear();
            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM bedehkar ", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                if (!combobed.Items.Contains(row["nam"].ToString()))
                    combobed.Items.Add(row["nam"].ToString());

            }
            con.Close();
        }


        private void Book_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbghDataSet.bedehkar' table. You can move, or remove it, as needed.
            this.bedehkarTableAdapter.Fill(this.dbghDataSet.bedehkar);
            bes();
            dataGridView7.DataSource = null;
            //combobed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            combobed.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combobed.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void pardakhtbed_TextChanged(object sender, EventArgs e)
        {

            if (kolbed.Text != string.Empty && pardakhtbed.Text != string.Empty)
            {
                double kharj = 0;
                double kol = Convert.ToDouble(kolbed.Text);
                double par = Convert.ToDouble(pardakhtbed.Text);
                kharj = kol - par;
                mandeh.Text = kharj.ToString();
            }
        }
    }
}
