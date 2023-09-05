using System.Diagnostics;
using System.Management;

namespace InstallerPlmConfigurations
{
    internal class MsiInstallProcess
    {
        public Process RunInstaller(string msiFile)
        {
            Process msiPlmProc = new Process();
            msiPlmProc.StartInfo = new ProcessStartInfo(msiFile)
            {
                UseShellExecute = true
            };
            msiPlmProc.Start();
            ManagementEventWatcher checkerPlmServer = GetPlmServerCheker();
            msiPlmProc.WaitForExit();
            checkerPlmServer.Stop();
            return msiPlmProc;
        }
        private ManagementEventWatcher GetPlmServerCheker()
        {
            var query = new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace");
            ManagementEventWatcher checkerPlmServer = new ManagementEventWatcher(query);
            checkerPlmServer.EventArrived
                        += new EventArrivedEventHandler(StartCheckPlmServer_EventArrived);
            checkerPlmServer.Start();
            return checkerPlmServer;
        }
        private static void StartCheckPlmServer_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            if (processName == "PLMMainServer.exe"
                || processName == "PLMFileServer.exe")
            {
                int pid = Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value);
                var plmServerProcess = Process.GetProcessById(pid);
                plmServerProcess.Kill();
            }
        }
    }
}
