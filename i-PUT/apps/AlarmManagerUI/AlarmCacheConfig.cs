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
using System.Data.SqlClient;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

using AlarmLib.PCD_ACM;

namespace AlarmManagerUI
{
    public partial class AlarmCacheConfig : UserControl
    {
        private string m_ConnectionString;

        public AlarmCacheConfig()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Name.StartsWith("tempLabel_")
                || Controls[i].Name.StartsWith("tempBox_"))
                {
                    Controls.RemoveAt(i--);
                }
            }

            AlarmCache ac = AlarmCache.Instance;

            int top = buttonInstall.Bottom + 2;
            int left = 0;

            buttonInstall.Left = left + 180;

            foreach (string item in ac.ConfigurationItems)
            {
                Label label = new Label();
                label.Text = item;
                label.Name = "tempLabel_" + item;
                label.Top = top;
                label.Left = left;
                label.Width = 180;

                TextBox box = new TextBox();
                box.Text = ac[item];
                box.Name = "tempBox_" + item;
                box.Top = top;
                box.Left = left + 180;
                box.Width = Width - box.Left - 10;
                box.Height = 50;
                box.Multiline = true;

                if (string.Compare(item, "Connection String", true) == 0)
                {
                    buttonInstall.Enabled = (box.Text.Length > 0);

                    m_ConnectionString = box.Text;

                    box.TextChanged += new EventHandler(connectionString_TextChanged);
                }

                Controls.Add(label);
                Controls.Add(box);
                top += 50;
            }

            this.MinimumSize = new Size(360, top);
        }

        void connectionString_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox box = (TextBox) sender;

                m_ConnectionString = box.Text;

                buttonInstall.Enabled = (box.Text.Length > 0);
            }
        }

        public bool Changed
        {
            get
            {
                AlarmCache ac = AlarmCache.Instance;

                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i].Name.StartsWith("tempBox_"))
                    {
                        string item = Controls[i].Name.Replace("tempBox_", string.Empty);
                        
                        if (string.Compare(ac[item], Controls[i].Text) != 0)
                            return true;
                    }
                }

                return false;
            }
        }

        public void Save()
        {
            AlarmCache ac = AlarmCache.Instance;

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Name.StartsWith("tempBox_"))
                {
                    string item = Controls[i].Name.Replace("tempBox_", string.Empty);

                    ac[item] = Controls[i].Text;
                }
            }
        }

        void AlarmCacheConfig_Resize(object sender, System.EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Name.StartsWith("tempBox_"))
                {
                    Controls[i].Width = Width - Controls[i].Left - 10;
                }
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if ((m_ConnectionString != null)
            &&  (m_ConnectionString.Length > 0))
            {
                SqlConnection conn = null;
                SqlCommand comm = null;

                try
                {
                    conn = new SqlConnection(m_ConnectionString);
                    comm = new SqlCommand(AlarmUIResource.create, conn);

                    conn.Open();
                    comm.ExecuteNonQuery();

                    MessageBox.Show("Database created successfully", "Database: Created!", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Creating of Database failed!", MessageBoxButtons.OK);
                }
                finally
                {
                    if (comm != null)
                    {
                        comm.Dispose();
                        comm = null;
                    }

                    if (conn != null)
                    {
                        if (conn.State == ConnectionState.Open)
                            conn.Close();

                        conn.Dispose();
                        conn = null;
                    }
                }
            }
        }
    }
}
