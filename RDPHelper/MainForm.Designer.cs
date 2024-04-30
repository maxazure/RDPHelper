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
            multimonPartial = new CheckBox();
            selectedMonitorIds = new TextBox();
            SuspendLayout();
            // 
            // comboBoxResolution
            // 
            comboBoxResolution.FormattingEnabled = true;
            comboBoxResolution.Location = new Point(189, 73);
            comboBoxResolution.Margin = new Padding(5, 4, 5, 4);
            comboBoxResolution.Name = "comboBoxResolution";
            comboBoxResolution.Size = new Size(274, 32);
            comboBoxResolution.TabIndex = 0;
            // 
            // comboBoxColorDepth
            // 
            comboBoxColorDepth.FormattingEnabled = true;
            comboBoxColorDepth.Location = new Point(189, 136);
            comboBoxColorDepth.Margin = new Padding(5, 4, 5, 4);
            comboBoxColorDepth.Name = "comboBoxColorDepth";
            comboBoxColorDepth.Size = new Size(274, 32);
            comboBoxColorDepth.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 79);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 2;
            label1.Text = "分辨率";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 141);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 3;
            label2.Text = "颜色深度";
            // 
            // checkBoxFullScreen
            // 
            checkBoxFullScreen.AutoSize = true;
            checkBoxFullScreen.Location = new Point(189, 202);
            checkBoxFullScreen.Margin = new Padding(5, 4, 5, 4);
            checkBoxFullScreen.Name = "checkBoxFullScreen";
            checkBoxFullScreen.Size = new Size(72, 28);
            checkBoxFullScreen.TabIndex = 4;
            checkBoxFullScreen.Text = "全屏";
            checkBoxFullScreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxMultiMonitor
            // 
            checkBoxMultiMonitor.AutoSize = true;
            checkBoxMultiMonitor.Checked = true;
            checkBoxMultiMonitor.CheckState = CheckState.Checked;
            checkBoxMultiMonitor.Location = new Point(190, 256);
            checkBoxMultiMonitor.Margin = new Padding(5, 4, 5, 4);
            checkBoxMultiMonitor.Name = "checkBoxMultiMonitor";
            checkBoxMultiMonitor.Size = new Size(162, 28);
            checkBoxMultiMonitor.TabIndex = 5;
            checkBoxMultiMonitor.Text = "使用全部显示器";
            checkBoxMultiMonitor.UseVisualStyleBackColor = true;
            // 
            // buttonModify
            // 
            buttonModify.Location = new Point(189, 388);
            buttonModify.Margin = new Padding(5, 4, 5, 4);
            buttonModify.Name = "buttonModify";
            buttonModify.Size = new Size(277, 61);
            buttonModify.TabIndex = 6;
            buttonModify.Text = "连接";
            buttonModify.UseVisualStyleBackColor = true;
            buttonModify.Click += buttonModify_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 347);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(190, 24);
            label3.TabIndex = 7;
            label3.Text = "自动重定向本地麦克风";
            // 
            // multimonPartial
            // 
            multimonPartial.AutoSize = true;
            multimonPartial.Checked = true;
            multimonPartial.CheckState = CheckState.Checked;
            multimonPartial.Location = new Point(190, 303);
            multimonPartial.Margin = new Padding(5, 4, 5, 4);
            multimonPartial.Name = "multimonPartial";
            multimonPartial.Size = new Size(162, 28);
            multimonPartial.TabIndex = 8;
            multimonPartial.Text = "使用部分显示器";
            multimonPartial.UseVisualStyleBackColor = true;
            // 
            // selectedMonitorIds
            // 
            selectedMonitorIds.Location = new Point(360, 303);
            selectedMonitorIds.Name = "selectedMonitorIds";
            selectedMonitorIds.Size = new Size(106, 30);
            selectedMonitorIds.TabIndex = 9;
            selectedMonitorIds.Text = "0,2";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 494);
            Controls.Add(selectedMonitorIds);
            Controls.Add(multimonPartial);
            Controls.Add(label3);
            Controls.Add(buttonModify);
            Controls.Add(checkBoxMultiMonitor);
            Controls.Add(checkBoxFullScreen);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxColorDepth);
            Controls.Add(comboBoxResolution);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
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
        private CheckBox multimonPartial;
        private TextBox selectedMonitorIds;
    }
}
