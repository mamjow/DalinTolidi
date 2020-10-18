using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BehComponents;

namespace Tolidi
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbghDataSet.kharj' table. You can move, or remove it, as needed.
            this.kharjTableAdapter.Fill(this.dbghDataSet.kharj);
            // TODO: This line of code loads data into the 'dbghDataSet.mozd' table. You can move, or remove it, as needed.
            this.mozdTableAdapter.Fill(this.dbghDataSet.mozd);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.Height = 450;

        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    this.kharjTableAdapter.FillBy(this.dbghDataSet.kharj, textBox1.Text, textBox2.Text, textBox3.Text);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

                try
                {
                    this.mozdTableAdapter.FillBy1(this.dbghDataSet.mozd, textBox1.Text, textBox2.Text, textBox3.Text);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                reportViewer1.Visible = true;
                reportViewer2.Visible = false;
               

            }
            if (radioButton1.Checked == true)
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;
            }
            this.reportViewer1.RefreshReport();

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



        private void textBox2_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                textBox2.Text = As;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            string As = "";
            if (taghvim(Cursor.Position.X, Cursor.Position.Y, ref As) == DialogResult.OK)

                textBox3.Text = As;
        }

        private void report_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            reportViewer2.LocalReport.ReleaseSandboxAppDomain();
        }




    }
}
