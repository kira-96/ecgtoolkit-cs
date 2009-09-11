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
    partial class HL7ConnectionList
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textIpEndPoint = new System.Windows.Forms.TextBox();
            this.textPortEndPoint = new System.Windows.Forms.TextBox();
            this.textApplicationName = new System.Windows.Forms.TextBox();
            this.textFacilityName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textReturnPort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textRetryTimeout = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textConnectionTimeout = new System.Windows.Forms.TextBox();
            this.checkSynchronous = new System.Windows.Forms.CheckBox();
            this.checkMSAResponse = new System.Windows.Forms.CheckBox();
            this.checkRelease2 = new System.Windows.Forms.CheckBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonNodeList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.White;
            this.listBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 14;
            this.listBox.Location = new System.Drawing.Point(2, 122);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(672, 60);
            this.listBox.TabIndex = 14;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(4, 52);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Enabled = false;
            this.buttonSet.Location = new System.Drawing.Point(4, 28);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 2;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Application Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Facility Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "IP End Point";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Return";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Retry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Connection";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(613, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Config";
            // 
            // textIpEndPoint
            // 
            this.textIpEndPoint.BackColor = System.Drawing.Color.White;
            this.textIpEndPoint.Location = new System.Drawing.Point(176, 27);
            this.textIpEndPoint.MaxLength = 15;
            this.textIpEndPoint.Name = "textIpEndPoint";
            this.textIpEndPoint.Size = new System.Drawing.Size(95, 20);
            this.textIpEndPoint.TabIndex = 4;
            this.textIpEndPoint.TextChanged += new System.EventHandler(this.textIpEndPoint_TextChanged);
            // 
            // textPortEndPoint
            // 
            this.textPortEndPoint.BackColor = System.Drawing.Color.White;
            this.textPortEndPoint.Location = new System.Drawing.Point(277, 27);
            this.textPortEndPoint.MaxLength = 5;
            this.textPortEndPoint.Name = "textPortEndPoint";
            this.textPortEndPoint.Size = new System.Drawing.Size(42, 20);
            this.textPortEndPoint.TabIndex = 5;
            this.textPortEndPoint.TextChanged += new System.EventHandler(this.textNr_TextChanged);
            // 
            // textApplicationName
            // 
            this.textApplicationName.BackColor = System.Drawing.Color.White;
            this.textApplicationName.Location = new System.Drawing.Point(176, 50);
            this.textApplicationName.MaxLength = 120;
            this.textApplicationName.Name = "textApplicationName";
            this.textApplicationName.Size = new System.Drawing.Size(143, 20);
            this.textApplicationName.TabIndex = 6;
            this.textApplicationName.TextChanged += new System.EventHandler(this.textAllInfo_TextChanged);
            // 
            // textFacilityName
            // 
            this.textFacilityName.BackColor = System.Drawing.Color.White;
            this.textFacilityName.Location = new System.Drawing.Point(176, 73);
            this.textFacilityName.MaxLength = 120;
            this.textFacilityName.Name = "textFacilityName";
            this.textFacilityName.Size = new System.Drawing.Size(143, 20);
            this.textFacilityName.TabIndex = 7;
            this.textFacilityName.TextChanged += new System.EventHandler(this.textAllInfo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Application Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Facility Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(85, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "End Point";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(510, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Timeout";
            // 
            // textReturnPort
            // 
            this.textReturnPort.BackColor = System.Drawing.Color.White;
            this.textReturnPort.Location = new System.Drawing.Point(431, 27);
            this.textReturnPort.MaxLength = 5;
            this.textReturnPort.Name = "textReturnPort";
            this.textReturnPort.Size = new System.Drawing.Size(42, 20);
            this.textReturnPort.TabIndex = 8;
            this.textReturnPort.TextChanged += new System.EventHandler(this.textNr_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(327, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Return Port";
            // 
            // textRetryTimeout
            // 
            this.textRetryTimeout.BackColor = System.Drawing.Color.White;
            this.textRetryTimeout.Location = new System.Drawing.Point(431, 50);
            this.textRetryTimeout.MaxLength = 10;
            this.textRetryTimeout.Name = "textRetryTimeout";
            this.textRetryTimeout.Size = new System.Drawing.Size(56, 20);
            this.textRetryTimeout.TabIndex = 9;
            this.textRetryTimeout.TextChanged += new System.EventHandler(this.textNr_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(327, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Retry Timeout";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(327, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Connection Timeout";
            // 
            // textConnectionTimeout
            // 
            this.textConnectionTimeout.BackColor = System.Drawing.Color.White;
            this.textConnectionTimeout.Location = new System.Drawing.Point(431, 73);
            this.textConnectionTimeout.MaxLength = 10;
            this.textConnectionTimeout.Name = "textConnectionTimeout";
            this.textConnectionTimeout.Size = new System.Drawing.Size(56, 20);
            this.textConnectionTimeout.TabIndex = 10;
            this.textConnectionTimeout.TextChanged += new System.EventHandler(this.textNr_TextChanged);
            // 
            // checkSynchronous
            // 
            this.checkSynchronous.AutoSize = true;
            this.checkSynchronous.Location = new System.Drawing.Point(499, 29);
            this.checkSynchronous.Name = "checkSynchronous";
            this.checkSynchronous.Size = new System.Drawing.Size(88, 17);
            this.checkSynchronous.TabIndex = 33;
            this.checkSynchronous.Text = "Synchronous";
            this.checkSynchronous.UseVisualStyleBackColor = true;
            // 
            // checkMSAResponse
            // 
            this.checkMSAResponse.AutoSize = true;
            this.checkMSAResponse.Location = new System.Drawing.Point(499, 74);
            this.checkMSAResponse.Name = "checkMSAResponse";
            this.checkMSAResponse.Size = new System.Drawing.Size(100, 17);
            this.checkMSAResponse.TabIndex = 34;
            this.checkMSAResponse.Text = "MSA Response";
            this.checkMSAResponse.UseVisualStyleBackColor = true;
            // 
            // checkRelease2
            // 
            this.checkRelease2.AutoSize = true;
            this.checkRelease2.Location = new System.Drawing.Point(499, 51);
            this.checkRelease2.Name = "checkRelease2";
            this.checkRelease2.Size = new System.Drawing.Size(74, 17);
            this.checkRelease2.TabIndex = 35;
            this.checkRelease2.Text = "Release 2";
            this.checkRelease2.UseVisualStyleBackColor = true;
            // 
            // comboType
            // 
            this.comboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboType.Enabled = false;
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "Normal",
            "Alarm Reporter",
            "Alarm Cache"});
            this.comboType.Location = new System.Drawing.Point(176, 3);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(143, 21);
            this.comboType.TabIndex = 36;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(85, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Type";
            // 
            // buttonNodeList
            // 
            this.buttonNodeList.Enabled = false;
            this.buttonNodeList.Location = new System.Drawing.Point(325, 4);
            this.buttonNodeList.Name = "buttonNodeList";
            this.buttonNodeList.Size = new System.Drawing.Size(75, 20);
            this.buttonNodeList.TabIndex = 38;
            this.buttonNodeList.Text = "Node List";
            this.buttonNodeList.UseVisualStyleBackColor = true;
            this.buttonNodeList.Click += new System.EventHandler(this.buttonNodeList_Click);
            // 
            // HL7ConnectionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNodeList);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.checkRelease2);
            this.Controls.Add(this.checkMSAResponse);
            this.Controls.Add(this.checkSynchronous);
            this.Controls.Add(this.textConnectionTimeout);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textRetryTimeout);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textReturnPort);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textFacilityName);
            this.Controls.Add(this.textApplicationName);
            this.Controls.Add(this.textPortEndPoint);
            this.Controls.Add(this.textIpEndPoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.listBox);
            this.MinimumSize = new System.Drawing.Size(680, 190);
            this.Name = "HL7ConnectionList";
            this.Size = new System.Drawing.Size(680, 190);
            this.Resize += new System.EventHandler(this.HL7ConnectionList_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textIpEndPoint;
        private System.Windows.Forms.TextBox textPortEndPoint;
        private System.Windows.Forms.TextBox textApplicationName;
        private System.Windows.Forms.TextBox textFacilityName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textReturnPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textRetryTimeout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textConnectionTimeout;
        private System.Windows.Forms.CheckBox checkSynchronous;
        private System.Windows.Forms.CheckBox checkMSAResponse;
        private System.Windows.Forms.CheckBox checkRelease2;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonNodeList;

    }
}
