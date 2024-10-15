namespace NumRecognize.Forms
{
    partial class BasicIO : Form
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
            IsSaveMode = new CheckBox();
            TargetLabel = new Label();
            OutputLable = new Label();
            label1 = new Label();
            label2 = new Label();
            buttonPop = new Button();
            SuspendLayout();
            // 
            // IsSaveMode
            // 
            IsSaveMode.AutoSize = true;
            IsSaveMode.Location = new Point(37, 346);
            IsSaveMode.Name = "IsSaveMode";
            IsSaveMode.Size = new Size(121, 24);
            IsSaveMode.TabIndex = 0;
            IsSaveMode.Text = "保存为训练集";
            IsSaveMode.UseVisualStyleBackColor = true;
            // 
            // TargetLabel
            // 
            TargetLabel.AutoSize = true;
            TargetLabel.Font = new Font("Microsoft YaHei UI", 20F);
            TargetLabel.Location = new Point(524, 9);
            TargetLabel.Name = "TargetLabel";
            TargetLabel.Size = new Size(163, 45);
            TargetLabel.TabIndex = 1;
            TargetLabel.Text = "Wating...";
            // 
            // OutputLable
            // 
            OutputLable.AutoSize = true;
            OutputLable.Font = new Font("Microsoft YaHei UI", 20F);
            OutputLable.Location = new Point(524, 54);
            OutputLable.Name = "OutputLable";
            OutputLable.Size = new Size(163, 45);
            OutputLable.TabIndex = 2;
            OutputLable.Text = "Wating...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 20F);
            label1.Location = new Point(417, 9);
            label1.Name = "label1";
            label1.Size = new Size(88, 45);
            label1.TabIndex = 3;
            label1.Text = "目标";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 20F);
            label2.Location = new Point(417, 54);
            label2.Name = "label2";
            label2.Size = new Size(88, 45);
            label2.TabIndex = 4;
            label2.Text = "输出";
            // 
            // buttonPop
            // 
            buttonPop.Location = new Point(37, 292);
            buttonPop.Name = "buttonPop";
            buttonPop.Size = new Size(141, 36);
            buttonPop.TabIndex = 5;
            buttonPop.Text = "删除最后一个数据";
            buttonPop.UseVisualStyleBackColor = true;
            buttonPop.Click += ButPop;
            // 
            // BasicIO
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(buttonPop);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OutputLable);
            Controls.Add(TargetLabel);
            Controls.Add(IsSaveMode);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(800, 400);
            MinimumSize = new Size(800, 400);
            Name = "BasicIO";
            Text = "BasicIO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox IsSaveMode;
        private Label TargetLabel;
        private Label OutputLable;
        private Label label1;
        private Label label2;
        private Button buttonPop;
    }
}