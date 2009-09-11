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
using System.Drawing;
using System.Data;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

using AlarmLib.PCD_ACM;

namespace AlarmManagerUI
{
    public partial class DisseminatorList : UserControl
    {
        private AlarmDisseminatorList _Disseminators;
        private IAlarmDisseminator __Disseminator;
        private Assembly _CurrentAssembly;

        private IAlarmDisseminator _Disseminator
        {
            get
            {
                return __Disseminator;
            }
            set
            {
                __Disseminator = value;

                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i].Name.StartsWith("tempLabel_")
                    ||  Controls[i].Name.StartsWith("tempBox_"))
                    {
                        Controls.RemoveAt(i--);
                    }
                }

                int top = textAssembly.Bottom + 5;

                if (__Disseminator != null)
                {
                    int left = label1.Left;

                    if (__Disseminator.ConfigurationItems != null)
                    {
                        foreach (string item in __Disseminator.ConfigurationItems)
                        {
                            Label label = new Label();
                            label.Text = item;
                            label.Name = "tempLabel_" + item;
                            label.Top = top;
                            label.Left = left;

                            TextBox box = new TextBox();
                            box.Text = __Disseminator[item];
                            box.Name = "tempBox_" + item;
                            box.Top = top;
                            box.Left = textName.Left;
                            box.Width = 160;
                            box.Multiline = true;
                            box.TextChanged += new EventHandler(box_TextChanged);

                            Controls.Add(label);
                            Controls.Add(box);
                            top += 25;
                        }
                    }
                    else
                    {
                        Label label = new Label();
                        label.Text = "This type can only be added in the HL7 Server Pool!";
                        label.Name = "tempLabel_0";
                        label.Top = top;
                        label.Left = left;
                        label.Width = 500;
                        Controls.Add(label);
                    }
                }

