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
    public partial class MainPage : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public MainPage()
        {
            InitializeComponent();
                 con = new OleDbConnection(ConnectionString);
       
        }

        private void item1_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms["kargar"] as kargar) != null)
            {
                Application.OpenForms["kargar"].BringToFront();
            }
            else
            {
                kargar objchild = new kargar();
                objchild.MdiParent = this;
                objchild.Show();
            }
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            label.Font = new Font("tahoma", label.Font.Size);
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            //textBox.KeyPress += new KeyPressEventHandler(tkp);
            textBox.TextAlign = HorizontalAlignment.Center;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(124, 15, 372, 13);
            textBox.SetBounds(12, 56, 372, 20);
            buttonOk.SetBounds(228, 92, 75, 23);
            buttonCancel.SetBounds(309, 92, 75, 23);
            
            label.AutoSize = true;
            //label.RightToLeft = true;
            label.TextAlign = ContentAlignment.MiddleRight;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 127);
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
        private void itemtanzim_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms["tanzimat"] as tanzimat) != null)
            {
                Application.OpenForms["tanzimat"].BringToFront();
            }
            else
            {
                tanzimat objchild = new tanzimat();
                objchild.MdiParent = this;
                objchild.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkap();
        }
        private void checkap()
        { int i = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM admin ", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    i = (int)cmd.ExecuteScalar();

                }
                con.Close();
                //i = 2;
                if (i == 0)
                { 
                passgiri:
                    string value="";

                if (InputBox("خوش آمدید", "لطفا رمز عبوری برای برنامه مشخص نمایید " + Environment.NewLine + "  : رمز عبور ", ref value) == DialogResult.OK)
                {
                    OleDbCommand myCommand = new OleDbCommand("INSERT INTO admin (username , pass) VALUES (@username , @pass)", con);
                    myCommand.Parameters.AddWithValue("@username", "admin");
                    myCommand.Parameters.AddWithValue("@pass", value);
                    con.Open();
                    myCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Username : admin " + Environment.NewLine + "Password : " + value, "اطلاعات مدیریت");
                }
                else
                    goto passgiri;
                }
        }

        private void دفترچهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms["book"] as Book) != null)
            {
                Application.OpenForms["book"].BringToFront();
            }
            else
            {
                Book objchild = new Book();
                objchild.MdiParent = this;
                objchild.Show();
            }
        }

        private void خریدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["kahrid"] as kharid) != null)
            {
                Application.OpenForms["kharid"].BringToFront();
            }
            else
            {
                kharid objchild = new kharid();
                objchild.MdiParent = this;
                objchild.Show();
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void حسابداریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["hesab"] as hesab) != null)
            {
                Application.OpenForms["hesab"].BringToFront();
            }
            else
            {
                hesab objchild = new hesab();
                objchild.MdiParent = this;
                objchild.Show();
            }
        }

        private void اToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["AboutBox1"] as AboutBox1) != null)
            {
                Application.OpenForms["AboutBox1"].BringToFront();
            }
            else
            {
                AboutBox1 objchild = new AboutBox1();
                objchild.MdiParent = this;

                objchild.Show();

            }
        }

    }
}
