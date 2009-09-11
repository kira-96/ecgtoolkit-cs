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
    partial class AlarmCacheConfig
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openSelectAssembly = new System.Windows.Forms.OpenFileDialog();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openSelectAssembly
            // 
            this.openSelectAssembly.Filter = "Assembly (*.dll)|*.dll|Assembly (*.exe)|*.exe";
            this.openSelectAssembly.Title = "Select an Assembly";
            // 
            // buttonInstall
            // 
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(4, 4);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(105, 23);
            this.buttonInstall.TabIndex = 0;
            this.buttonInstall.Text = "Create Database";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // AlarmCacheConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonInstall);
            this.MinimumSize = new System.Drawing.Size(476, 112);
            this.Name = "AlarmCacheConfig";
            this.Size = new System.Drawing.Size(476, 142);
            this.Resize += new System.EventHandler(this.AlarmCacheConfig_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openSelectAssembly;
        private System.Windows.Forms.Button buttonInstall;
    }
}
