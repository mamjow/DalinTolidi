using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using BehComponents;
using System.IO;

namespace Tolidi
{
    public partial class hesab : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public hesab()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);

        }

        private void hesab_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbghDataSet.mozd' table. You can move, or remove it, as needed.
            this.mozdTableAdapter.Fill(this.dbghDataSet.mozd);
            ghezaf();

        }

        private void filterk_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {
                string filteru = "";
                if (checkBox1.Checked == true)
                    filteru += "cod ='" + codebox.Text + "' AND ";
                if (checkBox2.Checked == true && checkBox4.Checked == true)
                    filteru += "tarikh BETWEEN '" + datetxt.Text + "' AND '" + tadatetxt.Text + "' AND ";
                if (checkBox2.Checked == true && checkBox4.Checked == false)
                    filteru += "tarikh ='" + datetxt.Text + "' AND ";
                filteru = filteru.Remove(filteru.Length - 4);
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM mozd WHERE " + filteru, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {


            double cash = 0;
            string filteru = "";
            if (checkBox1.Checked == true)
                filteru += "cod ='" + codebox.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == true)
                filteru += "tarikh BETWEEN'" + datetxt.Text + "' AND '" + tadatetxt.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == false)
                filteru += "tarikh ='" + datetxt.Text + "' AND ";
            filteru = filteru.Remove(filteru.Length - 4);
            if (filteru != "")
            {

                con.Open();
                OleDbDataAdapter das = new OleDbDataAdapter("SELECT * FROM mozd WHERE " + filteru, con);
                DataTable tables = new DataTable();
                das.Fill(tables);
                foreach (DataRow row in tables.Rows)
                {
                    cash = cash + Convert.ToDouble(row["pool"].ToString());
                }

                label20.Text = cash.ToString();


                string filters = "";
                if (checkBox1.Checked == true)

                    filters += "tozih ='" + codebox.Text + "' AND ";
                if (checkBox2.Checked == true && checkBox4.Checked == true)
                    filters += "tarikh BETWEEN'" + datetxt.Text + "' AND '" + tadatetxt.Text + "' AND ";
                if (checkBox2.Checked == true && checkBox4.Checked == false)
                    filters += "tarikh ='" + datetxt.Text + "' AND ";
                filters = filters.Remove(filters.Length - 4);

                OleDbDataAdapter daq = new OleDbDataAdapter("SELECT * FROM kharj WHERE " + filters, con);
                DataTable tablees = new DataTable();
                daq.Fill(tablees);
                double pish = 0;

                foreach (DataRow row in tablees.Rows)
                {

                    pish = pish + Convert.ToDouble(row["ghimat"].ToString());

                }
                label20.Text = label20.Text + " - " + pish.ToString();
                con.Close();
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true || checkBox5.Checked == true)
            {

                string zaman = "00:00";
                string filteru = "";
                if (checkBox6.Checked == true)

                    filteru += "cod ='" + textBox3.Text + "' AND ";

                if (checkBox5.Checked == true)

                    filteru += "tarikh BETWEEN'" + textBox2.Text + "' AND '" + textBox1.Text + "' AND ";

                filteru = filteru.Remove(filteru.Length - 4);
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM mozd WHERE " + filteru, con);
                DataTable table = new DataTable();
                da.Fill(table);

                foreach (DataRow row in table.Rows)
                {

                    zaman = jaam(zaman, row["sakol"].ToString());
                }

                OleDbDataAdapter dh = new OleDbDataAdapter("SELECT * FROM mozd WHERE " + filteru, con);
                DataSet ds = new DataSet();
                dh.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0].DefaultView;

                maskedTextBox1.Text = zaman.ToString();
                filteru = "";
                if (checkBox6.Checked == true)

                    filteru += "tozih ='" + textBox3.Text + "' AND ";

                if (checkBox5.Checked == true)

                    filteru += "tarikh BETWEEN'" + textBox2.Text + "' AND '" + textBox1.Text + "' AND ";

                filteru = filteru.Remove(filteru.Length - 4);
                OleDbDataAdapter dq = new OleDbDataAdapter("SELECT * FROM kharj WHERE " + filteru, con);
                DataTable tablee = new DataTable();
                dq.Fill(tablee);
                double pish = 0;
                foreach (DataRow row in tablee.Rows)
                {
                    pish = pish + Convert.ToDouble(row["ghimat"].ToString());
                }
                maskhoghugh.Text = pish.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true || checkBox5.Checked == true)
            {
                button15_Click(sender, e);
                double pish = Convert.ToDouble(maskhoghugh.Text);
                maskhoghugh.Text = "";
                string[] a = maskedTextBox1.Text.Split(':');
                int saat = Convert.ToInt32(a[0].ToString());
                OleDbCommand comd = new OleDbCommand("SELECT * FROM kargar WHERE cod =@cod ", con);
                comd.Parameters.AddWithValue("@cod", textBox3.Text);
                con.Open();
                OleDbDataReader kargar = comd.ExecuteReader();
                kargar.Read();
                double money = 0;
                string model = kargar[1].ToString();
                if (model == "ماهیانه")
                {
                    if (saat < 224)
                    {

                        double sar = Convert.ToInt32(kargar[4].ToString()) / 224;
                        double khorde = Convert.ToInt32(a[1].ToString()) / 0.6 / 100;
                        money = (khorde * sar) + (saat * sar);
                    }
                    else if (saat >= 224)
                    {
                        saat = saat - 224;
                        double khorde = Convert.ToDouble(a[1].ToString()) / 0.6 / 100;
                        money = khorde * Convert.ToInt32(textezaf.Text);
                        money = Convert.ToInt32(kargar[4].ToString()) + (khorde * Convert.ToInt32(textezaf.Text)) + (saat * Convert.ToInt32(textezaf.Text));
                    }
                }
                else if (model == "روزمزد")
                {
                    MessageBox.Show("کارگر انتخابی روزمزد است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button14_Click(sender, e);
                    goto tah;
                }
                string result = money.ToString();

                float adad = float.Parse(money.ToString("F" + 1));
                result = adad.ToString();


                maskhoghugh.Text = result + " - " + pish.ToString();
            tah:
                con.Close();
            }
        }

        public static DialogResult taghvim(int a, int b, ref string value)
        {

            Form form = new Form();
            Label label = new Label();
            Button btn = new Button();
            MonthCalendarX calen = new MonthCalendarX();
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.Manual;

            form.Location.X.Equals(a);
            form.Location.Y.Equals(b);
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ControlBox = false;

            form.Controls.AddRange(new Control[] { calen, btn });
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            form.Font = new Font("tahoma", label.Font.Size);
                        btn.BackColor = Color.Lime;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.FlatStyle = FlatStyle.Flat;
            

            btn.Text = "درج";

            btn.SetBounds(0, 200, 200, 23);
            form.SetBounds(a, b, 200, 200);

            btn.DialogResult = DialogResult.OK;
            form.AcceptButton = btn;


            form.ClientSize = new Size(200, 223);
            DialogResult taghvim = form.ShowDialog();
            value = calen.GetSelectedDateInPersianDateTime().ToShortDateString();
            char[] del = { '/' };
            string[] tarikh = value.Split(del);
            int mah = Convert.ToInt32(tarikh[1]);
            if (mah < 10)
                tarikh[1] = "0" + mah.ToString();

            int ruz = Convert.ToInt32(tarikh[2]);
            if (ruz < 10)
                tarikh[2] = "0" + ruz.ToString();
            value = tarikh[0] + "/" + tarikh[1] + "/" + tarikh[2];

            return taghvim;
        }
        public string jaam(string ta, string tp)
        {
            string[] a = ta.Split(':');
            string[] p = tp.Split(':');
            int h = 0;
            int m = 0;
            int mezaf = 0;
            h = Convert.ToInt32(p[0]) + Convert.ToInt32(a[0]);
            m = Convert.ToInt32(a[1]) + Convert.ToInt32(p[1]);
            mezaf = m / 60;
            m = m % 60;
            h = h + mezaf;
            string result = h.ToString() + ":" + m.ToString();
            return result;
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                textBox2.Text= As;

            string result;
            result = textBox2.Text;
            char[] del = { '/' };
            string[] tarikh = result.Split(del);
            string mah = (Convert.ToInt32(tarikh[1]) + 1).ToString();
            if (Convert.ToInt32(mah) < 10)
                mah = "0" + mah;
            if (mah == "13")
            {
                tarikh[0] = (Convert.ToInt32(tarikh[0]) + 1).ToString();
                mah = "01";
            }

            result = tarikh[0] + "/" + mah + "/" + tarikh[2];
            textBox1.Text = result;
        }

        private void codebox_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                codebox.Text = As;
        }

        private void datetxt_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                datetxt.Text = As;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM mozd", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0].DefaultView;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM mozd", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0].DefaultView;
        }
        public void ghezaf()
        {
            OleDbCommand comd = new OleDbCommand("SELECT * FROM ezaf WHERE ID=1", con);
            con.Open();
            OleDbDataReader ezafg = comd.ExecuteReader();
            ezafg.Read();
            toolStripStatusLabel1.Text = "دسمزد هر ساعت اضاف کاری برابر است با  : ";
            textezaf.Text = ezafg[1].ToString();
            con.Close();
            // textezaf.ForeColor = Color.Green;

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                textBox3.Enabled = true;
                button13.Enabled = true;
            }
            else if (checkBox6.Checked == false)
            {
                textBox3.Enabled = false;
                button13.Enabled = false;
                textBox3.Text = "";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox5.Checked == true)
            {
                textBox2.Enabled = true;
                textBox1.Enabled = false;

            }
            else if (checkBox5.Checked == false)
            {
                textBox2.Enabled = false;
                textBox2.Text = "";
                textBox1.Text = "";
                textBox1.Enabled = false;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                codebox.Enabled = true;
                button11.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                codebox.Enabled = false;
                codebox.Text = "";
                button11.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                datetxt.Enabled = true;
                tadatetxt.Enabled = true;
                checkBox4.Enabled = true;

            }
            else if (checkBox2.Checked == false)
            {
                datetxt.Enabled = false;
                datetxt.Text = "";
                tadatetxt.Text = "";
                tadatetxt.Enabled = false;
                checkBox4.Enabled = false;
                checkBox4.Checked = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string filteru = "";
            if (checkBox1.Checked == true)
                filteru += "cod ='" + codebox.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == true)
                filteru += "tarikh BETWEEN'" + datetxt.Text + "' AND '" + tadatetxt.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == false)
                filteru += "tarikh ='" + datetxt.Text + "' AND ";
            filteru = filteru.Remove(filteru.Length - 4);
            if (filteru != "")
            {
                OleDbCommand myCommanda = new OleDbCommand("UPDATE mozd SET tasviye=@tasviye WHERE " + filteru, con);
                myCommanda.Parameters.AddWithValue("@tasviye", "تسویه شده");
                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات با موفقیت به روز شد!");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

            string filteru = "";
            if (checkBox6.Checked == true)

                filteru += "cod ='" + textBox3.Text + "' AND ";

            if (checkBox5.Checked == true)

                filteru += "tarikh BETWEEN'" + textBox2.Text + "' AND '" + textBox1.Text + "' AND ";

            filteru = filteru.Remove(filteru.Length - 4);
            if (filteru != "")
            {
                OleDbCommand myCommanda = new OleDbCommand("UPDATE mozd SET tasviye=@tasviye WHERE " + filteru, con);
                myCommanda.Parameters.AddWithValue("@tasviye", "تسویه شده");
                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات با موفقیت به روز شد!");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM mozd WHERE ID =@id", con);
            myCommanda.Parameters.AddWithValue("@id", label33.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اطلاعات با موفقیت حذف شد!");
            button20.Visible = false;
            button12_Click(sender, e);
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            label33.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            button20.Visible = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            report x = new report();
            x.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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
            textezaf.Visible = false;
            textezaf.Visible = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = panel1.Height;
            x = x - 50;
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
                button1_Click(sender, e);
            }
        }
    }
}
