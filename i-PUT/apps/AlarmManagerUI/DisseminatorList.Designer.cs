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
    partial class DisseminatorList
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textAssembly = new System.Windows.Forms.TextBox();
            this.comboClass = new System.Windows.Forms.ComboBox();
            this.buttonSelectAssembly = new System.Windows.Forms.Button();
            this.openSelectAssembly = new System.Windows.Forms.OpenFileDialog();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(3, 31);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(86, 108);
            this.listBox.TabIndex = 4;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(96, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddSet_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Enabled = false;
            this.buttonSet.Location = new System.Drawing.Point(177, 4);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 3;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonAddSet_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(230, 30);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(100, 20);
            this.textName.TabIndex = 5;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // textAssembly
            // 
            this.textAssembly.Location = new System.Drawing.Point(230, 83);
            this.textAssembly.Name = "textAssembly";
            this.textAssembly.Size = new System.Drawing.Size(160, 20);
            this.textAssembly.TabIndex = 7;
            this.textAssembly.TextChanged += new System.EventHandler(this.textAssembly_TextChanged);
            // 
            // comboClass
            // 
            this.comboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClass.FormattingEnabled = true;
            this.comboClass.Location = new System.Drawing.Point(230, 56);
            this.comboClass.Name = "comboClass";
            this.comboClass.Size = new System.Drawing.Size(240, 21);
            this.comboClass.TabIndex = 6;
            this.comboClass.SelectedIndexChanged += new System.EventHandler(this.comboClass_SelectIndexChanged);
            // 
            // buttonSelectAssembly
            // 
            this.buttonSelectAssembly.Location = new System.Drawing.Point(395, 82);
            this.buttonSelectAssembly.Name = "buttonSelectAssembly";
            this.buttonSelectAssembly.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAssembly.TabIndex = 8;
            this.buttonSelectAssembly.Text = "Select";
            this.buttonSelectAssembly.UseVisualStyleBackColor = true;
            this.buttonSelectAssembly.Click += new System.EventHandler(this.buttonSelectAssembly_Click);
            // 
            // openSelectAssembly
            // 
            this.openSelectAssembly.Filter = "Assembly (*.dll)|*.dll|Assembly (*.exe)|*.exe";
            this.openSelectAssembly.Title = "Select an Assembly";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(3, 4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(86, 23);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 120);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(476, 22);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // DisseminatorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonSelectAssembly);
            this.Controls.Add(this.comboClass);
            this.Controls.Add(this.textAssembly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBox);
            this.MinimumSize = new System.Drawing.Size(476, 112);
            this.Name = "DisseminatorList";
            this.Size = new System.Drawing.Size(476, 142);
            this.Load += new System.EventHandler(this.DisseminatorList_Load);
            this.Resize += new System.EventHandler(this.DisseminatorList_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAssembly;
        private System.Windows.Forms.ComboBox comboClass;
        private System.Windows.Forms.Button buttonSelectAssembly;
        private System.Windows.Forms.OpenFileDialog openSelectAssembly;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}
