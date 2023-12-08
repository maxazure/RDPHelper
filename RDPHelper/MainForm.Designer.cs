namespace RDPHelper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            comboBoxResolution = new ComboBox();
            comboBoxColorDepth = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            checkBoxFullScreen = new CheckBox();
            checkBoxMultiMonitor = new CheckBox();
            buttonModify = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // comboBoxResolution
            // 
            comboBoxResolution.FormattingEnabled = true;
            comboBoxResolution.Location = new Point(120, 52);
            comboBoxResolution.Name = "comboBoxResolution";
            comboBoxResolution.Size = new Size(176, 25);
            comboBoxResolution.TabIndex = 0;
            // 
            // comboBoxColorDepth
            // 
            comboBoxColorDepth.FormattingEnabled = true;
            comboBoxColorDepth.Location = new Point(120, 96);
            comboBoxColorDepth.Name = "comboBoxColorDepth";
            comboBoxColorDepth.Size = new Size(176, 25);
            comboBoxColorDepth.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 56);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 2;
            label1.Text = "分辨率";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 100);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 3;
            label2.Text = "颜色深度";
            // 
            // checkBoxFullScreen
            // 
            checkBoxFullScreen.AutoSize = true;
            checkBoxFullScreen.Location = new Point(120, 143);
            checkBoxFullScreen.Name = "checkBoxFullScreen";
            checkBoxFullScreen.Size = new Size(51, 21);
            checkBoxFullScreen.TabIndex = 4;
            checkBoxFullScreen.Text = "全屏";
            checkBoxFullScreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxMultiMonitor
            // 
            checkBoxMultiMonitor.AutoSize = true;
            checkBoxMultiMonitor.Checked = true;
            checkBoxMultiMonitor.CheckState = CheckState.Checked;
            checkBoxMultiMonitor.Location = new Point(121, 181);
            checkBoxMultiMonitor.Name = "checkBoxMultiMonitor";
            checkBoxMultiMonitor.Size = new Size(111, 21);
            checkBoxMultiMonitor.TabIndex = 5;
            checkBoxMultiMonitor.Text = "使用多个显示器";
            checkBoxMultiMonitor.UseVisualStyleBackColor = true;
            // 
            // buttonModify
            // 
            buttonModify.Location = new Point(120, 275);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(176, 43);
            buttonModify.TabIndex = 6;
            buttonModify.Text = "连接";
            buttonModify.UseVisualStyleBackColor = true;
            buttonModify.Click += buttonModify_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 216);
            label3.Name = "label3";
            label3.Size = new Size(128, 17);
            label3.TabIndex = 7;
            label3.Text = "自动重定向本地麦克风";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 350);
            Controls.Add(label3);
            Controls.Add(buttonModify);
            Controls.Add(checkBoxMultiMonitor);
            Controls.Add(checkBoxFullScreen);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxColorDepth);
            Controls.Add(comboBoxResolution);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "远程连接设置器";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxResolution;
        private ComboBox comboBoxColorDepth;
        private Label label1;
        private Label label2;
        private CheckBox checkBoxFullScreen;
        private CheckBox checkBoxMultiMonitor;
        private Button buttonModify;
        private Label label3;
    }
}
