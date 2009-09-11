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

using AlarmLib.HL7;
using AlarmLib.PCD_ACM;

namespace AlarmManagerUI
{
    public partial class HL7ConnectionList : UserControl
    {
        private MLLPServerFarmList _ServerFarm;
        private MLLPNodeList hiddenNodeList;

        public HL7ConnectionList()
        {
            InitializeComponent();
        }

        public bool Changed
        {
            get { return _Changed; }
        }

        private bool _Changed = false;

        public MLLPServerFarmList List
        {
            get
            {
                return _ServerFarm;
            }
            set
            {
                _ServerFarm = value;

                LoadServerFarm();
            }
        }

        private void LoadServerFarm()
        {
            listBox.SelectedIndex = -1;
            listBox.Items.Clear();

            buttonAdd.Enabled = false;
            buttonSet.Enabled = false;
            buttonRemove.Enabled = false;

            textIpEndPoint.Text = "0.0.0.0";
            textPortEndPoint.Text = string.Empty;
            textApplicationName.Text = string.Empty;
            textFacilityName .Text = string.Empty;

            textReturnPort.Text = string.Empty;
            textRetryTimeout.Text = string.Empty;
            textConnectionTimeout.Text = string.Empty;

            checkSynchronous.Checked = false;
            checkRelease2.Checked = false;
            checkMSAResponse.Checked = false;

            if (_ServerFarm != null)
            {
                foreach (MLLPServer server in _ServerFarm)
                {
                    listBox.Items.Add(MakeElement(server));
                }
            }
        }

        private static string MakeElement(MLLPServer server)
        {
            StringBuilder sb = new StringBuilder();

            int width = 19;
            sb.Append(server.ApplicationName);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 20;
            sb.Append(server.FacilityName);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 21;
            sb.Append(server.EndPoint.ToString());
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 6;
            sb.Append(server.ReturnPort);
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 10;
            sb.Append(server.RetryTimeout);
            sb.Append(" ms");
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 10;
            sb.Append(server.ConnectionTimeOut);
            sb.Append(" ms");
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 5;
            sb.Append((server.Type == MLLPServer.MLLPServerType.Synchronous) ? "SYN" : "ASYN");
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 2;
            sb.Append((server.Version == MLLPAdaptor.MLLPVersion.Release1) ? "1" : "2");
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            width += 2;
            sb.Append(server.SendMSAResponse ? "Y" : "N");
            if (sb.Length < width)
                sb.Append(' ', width - sb.Length);
            else
                sb.Remove(width, sb.Length - width);
            sb.Append(" ");

            return sb.ToString();
        }

        public HL7AlarmDisseminator[] Disseminators
        {
            get
            {
                List<HL7AlarmDisseminator> ret = new List<HL7AlarmDisseminator>();

                if (_ServerFarm != null)
                {
                    for (int i = 0; i < _ServerFarm.Count; i++)
                        if (_ServerFarm[i].ApplicationName.EndsWith("_AC"))
                            ret.Add(new HL7AlarmDisseminator(_ServerFarm[i].ApplicationName));
                }

                return ret.ToArray();
            }
        }

        void HL7ConnectionList_Resize(object sender, System.EventArgs e)
        {
            listBox.Width = this.Width - 4;
            listBox.Height = this.Height - listBox.Top;
        }

        private void textIpEndPoint_TextChanged(object sender, EventArgs e)
        {
            bool bGood = true;

            if (textIpEndPoint.Text.Length > 0)
            {
                string[] temp = textIpEndPoint.Text.Split('.');

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
                            ||  (nr < 0)
                            ||  temp[i].Contains(" "))
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

            textIpEndPoint.BackColor = bGood ? Color.White : Color.Red;

            textAllInfo_TextChanged(sender, e);
        }

        private void textNr_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox) 
            {
                TextBox box = (TextBox) sender;

                bool bGood = true;

                if (box.Text.Length > 0)
                {
                    try
                    {
                        int.Parse(box.Text);
                    }
                    catch
                    {
                        bGood = false;
                    }
                }

                box.BackColor = bGood ? Color.White : Color.Red;
            }

