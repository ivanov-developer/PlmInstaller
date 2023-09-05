using System.Reflection;
using System.Xml.Linq;

namespace InstallerPlmConfigurations
{
    internal class XmlWorker
    {
        private XDocument XmlDoc { get; set; }
        private List<XElement> ConfigXmlElements { get; set; }
        private List<string> ConfigsFromSolution { get; set; }
        public List<string> GetListConfigurations()
        {
            List<string> configurationNames = new List<string>();
            foreach (XElement xmlElement in ConfigXmlElements)
            {
                string nameCfg = GetConfigurationName(xmlElement);
                configurationNames.Add(nameCfg);
            }
            return configurationNames;
        }
        private string GetConfigurationName(XElement xmlElement)
        {
            string name = xmlElement.Element("name").Value.ToString();
            return name;
        }
        public List<string> GetFileNames(string nameConfig)
        {
            List<string> files = new List<string>();
            XElement elementXml = GetXelement(nameConfig);
            XElement xElementFiles = elementXml.Element("files");
            List<XElement> fileNames = xElementFiles.Elements("filename").ToList();
            foreach (XElement fileName in fileNames)
            {
                files.Add(fileName.Value.ToString());
            }
            return files;
        }
        public string GetConfigPathFromFolder(string configFileNameFromXml)
        {
            string pathConfig = ConfigsFromSolution.Where(c => Path.GetFileName(c) == configFileNameFromXml).First();
            return pathConfig;
        }
        private XElement GetXelement(string configName)
        {
            XElement element = ConfigXmlElements.Where(x => x.Element("name").Value.ToString() == configName).First();
            return element;
        }        
        private List<string> GetPlmConfigurationsFromSolution()
        {
            string pathToConfigurations = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Configurations");
            List<string> plmConfigurations = Directory.GetFiles(pathToConfigurations).Where(x => x.EndsWith(".pmszcfg")).ToList();
            return plmConfigurations;
        }
        public XmlWorker()
        {
            string pathToXmlFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLs");
            string xmlPath = Directory.GetFiles(pathToXmlFolder).Where(f => f.EndsWith(".xml")).First();
            XmlDoc = XDocument.Load(xmlPath);
            ConfigXmlElements = XmlDoc.Root.Elements().Where(x => x.Name == "config").ToList();
            ConfigsFromSolution = GetPlmConfigurationsFromSolution();
        }
    }
}