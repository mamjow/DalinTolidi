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
    public partial class tanzimat : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public tanzimat()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);
        }

        public void salon()
        {

            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM salon", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                i++;
            }
            con.Close();
            tsalon.Text = i.ToString();
            tsalon.ForeColor = Color.Green;


        }

        public void radiofilter()
        {
            string baste = "";
            if (radiobaste.Checked == true)
            {
                baste = radiobaste.Text;

            }
            else if (radiofale.Checked == true)
            {
                baste = radiofale.Text;
            }
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM gharch WHERE bastebandi ='" + baste + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            textghimat.Text = "";
            textmodel.Text = "";
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
        }
        public void rejyab()
        {
            int i = 0;
            int a = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM kargar", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();

            }//end if
            con.Close();
            if (i > 0)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT TOP 1 * FROM kargar ORDER BY ID DESC", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0].DefaultView;
                //label8.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                a = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            }
            int sabtcd = a + 1001;

            textcod.Text = sabtcd.ToString();
            textcod.Enabled = false;
            OleDbDataAdapter dm = new OleDbDataAdapter("SELECT * FROM kargar ", con);
            DataSet dn = new DataSet();
            dm.Fill(dn);
            dataGridView2.DataSource = dn.Tables[0].DefaultView;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            int h = 0;
            OleDbCommand comd = new OleDbCommand("SELECT COUNT(*) FROM kargar WHERE kart=@kart", con);
            comd.Parameters.AddWithValue("@kart", textcard.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                h = (int)comd.ExecuteScalar();

            }//end if
            if (h > 0)
            {
                OleDbCommand myCo = new OleDbCommand("UPDATE kargar SET kart='انتقال' WHERE kart='" + textcard.Text + "'", con);
                myCo.ExecuteNonQuery();
            }
            con.Close();
            OleDbCommand myCommanda = new OleDbCommand("UPDATE kargar SET pardakht=@pardakht, nam=@nam ,cod=@cod , hoghugh=@hoghugh , kart=@kart WHERE ID=@id", con);

            myCommanda.Parameters.AddWithValue("@pardakht", label8.Text);
            myCommanda.Parameters.AddWithValue("@nam", textnamkargar.Text);
            myCommanda.Parameters.AddWithValue("@cod", textcod.Text);
            myCommanda.Parameters.AddWithValue("@hoghugh", texthoghugh.Text);
            myCommanda.Parameters.AddWithValue("@kart", textcard.Text);
            myCommanda.Parameters.AddWithValue("@id", label7.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            button6_Click(sender, e);
            rejyab();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("INSERT INTO kargar (pardakht, nam, cod , hoghugh , kart) VALUES (@pardakht, @nam, @cod , @hoghugh , @kart)", con);


            myCommanda.Parameters.AddWithValue("@pardakht", listBox1.SelectedItem.ToString());
            myCommanda.Parameters.AddWithValue("@nam", textnamkargar.Text);
            myCommanda.Parameters.AddWithValue("@cod", textcod.Text);
            myCommanda.Parameters.AddWithValue("@hoghugh", texthoghugh.Text);
            myCommanda.Parameters.AddWithValue("@kart", textcard.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            rejyab();
            button6_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM kargar WHERE ID =@id", con);
            myCommanda.Parameters.AddWithValue("@id", label7.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            rejyab();
            MessageBox.Show("اطلاعات با موفقیت حذف شد!");
            button6_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            button5.Visible = true;
            button7.Visible = false;
            textnamkargar.Text = "";
            textcod.Text = "";
            texthoghugh.Text = "";
            textcard.Text = "";
            textcod.Enabled = true;
            label8.Visible = false;
            button8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string baste = "";
            if (radiobaste.Checked == true)
            {
                baste = radiobaste.Text;

            }
            else if (radiofale.Checked == true)
            {
                baste = radiofale.Text;
            }


            OleDbCommand myCommanda = new OleDbCommand("UPDATE gharch SET ghimat=@ghimat, model=@model, bastebandi=@baste WHERE ID =@id", con);
            myCommanda.Parameters.AddWithValue("@ghimat", textghimat.Text);
            myCommanda.Parameters.AddWithValue("@model", textmodel.Text);
            myCommanda.Parameters.AddWithValue("@baste", baste);
            myCommanda.Parameters.AddWithValue("@id", label3.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اطلاعات با موفقیت به روز شد!");
            radiofilter();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textmodel.Text != "" && textghimat.Text != "")
            {
                string baste = "";
                if (radiobaste.Checked == true)
                    baste = radiobaste.Text;
                else if (radiofale.Checked == true)
                    baste = radiofale.Text;

                OleDbCommand myCommanda = new OleDbCommand("INSERT INTO gharch (bastebandi, ghimat, model) VALUES (@baste, @ghimat, @model)", con);
                myCommanda.Parameters.AddWithValue("@baste", baste);
                myCommanda.Parameters.AddWithValue("@ghimat", textghimat.Text);
                myCommanda.Parameters.AddWithValue("@model", textmodel.Text);
                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات بسته بندی قارچ ذخیره شد", "اعلان", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("لطفا قسمت های لازم را پر کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            radiofilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM gharch WHERE ID =@id", con);
            myCommanda.Parameters.AddWithValue("@id", label3.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            radiofilter();
            MessageBox.Show("اطلاعات با موفقیت حذف شد!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            radiofilter();
        }
        public void ghezaf()
        {
            OleDbCommand comd = new OleDbCommand("SELECT * FROM ezaf WHERE ID=1", con);
            con.Open();
            OleDbDataReader ezafg = comd.ExecuteReader();
            ezafg.Read();
            textezaf.Text = ezafg[1].ToString();
            con.Close();
            textezaf.ForeColor = Color.Green;

        }
        private void tanzimat_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbghDataSet.admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.dbghDataSet.admin);
            // TODO: This line of code loads data into the 'dbghDataSet.kargar' table. You can move, or remove it, as needed.
            this.kargarTableAdapter.Fill(this.dbghDataSet.kargar);
            // TODO: This line of code loads data into the 'dbghDataSet.gharch' table. You can move, or remove it, as needed.
            this.gharchTableAdapter.Fill(this.dbghDataSet.gharch);
            radiofilter();
            rejyab();
            ghezaf();
        }

        private void textezaf_TextChanged(object sender, EventArgs e)
        {
            textezaf.ForeColor = Color.Red;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            OleDbCommand myCommanda = new OleDbCommand("UPDATE ezaf SET ghimat=@ghimat WHERE ID=1", con);
            myCommanda.Parameters.AddWithValue("@ghimat", textezaf.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            textezaf.ForeColor = Color.Green;
        }

        private void sabtsalon_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM salon", con);
            //myCommanda.Parameters.AddWithValue("@id", label33.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();

            for (int i = 1; i <= Convert.ToInt32(tsalon.Text); i++)
            {

                OleDbCommand myCommand = new OleDbCommand("INSERT INTO salon (salon) VALUES (@salon)", con);
                myCommand.Parameters.AddWithValue("@salon", "سالن " + i.ToString());
                con.Open();
                myCommand.ExecuteNonQuery();
                con.Close();
            }
            MessageBox.Show(" .تعداد سالن ها به روز شد");
            tsalon.ForeColor = Color.Green;
        }

        private void tsalon_TextChanged(object sender, EventArgs e)
        {
            tsalon.ForeColor = Color.Red;
        }

        private void radiobaste_CheckedChanged(object sender, EventArgs e)
        {
            radiofilter();
        }

        private void radiofale_CheckedChanged(object sender, EventArgs e)
        {
            radiofilter();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textmodel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textghimat.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            button2.Visible = true;
            button3.Visible = true;
            button1.Visible = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textnamkargar.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textcod.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            label7.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            label8.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            texthoghugh.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textcard.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            button5.Visible = false;
            button7.Visible = true;
            label8.Visible = true;
            label8.ForeColor = Color.Red;
            button8.Visible = true;
            textcod.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = listBox1.SelectedItem.ToString();
            label8.ForeColor = Color.Green;
        }

        private void textcod_MouseClick(object sender, MouseEventArgs e)
        {
            rejyab();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "نام کاربری";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "گذرواژه";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommand = new OleDbCommand("INSERT INTO admin (username , pass) VALUES (@username , @pass)", con);
            myCommand.Parameters.AddWithValue("@username",textBox1.Text );
            myCommand.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           
        }

        private void button12_Click(object sender, EventArgs e)
        {


            int i = 0;
            try
            {

                if ((usert.Text == string.Empty) || (passt.Text == string.Empty))
                {
                    MessageBox.Show("لطفا نام کاربری و رمز عبور را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM admin WHERE username =@UserName AND  pass =@Password", con);
                cmd.Parameters.AddWithValue("@UserName", usert.Text);
                cmd.Parameters.AddWithValue("@Password", passt.Text);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    i = (int)cmd.ExecuteScalar();

                }//end if

                con.Close();
                //i = 2;
                if (i > 0)
                {
                    timer1.Start();
                    usert.Text = "";
                    passt.Text = "";
                }
                else
                    MessageBox.Show("نام کاربری و یا رمز عبور اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                i = 0;
                con.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = panel1.Height;
            x = x - 10;
            panel1.Height = x;
            if (x == 11)
            {
                panel1.Visible = false;
                timer1.Stop();
            }
        }

        private void passt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button12_Click(sender, e);
            }
        }






    }
}
