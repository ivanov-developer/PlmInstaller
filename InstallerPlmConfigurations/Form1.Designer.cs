namespace InstallerPlmConfigurations
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelCompany = new System.Windows.Forms.PictureBox();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonYes = new System.Windows.Forms.Button();
            this.ButtonReady = new System.Windows.Forms.Button();
            this.LabelChooseConf = new System.Windows.Forms.Label();
            this.ButtonNo = new System.Windows.Forms.Button();
            this.ButtonExitProgram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LabelCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelCompany
            // 
            this.LabelCompany.Location = new System.Drawing.Point(600, 12);
            this.LabelCompany.Name = "LabelCompany";
            this.LabelCompany.Size = new System.Drawing.Size(70, 70);
            this.LabelCompany.TabIndex = 0;
            this.LabelCompany.TabStop = false;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WelcomeLabel.Location = new System.Drawing.Point(64, 214);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(55, 23);
            this.WelcomeLabel.TabIndex = 1;
            this.WelcomeLabel.Text = "label1";
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(576, 364);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(94, 29);
            this.NextStepButton.TabIndex = 2;
            this.NextStepButton.Text = "Далее";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(12, 364);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(94, 29);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonYes
            // 
            this.ButtonYes.Location = new System.Drawing.Point(576, 364);
            this.ButtonYes.Name = "ButtonYes";
            this.ButtonYes.Size = new System.Drawing.Size(94, 29);
            this.ButtonYes.TabIndex = 4;
            this.ButtonYes.Text = "Да";
            this.ButtonYes.UseVisualStyleBackColor = true;
            this.ButtonYes.Click += new System.EventHandler(this.ButtonYes_Click);
            // 
            // ButtonReady
            // 
            this.ButtonReady.Location = new System.Drawing.Point(576, 364);
            this.ButtonReady.Name = "ButtonReady";
            this.ButtonReady.Size = new System.Drawing.Size(94, 29);
            this.ButtonReady.TabIndex = 5;
            this.ButtonReady.Text = "Готово";
            this.ButtonReady.UseVisualStyleBackColor = true;
            this.ButtonReady.Click += new System.EventHandler(this.ButtonReady_Click);
            // 
            // LabelChooseConf
            // 
            this.LabelChooseConf.AutoSize = true;
            this.LabelChooseConf.Location = new System.Drawing.Point(188, 12);
            this.LabelChooseConf.Name = "LabelChooseConf";
            this.LabelChooseConf.Size = new System.Drawing.Size(50, 20);
            this.LabelChooseConf.TabIndex = 6;
            this.LabelChooseConf.Text = "label2";
            // 
            // ButtonNo
            // 
            this.ButtonNo.Location = new System.Drawing.Point(12, 364);
            this.ButtonNo.Name = "ButtonNo";
            this.ButtonNo.Size = new System.Drawing.Size(94, 29);
            this.ButtonNo.TabIndex = 7;
            this.ButtonNo.Text = "Нет";
            this.ButtonNo.UseVisualStyleBackColor = true;
            this.ButtonNo.Click += new System.EventHandler(this.ButtonNo_Click);
            // 
            // ButtonExitProgram
            // 
            this.ButtonExitProgram.Location = new System.Drawing.Point(576, 364);
            this.ButtonExitProgram.Name = "ButtonExitProgram";
            this.ButtonExitProgram.Size = new System.Drawing.Size(100, 29);
            this.ButtonExitProgram.TabIndex = 8;
            this.ButtonExitProgram.Text = "Завершить";
            this.ButtonExitProgram.UseVisualStyleBackColor = true;
            this.ButtonExitProgram.Click += new System.EventHandler(this.ButtonExitProgram_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.ButtonExitProgram);
            this.Controls.Add(this.ButtonNo);
            this.Controls.Add(this.LabelChooseConf);
            this.Controls.Add(this.ButtonReady);
            this.Controls.Add(this.ButtonYes);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.LabelCompany);
            this.MaximumSize = new System.Drawing.Size(700, 497);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Установщик Союз PLM и пакетов конфигурации";
            ((System.ComponentModel.ISupportInitialize)(this.LabelCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox LabelCompany;
        private Label WelcomeLabel;
        private Button NextStepButton;
        private Button ButtonCancel;
        private Button ButtonYes;
        private Button ButtonReady;
        private Label LabelChooseConf;
        private Button ButtonNo;
        private Button ButtonExitProgram;
    }
}