                this.MinimumSize = new Size(
                    comboClass.Right + 2,
                    top + statusStrip.Height);
            }
        }

        public DisseminatorList()
        {
            InitializeComponent();
        }

        public bool Changed
        {
            get { return _Changed; }
        }

        private bool _Changed = false;

        public string[] Disseminators
        {
            get
            {
                string[] ret = new string[_Disseminators.Count];

                for (int i=0;i < ret.Length;i++)
                    ret[i] = _Disseminators.Keys[i];

                return ret;
            }
        }

        public AlarmDisseminatorList List
        {
            get
            {
                return _Disseminators;
            }
            set
            {
                _Disseminators = value;

                LoadDisseminators();
            }
        }

        private void LoadDisseminators()
        {
            _Changed = false;
            listBox.Items.Clear();
            buttonRemove.Enabled = false;

            textName.Text = string.Empty;
            comboClass.SelectedIndex = -1;
            textAssembly.Text = string.Empty;
            _Disseminator = null;

            if (_Disseminators != null)
            {
                foreach (string name in _Disseminators.Keys)
                    listBox.Items.Add(name);
            }
        }

        private void ReadConfig(IAlarmDisseminator iad)
        {
            if (iad == null)
                return;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Name.StartsWith("tempBox_"))
                {
                    string item = Controls[i].Name.Remove(0, 8);

                    iad[item] = Controls[i].Text;
                }
            }
        }

        private void LoadAssembly(Assembly assembly)
        {
            if (assembly != null)
            {
                try
                {
                    foreach (Type ti in assembly.GetTypes())
                    {
                        if (!ti.IsAbstract
                        && !ti.IsInterface
                        && ti.IsSubclassOf(typeof(IAlarmDisseminator)))
                        {
                            comboClass.Items.Add(ti.FullName);
                        }
                    }
                }
                catch
                {
                    comboClass.Items.Clear();
                }
            }
        }

        void DisseminatorList_Resize(object sender, System.EventArgs e)
        {
            listBox.Left = 0;
            listBox.Height = this.Height - listBox.Top - 4 - statusStrip.Height;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                IAlarmDisseminator iad = _Disseminators.Values[index];

                _Disseminator = iad.Rename("empty");

                Type ti = iad.GetType();

                textName.Text = iad.Name;
                
                textAssembly.Text = ti.Assembly == _Disseminators.GetType().Assembly ? string.Empty : ti.Assembly.Location;
                comboClass.Text = ti.FullName;

                buttonRemove.Enabled = !(iad is HL7AlarmDisseminator);
            }
            else
            {
                textName.Text = string.Empty;
                comboClass.Text = string.Empty;
                textAssembly.Text = string.Empty;

                buttonRemove.Enabled = false;
            }
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            bool bTemp  = (textName.Text.Length > 0)
                       && !textName.Text.Contains("|")
                       && !textName.Text.Contains(";")
                       && (comboClass.SelectedIndex >= 0)
                       && (__Disseminator != null)
                       && !(__Disseminator is HL7AlarmDisseminator);

            int index = _Disseminators != null ? _Disseminators.IndexOfKey(textName.Text) : -1;

            if (index >= 0)
            {
                bTemp &= !(_Disseminators.Values[index] is HL7AlarmDisseminator);

                buttonAdd.Enabled = false;
                buttonSet.Enabled = bTemp;
            }
            else
            {
                buttonAdd.Enabled = bTemp;
                buttonSet.Enabled = false;
            }
        }

        private void comboClass_SelectIndexChanged(object sender, EventArgs e)
        {
            int index = comboClass.SelectedIndex;
            if ((index >= 0)
            && (_CurrentAssembly != null))
            {
                Type type = _CurrentAssembly.GetType(comboClass.Text, false, false);

                if ((_Disseminator == null)
                ||  (_Disseminator.GetType() != type))
                {
                    try
                    {
                        _Disseminator = (IAlarmDisseminator)_CurrentAssembly.CreateInstance(
                            type.FullName,
                            false,
                            BindingFlags.CreateInstance,
                            null,
                            new object[] { "empty" },
                            null,
                            null);
                    }
                    catch { }
                }
            }

            textName_TextChanged(sender, e);
        }

        private void textAssembly_TextChanged(object sender, EventArgs e)
        {
            comboClass.Items.Clear();

            if (this.textAssembly.Text.Length > 0)
            {
                if (System.IO.File.Exists(textAssembly.Text))
                {
                    try
                    {
                        _CurrentAssembly = Assembly.LoadFrom(textAssembly.Text);
                    }
                    catch
                    {
                        _CurrentAssembly = null;
                    }
                }
                else
                {
                    _CurrentAssembly = null;
                }
            }
            else
            {
                _CurrentAssembly = typeof(AlarmDisseminatorList).Assembly;
            }

            LoadAssembly(_CurrentAssembly);

            comboClass_SelectIndexChanged(sender, e);
        }

        private void buttonSelectAssembly_Click(object sender, EventArgs e)
        {
            openSelectAssembly.FileName = textAssembly.Text;

            DialogResult dr = openSelectAssembly.ShowDialog(this);

            if ((dr == DialogResult.OK)
            ||  (dr == DialogResult.Yes))
            {
                textAssembly.Text = openSelectAssembly.FileName;
            }
        }

        private void DisseminatorList_Load(object sender, EventArgs e)
        {
            textAssembly_TextChanged(sender, e);
        }

        private void buttonAddSet_Click(object sender, EventArgs e)
        {
            try
            {
                ReadConfig(__Disseminator);

                IAlarmDisseminator iad = __Disseminator.Rename(this.textName.Text);

                int index = _Disseminators.IndexOfKey(iad.Name);
                if (index >= 0)
                    _Disseminators.RemoveAt(index);

                _Disseminators.Add(iad.Name, iad);

                LoadDisseminators();

                _Changed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Configuration Error!", MessageBoxButtons.OK);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                _Disseminators.Remove((string)listBox.Items[index]);

                LoadDisseminators();

                listBox.SelectedIndex = -1;

                textName_TextChanged(sender, e);

                _Changed = true;
            }
        }

        void box_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox box = (TextBox)sender;

                if (box.Name.StartsWith("tempBox_"))
                {
                    try
                    {
                        __Disseminator[box.Name.Remove(0, 8)] = box.Text;

                        toolStripStatusLabel.Text = string.Empty;
                        box.BackColor = Color.White;
                    }
                    catch (Exception ex)
                    {
                        toolStripStatusLabel.Text = ex.Message;
                        box.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
