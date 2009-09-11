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
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Text;

namespace AlarmManagerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(String[] args)
        {
            if (args.Length == 1)
            {
                try
                {
                    if (String.Compare(args[0], "--install") == 0)
                    {
                        Hashtable ht = new Hashtable();

                        TransactedInstaller ti = new TransactedInstaller();
                        AlarmManagerInstall ami = new AlarmManagerInstall();
                        ti.Installers.Add(ami);
                        String path = String.Format("/assemblypath={0}", System.Reflection.Assembly.GetExecutingAssembly().Location);
                        String[] cmdline = { path };
                        InstallContext ctx = new InstallContext("", cmdline);
                        ti.Context = ctx;
                        ti.Install(ht);
                    }
                    else if (String.Compare(args[0], "--uninstall") == 0)
                    {
                        TransactedInstaller ti = new TransactedInstaller();
                        AlarmManagerInstall ami = new AlarmManagerInstall();
                        ti.Installers.Add(ami);
                        String path = String.Format("/assemblypath={0}",
                        System.Reflection.Assembly.GetExecutingAssembly().Location);
                        String[] cmdline = { path };
                        InstallContext ctx = new InstallContext("", cmdline);
                        ti.Context = ctx;
                        ti.Uninstall(null);
                    }
                    else if (String.Compare(args[0], "--debug") == 0)
                    {
                        AlarmManagerService service = new AlarmManagerService();

                        service.UseEventLog = false;

                        service.LoadConfig();
                        service.Run();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Running from command line failed");
                    Console.WriteLine();
                    Console.WriteLine(ex.ToString());
                }

                return;
            }

            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new AlarmManagerService() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}