namespace NumRecognize
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.ImageScalingSize = new Size(100, 45);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MaximumSize = new Size(200, 0);
            menuStrip1.MinimumSize = new Size(100, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(100, 403);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.AutoSize = false;
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem1.CheckState = CheckState.Checked;
            toolStripMenuItem1.Font = new Font("Microsoft YaHei UI", 12F);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(90, 60);
            toolStripMenuItem1.Text = "基本输入";
            toolStripMenuItem1.Click += OpenBIO;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.AutoSize = false;
            toolStripMenuItem2.Font = new Font("Microsoft YaHei UI", 12F);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(90, 60);
            toolStripMenuItem2.Text = "数据管理";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.AutoSize = false;
            toolStripMenuItem3.Font = new Font("Microsoft YaHei UI", 12F);
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(90, 60);
            toolStripMenuItem3.Text = "训练面板";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Alignment = ToolStripItemAlignment.Right;
            toolStripMenuItem4.AutoSize = false;
            toolStripMenuItem4.Font = new Font("Microsoft YaHei UI", 12F);
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(90, 60);
            toolStripMenuItem4.Text = "退出";
            toolStripMenuItem4.Click += QuitApp;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 403);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
    }
}