namespace Tolidi
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.منوToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خریدToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.حسابداریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.دفترچهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemtanzim = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.منوToolStripMenuItem,
            this.اToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // منوToolStripMenuItem
            // 
            this.منوToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.خریدToolStripMenuItem,
            this.item1,
            this.حسابداریToolStripMenuItem,
            this.دفترچهToolStripMenuItem,
            this.itemtanzim,
            this.خروجToolStripMenuItem});
            this.منوToolStripMenuItem.Name = "منوToolStripMenuItem";
            this.منوToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.منوToolStripMenuItem.Text = "منو";
            // 
            // خریدToolStripMenuItem
            // 
            this.خریدToolStripMenuItem.Name = "خریدToolStripMenuItem";
            this.خریدToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.خریدToolStripMenuItem.Text = "خرید / فروش";
            this.خریدToolStripMenuItem.Click += new System.EventHandler(this.خریدToolStripMenuItem_Click);
            // 
            // item1
            // 
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(141, 22);
            this.item1.Text = "حضور و غیاب";
            this.item1.Click += new System.EventHandler(this.item1_Click);
            // 
            // حسابداریToolStripMenuItem
            // 
            this.حسابداریToolStripMenuItem.Name = "حسابداریToolStripMenuItem";
            this.حسابداریToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.حسابداریToolStripMenuItem.Text = "کار و دستمزد";
            this.حسابداریToolStripMenuItem.Click += new System.EventHandler(this.حسابداریToolStripMenuItem_Click);
            // 
            // دفترچهToolStripMenuItem
            // 
            this.دفترچهToolStripMenuItem.Name = "دفترچهToolStripMenuItem";
            this.دفترچهToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.دفترچهToolStripMenuItem.Text = "دفترچه";
            this.دفترچهToolStripMenuItem.Click += new System.EventHandler(this.دفترچهToolStripMenuItem_Click);
            // 
            // itemtanzim
            // 
            this.itemtanzim.Image = ((System.Drawing.Image)(resources.GetObject("itemtanzim.Image")));
            this.itemtanzim.Name = "itemtanzim";
            this.itemtanzim.Size = new System.Drawing.Size(141, 22);
            this.itemtanzim.Text = "تنظیمات";
            this.itemtanzim.Click += new System.EventHandler(this.itemtanzim_Click);
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("خروجToolStripMenuItem.Image")));
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.خروجToolStripMenuItem.Text = "خروج";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // اToolStripMenuItem
            // 
            this.اToolStripMenuItem.Name = "اToolStripMenuItem";
            this.اToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.اToolStripMenuItem.Text = "درباره برنامه";
            this.اToolStripMenuItem.Click += new System.EventHandler(this.اToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 381);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "صفحه اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem منوToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item1;
        private System.Windows.Forms.ToolStripMenuItem حسابداریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خریدToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem دفترچهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemtanzim;
        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اToolStripMenuItem;
    }
}

