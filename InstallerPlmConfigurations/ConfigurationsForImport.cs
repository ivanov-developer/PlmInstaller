
namespace InstallerPlmConfigurations
{
    internal class ConfigurationsForImport
    {
        public List<PLMConfiguration> Configurations { get; set; }
        public void ImportConfigurations()
        {
            string pathToServer = GetPathServer();
            AddConfigsInStartUpCfgs(pathToServer);
        }
        private string GetPathServer()
        {
            PLMServers mainServer = new PLMServers();
            string pathToServer = mainServer.GetPathToBIS();
            return pathToServer;
        }
        private void AddConfigsInStartUpCfgs(string pathToBis)
        {
            string pathToStrtUpCfgs = $"{pathToBis}\\Server\\StartUpCfgs";
            CopyConfigurations(pathToStrtUpCfgs);    
        }
        private void CopyConfigurations(string pathToStrtUpCfgs)
        {
            foreach (PLMConfiguration config in Configurations)
            {
                CopyFiles(config, pathToStrtUpCfgs);
            }
        }
        private void CopyFiles(PLMConfiguration config, string pathToStrtUpCfgs)
        {
            XmlWorker workerXml = new XmlWorker();
            foreach (string fileName in config.FileNames)
            {
                string pathToConfig = workerXml.GetConfigPathFromFolder(fileName);
                FileInfo fileInfo= new FileInfo(pathToConfig);
                string copyPath = $"{pathToStrtUpCfgs}\\{fileName}";
                fileInfo.CopyTo(copyPath,true);
            }
        }
        public ConfigurationsForImport()
        {
            Configurations= new List<PLMConfiguration>();
        }
    }
}
