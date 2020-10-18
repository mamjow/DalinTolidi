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
    public partial class kargar : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public kargar()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);
        }
        public string refdate()
        {
            System.Globalization.PersianCalendar pc = new
            System.Globalization.PersianCalendar();
            int mah = pc.GetMonth(DateTime.Now);
            int ruz = pc.GetDayOfMonth(DateTime.Now);
            string maha = pc.GetMonth(DateTime.Now).ToString();
            string ruza = pc.GetDayOfMonth(DateTime.Now).ToString();
            if (mah < 10)
                maha = "0" + mah.ToString();
            if (ruz < 10)
                ruza = "0" + ruz.ToString();
            string tarkh = pc.GetYear(DateTime.Now) + "/" + maha + "/" + ruza;
            return tarkh;

        }
        public void ghezaf()
        {
            OleDbCommand comd = new OleDbCommand("SELECT * FROM ezaf WHERE ID=1", con);
            con.Open();
            OleDbDataReader ezafg = comd.ExecuteReader();
            ezafg.Read();
            toolStripStatusLabel1.Text = "دسمزد هر ساعت اضاف کاری برابر است با  : ";
            toolStripStatusLabel2.Text = ezafg[1].ToString();
            con.Close();
           // textezaf.ForeColor = Color.Green;

        }
        public string mohasebe(string ta, string tp)
        {
            string[] a = ta.Split(':');
            string[] p = tp.Split(':');
            int h = 0;
            int m = 0;
            int mezaf = 0;
            h = Convert.ToInt32(p[0]) - Convert.ToInt32(a[0]) - 1;
            m = (60 - Convert.ToInt32(a[1])) + Convert.ToInt32(p[1]);
            mezaf = m / 60;
            m = m % 60;
            h = h + mezaf;
            string result = h.ToString() + ":" + m.ToString();
            return result;
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
        public string hazineruz(string kar, string codkar)
        {
            string[] a = kar.Split(':');
            int saat = Convert.ToInt32(a[0].ToString());
            OleDbCommand comd = new OleDbCommand("SELECT * FROM kargar WHERE cod =@cod ", con);
            comd.Parameters.AddWithValue("@cod", codkar);
            con.Open();
            OleDbDataReader kargar = comd.ExecuteReader();
            kargar.Read();
            double money = 0;
            string model = kargar[1].ToString();
            if (model == "روزمزد")
            {
                if (saat < 8)
                {
                    double sar = Convert.ToInt32(kargar[4].ToString()) / 8;
                    double khorde = Convert.ToInt32(a[1].ToString()) / 0.6 / 100;
                    money = (khorde * sar) + (saat * sar);
                }
                else if (saat >= 8)
                {
                    saat = saat - 8;
                    double khorde = Convert.ToDouble(a[1].ToString()) / 0.6 / 100;
                    money = khorde * Convert.ToInt32(toolStripStatusLabel2.Text);
                    money = Convert.ToInt32(kargar[4].ToString()) + (khorde * Convert.ToInt32(toolStripStatusLabel2.Text)) + (saat * Convert.ToInt32(toolStripStatusLabel2.Text));
                }
            }

            string result = money.ToString();
            con.Close();
            return result;
        }
        private void button9_Click(object sender, EventArgs e)
        {


            int i = 0;
            if ((incod.Text == string.Empty) || (intime.Text == string.Empty) || (indate.Text == string.Empty))
            {
                MessageBox.Show("لطفا اطلاعات را به صورت کامل پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto End;
            }
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM mozd WHERE cod =@cod AND  tarikh =@tarikh", con);
            cmd.Parameters.AddWithValue("@cod", incod.Text);
            cmd.Parameters.AddWithValue("@tarikh", indate.Text);
            con.Open();
            i = (int)cmd.ExecuteScalar();
            con.Close();

            if (i > 0)
            {
                OleDbDataAdapter dq = new OleDbDataAdapter("SELECT * FROM kharj WHERE tozih ='" + incod.Text + "' AND  tarikh ='" + indate.Text + "'", con);
                DataTable tablee = new DataTable();
                dq.Fill(tablee);
                double pish = 0;
                foreach (DataRow row in tablee.Rows)
                {
                    pish = pish + Convert.ToDouble(row["ghimat"].ToString());
                }
                string bedehi = "- " + pish.ToString();

                OleDbCommand comd = new OleDbCommand("SELECT * FROM mozd WHERE cod =@cod AND  tarikh =@tarikh", con);
                comd.Parameters.AddWithValue("@cod", incod.Text);
                comd.Parameters.AddWithValue("@tarikh", indate.Text);
                con.Open();
                OleDbDataReader kargar = comd.ExecuteReader();
                kargar.Read();

                string ids = kargar[0].ToString();
                string dakhel = kargar[9].ToString();
                string zaman1 = kargar[7].ToString();
                string zaman2 = intime.Text;
                string skol = mohasebe(zaman1, zaman2);
                string zamank = kargar[5].ToString();
                string sinput = jaam(skol, zamank);


                con.Close();
                if (dakhel == "True")
                {
                    string poool = hazineruz(sinput, incod.Text).ToString();// +" " + bedehi;

                    OleDbCommand myCommanda = new OleDbCommand("UPDATE mozd SET saout=@saout, tsaout=@tsaout ,sakol=@sakol ,pool =@pool ,darhalekar=@dar WHERE ID=@id", con);
                    myCommanda.Parameters.AddWithValue("@saout", intime.Text);
                    myCommanda.Parameters.AddWithValue("@tsaout", intime.Text);
                    myCommanda.Parameters.AddWithValue("@sakol", sinput);
                    myCommanda.Parameters.AddWithValue("@pool", poool);
                    myCommanda.Parameters.AddWithValue("@dar", "0");
                    myCommanda.Parameters.AddWithValue("@id", ids);
                    con.Open();

                    myCommanda.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("خروج برای کارگر مورد نظر ثبت شد" + Environment.NewLine + "مجموع ساعات کار امروز : " + sinput, " اعلان خروج", MessageBoxButtons.OK);
                }
                else if (dakhel == "False")
                {
                    OleDbCommand myCommanda = new OleDbCommand("UPDATE mozd SET  tsain=@tsain ,darhalekar=@dar WHERE ID=@id", con);
                    myCommanda.Parameters.AddWithValue("@tsain", intime.Text);
                    myCommanda.Parameters.AddWithValue("@dar", "-1");
                    myCommanda.Parameters.AddWithValue("@id", ids);
                    con.Open();
                    myCommanda.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ورود برای کارگر مورد نظر ثبت شد", "اعلان ورود", MessageBoxButtons.OK);
                }
            }
            else
            {
                OleDbCommand myCommanda = new OleDbCommand("INSERT INTO mozd (cod ,tarikh,sain,sakol,pool,tsain,darhalekar ) VALUES (@cod ,@tarikh,@sain,@sakol,@pool,@tsain,@dar)", con);
                myCommanda.Parameters.AddWithValue("@cod", incod.Text);
                myCommanda.Parameters.AddWithValue("@tarikh", indate.Text);
                myCommanda.Parameters.AddWithValue("@sain", intime.Text);
                myCommanda.Parameters.AddWithValue("@sakol", "00:00");
                myCommanda.Parameters.AddWithValue("@pool", "0");
                myCommanda.Parameters.AddWithValue("@tsain", intime.Text);
                myCommanda.Parameters.AddWithValue("@dar", "-1");
                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ورود برای کارگر مورد نظر ثبت شد", "اعلان ورود", MessageBoxButtons.OK);
            }
        End:
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM mozd ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0].DefaultView;
            i = 0;

            dataGridView3.FirstDisplayedScrollingRowIndex = dataGridView3.RowCount - 1;
            if (checkBox8.Checked == true)
            {
                timer1.Enabled = true;
                intime.Text = "";
                indate.Text = "";
                incod.Text = "";
                label34.Text = " نام کارگر ";
            }
            else
                timer1.Enabled = false;


        }

        private void incod_Leave(object sender, EventArgs e)
        {

            if (incod.Text != "")
            {
                if (checkBox8.Checked == true)
                {
                    if (incod.Text.Length == 10)
                    {

                        int j = 0;
                        string kod = incod.Text;
                        OleDbCommand camd = new OleDbCommand("SELECT COUNT(*) FROM kargar WHERE kart ='" + kod + "'", con);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                            j = (int)camd.ExecuteScalar();

                        }//end if
                        con.Close();
                        if (j > 0)
                        {
                            timer1.Enabled = false;
                            OleDbCommand comd = new OleDbCommand("SELECT * FROM kargar WHERE kart =@kart ", con);
                            comd.Parameters.AddWithValue("@kart", kod);
                            con.Open();
                            OleDbDataReader kargar = comd.ExecuteReader();
                            kargar.Read();
                            incod.Text = kargar[3].ToString();
                            label34.Text = kargar[2].ToString();
                            indate_DoubleClick(sender, e);
                            intime_DoubleClick(sender, e);
                            con.Close();
                            button9_Click(sender, e);

                            intime.Text = "";
                            indate.Text = "";
                            incod.Text = "";
                            timer1.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("خظا");
                            MessageBox.Show("شماره کارت وارد شده صحیح نیست ، مجدد تلاش کنید");
                        }
                    }

                }
                else if (checkBox8.Checked == false)
                {
                    int i = 0;
                    OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM kargar WHERE cod ='" + incod.Text + "'", con);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        i = (int)cmd.ExecuteScalar();

                    }//end if
                    con.Close();
                    if (i > 0)
                    {
                        OleDbCommand comd = new OleDbCommand("SELECT * FROM kargar WHERE cod =@cod ", con);
                        comd.Parameters.AddWithValue("@cod", incod.Text);
                        con.Open();
                        OleDbDataReader kargar = comd.ExecuteReader();
                        kargar.Read();
                        label34.Text = kargar[2].ToString();
                        con.Close();
                    }
                    else
                        MessageBox.Show("کد کارگر وجود ندارد");
                }
            }
        }

        private void incod_TextChanged(object sender, EventArgs e)
        {

            if (incod.Text.Length == 10)
                incod_Leave(sender, e);
        }



 

        private void kargar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbghDataSet.mozd' table. You can move, or remove it, as needed.
            this.mozdTableAdapter.Fill(this.dbghDataSet.mozd);
            ghezaf();

        }

        private void indate_DoubleClick(object sender, EventArgs e)
        {
            indate.Text = refdate();
        }

        private void intime_DoubleClick(object sender, EventArgs e)
        {
            intime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (incod.Focused != false)
            {
                incod.Focus();
                incod.Text = "";

            }
            else
            {
                incod.Focus();
                incod.Text = "";
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                timer1.Enabled = true;
                incod.Focus();
                this.BringToFront(); 
                this.TopMost = true;
            }

            else if (checkBox8.Checked == false)
                timer1.Enabled = false;
        }

    }
}
