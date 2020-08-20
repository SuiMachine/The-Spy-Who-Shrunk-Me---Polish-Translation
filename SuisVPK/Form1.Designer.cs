namespace SuisVPK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TB_TranslationDir = new System.Windows.Forms.TextBox();
            this.b_devpath_set = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Watch = new System.Windows.Forms.Button();
            this.minizedIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolbarContexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbarContexMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_TranslationDir
            // 
            this.TB_TranslationDir.Location = new System.Drawing.Point(89, 12);
            this.TB_TranslationDir.Name = "TB_TranslationDir";
            this.TB_TranslationDir.Size = new System.Drawing.Size(301, 20);
            this.TB_TranslationDir.TabIndex = 0;
            // 
            // b_devpath_set
            // 
            this.b_devpath_set.Location = new System.Drawing.Point(396, 10);
            this.b_devpath_set.Name = "b_devpath_set";
            this.b_devpath_set.Size = new System.Drawing.Size(75, 23);
            this.b_devpath_set.TabIndex = 1;
            this.b_devpath_set.Text = "Set";
            this.b_devpath_set.UseVisualStyleBackColor = true;
            this.b_devpath_set.Click += new System.EventHandler(this.B_devpath_set_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Translation dir:";
            // 
            // B_Watch
            // 
            this.B_Watch.Location = new System.Drawing.Point(360, 38);
            this.B_Watch.Name = "B_Watch";
            this.B_Watch.Size = new System.Drawing.Size(111, 23);
            this.B_Watch.TabIndex = 6;
            this.B_Watch.Text = "Watch for changes";
            this.B_Watch.UseVisualStyleBackColor = true;
            this.B_Watch.Click += new System.EventHandler(this.B_Watch_Click);
            // 
            // minizedIcon
            // 
            this.minizedIcon.ContextMenuStrip = this.toolbarContexMenu;
            this.minizedIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("minizedIcon.Icon")));
            this.minizedIcon.Text = "SuicideMachine\'s VPK Helper";
            this.minizedIcon.Visible = true;
            this.minizedIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.minizedIcon_MouseDoubleClick);
            // 
            // toolbarContexMenu
            // 
            this.toolbarContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolbarContexMenu.Name = "toolbarContexMenu";
            this.toolbarContexMenu.Size = new System.Drawing.Size(111, 48);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 67);
            this.Controls.Add(this.B_Watch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_devpath_set);
            this.Controls.Add(this.TB_TranslationDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SuicideMachine\'s Translation Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolbarContexMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_TranslationDir;
        private System.Windows.Forms.Button b_devpath_set;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Watch;
        private System.Windows.Forms.NotifyIcon minizedIcon;
        private System.Windows.Forms.ContextMenuStrip toolbarContexMenu;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}

