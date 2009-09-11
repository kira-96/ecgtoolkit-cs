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
using System.Diagnostics;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;

using AlarmLib.HL7;
using AlarmLib.PCD_ACM;

namespace AlarmManagerService
{
    public partial class AlarmManagerService : ServiceBase
    {
        private MLLPServerFarm _Receivers;
        private AlarmManager _Manager;
        public bool UseEventLog = true;

        public AlarmManagerService()
        {
            InitializeComponent();

            _Receivers = new MLLPServerFarm();
            _Manager = new AlarmManager(_Receivers);

            _Manager.OnError = new AlarmManager.OnErrorHandler(Manager_OnError);
        }

        public void Check()
        {
            if (_Manager != null)
                _Manager.MatchList.Load(null);
        }

        public void LoadConfig()
        {
            try
            {
                if (_Receivers != null)
                {
                    _Receivers.OnIteration = new ThreadStart(this.Check);
                    _Receivers.Servers.Load(@"AlarmManager.cfg");

                    _Receivers.OnError = new MLLPServer.OnErrorHandler(this.HandleError);
                    _Receivers.OnMessage = new MLLPServer.OnMessageHandler(this.HandleMessage);
                }

                if (_Manager != null)
                {
                    _Manager.Init();
                    _Manager.AlarmDisseminators.Load(@"AlarmDisseminator.cfg");
                    _Manager.MatchList.Load(@"MatchList.cfg");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Error: {0}", ex.ToString());

                if (UseEventLog)
                {
                    this.EventLog.WriteEntry(sb.ToString(), EventLogEntryType.Error);
                }
                else
                {
                    Console.WriteLine(sb.ToString());
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            LoadConfig();

            _Receivers.DoStart();
            _Manager.DoStart();
        }

        protected override void OnStop()
        {
            if (_Manager != null)
                _Manager.DoStop();

            if (_Receivers != null)
                _Receivers.DoStop();
        }

        protected override void OnPause()
        {
            if (_Manager != null)
                _Manager.DoStop();

            if (_Receivers != null)
                _Receivers.DoPause();   
        }

        protected override void OnContinue()
        {
            LoadConfig();

            if (_Manager != null)
                _Manager.DoStart();

            if (_Receivers != null)
                _Receivers.DoContinue();
        }

        public void Run()
        {
            string sLine = null;

            OnStart(null);

            while ((sLine = System.Console.ReadLine()) != null)
            {
                if (string.Compare(sLine, "quit", true) == 0)
                    break;
            }

            OnStop();
        }

        private bool HandleError(MLLPServer server, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Error: {0}: {1}", (server != null ? server.ToString() : "NULL"), ex.ToString());

            if (UseEventLog)
            {
                this.EventLog.WriteEntry(sb.ToString(), EventLogEntryType.Error);
            }
            else
            {
                lock (this)
                {
                    Console.WriteLine(sb.ToString());
                }
            }

            return true;
        }

        void Manager_OnError(AlarmManager am, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Error: Manager {0}", ex.ToString());

            if (UseEventLog)
            {
                this.EventLog.WriteEntry(sb.ToString(), EventLogEntryType.Error);
            }
            else
            {
                lock (this)
                {
                    Console.WriteLine(sb.ToString());
                }
            }
        }

        private AlarmLib.HL7.HL7SegmentMSA HandleMessage(AlarmLib.HL7.MLLPServer server, AlarmLib.HL7.MLLPAdaptor adaptor, AlarmLib.HL7.HL7Message msg)
        {
            HL7SegmentMSA msa = null;

            if ((adaptor != null)
            && (msg != null)
            && !msg.Empty)
            {
                msa = _Manager.HandleMessage(server, adaptor, msg);
            }

            return msa;
        }
    }
}