            textAllInfo_TextChanged(sender, e);
        }

        private void textAllInfo_TextChanged(object sender, EventArgs e)
        {
            buttonNodeList.Enabled = comboType.Enabled = textApplicationName.Text.Length > 0;

            bool bResult =  (textIpEndPoint.BackColor != Color.Red)
                         && (textPortEndPoint.BackColor != Color.Red)
                         && (textPortEndPoint.Text.Length > 0)
                         && (textApplicationName.Text.Length > 0)
                         && (textFacilityName.Text.Length > 0)
                         && (textReturnPort.BackColor != Color.Red)
                         && (textRetryTimeout.BackColor != Color.Red)
                         && (textConnectionTimeout.BackColor != Color.Red);

            if (textApplicationName.Text.EndsWith("_AR"))
            {
                comboType.SelectedIndex = 1;
            }
            else if (textApplicationName.Text.EndsWith("_AC"))
            {
                comboType.SelectedIndex = 2;
            }
            else
            {
                comboType.SelectedIndex = 0;
            }

            buttonSet.Enabled = bResult && listBox.SelectedIndex >= 0;

            if (bResult)
            {
                try
                {
                    System.Net.IPAddress addr = System.Net.IPAddress.Parse(textIpEndPoint.Text);
                    int port = int.Parse(textPortEndPoint.Text);

                    lock (_ServerFarm)
                    {
                        for (int i = 0; i < _ServerFarm.Count; i++)
                        {
                            if ((string.Compare(_ServerFarm[i].Address.ToString(), addr.ToString(), true) == 0)
                            &&  (_ServerFarm[i].Port == port))
                            {
                                bResult = false;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    bResult = false;
                }
            }

            buttonAdd.Enabled = bResult;
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboType.SelectedIndex;

            if (index >= 0)
            {
                string text = textApplicationName.Text;

                if (text.EndsWith("_AR"))
                {
                    if (index == 1)
                        return;

                    text = text.Remove(text.Length - 3, 3);
                }
                else if (text.EndsWith("_AC"))
                {
                    if (index == 2)
                        return;

                    text = text.Remove(text.Length - 3, 3);
                }
                else if (index == 0)
                {
                    return;
                }

                if (index == 1)
                    text += "_AR";
                else if (index == 2)
                    text += "_AC";

                textApplicationName.Text = text;
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            if (index >= 0)
            {
                textIpEndPoint.Text = _ServerFarm[index].EndPoint.Address.ToString();
                textPortEndPoint.Text = _ServerFarm[index].EndPoint.Port.ToString();
                textApplicationName.Text = _ServerFarm[index].ApplicationName;
                textFacilityName.Text = _ServerFarm[index].FacilityName;

                textReturnPort.Text = ((_ServerFarm[index].ReturnPort == _ServerFarm[index].EndPoint.Port) ? string.Empty : _ServerFarm[index].ReturnPort.ToString());
                textRetryTimeout.Text = _ServerFarm[index].RetryTimeout.ToString();
                textConnectionTimeout.Text = _ServerFarm[index].ConnectionTimeOut.ToString();

                checkSynchronous.Checked = _ServerFarm[index].Type == MLLPServer.MLLPServerType.Synchronous;
                checkRelease2.Checked = _ServerFarm[index].Version == MLLPAdaptor.MLLPVersion.Release2;
                checkMSAResponse.Checked = _ServerFarm[index].SendMSAResponse;

                hiddenNodeList = _ServerFarm[index].NodeList;
            }

            buttonRemove.Enabled = index >= 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MLLPServer server = new MLLPServer(System.Net.IPAddress.Parse(textIpEndPoint.Text), int.Parse(textPortEndPoint.Text));
                server.ApplicationName = textApplicationName.Text;
                server.FacilityName = textFacilityName.Text;

                if (textReturnPort.Text.Length > 0)
                    server.ReturnPort = int.Parse(textReturnPort.Text);

                server.RetryTimeout = int.Parse(textRetryTimeout.Text);
                server.ConnectionTimeOut = int.Parse(textConnectionTimeout.Text);

                server.Type = checkSynchronous.Checked ? MLLPServer.MLLPServerType.Synchronous : MLLPServer.MLLPServerType.Asynchronous;
                server.Version = checkRelease2.Checked ? MLLPAdaptor.MLLPVersion.Release2 : MLLPAdaptor.MLLPVersion.Release1;
                server.SendMSAResponse = checkMSAResponse.Checked;

                server.NodeList = hiddenNodeList;

                _ServerFarm.Add(server);
                listBox.Items.Add(MakeElement(server));

                buttonAdd.Enabled = false;

                _Changed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Adding HL7 server failed!", MessageBoxButtons.OK);
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listBox.SelectedIndex;

                if (index >= 0)
                {
                    MLLPServer server = new MLLPServer(System.Net.IPAddress.Parse(textIpEndPoint.Text), int.Parse(textPortEndPoint.Text));
                    server.ApplicationName = textApplicationName.Text;
                    server.FacilityName = textFacilityName.Text;

                    if (textReturnPort.Text.Length > 0)
                        server.ReturnPort = int.Parse(textReturnPort.Text);

                    server.RetryTimeout = int.Parse(textRetryTimeout.Text);
                    server.ConnectionTimeOut = int.Parse(textConnectionTimeout.Text);

                    server.Type = checkSynchronous.Checked ? MLLPServer.MLLPServerType.Synchronous : MLLPServer.MLLPServerType.Asynchronous;
                    server.Version = checkRelease2.Checked ? MLLPAdaptor.MLLPVersion.Release2 : MLLPAdaptor.MLLPVersion.Release1;
                    server.SendMSAResponse = checkMSAResponse.Checked;

                    server.NodeList = hiddenNodeList;

                    _ServerFarm[index] = server;

                    listBox.Items[index] = MakeElement(server);

                    _Changed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Setting HL7 server failed!", MessageBoxButtons.OK);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listBox.SelectedIndex;

                if (index >= 0)
                {
                    listBox.SelectedIndex = -1;
                    listBox.Items.RemoveAt(index);

                    _ServerFarm.RemoveAt(index);

                    buttonAdd.Enabled = true;
                    buttonSet.Enabled = false;

                    _Changed = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Remove HL7 server failed!", MessageBoxButtons.OK);
            }
        }

        private void buttonNodeList_Click(object sender, EventArgs e)
        {
            MLLPNodeList nl = hiddenNodeList;

            if (nl == null)
            {
                nl = new MLLPNodeList(".\\" + textApplicationName.Text + ".nlf");

                if (nl.FilePath == null)
                    nl.FilePath = ".\\" + textApplicationName.Text + ".nlf";
            }
            else
            {
                nl = nl.Clone();
            }

            NodeListScreen nls = new NodeListScreen(nl);
            DialogResult dr = nls.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                hiddenNodeList = nls.NodeList;
            }
        }
    }
}
