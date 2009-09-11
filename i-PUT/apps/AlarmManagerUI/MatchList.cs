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
using System.Windows.Forms;

using AlarmLib.PCD_ACM;

namespace AlarmManagerUI
{
    public partial class MatchList : UserControl
    {

        public MatchList()
        {
            InitializeComponent();
        }

        public bool Changed
        {
            get { return _Changed; }
        }

        private bool _Changed = false;

        private AlarmMatchList _MatchList;

        public AlarmMatchList List
        {
            get
            {
                return _MatchList;
            }
            set
            {
                _MatchList = value;

                LoadMatchList();
            }
        }

        public string[] Disseminators
        {
            get
            {
                string[] ret = new string[comboDisseminator.Items.Count];

                for (int i = 0; i < ret.Length; i++)
                    ret[i] = (string)comboDisseminator.Items[i];

                return ret;
            }
            set
            {
                comboDisseminator.Items.Clear();

                if (value != null)
                    comboDisseminator.Items.AddRange(value);
            }
        }

        private void LoadMatchList()
        {
            _Changed = false;
            this.listBox.Items.Clear();

            this.comboDisseminator.Text = string.Empty;
            this.textDestination.Text = string.Empty;
            this.textPatientId.Text = string.Empty;
            this.textCareUnit.Text = string.Empty;
            this.textRoom.Text = string.Empty;
            this.textBed.Text = string.Empty;

            if (_MatchList != null)
            {
                foreach (AlarmMatchList.AlarmMatch am in _MatchList)
                {
                    listBox.Items.Add(MakeElement(am));
                }
            }
        }

        private static string MakeElement(AlarmMatchList.AlarmMatch am)
        {
            StringBuilder sb = new StringBuilder();

            int width = 15;
            sb.Append(am.DisseminatorName);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 16;
            sb.Append(am.SpecificLocation);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 16;
            sb.Append(am.PatientId);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 16;
            sb.Append(am.CareUnit);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 16;
            sb.Append(am.Room);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 16;
            sb.Append(am.Bed);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            return sb.ToString();
        }

        void MatchList_Resize(object sender, System.EventArgs e)
        {
            this.listBox.Width = this.Width - this.listBox.Left - 4;
            this.listBox.Height = this.Height - this.listBox.Top;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                comboDisseminator.Text = _MatchList[index].DisseminatorName;
                textDestination.Text = _MatchList[index].SpecificLocation;
                textPatientId.Text = _MatchList[index].PatientId;
                textCareUnit.Text = _MatchList[index].CareUnit;
                textRoom.Text = _MatchList[index].Room;
                textBed.Text = _MatchList[index].Bed;

                buttonSet.Enabled = true;
                buttonRemove.Enabled = true;
                buttonUp.Enabled = true;
                buttonDown.Enabled = true;
            }
            else
            {
                buttonSet.Enabled = false;
                buttonRemove.Enabled = false;
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _Changed = true;

            AlarmMatchList.AlarmMatch am = new AlarmMatchList.AlarmMatch(
                comboDisseminator.Text,
                textDestination.Text,
                textPatientId.Text,
                textCareUnit.Text,
                textRoom.Text,
                textBed.Text);

            _MatchList.Add(am);
            listBox.Items.Add(MakeElement(am));
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                _Changed = true;

                AlarmMatchList.AlarmMatch am = _MatchList[index];

                am.DisseminatorName = comboDisseminator.Text;
                am.SpecificLocation = textDestination.Text;
                am.PatientId = textPatientId.Text;
                am.CareUnit = textCareUnit.Text;
                am.Room = textRoom.Text;
                am.Bed = textBed.Text;

                listBox.Items[index] = MakeElement(am);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index >= 0)
            {
                _Changed = true;

                listBox.Items.RemoveAt(index);
                _MatchList.RemoveAt(index);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if (index > 0)
            {
                _Changed = true;

                object temp = listBox.Items[index - 1];
                listBox.Items[index - 1] = listBox.Items[index];
                listBox.Items[index] = temp;

                AlarmMatchList.AlarmMatch am = _MatchList[index - 1];
                _MatchList[index - 1] = _MatchList[index];
                _MatchList[index] = am;

                listBox.SelectedIndex = index - 1;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;

            if ((index >= 0)
            &&  ((index+1) < listBox.Items.Count))
            {
                _Changed = true;

                object temp = listBox.Items[index + 1];
                listBox.Items[index + 1] = listBox.Items[index];
                listBox.Items[index] = temp;

                AlarmMatchList.AlarmMatch am = _MatchList[index + 1];
                _MatchList[index + 1] = _MatchList[index];
                _MatchList[index] = am;

                listBox.SelectedIndex = index + 1;
            }
        }

        void comboDisseminator_TextChanged(object sender, System.EventArgs e)
        {
            comboDisseminator.BackColor = comboDisseminator.Text.Contains("|") ? Color.Red : Color.White;

            buttonAdd.Enabled = (comboDisseminator.Text.Length > 0)
                             && (comboDisseminator.BackColor != Color.Red)
                             && (textDestination.BackColor != Color.Red)
                             && (textPatientId.BackColor != Color.Red)
                             && (textCareUnit.BackColor != Color.Red)
                             && (textRoom.BackColor != Color.Red)
                             && (textBed.BackColor != Color.Red);

        }

        private void textDestination_TextChanged(object sender, EventArgs e)
        {
            textDestination.BackColor = textDestination.Text.Contains("|") ? Color.Red : Color.White;

            comboDisseminator_TextChanged(sender, e);
        }

        private void textPatientId_TextChanged(object sender, EventArgs e)
        {
            textPatientId.BackColor = textPatientId.Text.Contains("|") ? Color.Red : Color.White;

            textPatientId.Font = new System.Drawing.Font(
                textPatientId.Font,
                (string.Compare(textPatientId.Text, "NULL", true) == 0) ? FontStyle.Italic: FontStyle.Regular);

            comboDisseminator_TextChanged(sender, e);
        }

        private void textCareUnit_TextChanged(object sender, EventArgs e)
        {
            textCareUnit.BackColor = textCareUnit.Text.Contains("|") ? Color.Red : Color.White;

            textCareUnit.Font = new System.Drawing.Font(
                textCareUnit.Font,
                (string.Compare(textCareUnit.Text, "NULL", true) == 0) ? FontStyle.Italic : FontStyle.Regular);

            comboDisseminator_TextChanged(sender, e);
        }

        private void textRoom_TextChanged(object sender, EventArgs e)
        {
            textRoom.BackColor = textRoom.Text.Contains("|") ? Color.Red : Color.White;

            textRoom.Font = new System.Drawing.Font(
                textRoom.Font,
                (string.Compare(textRoom.Text, "NULL", true) == 0) ? FontStyle.Italic : FontStyle.Regular);

            comboDisseminator_TextChanged(sender, e);
        }

        private void textBed_TextChanged(object sender, EventArgs e)
        {
            textBed.BackColor = textBed.Text.Contains("|") ? Color.Red : Color.White;

            textBed.Font = new System.Drawing.Font(
                textBed.Font,
                (string.Compare(textBed.Text, "NULL", true) == 0) ? FontStyle.Italic : FontStyle.Regular);

            comboDisseminator_TextChanged(sender, e);
        }
    }
}
