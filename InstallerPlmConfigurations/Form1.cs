using System.Diagnostics;
using System.Reflection;

namespace InstallerPlmConfigurations
{
    public partial class MainWindow : Form
    {
        private List<string> PlmInstallers { get; set; }
        private ConfigurationsForImport ConfigurationsForImport { get; set; }
        private XmlWorker DataConfigurations = new XmlWorker();
        public MainWindow()
        {
            InitializeComponent();
            SetPanelElement();
            PlmInstallers= new List<string>();
        }
        private void SetPanelElement()
        {
            WelcomeLabel.Text = "   Вас приветствует установщик пакетов конфигурации для Союз PLM!\n                    Для начала установки нажмите Далее.";
            NextStepButton.BackColor = Color.White;
            NextStepButton.FlatStyle = FlatStyle.Flat;
            NextStepButton.FlatAppearance.BorderColor = Color.WhiteSmoke;
            Bitmap bmp = InstallerPlmConfigurations.Properties.Resources.ait;
            bmp.MakeTransparent(Color.AliceBlue);
            LabelCompany.SizeMode = PictureBoxSizeMode.StretchImage;
            LabelCompany.Image = bmp;            
            ButtonCancel.BackColor = Color.White;
            ButtonCancel.FlatStyle = FlatStyle.Flat;
            ButtonCancel.FlatAppearance.BorderColor = Color.WhiteSmoke;
            ButtonYes.BackColor = Color.White;
            ButtonYes.FlatStyle = FlatStyle.Flat;
            ButtonYes.FlatAppearance.BorderColor = Color.WhiteSmoke;
            ButtonYes.Visible = false;
            ButtonYes.Enabled = false;
            ButtonNo.BackColor = Color.White;
            ButtonNo.FlatStyle = FlatStyle.Flat;
            ButtonNo.FlatAppearance.BorderColor = Color.WhiteSmoke;
            ButtonNo.Visible = false;
            ButtonNo.Enabled = false;
            ButtonReady.BackColor = Color.White;
            ButtonReady.FlatStyle = FlatStyle.Flat;
            ButtonReady.FlatAppearance.BorderColor = Color.WhiteSmoke;
            ButtonReady.Visible = false;
            ButtonReady.Enabled = false;
            ButtonExitProgram.BackColor= Color.White;
            ButtonExitProgram.FlatStyle = FlatStyle.Flat;
            ButtonExitProgram.FlatAppearance.BorderColor= Color.WhiteSmoke;
            ButtonExitProgram.Visible= false;
            ButtonExitProgram.Enabled = false;
            LabelChooseConf.Visible= false;
        }
        private void NextStepButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartPLMInstallers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
            }
        }
        private void StartPLMInstallers()
        {
            PlmInstallers = GetPlmInstallers();
            TypeOfInstall typeOfInstall = new TypeOfInstall();
            typeOfInstall = TypeOfInstall.BisClient;
            string msiBisFile = GetBisClientMsi();
            SetupBISClient(msiBisFile, typeOfInstall);
        }
        private List<string> GetPlmInstallers()
        {
            string pathInstallers = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"PLMInstallers");
            List<string> msiPlmInstallers = Directory.GetFiles(pathInstallers).Where(x => x.EndsWith(".msi")).ToList();
            return msiPlmInstallers;
        }
        private string GetBisClientMsi()
        {
            string bis = "bis";
            string msiBisFile = PlmInstallers.Where(m => m.ToLower().Contains(bis.ToLower())).First();
            return msiBisFile;
        }
        private void SetupBISClient(string msiBisFile, TypeOfInstall typeOfInstall)
        {
            Process setupBisClient = RunInstaller(msiBisFile);
            ExitInstall(setupBisClient.ExitCode, typeOfInstall);
        }
        private Process RunInstaller(string msiFile)
        {
            this.Visible = false;
            MsiInstallProcess msiInstallProcess = new MsiInstallProcess();
            Process process = msiInstallProcess.RunInstaller(msiFile);
            return process;
        }
        private void ExitInstall(int exitCode, TypeOfInstall typeOfInstall)
        {
            switch (exitCode)
            {
                case 0:
                    if (typeOfInstall == TypeOfInstall.BisClient)
                    {
                        PageChooseSetupPlatformSoyuzPLM();
                    }
                    else
                    {
                        EndSetupPlmPlatform();
                    }
                    break;
                case 1602:
                    this.Visible = true;
                    break;
                case 1604:
                case 1603:
                    WelcomeLabel.Text = "Произошла ошибка в процессе установки.";
                    this.Visible = true;
                    break;
            }
        }
        private void PageChooseSetupPlatformSoyuzPLM()
        {
            WelcomeLabel.Text = "               Установка БИС Програмсоюз прошла успешно.\nЖелаете установить Прикладную техническую платформу Союз-PLM?";
            WelcomeLabel.Visible = true;
            WelcomeLabel.Enabled= true;
            LabelChooseConf.Visible = false;
            NextStepButton.Visible = false;
            NextStepButton.Enabled = false;
            ButtonYes.Enabled = true;
            ButtonYes.Visible = true;
            ButtonNo.Enabled = true;
            ButtonNo.Visible = true;
            this.Visible = true;
        }
        private void ButtonYes_Click(object sender, EventArgs e)
        {
            try
            {
                string msiPlmPlatformFile = GetMsiPlmPlatform();
                Process setupPlmPlatform = RunInstaller(msiPlmPlatformFile);
                TypeOfInstall typeOfInstall = new TypeOfInstall();
                typeOfInstall = TypeOfInstall.PlmPlatform;                
                ExitInstall(setupPlmPlatform.ExitCode, typeOfInstall);
                FormationPageConfigs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string GetMsiPlmPlatform()
        {
            string plmSoyuz = "pmsz.plmsoyuz";
            string msiPlmPlatformFile = PlmInstallers.Where(m => m.Contains(plmSoyuz)).First();
            return msiPlmPlatformFile;
        }
        private void FormationPageConfigs()
        {
            PLMServers mainServer = new PLMServers();
            bool existServer = mainServer.CheckServer();
            if (existServer == true)
            {
                MakePanelElementsForCfgsVisible();
                SetCheckBoxesForPlmCfgs();
            }
            else
            {
                EndSetupPlmPlatform();
            }
        }
        private void MakePanelElementsForCfgsVisible()
        {
            WelcomeLabel.Enabled = false;
            WelcomeLabel.Visible = false;
            NextStepButton.Enabled = false;
            NextStepButton.Visible = false;
            ButtonReady.BackColor = Color.White;
            ButtonReady.FlatStyle = FlatStyle.Flat;
            ButtonReady.FlatAppearance.BorderColor = Color.WhiteSmoke;
            ButtonReady.Visible = true;
            ButtonReady.Enabled = true;
            ButtonExitProgram.Visible = false;
            ButtonExitProgram.Enabled = false;
            LabelChooseConf.Visible = true;
            LabelChooseConf.TextAlign = ContentAlignment.MiddleCenter;
            LabelChooseConf.Text = "Выберите нужные конфигурации.";
        }
        private void SetCheckBoxesForPlmCfgs()
        {
            List<string> plmConfigurationsNames = DataConfigurations.GetListConfigurations();
            int x = 52;
            int y = 42;
            ConfigurationsForImport = new ConfigurationsForImport();
            foreach (string configurationName in plmConfigurationsNames)
            {
                PLMConfiguration plmConfiguration = SetPlmConfig(configurationName);
                SetConfigCheckBox(configurationName, x, y);               
                ConfigurationsForImport.Configurations.Add(plmConfiguration);
                y += 25;
            }
        }        
        private void SetConfigCheckBox(string nameConfiguration, int x, int y)
        {
            CheckBox checkBox = new CheckBox()
            {
                Text = nameConfiguration,
                Name = $"CheckBox{nameConfiguration}",
                Location= new Point(x,y),
                Width = 500,
                ImageKey= $"CheckBox{nameConfiguration}",
            };
            this.Controls.Add(checkBox);
            this.Update();
        }
        private PLMConfiguration SetPlmConfig(string nameConfig)
        {
            PLMConfiguration plmCfg = new PLMConfiguration();
            plmCfg.NameCfg = nameConfig;
            return plmCfg;
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }
        private void ButtonReady_Click(object sender, EventArgs e)
        {
            var checkBoxes = GetControlsCheckBoxes();
            foreach (CheckBox checkBox in checkBoxes)
            {
                SetPlmConfig(checkBox);
            }
            ConfigurationsForImport.Configurations = ConfigurationsForImport.Configurations.Where(x => x.IsInstall == true).ToList();
            ConfigurationsForImport.ImportConfigurations();
            this.Visible = false;
            RunServers();
            RemoveCheckBoxes();
            EndSetupPlmPlatform();
        }
        private PLMConfiguration SetPlmConfig(CheckBox checkBox)
        {
            PLMConfiguration plmCfg = ConfigurationsForImport.Configurations.Where(c => c.NameCfg.Contains(checkBox.Text)).First();
            plmCfg.IsInstall = checkBox.Checked;
            plmCfg.FileNames = DataConfigurations.GetFileNames(checkBox.Text);
            return plmCfg;
        }
        private List<CheckBox> GetControlsCheckBoxes()
        {
            var checkBoxes = this.Controls.OfType<CheckBox>().ToList();
            return checkBoxes;
        }
        private void RunServers()
        {
            PLMServers mainServer = new PLMServers();
            mainServer.StartServers();
        }
        private void RemoveCheckBoxes()
        {
            LabelChooseConf.Visible= false;
            var checkBoxes = GetControlsCheckBoxes();
            foreach (CheckBox checkBox in checkBoxes)
            {
                this.Controls.Remove(checkBox);
            }
        }
        private void EndSetupPlmPlatform()
        {
            HiddenButtons();
            WelcomeLabel.Text = "                           Установка прошла успешно.";
            WelcomeLabel.Visible = true;
            WelcomeLabel.Enabled= true;
            ButtonReady.Enabled = false;
            ButtonReady.Visible = false;
            ButtonExitProgram.Enabled = true;
            ButtonExitProgram.Visible= true;
            ButtonCancel.Visible = false;
            ButtonCancel.Enabled = false;
            this.Visible = true;
        }        
        private void HiddenButtons()
        {
            ButtonYes.Visible = false;
            ButtonYes.Enabled = false;
            ButtonNo.Visible = false;
            ButtonNo.Enabled = false;
        }
        private void ExitProgram()
        {
            Environment.Exit(0);
        }
        private void ButtonNo_Click(object sender, EventArgs e)
        {
            HiddenButtons();
            FormationPageConfigs();
        }
        private void ButtonExitProgram_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }
    }
}