/***************************************************************************
Copyright 2009, Thoraxcentrum, Erasmus MC, Rotterdam, The Netherlands

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

Written by Maarten JB van Ettinger.

****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

using AlarmLib.HL7;
using AlarmLib.PCD_ACM;

namespace AlarmManagerUI
{
    public partial class MainScreen : Form
    {
        public MainScreen(bool bInstall)
        {
            InitializeComponent();

            matchList.List = new AlarmMatchList();
            disseminatorList.List = new AlarmDisseminatorList();
            hl7List.List = new MLLPServerFarmList();

            ServiceControllerStatus scs;

            try
            {
                scs = serviceAlarmManager.Status;
            }
            catch (Exception)
            {
                const string alarmManagerExe = ".\\AlarmManager.exe";

                if (File.Exists(alarmManagerExe))
                {
                    System.Diagnostics.Process process = null;

                    try
                    {
                        process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), alarmManagerExe);
                        process.StartInfo.Arguments = "--install";
                        process.StartInfo.CreateNoWindow = false;
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                        process.Start();
                        process.WaitForExit(5000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString(), "Install failed!", MessageBoxButtons.OK);
                    }
                    finally
                    {
                        if (process != null)
                        {
                            process.Close();
                            process.Dispose();
                        }

                        Show();
                        Focus();
                    }
                }
            }

            UpdateStatus(this, null);

            if (bInstall)
            {
                WindowState = FormWindowState.Normal;

                this.MainScreen_Resize(this, null);
            }
        }

        void UpdateStatus(object sender, EventArgs e)
        {
            string status = "AlarmManager: ";
            ServiceControllerStatus scs = ServiceControllerStatus.StopPending;

            try
            {
                serviceAlarmManager.Refresh();

                scs = serviceAlarmManager.Status;

                switch (serviceAlarmManager.Status)
                {
                    case ServiceControllerStatus.Running:
                        status += "Running";
                        break;
                    case ServiceControllerStatus.Paused:
                        status += "Paused";
                        break;
                    case ServiceControllerStatus.Stopped:
                        status += "Stopped";
                        break;
                }
            }
            catch (Exception)
            {
                status += "Not installed!";
            }

            if ((status != null)
            &&  (status.Length > 14))
            {
                UpdateStatus(status, scs);
                this.Text = status;
                this.notifyIcon.Text = status;
            }
        }

        private delegate void UpdateStatusDelegate(string status, ServiceControllerStatus scs);
        private UpdateStatusDelegate m_UpdateStatus;

        private void UpdateStatus(string status, ServiceControllerStatus scs)
        {
            if (InvokeRequired)
            {
                if (m_UpdateStatus == null)
                    m_UpdateStatus = new UpdateStatusDelegate(this.UpdateStatus);

                Invoke(m_UpdateStatus, new object[] { status, scs });
                return;
            }

            switch (scs)
            {
                case ServiceControllerStatus.Paused:
                case ServiceControllerStatus.Running:
                    startToolStripMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = true;
                    break;
                case ServiceControllerStatus.Stopped:
                    startToolStripMenuItem.Enabled = true;
                    stopToolStripMenuItem.Enabled = false;
                    break;
                default:
                    startToolStripMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = false;
                    break;
            }

            this.Text = status;
            this.notifyIcon.Text = status;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            configureToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool
                bReset = false,
                alarmCacheConfigChanged = alarmCacheConfig.Changed;

            try
            {
                if ((disseminatorList.Changed
                ||  alarmCacheConfigChanged
                ||   hl7List.Changed)
                &&  (serviceAlarmManager.Status == ServiceControllerStatus.Running))
                {
                    serviceAlarmManager.Pause();

                    bReset = true;

                    serviceAlarmManager.WaitForStatus(ServiceControllerStatus.Paused);
                }
            }
            catch { }

            try
            {
                if (alarmCacheConfigChanged)
                    alarmCacheConfig.Save();

                if (matchList.Changed)
                    matchList.List.Save("MatchList.cfg");

                if (disseminatorList.Changed
                ||  alarmCacheConfigChanged)
                {
                    disseminatorList.List.Save("AlarmDisseminator.cfg");
                }

                if (hl7List.Changed)
                    hl7List.List.Save("AlarmManager.cfg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Saving failed!", MessageBoxButtons.OK);

                return;
            }

            try
            {
                if (bReset)
                {
                    serviceAlarmManager.Continue();

                    serviceAlarmManager.WaitForStatus(ServiceControllerStatus.Running);
                }
            }
            catch { }

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serviceAlarmManager != null)
            {
                serviceAlarmManager.Start();

                startToolStripMenuItem.Enabled = false;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serviceAlarmManager != null)
            {
                serviceAlarmManager.Stop();

                stopToolStripMenuItem.Enabled = false;
            }
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                return;

            MainScreen_Load(sender, e);

            tabControl.SelectedIndex = 0;
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MainScreen_Resize(sender, e);

            if (hl7List.Changed)
            {
                AlarmDisseminatorList adl = disseminatorList.List;
                adl.AddHL7Disseminators(hl7List.Disseminators);
                disseminatorList.List = adl;

                matchList.Disseminators = disseminatorList.Disseminators;
            }
            else if (disseminatorList.Changed)
            {
                matchList.Disseminators = disseminatorList.Disseminators;
            }
        }

        private void MainScreen_Resize(object sender, System.EventArgs e)
        {
            buttonCancel.Top = buttonOk.Top = (this.Height - buttonOk.Height - 35);
            buttonOk.Left = this.Width - 15 - buttonOk.Width;
            buttonCancel.Left = buttonOk.Left - 10 - buttonCancel.Width;

            tabControl.Width = this.Width - (tabControl.Left << 1) - 5;
            tabControl.Height = buttonOk.Top - 5 - tabControl.Top;

            matchList.Top = 0;
            matchList.Left = 0;
            matchList.Width = tabMatchList.Width - ((tabMatchList.Height < matchList.MinimumSize.Height) ? 20 : 0);
            matchList.Height = tabMatchList.Height - ((tabMatchList.Width < matchList.MinimumSize.Width) ? 20 : 0);

            disseminatorList.Top = 0;
            disseminatorList.Left = 0;
            disseminatorList.Width = tabDisseminatorList.Width - ((tabDisseminatorList.Height < disseminatorList.MinimumSize.Height) ? 20 : 0);
            disseminatorList.Height = tabDisseminatorList.Height - ((tabDisseminatorList.Width < disseminatorList.MinimumSize.Width) ? 20 : 0);

            hl7List.Top = 0;
            hl7List.Left = 0;
            hl7List.Width = tabConnectionList.Width - ((tabConnectionList.Height < hl7List.MinimumSize.Height) ? 20 : 0);
            hl7List.Height = tabConnectionList.Height - ((tabConnectionList.Width < hl7List.MinimumSize.Width) ? 20 : 0);

            alarmCacheConfig.Top = 0;
            alarmCacheConfig.Left = 0;
            alarmCacheConfig.Width = tabAlarmCache.Width - ((tabAlarmCache.Height < alarmCacheConfig.MinimumSize.Height) ? 20 : 0);
            alarmCacheConfig.Height = tabAlarmCache.Height - ((tabAlarmCache.Width < alarmCacheConfig.MinimumSize.Width) ? 20 : 0);
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            AlarmMatchList aml = matchList.List;
            if (aml != null)
            {
                aml.Clear();
                aml.Load("MatchList.cfg");
                matchList.List = aml;
            }

            MLLPServerFarmList sfl = hl7List.List;
            if (sfl != null)
            {
                sfl.Clear();
                sfl.Load("AlarmManager.cfg");
                hl7List.List = sfl;
            }

            AlarmDisseminatorList adl = disseminatorList.List;
            if (adl != null)
            {
                adl.Clear();
                adl.Load("AlarmDisseminator.cfg");
                adl.AddHL7Disseminators(hl7List.Disseminators);
                disseminatorList.List = adl;

                matchList.Disseminators = disseminatorList.Disseminators;

                alarmCacheConfig.Reload();
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string alarmManagerExe = ".\\AlarmManager.exe";

            if (File.Exists(alarmManagerExe))
            {
                buttonCancel_Click(sender, e);

                System.Diagnostics.Process process = null;

                try
                {
                    process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), alarmManagerExe);
                    process.StartInfo.Arguments = "--uninstall";
                    process.StartInfo.CreateNoWindow = false;
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                    process.Start();
                    process.WaitForExit(25000);

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Uninstall failed!", MessageBoxButtons.OK);
                }
                finally
                {
                    if (process != null)
                    {
                        process.Close();
                        process.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Unable to find AlarmManager.exe so can't perform uninstall!", "Uninstall Failed!", MessageBoxButtons.OK);
            }
        }
    }
}