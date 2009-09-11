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
    partial class NodeListScreen
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listNodes = new System.Windows.Forms.ListBox();
            this.textIp = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textApplicationName = new System.Windows.Forms.TextBox();
            this.textFacilityName = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.openNodeList = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(366, 266);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(285, 266);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(42, 12);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(181, 20);
            this.textFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File";
            // 
            // listNodes
            // 
            this.listNodes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNodes.FormattingEnabled = true;
            this.listNodes.ItemHeight = 14;
            this.listNodes.Location = new System.Drawing.Point(11, 88);
            this.listNodes.Name = "listNodes";
            this.listNodes.Size = new System.Drawing.Size(430, 172);
            this.listNodes.TabIndex = 4;
            this.listNodes.SelectedIndexChanged += new System.EventHandler(this.listNodes_SelectedIndexChanged);
            // 
            // textIp
            // 
            this.textIp.Location = new System.Drawing.Point(11, 67);
            this.textIp.Name = "textIp";
            this.textIp.Size = new System.Drawing.Size(109, 20);
            this.textIp.TabIndex = 5;
            this.textIp.TextChanged += new System.EventHandler(this.textIp_TextChanged);
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(126, 67);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(37, 20);
            this.textPort.TabIndex = 6;
            this.textPort.TextChanged += new System.EventHandler(this.textPort_TextChanged);
            // 
            // textApplicationName
            // 
            this.textApplicationName.Location = new System.Drawing.Point(169, 67);
            this.textApplicationName.Name = "textApplicationName";
            this.textApplicationName.Size = new System.Drawing.Size(133, 20);
            this.textApplicationName.TabIndex = 7;
            this.textApplicationName.TextChanged += new System.EventHandler(this.textAllInfo_TextChanged);
            // 
            // textFacilityName
            // 
            this.textFacilityName.Location = new System.Drawing.Point(308, 67);
            this.textFacilityName.Name = "textFacilityName";
            this.textFacilityName.Size = new System.Drawing.Size(133, 20);
            this.textFacilityName.TabIndex = 8;
            this.textFacilityName.TextChanged += new System.EventHandler(this.textAllInfo_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(12, 38);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Enabled = false;
            this.buttonSet.Location = new System.Drawing.Point(93, 38);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 10;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(174, 38);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(229, 9);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 12;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // openNodeList
            // 
            this.openNodeList.FileName = "Open Node List";
            // 
            // NodeListScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 304);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textFacilityName);
            this.Controls.Add(this.textApplicationName);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIp);
            this.Controls.Add(this.listNodes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NodeListScreen";
            this.Text = "Node List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listNodes;
        private System.Windows.Forms.TextBox textIp;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textApplicationName;
        private System.Windows.Forms.TextBox textFacilityName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.OpenFileDialog openNodeList;
    }
}