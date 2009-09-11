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
using System.Text;
using System.Windows.Forms;

using AlarmLib.HL7;

namespace AlarmManagerUI
{
    public partial class NodeListScreen : Form
    {
        private MLLPNodeList _NodeList;

        public NodeListScreen(MLLPNodeList nl)
        {
            InitializeComponent();

            _NodeList = nl;
            textFile.Text = _NodeList.FilePath;

            for (int i=0,e = _NodeList.Count;i < e;i++)
            {
                string ip, appName, facName;
                int port;

                if (_NodeList.Get(i, out ip, out port, out appName, out facName))
                {
                    listNodes.Items.Add(MakeElement(ip, port, appName, facName));
                }
            }
        }

        private string MakeElement(string ip, int port, string appName, string facName)
        {
            StringBuilder sb = new StringBuilder();

            int width = 15;

            sb.Append(ip);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 6;

            sb.Append(port);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 20;
            sb.Append(appName);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 20;
            sb.Append(facName);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            return sb.ToString();
        }

        public MLLPNodeList NodeList
        {
            get
            {
                return _NodeList;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            if (textFile.Text.Length == 0)
            {
                _NodeList.Close();
                _NodeList = null;
            }

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            Close();
        }

        private void textIp_TextChanged(object sender, EventArgs e)
        {
            bool bGood = true;

            if (textIp.Text.Length > 0)
            {
                string[] temp = textIp.Text.Split('.');

                bGood = false;

                if (temp.Length == 4)
                {
                    try
                    {
                        bGood = true;

                        for (int i = 0; i < 4; i++)
                        {
                            int nr = int.Parse(temp[i]);

                            if ((nr > 255)
                            || (nr < 0)
                            || temp[i].Contains(" "))
                            {
                                bGood = false;
                                break;
                            }
                        }
                    }
                    catch
                    {
                        bGood = false;
                    }
                }
            }

            textIp.BackColor = bGood ? Color.White : Color.Red;

            textAllInfo_TextChanged(sender, e);
        }

        private void textPort_TextChanged(object sender, EventArgs e)
        {
            if (textPort.Text.Length > 0)
            {
                bool bGood = true;

                if (textPort.Text.Length > 0)
                {
                    try
                    {
                        int.Parse(textPort.Text);
                    }
                    catch
                    {
                        bGood = false;
                    }
                }

                textPort.BackColor = bGood ? Color.White : Color.Red;
            }

            textAllInfo_TextChanged(sender, e);
        }

        private void textAllInfo_TextChanged(object sender, EventArgs e)
        {
            bool bResult =  textIp.BackColor != Color.Red
                         && textPort.BackColor != Color.Red
                         && (textApplicationName.Text.Length > 0)
                         && (textFacilityName.Text.Length > 0);

            buttonAdd.Enabled = false;
            buttonSet.Enabled = false;

            if (bResult)
            {
                if (_NodeList.Exists(textIp.Text))
                {
                    buttonSet.Enabled = true;
                }
                else
                {
                    buttonAdd.Enabled = true;
                }
            }
        }

        private void listNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listNodes.SelectedIndex;

            if (index >= 0)
            {
                buttonRemove.Enabled = true;

                string ip;
                MLLPNodeList.NodeInfo ni;

                _NodeList.Get(index, out ip, out ni);

                textIp.Text = ip;
                textPort.Text = ni.Port.ToString();
                textApplicationName.Text = ni.ApplicationName;
                textFacilityName.Text = ni.FacilityName;
            }
            else
            {
                buttonRemove.Enabled = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MLLPNodeList.NodeInfo ni = new MLLPNodeList.NodeInfo();

            ni.Port = textPort.Text.Length > 0 ? int.Parse(textPort.Text) : 0;
            ni.ApplicationName = textApplicationName.Text;
            ni.FacilityName = textFacilityName.Text;

            _NodeList.Set(textIp.Text, ni);

            int index = _NodeList.GetIndex(textIp.Text);

            listNodes.Items.Insert(index, MakeElement(textIp.Text, ni.Port, ni.ApplicationName, ni.FacilityName));
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            MLLPNodeList.NodeInfo ni = new MLLPNodeList.NodeInfo();

            ni.Port = textPort.Text.Length > 0 ? int.Parse(textPort.Text) : 0;
            ni.ApplicationName = textApplicationName.Text;
            ni.FacilityName = textFacilityName.Text;

            int index = _NodeList.GetIndex(textIp.Text);

            _NodeList.Set(textIp.Text, ni);
            listNodes.Items[index] = MakeElement(textIp.Text, ni.Port, ni.ApplicationName, ni.FacilityName);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int index = listNodes.SelectedIndex;

            if (index >= 0)
            {
                _NodeList.Set(_NodeList.GetIP(index), null);

                listNodes.Items.RemoveAt(index);
                listNodes.SelectedIndex = -1;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            DialogResult dr =  this.openNodeList.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                string
                    fileName = openNodeList.FileName,
                    relative = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

                if (fileName.StartsWith(relative, true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    fileName = "." + fileName.Remove(0, relative.Length);
                }

                textFile.Text = fileName;

                _NodeList.Open(fileName);

                listNodes.SelectedIndex = -1;
                listNodes.Items.Clear();

                for (int i = 0, end = _NodeList.Count; i < end; i++)
                {
                    string ip, appName, facName;
                    int port;

                    if (_NodeList.Get(i, out ip, out port, out appName, out facName))
                    {
                        listNodes.Items.Add(MakeElement(ip, port, appName, facName));
                    }
                }
            }
        }
    }
}