namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveContourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageWithContourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.costGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.normalizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianFilterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(12, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(393, 299);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(509, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Start";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            this.toolStripButton1.EnabledChanged += new System.EventHandler(this.toolStripButton1_EnabledChanged);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Stop";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Zoom in";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Zoom out";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Undo";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.modeToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveContourToolStripMenuItem,
            this.saveMaskToolStripMenuItem,
            this.saveROIToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 21);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveContourToolStripMenuItem
            // 
            this.saveContourToolStripMenuItem.Name = "saveContourToolStripMenuItem";
            this.saveContourToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveContourToolStripMenuItem.Text = "Save Contour";
            this.saveContourToolStripMenuItem.Click += new System.EventHandler(this.saveContourToolStripMenuItem_Click);
            // 
            // saveMaskToolStripMenuItem
            // 
            this.saveMaskToolStripMenuItem.Name = "saveMaskToolStripMenuItem";
            this.saveMaskToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveMaskToolStripMenuItem.Text = "Save Mask";
            this.saveMaskToolStripMenuItem.Click += new System.EventHandler(this.saveMaskToolStripMenuItem_Click);
            // 
            // saveROIToolStripMenuItem
            // 
            this.saveROIToolStripMenuItem.Name = "saveROIToolStripMenuItem";
            this.saveROIToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveROIToolStripMenuItem.Text = "Save ROI";
            this.saveROIToolStripMenuItem.Click += new System.EventHandler(this.saveROIToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workModeToolStripMenuItem,
            this.debugModeToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // workModeToolStripMenuItem
            // 
            this.workModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageOnlyToolStripMenuItem,
            this.imageWithContourToolStripMenuItem,
            this.imageMaskToolStripMenuItem,
            this.imageROIToolStripMenuItem});
            this.workModeToolStripMenuItem.Name = "workModeToolStripMenuItem";
            this.workModeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.workModeToolStripMenuItem.Text = "Work Mode";
            // 
            // imageOnlyToolStripMenuItem
            // 
            this.imageOnlyToolStripMenuItem.Name = "imageOnlyToolStripMenuItem";
            this.imageOnlyToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.imageOnlyToolStripMenuItem.Text = "Image Only";
            this.imageOnlyToolStripMenuItem.Click += new System.EventHandler(this.imageOnlyToolStripMenuItem_Click);
            // 
            // imageWithContourToolStripMenuItem
            // 
            this.imageWithContourToolStripMenuItem.Name = "imageWithContourToolStripMenuItem";
            this.imageWithContourToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.imageWithContourToolStripMenuItem.Text = "Image With Contour";
            this.imageWithContourToolStripMenuItem.Click += new System.EventHandler(this.imageWithContourToolStripMenuItem_Click);
            // 
            // imageMaskToolStripMenuItem
            // 
            this.imageMaskToolStripMenuItem.Name = "imageMaskToolStripMenuItem";
            this.imageMaskToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.imageMaskToolStripMenuItem.Text = "Image Mask";
            this.imageMaskToolStripMenuItem.Click += new System.EventHandler(this.imageMaskToolStripMenuItem_Click);
            // 
            // imageROIToolStripMenuItem
            // 
            this.imageROIToolStripMenuItem.Name = "imageROIToolStripMenuItem";
            this.imageROIToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.imageROIToolStripMenuItem.Text = "Image ROI";
            this.imageROIToolStripMenuItem.Click += new System.EventHandler(this.imageROIToolStripMenuItem_Click);
            // 
            // debugModeToolStripMenuItem
            // 
            this.debugModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pixelNodeToolStripMenuItem,
            this.costGraphToolStripMenuItem,
            this.pathTreeToolStripMenuItem,
            this.minPathToolStripMenuItem});
            this.debugModeToolStripMenuItem.Name = "debugModeToolStripMenuItem";
            this.debugModeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.debugModeToolStripMenuItem.Text = "Debug Mode";
            // 
            // pixelNodeToolStripMenuItem
            // 
            this.pixelNodeToolStripMenuItem.Name = "pixelNodeToolStripMenuItem";
            this.pixelNodeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pixelNodeToolStripMenuItem.Text = "Pixel Node";
            this.pixelNodeToolStripMenuItem.Click += new System.EventHandler(this.pixelNodeToolStripMenuItem_Click);
            // 
            // costGraphToolStripMenuItem
            // 
            this.costGraphToolStripMenuItem.Name = "costGraphToolStripMenuItem";
            this.costGraphToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.costGraphToolStripMenuItem.Text = "Cost Graph";
            this.costGraphToolStripMenuItem.Click += new System.EventHandler(this.costGraphToolStripMenuItem_Click);
            // 
            // pathTreeToolStripMenuItem
            // 
            this.pathTreeToolStripMenuItem.Name = "pathTreeToolStripMenuItem";
            this.pathTreeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pathTreeToolStripMenuItem.Text = "Path Tree";
            this.pathTreeToolStripMenuItem.Click += new System.EventHandler(this.pathTreeToolStripMenuItem_Click);
            // 
            // minPathToolStripMenuItem
            // 
            this.minPathToolStripMenuItem.Name = "minPathToolStripMenuItem";
            this.minPathToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.minPathToolStripMenuItem.Text = "Min Path";
            this.minPathToolStripMenuItem.Click += new System.EventHandler(this.minPathToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem1});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // blurToolStripMenuItem1
            // 
            this.blurToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalizedToolStripMenuItem,
            this.gaussianFilterToolStripMenuItem1});
            this.blurToolStripMenuItem1.Name = "blurToolStripMenuItem1";
            this.blurToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.blurToolStripMenuItem1.Text = "Blur";
            // 
            // normalizedToolStripMenuItem
            // 
            this.normalizedToolStripMenuItem.Name = "normalizedToolStripMenuItem";
            this.normalizedToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.normalizedToolStripMenuItem.Text = "Normalized Box Filter";
            this.normalizedToolStripMenuItem.Click += new System.EventHandler(this.normalizedToolStripMenuItem_Click);
            // 
            // gaussianFilterToolStripMenuItem1
            // 
            this.gaussianFilterToolStripMenuItem1.Name = "gaussianFilterToolStripMenuItem1";
            this.gaussianFilterToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.gaussianFilterToolStripMenuItem1.Text = "Gaussian Filter";
            this.gaussianFilterToolStripMenuItem1.Click += new System.EventHandler(this.gaussianFilterToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(509, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(507, 50);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(2, 354);
            this.statusStrip2.TabIndex = 11;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1, 0);
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 359);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(507, 45);
            this.trackBar1.TabIndex = 12;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 426);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Intelligent Scissor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveContourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageWithContourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem costGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageROIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveROIToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem normalizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianFilterToolStripMenuItem1;

    }
}

