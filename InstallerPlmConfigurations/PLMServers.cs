using Microsoft.Win32;
using System.Diagnostics;
using System.ServiceProcess;

namespace InstallerPlmConfigurations
{
    internal class PLMServers
    {
        public bool CheckServer()
        {
            string pathToBis = GetPathToBIS();
            bool serverExist = false;
            if (pathToBis != "")
            { 
                string pathToServer = $"{pathToBis}\\Server\\PLMMainServer.exe";
                if (File.Exists(pathToServer))
                {
                    serverExist = true;
                }
            }            
            return serverExist;
        }
        public string GetPathToBIS()
        {
            string pathToBis = "";
            string pathReestr = @"SOFTWARE\ProgramSoyuz\BIS\3.0";
            RegistryKey reestr = Registry.LocalMachine;
            RegistryKey bis = reestr.OpenSubKey(pathReestr);
            if (bis != null)
            {
                pathToBis = bis.GetValue("Path").ToString();
            }
            return pathToBis;
        }
        public void StartServers()
        {
            string pathToBis = GetPathToBIS();
            string pathToMainServer = $"{pathToBis}\\Server\\PLMMainServer -config.lnk";
            string pathToFileServer = $"{pathToBis}\\Server\\PLMFileServer -config.lnk";
            string nameMainServerService = "PMSZ.BIS-MT";
            string nameFileServerService = "PMSZ.PLMFRM-FS";
            bool mainServerExist = StartServer(pathToMainServer);         
            if (mainServerExist == true)
            {
                StartPLMService(nameMainServerService);
                bool fileServerExist = StartServer(pathToFileServer);
                if (fileServerExist == true)
                {
                    StartPLMService(nameFileServerService);
                }
            }
        }
        private bool StartServer(string pathToServer)
        {
            bool isExist = false;
            if (File.Exists(pathToServer) == true)
            {
                Process plmServer = new Process();
                plmServer.StartInfo = new ProcessStartInfo
                {
                    FileName = pathToServer,
                    UseShellExecute = true
                };
                plmServer.Start();
                plmServer.WaitForExit();
                isExist = true;
            }
            return isExist;
        }
        private void StartPLMService(string nameService)
        {
            try
            {
                ServiceController service = new ServiceController(nameService);
                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                }
            }
            catch (InvalidOperationException)
            {
                StartPlmServiceFromCmd(nameService);
            }
            
        }
        private void StartPlmServiceFromCmd(string nameService)
        {
            string pathToServer = GetPathToServer(nameService);
            string quote = "\"";
            string rowConnect = quote+pathToServer+quote+ " -install";
            Process cmd = new Process();
            cmd.StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = "/C"+rowConnect,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            cmd.Start();
            StartPLMService(nameService);
        }
        private string GetPathToServer(string nameService)
        {
            string pathToBis = GetPathToBIS();
            string pathToServer = $"{pathToBis}\\Server";
            if (nameService == "PMSZ.BIS-MT")
            {
                pathToServer = $"{pathToServer}\\PLMMainServer.exe";
            }
            else
            {
                pathToServer = $"{pathToServer}\\PLMFileServer.exe";
            }
            return pathToServer;
        }
        public PLMServers() 
        {
            
        }
    }
}
