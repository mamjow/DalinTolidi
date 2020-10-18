namespace Tolidi
{
    partial class Book
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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.bed = new System.Windows.Forms.Button();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pardakhtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mandeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarikhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tozihDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedehkarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbghDataSet = new Tolidi.dbghDataSet();
            this.mandeh = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tarikhbed = new System.Windows.Forms.TextBox();
            this.sharhbed = new System.Windows.Forms.TextBox();
            this.pardakhtbed = new System.Windows.Forms.TextBox();
            this.kolbed = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label38 = new System.Windows.Forms.Label();
            this.combobed = new System.Windows.Forms.ComboBox();
            this.bedehkarTableAdapter = new Tolidi.dbghDataSetTableAdapters.bedehkarTableAdapter();
            this.bedehkarBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedehkarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbghDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedehkarBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label42);
            this.groupBox11.Controls.Add(this.bed);
            this.groupBox11.Controls.Add(this.dataGridView7);
            this.groupBox11.Controls.Add(this.mandeh);
            this.groupBox11.Controls.Add(this.label44);
            this.groupBox11.Controls.Add(this.label43);
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.tarikhbed);
            this.groupBox11.Controls.Add(this.sharhbed);
            this.groupBox11.Controls.Add(this.pardakhtbed);
            this.groupBox11.Controls.Add(this.kolbed);
            this.groupBox11.Controls.Add(this.label40);
            this.groupBox11.Controls.Add(this.label39);
            this.groupBox11.Controls.Add(this.radioButton5);
            this.groupBox11.Controls.Add(this.radioButton4);
            this.groupBox11.Controls.Add(this.label38);
            this.groupBox11.Controls.Add(this.combobed);
            this.groupBox11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox11.Location = new System.Drawing.Point(12, 12);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox11.Size = new System.Drawing.Size(385, 237);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "بدهکار / بستانکار";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(6, 208);
            this.label42.Name = "label42";
            this.label42.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label42.Size = new System.Drawing.Size(173, 18);
            this.label42.TabIndex = 13;
            this.label42.Text = "جمع";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label42, "تراز منفی به معنای بستانکار و تراز مثبت به معنای بدهکار");
            // 
            // bed
            // 
            this.bed.Location = new System.Drawing.Point(287, 208);
            this.bed.Name = "bed";
            this.bed.Size = new System.Drawing.Size(82, 23);
            this.bed.TabIndex = 8;
            this.bed.Text = "ثبت";
            this.bed.UseVisualStyleBackColor = true;
            this.bed.Click += new System.EventHandler(this.bed_Click);
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AllowUserToDeleteRows = false;
            this.dataGridView7.AutoGenerateColumns = false;
            this.dataGridView7.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.namDataGridViewTextBoxColumn,
            this.kolDataGridViewTextBoxColumn,
            this.pardakhtDataGridViewTextBoxColumn,
            this.mandeDataGridViewTextBoxColumn,
            this.tarikhDataGridViewTextBoxColumn,
            this.tozihDataGridViewTextBoxColumn});
            this.dataGridView7.DataSource = this.bedehkarBindingSource;
            this.dataGridView7.Location = new System.Drawing.Point(7, 19);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.ReadOnly = true;
            this.dataGridView7.RowHeadersVisible = false;
            this.dataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView7.Size = new System.Drawing.Size(189, 186);
            this.dataGridView7.TabIndex = 12;
            this.dataGridView7.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView7_CellClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // namDataGridViewTextBoxColumn
            // 
            this.namDataGridViewTextBoxColumn.DataPropertyName = "nam";
            this.namDataGridViewTextBoxColumn.HeaderText = "nam";
            this.namDataGridViewTextBoxColumn.Name = "namDataGridViewTextBoxColumn";
            this.namDataGridViewTextBoxColumn.ReadOnly = true;
            this.namDataGridViewTextBoxColumn.Visible = false;
            // 
            // kolDataGridViewTextBoxColumn
            // 
            this.kolDataGridViewTextBoxColumn.DataPropertyName = "kol";
            this.kolDataGridViewTextBoxColumn.HeaderText = "kol";
            this.kolDataGridViewTextBoxColumn.Name = "kolDataGridViewTextBoxColumn";
            this.kolDataGridViewTextBoxColumn.ReadOnly = true;
            this.kolDataGridViewTextBoxColumn.Visible = false;
            // 
            // pardakhtDataGridViewTextBoxColumn
            // 
            this.pardakhtDataGridViewTextBoxColumn.DataPropertyName = "pardakht";
            this.pardakhtDataGridViewTextBoxColumn.HeaderText = "pardakht";
            this.pardakhtDataGridViewTextBoxColumn.Name = "pardakhtDataGridViewTextBoxColumn";
            this.pardakhtDataGridViewTextBoxColumn.ReadOnly = true;
            this.pardakhtDataGridViewTextBoxColumn.Visible = false;
            // 
            // mandeDataGridViewTextBoxColumn
            // 
            this.mandeDataGridViewTextBoxColumn.DataPropertyName = "mande";
            this.mandeDataGridViewTextBoxColumn.HeaderText = "مانده";
            this.mandeDataGridViewTextBoxColumn.Name = "mandeDataGridViewTextBoxColumn";
            this.mandeDataGridViewTextBoxColumn.ReadOnly = true;
            this.mandeDataGridViewTextBoxColumn.Width = 60;
            // 
            // tarikhDataGridViewTextBoxColumn
            // 
            this.tarikhDataGridViewTextBoxColumn.DataPropertyName = "tarikh";
            this.tarikhDataGridViewTextBoxColumn.HeaderText = "تاریخ";
            this.tarikhDataGridViewTextBoxColumn.Name = "tarikhDataGridViewTextBoxColumn";
            this.tarikhDataGridViewTextBoxColumn.ReadOnly = true;
            this.tarikhDataGridViewTextBoxColumn.Width = 60;
            // 
            // tozihDataGridViewTextBoxColumn
            // 
            this.tozihDataGridViewTextBoxColumn.DataPropertyName = "tozih";
            this.tozihDataGridViewTextBoxColumn.HeaderText = "توضیح";
            this.tozihDataGridViewTextBoxColumn.Name = "tozihDataGridViewTextBoxColumn";
            this.tozihDataGridViewTextBoxColumn.ReadOnly = true;
            this.tozihDataGridViewTextBoxColumn.Width = 60;
            // 
            // bedehkarBindingSource
            // 
            this.bedehkarBindingSource.DataMember = "bedehkar";
            this.bedehkarBindingSource.DataSource = this.dbghDataSet;
            // 
            // dbghDataSet
            // 
            this.dbghDataSet.DataSetName = "dbghDataSet";
            this.dbghDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mandeh
            // 
            this.mandeh.Location = new System.Drawing.Point(202, 128);
            this.mandeh.Name = "mandeh";
            this.mandeh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mandeh.Size = new System.Drawing.Size(125, 20);
            this.mandeh.TabIndex = 6;
            this.mandeh.Text = "------------";
            this.mandeh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(340, 181);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(32, 13);
            this.label44.TabIndex = 5;
            this.label44.Text = "تاریخ:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(338, 154);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(34, 13);
            this.label43.TabIndex = 5;
            this.label43.Text = "شرح:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(337, 132);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(34, 13);
            this.label41.TabIndex = 5;
            this.label41.Text = "مانده:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tarikhbed
            // 
            this.tarikhbed.Location = new System.Drawing.Point(203, 178);
            this.tarikhbed.Name = "tarikhbed";
            this.tarikhbed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tarikhbed.Size = new System.Drawing.Size(125, 21);
            this.tarikhbed.TabIndex = 7;
            this.tarikhbed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sharhbed
            // 
            this.sharhbed.Location = new System.Drawing.Point(203, 151);
            this.sharhbed.Name = "sharhbed";
            this.sharhbed.Size = new System.Drawing.Size(125, 21);
            this.sharhbed.TabIndex = 6;
            // 
            // pardakhtbed
            // 
            this.pardakhtbed.Location = new System.Drawing.Point(202, 101);
            this.pardakhtbed.Name = "pardakhtbed";
            this.pardakhtbed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pardakhtbed.Size = new System.Drawing.Size(125, 21);
            this.pardakhtbed.TabIndex = 5;
            this.pardakhtbed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pardakhtbed.TextChanged += new System.EventHandler(this.pardakhtbed_TextChanged);
            // 
            // kolbed
            // 
            this.kolbed.Location = new System.Drawing.Point(202, 74);
            this.kolbed.Name = "kolbed";
            this.kolbed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kolbed.Size = new System.Drawing.Size(125, 21);
            this.kolbed.TabIndex = 4;
            this.kolbed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(331, 101);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 13);
            this.label40.TabIndex = 3;
            this.label40.Text = "پرداختی:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(332, 81);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(47, 13);
            this.label39.TabIndex = 3;
            this.label39.Text = "مبلغ کل:";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(202, 47);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(53, 17);
            this.radioButton5.TabIndex = 3;
            this.radioButton5.Text = "فروش";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(282, 47);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(46, 17);
            this.radioButton4.TabIndex = 2;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "خرید";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(340, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(27, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "نام :";
            // 
            // combobed
            // 
            this.combobed.FormattingEnabled = true;
            this.combobed.Location = new System.Drawing.Point(203, 19);
            this.combobed.Name = "combobed";
            this.combobed.Size = new System.Drawing.Size(126, 21);
            this.combobed.TabIndex = 1;
            this.combobed.TextChanged += new System.EventHandler(this.combobed_Leave);
            this.combobed.Leave += new System.EventHandler(this.combobed_Leave);
            // 
            // bedehkarTableAdapter
            // 
            this.bedehkarTableAdapter.ClearBeforeFill = true;
            // 
            // bedehkarBindingSource1
            // 
            this.bedehkarBindingSource1.DataMember = "bedehkar";
            this.bedehkarBindingSource1.DataSource = this.dbghDataSet;
            // 
            // Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 259);
            this.Controls.Add(this.groupBox11);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Book";
            this.Text = "دفترچه حساب";
            this.Load += new System.EventHandler(this.Book_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedehkarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbghDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedehkarBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button bed;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.Label mandeh;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox tarikhbed;
        private System.Windows.Forms.TextBox sharhbed;
        private System.Windows.Forms.TextBox pardakhtbed;
        private System.Windows.Forms.TextBox kolbed;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox combobed;
        private dbghDataSet dbghDataSet;
        private System.Windows.Forms.BindingSource bedehkarBindingSource;
        private dbghDataSetTableAdapters.bedehkarTableAdapter bedehkarTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pardakhtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mandeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarikhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tozihDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bedehkarBindingSource1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}