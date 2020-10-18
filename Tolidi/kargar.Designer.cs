namespace Tolidi
{
    partial class kargar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.indate = new System.Windows.Forms.MaskedTextBox();
            this.intime = new System.Windows.Forms.MaskedTextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.incod = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.monthCalendarX1 = new BehComponents.MonthCalendarX();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarikhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sakolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsaoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.darhalekarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tasviyeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mozdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbghDataSet = new Tolidi.dbghDataSet();
            this.mozdTableAdapter = new Tolidi.dbghDataSetTableAdapters.mozdTableAdapter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mozdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbghDataSet)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox8);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.indate);
            this.groupBox3.Controls.Add(this.intime);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.incod);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(519, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 188);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ورود / خروج";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(11, 16);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox8.Size = new System.Drawing.Size(72, 17);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Text = "کارت خوان";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Location = new System.Drawing.Point(24, 120);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(149, 17);
            this.label34.TabIndex = 9;
            this.label34.Text = "نام کارگر";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // indate
            // 
            this.indate.Location = new System.Drawing.Point(11, 66);
            this.indate.Name = "indate";
            this.indate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.indate.Size = new System.Drawing.Size(114, 21);
            this.indate.TabIndex = 1;
            this.indate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.indate.DoubleClick += new System.EventHandler(this.indate_DoubleClick);
            // 
            // intime
            // 
            this.intime.Location = new System.Drawing.Point(11, 92);
            this.intime.Mask = "00:00";
            this.intime.Name = "intime";
            this.intime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.intime.Size = new System.Drawing.Size(114, 21);
            this.intime.TabIndex = 2;
            this.intime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intime.ValidatingType = typeof(System.DateTime);
            this.intime.DoubleClick += new System.EventHandler(this.intime_DoubleClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(13, 144);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(172, 32);
            this.button9.TabIndex = 3;
            this.button9.Text = "وررو / خروج";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(143, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "تاریخ :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(143, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "ساعت :";
            // 
            // incod
            // 
            this.incod.Location = new System.Drawing.Point(11, 39);
            this.incod.Name = "incod";
            this.incod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.incod.Size = new System.Drawing.Size(114, 21);
            this.incod.TabIndex = 0;
            this.incod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.incod.TextChanged += new System.EventHandler(this.incod_TextChanged);
            this.incod.Leave += new System.EventHandler(this.incod_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(127, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 21);
            this.label10.TabIndex = 3;
            this.label10.Text = "کد کارگر :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // monthCalendarX1
            // 
            this.monthCalendarX1.BoldedDayForeColor = System.Drawing.Color.Blue;
            this.monthCalendarX1.BorderColor = System.Drawing.Color.CadetBlue;
            this.monthCalendarX1.CalendarType = BehComponents.CalendarTypes.Persian;
            this.monthCalendarX1.DayRectTickness = 2F;
            this.monthCalendarX1.DaysBackColor = System.Drawing.Color.LightGray;
            this.monthCalendarX1.DaysFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarX1.DaysForeColor = System.Drawing.Color.DodgerBlue;
            this.monthCalendarX1.EnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.monthCalendarX1.EnglishBoldedDates = new System.DateTime[0];
            this.monthCalendarX1.EnglishHolidayDates = new System.DateTime[0];
            this.monthCalendarX1.EnglishMonthlyBoldedDates = new System.DateTime[0];
            this.monthCalendarX1.HolidayForeColor = System.Drawing.Color.Red;
            this.monthCalendarX1.HolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.monthCalendarX1.LineWeekColor = System.Drawing.Color.Black;
            this.monthCalendarX1.Location = new System.Drawing.Point(519, 215);
            this.monthCalendarX1.Name = "monthCalendarX1";
            this.monthCalendarX1.PersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.PersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.PersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.PersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.ShowToday = true;
            this.monthCalendarX1.ShowTodayRect = true;
            this.monthCalendarX1.ShowToolTips = false;
            this.monthCalendarX1.ShowTrailing = true;
            this.monthCalendarX1.Size = new System.Drawing.Size(202, 176);
            this.monthCalendarX1.Style_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.monthCalendarX1.Style_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.monthCalendarX1.Style_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.monthCalendarX1.Style_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.monthCalendarX1.Style_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.monthCalendarX1.Style_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.monthCalendarX1.TabIndex = 35;
            this.monthCalendarX1.TitleBackColor = System.Drawing.Color.Wheat;
            this.monthCalendarX1.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.monthCalendarX1.TitleForeColor = System.Drawing.Color.Black;
            this.monthCalendarX1.TodayBackColor = System.Drawing.Color.Wheat;
            this.monthCalendarX1.TodayFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendarX1.TodayForeColor = System.Drawing.Color.Black;
            this.monthCalendarX1.TodayRectColor = System.Drawing.Color.Coral;
            this.monthCalendarX1.TodayRectTickness = 2F;
            this.monthCalendarX1.TrailingForeColor = System.Drawing.Color.DarkGray;
            this.monthCalendarX1.WeekDaysBackColor = System.Drawing.Color.Wheat;
            this.monthCalendarX1.WeekDaysFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.monthCalendarX1.WeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.monthCalendarX1.WeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.codDataGridViewTextBoxColumn,
            this.tarikhDataGridViewTextBoxColumn,
            this.sainDataGridViewTextBoxColumn,
            this.saoutDataGridViewTextBoxColumn,
            this.sakolDataGridViewTextBoxColumn,
            this.poolDataGridViewTextBoxColumn,
            this.tsainDataGridViewTextBoxColumn,
            this.tsaoutDataGridViewTextBoxColumn,
            this.darhalekarDataGridViewCheckBoxColumn,
            this.tasviyeDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.mozdBindingSource;
            this.dataGridView3.Location = new System.Drawing.Point(3, 15);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(510, 376);
            this.dataGridView3.TabIndex = 36;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // codDataGridViewTextBoxColumn
            // 
            this.codDataGridViewTextBoxColumn.DataPropertyName = "cod";
            this.codDataGridViewTextBoxColumn.HeaderText = "کد";
            this.codDataGridViewTextBoxColumn.Name = "codDataGridViewTextBoxColumn";
            this.codDataGridViewTextBoxColumn.ReadOnly = true;
            this.codDataGridViewTextBoxColumn.Width = 40;
            // 
            // tarikhDataGridViewTextBoxColumn
            // 
            this.tarikhDataGridViewTextBoxColumn.DataPropertyName = "tarikh";
            this.tarikhDataGridViewTextBoxColumn.HeaderText = "تاریخ";
            this.tarikhDataGridViewTextBoxColumn.Name = "tarikhDataGridViewTextBoxColumn";
            this.tarikhDataGridViewTextBoxColumn.ReadOnly = true;
            this.tarikhDataGridViewTextBoxColumn.Width = 70;
            // 
            // sainDataGridViewTextBoxColumn
            // 
            this.sainDataGridViewTextBoxColumn.DataPropertyName = "sain";
            this.sainDataGridViewTextBoxColumn.HeaderText = "اغاز کار";
            this.sainDataGridViewTextBoxColumn.Name = "sainDataGridViewTextBoxColumn";
            this.sainDataGridViewTextBoxColumn.ReadOnly = true;
            this.sainDataGridViewTextBoxColumn.Width = 70;
            // 
            // saoutDataGridViewTextBoxColumn
            // 
            this.saoutDataGridViewTextBoxColumn.DataPropertyName = "saout";
            this.saoutDataGridViewTextBoxColumn.HeaderText = "پایان کار";
            this.saoutDataGridViewTextBoxColumn.Name = "saoutDataGridViewTextBoxColumn";
            this.saoutDataGridViewTextBoxColumn.ReadOnly = true;
            this.saoutDataGridViewTextBoxColumn.Width = 70;
            // 
            // sakolDataGridViewTextBoxColumn
            // 
            this.sakolDataGridViewTextBoxColumn.DataPropertyName = "sakol";
            this.sakolDataGridViewTextBoxColumn.HeaderText = "کار";
            this.sakolDataGridViewTextBoxColumn.Name = "sakolDataGridViewTextBoxColumn";
            this.sakolDataGridViewTextBoxColumn.ReadOnly = true;
            this.sakolDataGridViewTextBoxColumn.Width = 55;
            // 
            // poolDataGridViewTextBoxColumn
            // 
            this.poolDataGridViewTextBoxColumn.DataPropertyName = "pool";
            this.poolDataGridViewTextBoxColumn.HeaderText = "هزینه";
            this.poolDataGridViewTextBoxColumn.Name = "poolDataGridViewTextBoxColumn";
            this.poolDataGridViewTextBoxColumn.ReadOnly = true;
            this.poolDataGridViewTextBoxColumn.Width = 70;
            // 
            // tsainDataGridViewTextBoxColumn
            // 
            this.tsainDataGridViewTextBoxColumn.DataPropertyName = "tsain";
            this.tsainDataGridViewTextBoxColumn.HeaderText = "ورود";
            this.tsainDataGridViewTextBoxColumn.Name = "tsainDataGridViewTextBoxColumn";
            this.tsainDataGridViewTextBoxColumn.ReadOnly = true;
            this.tsainDataGridViewTextBoxColumn.Width = 55;
            // 
            // tsaoutDataGridViewTextBoxColumn
            // 
            this.tsaoutDataGridViewTextBoxColumn.DataPropertyName = "tsaout";
            this.tsaoutDataGridViewTextBoxColumn.HeaderText = "خروج";
            this.tsaoutDataGridViewTextBoxColumn.Name = "tsaoutDataGridViewTextBoxColumn";
            this.tsaoutDataGridViewTextBoxColumn.ReadOnly = true;
            this.tsaoutDataGridViewTextBoxColumn.Width = 55;
            // 
            // darhalekarDataGridViewCheckBoxColumn
            // 
            this.darhalekarDataGridViewCheckBoxColumn.DataPropertyName = "darhalekar";
            this.darhalekarDataGridViewCheckBoxColumn.HeaderText = "حاضر";
            this.darhalekarDataGridViewCheckBoxColumn.Name = "darhalekarDataGridViewCheckBoxColumn";
            this.darhalekarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.darhalekarDataGridViewCheckBoxColumn.Visible = false;
            this.darhalekarDataGridViewCheckBoxColumn.Width = 40;
            // 
            // tasviyeDataGridViewTextBoxColumn
            // 
            this.tasviyeDataGridViewTextBoxColumn.DataPropertyName = "tasviye";
            this.tasviyeDataGridViewTextBoxColumn.HeaderText = "تسویه";
            this.tasviyeDataGridViewTextBoxColumn.Name = "tasviyeDataGridViewTextBoxColumn";
            this.tasviyeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tasviyeDataGridViewTextBoxColumn.Visible = false;
            // 
            // mozdBindingSource
            // 
            this.mozdBindingSource.DataMember = "mozd";
            this.mozdBindingSource.DataSource = this.dbghDataSet;
            // 
            // dbghDataSet
            // 
            this.dbghDataSet.DataSetName = "dbghDataSet";
            this.dbghDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mozdTableAdapter
            // 
            this.mozdTableAdapter.ClearBeforeFill = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 22);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // kargar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(730, 419);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.monthCalendarX1);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kargar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "حضور و غیاب";
            this.Load += new System.EventHandler(this.kargar_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mozdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbghDataSet)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.MaskedTextBox indate;
        private System.Windows.Forms.MaskedTextBox intime;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox incod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
        private BehComponents.MonthCalendarX monthCalendarX1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private dbghDataSet dbghDataSet;
        private System.Windows.Forms.BindingSource mozdBindingSource;
        private dbghDataSetTableAdapters.mozdTableAdapter mozdTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarikhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sakolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn poolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsaoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn darhalekarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tasviyeDataGridViewTextBoxColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}