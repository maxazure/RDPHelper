using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace RDPHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // ��ʼ��������ȿؼ�
            comboBoxResolution.Items.Add("1920x1080");
            comboBoxResolution.Items.Add("2560x1080");
            comboBoxResolution.Items.Add("3440x1440");
            comboBoxResolution.Items.Add("3840x1600");
            comboBoxResolution.Items.Add("1280x720");
            // �����������ķֱ���ѡ��
            comboBoxResolution.SelectedIndex = 0;
            comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;

            // ��ʼ����ɫ���������
            comboBoxColorDepth.Items.Add("16");
            comboBoxColorDepth.Items.Add("24");
            comboBoxColorDepth.Items.Add("32");
            // ...���������ɫ���ѡ��
            comboBoxColorDepth.SelectedIndex = 0;
            comboBoxColorDepth.DropDownStyle = ComboBoxStyle.DropDownList;

            checkBoxFullScreen.Checked = false;
            checkBoxMultiMonitor.Checked = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default["Resolution"] = comboBoxResolution.SelectedItem.ToString();
            Properties.Settings.Default["ColorDepth"] = comboBoxColorDepth.SelectedItem.ToString();
            Properties.Settings.Default["FullScreen"] = checkBoxFullScreen.Checked;
            Properties.Settings.Default["MultiMonitor"] = checkBoxMultiMonitor.Checked;
            Properties.Settings.Default.Save();
        }

        private void LoadSettings()
        {
            comboBoxResolution.SelectedItem = Properties.Settings.Default["Resolution"];
            comboBoxColorDepth.SelectedItem = Properties.Settings.Default["ColorDepth"];
            checkBoxFullScreen.Checked = (bool)Properties.Settings.Default["FullScreen"];
            checkBoxMultiMonitor.Checked = (bool)Properties.Settings.Default["MultiMonitor"];
        }


        private void buttonModify_Click(object sender, EventArgs e)
        {
            string resolution = comboBoxResolution.SelectedItem.ToString();
            string colorDepth = comboBoxColorDepth.SelectedItem.ToString();
            bool fullScreen = checkBoxFullScreen.Checked;
            bool multiMonitor = checkBoxMultiMonitor.Checked;

            // ��ȡ�����ļ���·��
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            // �ҵ����µ� .rdp �ļ�
            var rdpFiles = new DirectoryInfo(downloadsPath).GetFiles("*.rdp").OrderByDescending(f => f.LastWriteTime).ToList();
            var latestRdpFile = rdpFiles.FirstOrDefault();

            if (latestRdpFile != null)
            {
                string filePath = latestRdpFile.FullName;
                string[] resSplit = resolution.Split('x');
                string desktopWidth = resSplit[0];
                string desktopHeight = resSplit[1];

                // ��ȡ�ļ�����
                StringBuilder newContent = new StringBuilder();
                string[] content = File.ReadAllLines(filePath);

                // �޸�����
                foreach (string line in content)
                {
         
                    if (line.StartsWith("use multimon:i:"))
                        newContent.AppendLine($"use multimon:i:" + (multiMonitor ? "1" : "0"));
                    else
                        newContent.AppendLine(line);
                }

                if (!fullScreen)
                {
                    newContent.AppendLine($"desktopwidth:i:{desktopWidth}");
                    newContent.AppendLine($"desktopheight:i:{desktopHeight}");
                    newContent.AppendLine("disable full window drag:i:1");

                }
               
                newContent.AppendLine($"screen mode id:i:" + (fullScreen ? "2" : "1"));
                newContent.AppendLine($"session bpp:i:{colorDepth}");
                newContent.AppendLine("audiocapturemode:i:1");
                newContent.AppendLine("redirectvideo:i:1");


                // ���޸ĺ������д���ļ�
                File.WriteAllText(filePath, newContent.ToString());


                // ɾ���������ļ�֮������� .rdp �ļ�
                foreach (var file in rdpFiles)
                {
                    if (file.FullName != filePath)
                    {
                        try
                        {
                            File.Delete(file.FullName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to delete file {file.Name}: {ex.Message}");
                        }
                    }
                }

                SaveSettings();

                // ֱ������Զ������Ự
                try
                {
                    Process.Start("mstsc.exe", $"\"{filePath}\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to start remote desktop session: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No RDP file found in Downloads.");
            }
        }
    }
}
