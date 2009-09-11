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
namespace AlarmManagerUI
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.serviceAlarmManager = new System.ServiceProcess.ServiceController();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMatchList = new System.Windows.Forms.TabPage();
            this.matchList = new AlarmManagerUI.MatchList();
            this.tabDisseminatorList = new System.Windows.Forms.TabPage();
            this.disseminatorList = new AlarmManagerUI.DisseminatorList();
            this.tabConnectionList = new System.Windows.Forms.TabPage();
            this.hl7List = new AlarmManagerUI.HL7ConnectionList();
            this.tabAlarmCache = new System.Windows.Forms.TabPage();
            this.alarmCacheConfig = new AlarmManagerUI.AlarmCacheConfig();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMatchList.SuspendLayout();
            this.tabDisseminatorList.SuspendLayout();
            this.tabConnectionList.SuspendLayout();
            this.tabAlarmCache.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AlarmManager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.toolStripSeparator2,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator3,
            this.uninstallToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 154);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(630, 437);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(549, 437);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // serviceAlarmManager
            // 
            this.serviceAlarmManager.ServiceName = "AlarmManager";
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 250;
            this.timerStatus.Tick += new System.EventHandler(this.UpdateStatus);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMatchList);
            this.tabControl.Controls.Add(this.tabDisseminatorList);
            this.tabControl.Controls.Add(this.tabConnectionList);
            this.tabControl.Controls.Add(this.tabAlarmCache);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(695, 421);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabMatchList
            // 
            this.tabMatchList.AutoScroll = true;
            this.tabMatchList.Controls.Add(this.matchList);
            this.tabMatchList.Location = new System.Drawing.Point(4, 22);
            this.tabMatchList.Name = "tabMatchList";
            this.tabMatchList.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatchList.Size = new System.Drawing.Size(687, 395);
            this.tabMatchList.TabIndex = 0;
            this.tabMatchList.Text = "Match List";
            this.tabMatchList.UseVisualStyleBackColor = true;
            // 
            // matchList
            // 
            this.matchList.Disseminators = new string[0];
            this.matchList.List = null;
            this.matchList.Location = new System.Drawing.Point(0, 0);
            this.matchList.MinimumSize = new System.Drawing.Size(589, 148);
            this.matchList.Name = "matchList";
            this.matchList.Size = new System.Drawing.Size(589, 148);
            this.matchList.TabIndex = 0;
            // 
            // tabDisseminatorList
            // 
            this.tabDisseminatorList.AutoScroll = true;
            this.tabDisseminatorList.Controls.Add(this.disseminatorList);
            this.tabDisseminatorList.Location = new System.Drawing.Point(4, 22);
            this.tabDisseminatorList.Name = "tabDisseminatorList";
            this.tabDisseminatorList.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisseminatorList.Size = new System.Drawing.Size(687, 395);
            this.tabDisseminatorList.TabIndex = 1;
            this.tabDisseminatorList.Text = "Disseminators";
            this.tabDisseminatorList.UseVisualStyleBackColor = true;
            // 
            // disseminatorList
            // 
            this.disseminatorList.List = null;
            this.disseminatorList.Location = new System.Drawing.Point(0, 0);
            this.disseminatorList.MinimumSize = new System.Drawing.Size(476, 112);
            this.disseminatorList.Name = "disseminatorList";
            this.disseminatorList.Size = new System.Drawing.Size(476, 142);
            this.disseminatorList.TabIndex = 0;
            // 
            // tabConnectionList
            // 
            this.tabConnectionList.AutoScroll = true;
            this.tabConnectionList.Controls.Add(this.hl7List);
            this.tabConnectionList.Location = new System.Drawing.Point(4, 22);
            this.tabConnectionList.Name = "tabConnectionList";
            this.tabConnectionList.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectionList.Size = new System.Drawing.Size(687, 395);
            this.tabConnectionList.TabIndex = 2;
            this.tabConnectionList.Text = "HL7 Connections";
            this.tabConnectionList.UseVisualStyleBackColor = true;
            // 
            // hl7List
            // 
            this.hl7List.List = null;
            this.hl7List.Location = new System.Drawing.Point(3, 3);
            this.hl7List.MinimumSize = new System.Drawing.Size(680, 180);
            this.hl7List.Name = "hl7List";
            this.hl7List.Size = new System.Drawing.Size(680, 180);
            this.hl7List.TabIndex = 0;
            // 
            // tabAlarmCache
            // 
            this.tabAlarmCache.AutoScroll = true;
            this.tabAlarmCache.Controls.Add(this.alarmCacheConfig);
            this.tabAlarmCache.Location = new System.Drawing.Point(4, 22);
            this.tabAlarmCache.Name = "tabAlarmCache";
            this.tabAlarmCache.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlarmCache.Size = new System.Drawing.Size(687, 395);
            this.tabAlarmCache.TabIndex = 3;
            this.tabAlarmCache.Text = "Alarm Cache";
            this.tabAlarmCache.UseVisualStyleBackColor = true;
            // 
            // alarmCacheConfig
            // 
            this.alarmCacheConfig.Location = new System.Drawing.Point(0, 0);
            this.alarmCacheConfig.MinimumSize = new System.Drawing.Size(476, 112);
            this.alarmCacheConfig.Name = "alarmCacheConfig";
            this.alarmCacheConfig.Size = new System.Drawing.Size(476, 142);
            this.alarmCacheConfig.TabIndex = 0;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 472);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainScreen";
            this.ShowInTaskbar = false;
            this.Text = "AlarmManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.Resize += new System.EventHandler(this.MainScreen_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabMatchList.ResumeLayout(false);
            this.tabDisseminatorList.ResumeLayout(false);
            this.tabConnectionList.ResumeLayout(false);
            this.tabAlarmCache.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.ServiceProcess.ServiceController serviceAlarmManager;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMatchList;
        private MatchList matchList;
        private System.Windows.Forms.TabPage tabDisseminatorList;
        private DisseminatorList disseminatorList;
        private System.Windows.Forms.TabPage tabConnectionList;
        private HL7ConnectionList hl7List;
        private System.Windows.Forms.TabPage tabAlarmCache;
        private AlarmCacheConfig alarmCacheConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
    }
}

