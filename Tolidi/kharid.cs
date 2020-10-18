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
    public partial class kharid : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));

        public kharid()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);

        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            label.Font = new Font("tahoma", label.Font.Size);
            textBox.Text = value;
            //textBox.KeyPress += new KeyPressEventHandler(tkp);
            textBox.TextAlign = HorizontalAlignment.Center;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
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
        public void refresh()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM sell ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView6.DataSource = ds.Tables[0].DefaultView;

            OleDbDataAdapter daa = new OleDbDataAdapter("SELECT * FROM kk ", con);
            DataSet dss = new DataSet();
            daa.Fill(dss);
            dataGridView5.DataSource = dss.Tables[0].DefaultView;

            OleDbDataAdapter das = new OleDbDataAdapter("SELECT * FROM kharj ", con);
            DataSet dsa = new DataSet();
            das.Fill(dsa);
            dataGridView4.DataSource = dsa.Tables[0].DefaultView;

        }
        public void loadno()
        {
            comboBox2.Items.Clear();
            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM gharch WHERE bastebandi = '" + comboBox1.SelectedItem.ToString() + "' ", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                comboBox2.Items.Add(row["model"].ToString());

            }
            con.Close();
        }
        public void salon()
        {
            combosalon1.Items.Clear();
            combosalon2.Items.Clear();
            combosalon3.Items.Clear();
            comboBox4.Items.Clear();
            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM salon", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                i++;
                combosalon1.Items.Add(row["salon"].ToString());
                combosalon2.Items.Add(row["salon"].ToString());
                combosalon3.Items.Add(row["salon"].ToString());
                comboBox4.Items.Add(row["salon"].ToString());

            }
            con.Close();
            // tsalon.Text = i.ToString();
            // tsalon.ForeColor = Color.Green;


        }
        public static void tkp(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;

            }

            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }


        private void kharid_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbghDataSet.kharj' table. You can move, or remove it, as needed.
            this.kharjTableAdapter.Fill(this.dbghDataSet.kharj);
            // TODO: This line of code loads data into the 'dbghDataSet.kk' table. You can move, or remove it, as needed.
            this.kkTableAdapter.Fill(this.dbghDataSet.kk);
            // TODO: This line of code loads data into the 'dbghDataSet.sell' table. You can move, or remove it, as needed.
            this.sellTableAdapter.Fill(this.dbghDataSet.sell);
            salon();
            dataGridView4.Columns[0].Visible = false;
            dataGridView5.Columns[0].Visible = false;
            dataGridView6.Columns[0].Visible = false;
            tabControl1.SelectedTab = tabPage1;
            tabControl1.SelectedTab = tabPage2;


        }



        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loadno();
            if (comboBox1.SelectedItem.ToString() == "کیلویی")
                label17.Text = "وزن :";
            else if (comboBox1.SelectedItem.ToString() == "بسته بندی")
                label17.Text = "تعداد :";
        }

        private void furushhazine_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (furushmeghdar.Text != string.Empty && comboBox1.SelectedItem.ToString() != string.Empty && comboBox2.SelectedItem.ToString() != string.Empty)
            {
                OleDbCommand comd = new OleDbCommand("SELECT * FROM gharch WHERE model=@model AND bastebandi=@bastebandi", con);
                comd.Parameters.AddWithValue("@model", comboBox2.SelectedItem.ToString());
                comd.Parameters.AddWithValue("@bastebandi", comboBox1.SelectedItem.ToString());
                con.Open();
                OleDbDataReader gharch = comd.ExecuteReader();
                gharch.Read();
                double hazineh = Convert.ToDouble(gharch[3].ToString());
                //furushhazine.Text = comboBox2.
                con.Close();
                hazineh = Convert.ToDouble(furushmeghdar.Text) * hazineh;
                furushhazine.Text = hazineh.ToString();
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {

            if (comboBox1.Text != string.Empty && comboBox2.Text != string.Empty && furushhazine.Text != string.Empty && furushdat.Text != string.Empty && combosalon1.Text != string.Empty)
            {
                OleDbCommand myCommanda = new OleDbCommand("INSERT INTO sell (halat ,tarikh,model,meghdar,hazine,kharidar,tozih,salon ) VALUES (@halat ,@tarikh,@model,@meghdar,@hazine,@kharidar,@tozih,@salon)", con);
                myCommanda.Parameters.AddWithValue("@halat", comboBox1.SelectedItem.ToString());
                myCommanda.Parameters.AddWithValue("@tarikh", furushdat.Text);
                myCommanda.Parameters.AddWithValue("@model", comboBox2.SelectedItem.ToString());
                myCommanda.Parameters.AddWithValue("@meghdar", furushmeghdar.Text);
                myCommanda.Parameters.AddWithValue("@hazine", furushhazine.Text);
                myCommanda.Parameters.AddWithValue("@kharidar", furushkharidar.Text);
                myCommanda.Parameters.AddWithValue("@tozih", furushtozih.Text);
                myCommanda.Parameters.AddWithValue("@salon", combosalon1.SelectedItem.ToString());
                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("فروش ثبت شد", "اعلان", MessageBoxButtons.OK);
                furushdat.Text = "";
                furushhazine.Text = "";
                furushmeghdar.Text = "";
                furushkharidar.Text = "";
                furushtozih.Text = "";
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM sell ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView6.DataSource = ds.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("لطفا اطلاعات لازم را پر کنید");
        }

        private void furushdat_DoubleClick(object sender, EventArgs e)
        {
            furushdat.Text = refdate();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                dataGridView6.Visible = true;
                dataGridView5.Visible = false;
                dataGridView4.Visible = false;
                chart1.Visible = false;

            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                dataGridView6.Visible = false;
                dataGridView5.Visible = false;
                dataGridView4.Visible = true;
                chart1.Visible = false;
            }
            else if (tabControl1.SelectedTab == tabPage1)
            {
                dataGridView6.Visible = false;
                dataGridView5.Visible = true;
                dataGridView4.Visible = false;
                chart1.Visible = false;
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                dataGridView6.Visible = false;
                dataGridView5.Visible = false;
                dataGridView4.Visible = false;
                chart1.Visible = true;
            }


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
                label24.Text = "ش بارنامه :";
            else if (comboBox3.SelectedIndex == 1)
                label24.Text = "تعداد : ";
        }



        private void kksabt_Click(object sender, EventArgs e)
        {

            if (comboBox3.Text != "" && kktarikh.Text != "" && kkmablagh.Text != "" && combosalon2.Text != string.Empty)
            {
                OleDbCommand myCommanda = new OleDbCommand("INSERT INTO Kk (mahmule,vazn,ghimat,tyash,tarikh , salon) VALUES (@mahmule,@vazn,@ghimat,@tyash,@tarikh,@salon)", con);
                myCommanda.Parameters.AddWithValue("@mahmule", comboBox3.SelectedItem.ToString());
                myCommanda.Parameters.AddWithValue("@vazn", kkvazn.Text);
                myCommanda.Parameters.AddWithValue("@ghimat", kkmablagh.Text);
                myCommanda.Parameters.AddWithValue("@tyash", kkbarname.Text);
                myCommanda.Parameters.AddWithValue("@tarikh", kktarikh.Text);
                myCommanda.Parameters.AddWithValue("@salon", combosalon2.SelectedItem.ToString());
                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("خرید ثبت شد", "اعلان", MessageBoxButtons.OK);
                kkvazn.Text = "";
                kkmablagh.Text = "";
                kkbarname.Text = "";
                kktarikh.Text = "";
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kk ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView5.DataSource = ds.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("لطفا اطلاعات لازم را پر کنید");

        }


        private void hazinetozih_Leave(object sender, EventArgs e)
        {
            if (hazinetozih.Text.Length == 10)
            {
                int j = 0;
                string kod = hazinetozih.Text;
                OleDbCommand camd = new OleDbCommand("SELECT COUNT(*) FROM kargar WHERE kart ='" + kod + "'", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    j = (int)camd.ExecuteScalar();

                }//end if
                con.Close();
                if (j > 0)
                {
                    //timer1.Enabled = false;
                    OleDbCommand comd = new OleDbCommand("SELECT * FROM kargar WHERE kart =@kart ", con);
                    comd.Parameters.AddWithValue("@kart", kod);
                    con.Open();
                    OleDbDataReader kargar = comd.ExecuteReader();
                    kargar.Read();
                    hazinetozih.Text = kargar[3].ToString();
                    hazinetozih_Leave(sender, e);
                    con.Close();
                }
            }
            int i = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM kargar WHERE cod ='" + hazinetozih.Text + "'", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();

            }//end if
            con.Close();
            if (i > 0)
            {
                OleDbCommand comd = new OleDbCommand("SELECT * FROM kargar WHERE cod =@cod ", con);
                comd.Parameters.AddWithValue("@cod", hazinetozih.Text);
                con.Open();
                OleDbDataReader kargar = comd.ExecuteReader();
                kargar.Read();
                string value = "وجه نقد";
                if (InputBox("هزینه بابت", "هزینه پرداختی به " + kargar[2].ToString() + " را توضیح دهید.", ref value) == DialogResult.OK)
                    sahrh.Text = value;
                else
                    hazinetozih.Text = "";
                con.Close();
            }
            else
                sahrh.Text = "خرج";
        }

        private void hazinetarikh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            hazinetarikh.Text = refdate();
        }

        private void hazinesabt_Click(object sender, EventArgs e)
        {

            if (hazinetarikh.Text != string.Empty && hazineghimat.Text != string.Empty && hazinetozih.Text != string.Empty)
            {
                hazinetozih_Leave(sender, e);
                OleDbCommand myCommanda = new OleDbCommand("INSERT INTO Kharj (tarikh,ghimat,tozih,salon,sharh) VALUES (@tarikh,@ghimat,@tozih,@salon,@sharh)", con);
                myCommanda.Parameters.AddWithValue("@tarikh", hazinetarikh.Text);
                myCommanda.Parameters.AddWithValue("@ghimat", hazineghimat.Text);
                myCommanda.Parameters.AddWithValue("@tozih", hazinetozih.Text);
                myCommanda.Parameters.AddWithValue("@salon", combosalon3.Text);
                myCommanda.Parameters.AddWithValue("@sharh", sahrh.Text);

                con.Open();
                myCommanda.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("خرید ثبت شد", "اعلان", MessageBoxButtons.OK);
                hazineghimat.Text = "";
                hazinetarikh.Text = "";
                hazinetozih.Text = "";
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kharj ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView4.DataSource = ds.Tables[0].DefaultView;
            }
            else
                MessageBox.Show("لطفا اطلاعات لازم را پر کنید");
        }



        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                tatarikh.Enabled = true;
            else if (checkBox3.Checked == false)
                tatarikh.Enabled = false;
        }

        private void tatarikh_DoubleClick(object sender, EventArgs e)
        {
            tatarikh.Text = refdate();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
                comboBox4.Enabled = true;
            else if (checkBox7.Checked == false)
                comboBox4.Enabled = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (aztarikh.Text == "")
                MessageBox.Show("بهتر است تاریخ مشخصی را اعلام کنید");
            con.Open();
            string filters = "";
            if (checkBox3.Checked == true)
                filters += "tarikh BETWEEN '" + aztarikh.Text + "' AND '" + tatarikh.Text + "' AND ";
            if (checkBox3.Checked == false)
                filters += "tarikh ='" + aztarikh.Text + "' AND ";
            if (checkBox7.Checked == true)
                filters += "salon ='" + comboBox4.SelectedItem.ToString() + "' AND ";

            filters = filters.Remove(filters.Length - 4);
            OleDbDataAdapter daq = new OleDbDataAdapter("SELECT * FROM kharj WHERE " + filters, con);
            DataTable tablees = new DataTable();
            daq.Fill(tablees);
            double pish = 0;
            foreach (DataRow row in tablees.Rows)
            {
                pish = pish + Convert.ToDouble(row["ghimat"].ToString());
            }
            labelhazine.Text = pish.ToString();
            //double pish = 0;

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kk WHERE " + filters, con);
            DataTable tablee = new DataTable();
            da.Fill(tablee);
            double kk = 0;
            foreach (DataRow row in tablee.Rows)
            {
                kk = kk + Convert.ToDouble(row["ghimat"].ToString());
            }
            labelkharid.Text = kk.ToString();

            OleDbDataAdapter ds = new OleDbDataAdapter("SELECT * FROM sell WHERE " + filters, con);
            DataTable table = new DataTable();
            ds.Fill(table);
            double sell = 0;
            foreach (DataRow row in table.Rows)
            {
                sell = sell + Convert.ToDouble(row["hazine"].ToString());
            }
            labelfurush.Text = sell.ToString();
            double kol = sell - kk - pish;
            labelkol.Text = kol.ToString();
            con.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(textBox1.Location.X, textBox1.Location.Y, ref As) == DialogResult.OK)

                textBox1.Text = As;
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

            btn.Text = "درج";

            btn.SetBounds(75, 200, 50, 23);
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



        private void hazinetarikh_Click(object sender, EventArgs e)
        {

            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                hazinetarikh.Text = As;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                textBox2.Text = As;
        }

        private void aztarikh_MouseClick(object sender, MouseEventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                aztarikh.Text = As;
        }

        private void tatarikh_MouseClick(object sender, MouseEventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                tatarikh.Text = As;
        }

        private void furushdat_MouseClick(object sender, MouseEventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                furushdat.Text = As;
        }

        private void kktarikh_Click(object sender, EventArgs e)
        {

            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                kktarikh.Text = As;
        }

        private void filterkey_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                con.Open();
                string filters = "";
                filters = "tarikh BETWEEN '" + textBox1.Text + "' AND '" + textBox2.Text + "' AND tozih ='" + textBox3.Text + "'";

                OleDbDataAdapter daq = new OleDbDataAdapter("SELECT * FROM kharj WHERE " + filters, con);
                DataTable tablees = new DataTable();
                daq.Fill(tablees);
                double pish = 0;
                foreach (DataRow row in tablees.Rows)
                {
                    pish = pish + Convert.ToDouble(row["ghimat"].ToString());
                }
                labelhazine.Text = pish.ToString();
                con.Close();
            }
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
            panel1.Dock = DockStyle.Bottom;
            int x = panel1.Height;
            x = x - 10;
            panel1.Height = x;
            if (x <= 117)
            {
                panel1.Enabled = false;
                timer1.Stop();
                pictureBox1.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                hazindel.Visible = true;
                //hazinedit.Visible = true;
                khariddel.Visible = true;
                //kharidedit.Visible = true;
                selldel.Visible = true;
                //selledit.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                hazindel.Visible = false;
                //hazinedit.Visible = false;
                khariddel.Visible = false;
               // kharidedit.Visible = false;
                selldel.Visible = false;
                //selledit.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            panel1.Height = 389;
            panel1.Enabled = true;
            pictureBox1.Visible = true;
            checkBox1.Checked = false;
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                hazinetarikh.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                label8.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                hazinetozih.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                hazineghimat.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                combosalon3.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            }
            //sharhbed.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
        }

        private void passt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button12_Click(sender, e);
            }
        }

        private void hazindel_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM Kharj WHERE ID=@id", con);
            myCommanda.Parameters.AddWithValue("@id", label8.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            tabControl1.SelectedTab = tabPage3;
            refresh();
        }

        private void khariddel_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM kk WHERE ID=@id", con);
            myCommanda.Parameters.AddWithValue("@id", label7.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            tabControl1.SelectedTab = tabPage1;
            refresh();
        }

        private void selldel_Click(object sender, EventArgs e)
        {
            OleDbCommand myCommanda = new OleDbCommand("DELETE FROM sell WHERE ID=@id", con);
            myCommanda.Parameters.AddWithValue("@id", label6.Text);
            con.Open();
            myCommanda.ExecuteNonQuery();
            con.Close();
            tabControl1.SelectedTab = tabPage2;
            refresh();
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                kkvazn.Text = dataGridView5.CurrentRow.Cells[3].Value.ToString();
                kkbarname.Text = dataGridView5.CurrentRow.Cells[5].Value.ToString();
                kktarikh.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
                kkmablagh.Text = dataGridView5.CurrentRow.Cells[4].Value.ToString();
                combosalon2.Text = dataGridView5.CurrentRow.Cells[6].Value.ToString();
                comboBox3.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
                label7.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                label6.Text = dataGridView6.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
                furushdat.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString();
                comboBox2.Text = dataGridView6.CurrentRow.Cells[3].Value.ToString();
                furushmeghdar.Text = dataGridView6.CurrentRow.Cells[4].Value.ToString();
                furushhazine.Text = dataGridView6.CurrentRow.Cells[5].Value.ToString();
                furushkharidar.Text = dataGridView6.CurrentRow.Cells[6].Value.ToString();
                furushtozih.Text = dataGridView6.CurrentRow.Cells[7].Value.ToString();
                combosalon1.Text = dataGridView6.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[0].Points.Clear();
           
            con.Open();
            string tarikh = aztarikh.Text;
            string tarikh1 = "";
            string filters = "";

            if (checkBox3.Checked == true)
                filters += "tarikh BETWEEN '" + aztarikh.Text + "' AND '" + tatarikh.Text + "' AND ";
            if (checkBox3.Checked == false)
                filters += "tarikh ='" + aztarikh.Text + "' AND ";
            if (checkBox7.Checked == true)
                filters += "salon ='" + comboBox4.SelectedItem.ToString() + "' AND ";

            filters = filters.Remove(filters.Length - 4);
            OleDbDataAdapter daq = new OleDbDataAdapter("SELECT * FROM kharj WHERE " + filters, con);
            DataTable tablees = new DataTable();
            daq.Fill(tablees);
            double pish = 0;

            foreach (DataRow row in tablees.Rows)
            {
                pish = pish + Convert.ToDouble(row["ghimat"].ToString());
                tarikh1 = row["tarikh"].ToString();
                /*if (tarikh1 != tarikh)
                {
                    pish = -pish;
                    tarikh = tarikh1;
                    chart1.Series["هزینه/حقوق"].XValueMember = tarikh.ToString();
                    chart1.Series["هزینه/حقوق"].Points.Add(Convert.ToDouble(pish.ToString()));
                    pish = 0;
                }*/
     
            }

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kk WHERE " + filters, con);
            DataTable tablee = new DataTable();
            da.Fill(tablee);
            double kk = 0;
            foreach (DataRow row in tablee.Rows)
            {
                kk = kk + Convert.ToDouble(row["ghimat"].ToString());
                tarikh1 = row["tarikh"].ToString();
                /*if (tarikh1 != tarikh)
                {
                    kk = -kk;
                    tarikh = tarikh1;
                    chart1.Series["خرید"].XValueMember = tarikh.ToString() ;
                    chart1.Series["خرید"].Points.Add(Convert.ToDouble(kk.ToString()));
                    kk = 0;
                }*/
            }

            OleDbDataAdapter ds = new OleDbDataAdapter("SELECT * FROM sell WHERE " + filters, con);
            DataTable table = new DataTable();
            ds.Fill(table);
            double sell = 0;
            int k = 0;
            foreach (DataRow row in table.Rows)
            {
               
                sell = sell + Convert.ToDouble(row["hazine"].ToString());
                tarikh1 = row["tarikh"].ToString();
                if (tarikh1 != tarikh)
                {
                    k = k + 1;
                    tarikh = tarikh1;
                    chart1.Series["فروش"].Points.Add(Convert.ToDouble(sell.ToString()));

                    chart1.Series["فروش"].Points[k-1].AxisLabel = tarikh;
                    sell=0;
                }
            }
            //labelfurush.Text = sell.ToString();
            double kol = sell - kk - pish;
            //labelkol.Text = kol.ToString();


            con.Close();

            chart1.Show();

        }

    }
}
