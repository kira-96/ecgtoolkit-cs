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
    partial class MatchList
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
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.comboDisseminator = new System.Windows.Forms.ComboBox();
            this.textDestination = new System.Windows.Forms.TextBox();
            this.textPatientId = new System.Windows.Forms.TextBox();
            this.textCareUnit = new System.Windows.Forms.TextBox();
            this.textRoom = new System.Windows.Forms.TextBox();
            this.textBed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonUp
            // 
            this.buttonUp.Enabled = false;
            this.buttonUp.Location = new System.Drawing.Point(84, 52);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 9;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Enabled = false;
            this.buttonDown.Location = new System.Drawing.Point(165, 52);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 10;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // listBox
            // 
            this.listBox.ColumnWidth = 32;
            this.listBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 14;
            this.listBox.Location = new System.Drawing.Point(3, 83);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(577, 256);
            this.listBox.TabIndex = 11;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(4, 52);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // comboDisseminator
            // 
            this.comboDisseminator.FormattingEnabled = true;
            this.comboDisseminator.Location = new System.Drawing.Point(84, 20);
            this.comboDisseminator.Name = "comboDisseminator";
            this.comboDisseminator.Size = new System.Drawing.Size(91, 21);
            this.comboDisseminator.TabIndex = 0;
            this.comboDisseminator.TextChanged += new System.EventHandler(this.comboDisseminator_TextChanged);
            // 
            // textDestination
            // 
            this.textDestination.Location = new System.Drawing.Point(181, 20);
            this.textDestination.Name = "textDestination";
            this.textDestination.Size = new System.Drawing.Size(75, 20);
            this.textDestination.TabIndex = 1;
            this.textDestination.TextChanged += new System.EventHandler(this.textDestination_TextChanged);
            // 
            // textPatientId
            // 
            this.textPatientId.Location = new System.Drawing.Point(262, 20);
            this.textPatientId.Name = "textPatientId";
            this.textPatientId.Size = new System.Drawing.Size(75, 20);
            this.textPatientId.TabIndex = 2;
            this.textPatientId.TextChanged += new System.EventHandler(this.textPatientId_TextChanged);
            // 
            // textCareUnit
            // 
            this.textCareUnit.Location = new System.Drawing.Point(343, 20);
            this.textCareUnit.Name = "textCareUnit";
            this.textCareUnit.Size = new System.Drawing.Size(75, 20);
            this.textCareUnit.TabIndex = 3;
            this.textCareUnit.TextChanged += new System.EventHandler(this.textCareUnit_TextChanged);
            // 
            // textRoom
            // 
            this.textRoom.Location = new System.Drawing.Point(424, 20);
            this.textRoom.Name = "textRoom";
            this.textRoom.Size = new System.Drawing.Size(75, 20);
            this.textRoom.TabIndex = 4;
            this.textRoom.TextChanged += new System.EventHandler(this.textRoom_TextChanged);
            // 
            // textBed
            // 
            this.textBed.Location = new System.Drawing.Point(505, 20);
            this.textBed.Name = "textBed";
            this.textBed.Size = new System.Drawing.Size(75, 20);
            this.textBed.TabIndex = 5;
            this.textBed.TextChanged += new System.EventHandler(this.textBed_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Disseminator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Patient ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "CareUnit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(424, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Room";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bed";
            // 
            // buttonSet
            // 
            this.buttonSet.Enabled = false;
            this.buttonSet.Location = new System.Drawing.Point(4, 28);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 7;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // MatchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBed);
            this.Controls.Add(this.textRoom);
            this.Controls.Add(this.textCareUnit);
            this.Controls.Add(this.textPatientId);
            this.Controls.Add(this.textDestination);
            this.Controls.Add(this.comboDisseminator);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.MinimumSize = new System.Drawing.Size(589, 148);
            this.Name = "MatchList";
            this.Size = new System.Drawing.Size(657, 373);
            this.Resize += new System.EventHandler(this.MatchList_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ComboBox comboDisseminator;
        private System.Windows.Forms.TextBox textDestination;
        private System.Windows.Forms.TextBox textPatientId;
        private System.Windows.Forms.TextBox textCareUnit;
        private System.Windows.Forms.TextBox textRoom;
        private System.Windows.Forms.TextBox textBed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSet;
    }
}
