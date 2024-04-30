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
            // 初始化下拉框等控件
            comboBoxResolution.Items.Add("1920x1080");
            comboBoxResolution.Items.Add("2560x1080");
            comboBoxResolution.Items.Add("3440x1440");
            comboBoxResolution.Items.Add("3840x1600");
            comboBoxResolution.Items.Add("1280x720");
            // 添加其他所需的分辨率选项
            comboBoxResolution.SelectedIndex = 0;
            comboBoxResolution.DropDownStyle = ComboBoxStyle.DropDownList;

            // 初始化颜色深度下拉框
            comboBoxColorDepth.Items.Add("16");
            comboBoxColorDepth.Items.Add("24");
            comboBoxColorDepth.Items.Add("32");
            // ...添加其他颜色深度选项
            comboBoxColorDepth.SelectedIndex = 0;
            comboBoxColorDepth.DropDownStyle = ComboBoxStyle.DropDownList;

            checkBoxFullScreen.Checked = false;
            checkBoxMultiMonitor.Checked = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadSettings();
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default["Resolution"] = comboBoxResolution.SelectedItem.ToString();
                Properties.Settings.Default["ColorDepth"] = comboBoxColorDepth.SelectedItem.ToString();
                Properties.Settings.Default["FullScreen"] = checkBoxFullScreen.Checked;
                Properties.Settings.Default["MultiMonitor"] = checkBoxMultiMonitor.Checked;
                Properties.Settings.Default["PartialScreen"] = multimonPartial.Checked;
                Properties.Settings.Default["SelectedMonitors"] = selectedMonitorIds.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // 记录异常信息到app-error.log
                string logFilePath = "app-error.log";
                File.AppendAllText(logFilePath, $"Failed to save settings: {ex.Message}\n");
            }
        }

        private void LoadSettings()
        {
            try
            {
                comboBoxResolution.SelectedItem = Properties.Settings.Default["Resolution"];
                comboBoxColorDepth.SelectedItem = Properties.Settings.Default["ColorDepth"];
                checkBoxFullScreen.Checked = (bool)Properties.Settings.Default["FullScreen"];
                checkBoxMultiMonitor.Checked = (bool)Properties.Settings.Default["MultiMonitor"];
                multimonPartial.Checked = (bool)Properties.Settings.Default["PartialScreen"];
                selectedMonitorIds.Text = Properties.Settings.Default["SelectedMonitors"].ToString();
            }
            catch (Exception ex)
            {
                // 记录异常信息到app-error.log
                string logFilePath = "app-error.log";
                File.AppendAllText(logFilePath, $"Failed to load settings: {ex.Message}\n");
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            try
            {
                string resolution = comboBoxResolution.SelectedItem.ToString();
                string colorDepth = comboBoxColorDepth.SelectedItem.ToString();
                bool fullScreen = checkBoxFullScreen.Checked;
                bool partialScreen = multimonPartial.Checked;
                string selectedMonitors = selectedMonitorIds.ToString();

                bool multiMonitor = checkBoxMultiMonitor.Checked;

                // 获取下载文件夹路径
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

                // 找到最新的 .rdp 文件
                var rdpFiles = new DirectoryInfo(downloadsPath).GetFiles("*.rdp").OrderByDescending(f => f.LastWriteTime).ToList();
                var latestRdpFile = rdpFiles.FirstOrDefault();

                if (latestRdpFile != null)
                {
                    string filePath = latestRdpFile.FullName;
                    string[] resSplit = resolution.Split('x');
                    string desktopWidth = resSplit[0];
                    string desktopHeight = resSplit[1];

                    // 读取文件内容
                    StringBuilder newContent = new StringBuilder();
                    string[] content = File.ReadAllLines(filePath);

                    // 修改内容
                    foreach (string line in content)
                    {
                        if (line.StartsWith("use multimon:i:"))
                        {
                            if (partialScreen)
                            {
                                newContent.AppendLine($"use multimon:i:-1");
                                newContent.AppendLine($"selectedmonitors:s:" + selectedMonitors);
                            }
                            else
                            {
                                newContent.AppendLine($"screen mode id:i:2");
                                newContent.AppendLine($"use multimon:i:" + (multiMonitor ? "1" : "0"));
                            }
                        }
                        else
                        {
                            newContent.AppendLine(line);
                        }
                    }

                    if (!fullScreen)
                    {
                        newContent.AppendLine($"desktopwidth:i:{desktopWidth}");
                        newContent.AppendLine($"desktopheight:i:{desktopHeight}");
                        newContent.AppendLine("disable full window drag:i:1");
                        newContent.AppendLine($"screen mode id:i:1");
                    }

                    newContent.AppendLine($"session bpp:i:{colorDepth}");
                    newContent.AppendLine("audiocapturemode:i:1");
                    newContent.AppendLine("redirectvideo:i:1");

                    // 将修改后的内容写回文件
                    File.WriteAllText(filePath, newContent.ToString());

                    // 删除除最新文件之外的所有 .rdp 文件
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
                                // 记录异常信息到app-error.log
                                string logFilePath = "app-error.log";
                                File.AppendAllText(logFilePath, $"Failed to delete file {file.Name}: {ex.Message}\n");
                            }
                        }
                    }

                    SaveSettings();

                    // 直接启动远程桌面会话
                    try
                    {
                        Process.Start("mstsc.exe", $"\"{filePath}\"");
                    }
                    catch (Exception ex)
                    {
                        // 记录异常信息到app-error.log
                        string logFilePath = "app-error.log";
                        File.AppendAllText(logFilePath, $"Failed to start remote desktop session: {ex.Message}\n");
                    }
                }
                else
                {
                    MessageBox.Show("No RDP file found in Downloads.");
                }
            }
            catch (Exception ex)
            {
                // 记录异常信息到app-error.log
                string logFilePath = "app-error.log";
                File.AppendAllText(logFilePath, $"An error occurred: {ex.Message}\n");
            }
        }
    }
}
