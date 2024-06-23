
namespace Курсовая_работа
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        //// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.Shop = new System.Windows.Forms.PictureBox();
            this.Setting = new System.Windows.Forms.PictureBox();
            this.Records = new System.Windows.Forms.PictureBox();
            this.inf = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OnOffsfx = new System.Windows.Forms.PictureBox();
            this.sfxBar = new System.Windows.Forms.TrackBar();
            this.OnOffMusic = new System.Windows.Forms.PictureBox();
            this.MusicBar = new System.Windows.Forms.TrackBar();
            this.SettingBackMenu = new System.Windows.Forms.PictureBox();
            this.HelpPanel = new System.Windows.Forms.Panel();
            this.HelpGame = new System.Windows.Forms.PictureBox();
            this.HelpControl = new System.Windows.Forms.PictureBox();
            this.HelpTanks = new System.Windows.Forms.PictureBox();
            this.settingMusic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Setting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnOffsfx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnOffMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBackMenu)).BeginInit();
            this.HelpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HelpGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpTanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Transparent;
            this.Start.Image = global::Курсовая_работа.Properties.Resources.Start;
            this.Start.Location = new System.Drawing.Point(222, 383);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(130, 62);
            this.Start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Start.TabIndex = 2;
            this.Start.TabStop = false;
            this.Start.Tag = "buttonMenu";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            this.Start.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Start.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Image = global::Курсовая_работа.Properties.Resources.Exit;
            this.Exit.Location = new System.Drawing.Point(233, 457);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(108, 55);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit.TabIndex = 3;
            this.Exit.TabStop = false;
            this.Exit.Tag = "buttonMenu";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // Shop
            // 
            this.Shop.Image = global::Курсовая_работа.Properties.Resources.Shop;
            this.Shop.Location = new System.Drawing.Point(150, 432);
            this.Shop.Name = "Shop";
            this.Shop.Size = new System.Drawing.Size(61, 56);
            this.Shop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Shop.TabIndex = 4;
            this.Shop.TabStop = false;
            this.Shop.Tag = "buttonMenu";
            this.Shop.Click += new System.EventHandler(this.Shop_Click);
            this.Shop.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Shop.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // Setting
            // 
            this.Setting.Image = global::Курсовая_работа.Properties.Resources.setting;
            this.Setting.Location = new System.Drawing.Point(12, 12);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(61, 56);
            this.Setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Setting.TabIndex = 5;
            this.Setting.TabStop = false;
            this.Setting.Tag = "buttonMenu";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
            this.Setting.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Setting.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // Records
            // 
            this.Records.Image = global::Курсовая_работа.Properties.Resources.Records;
            this.Records.Location = new System.Drawing.Point(364, 432);
            this.Records.Name = "Records";
            this.Records.Size = new System.Drawing.Size(61, 56);
            this.Records.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Records.TabIndex = 6;
            this.Records.TabStop = false;
            this.Records.Tag = "buttonMenu";
            this.Records.Click += new System.EventHandler(this.Records_Click);
            this.Records.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Records.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // inf
            // 
            this.inf.Image = global::Курсовая_работа.Properties.Resources.inf;
            this.inf.Location = new System.Drawing.Point(536, 742);
            this.inf.Name = "inf";
            this.inf.Size = new System.Drawing.Size(61, 56);
            this.inf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inf.TabIndex = 7;
            this.inf.TabStop = false;
            this.inf.Tag = "buttonMenu";
            this.inf.Click += new System.EventHandler(this.inf_Click);
            this.inf.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.inf.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OnOffsfx
            // 
            this.OnOffsfx.Image = global::Курсовая_работа.Properties.Resources.ON;
            this.OnOffsfx.Location = new System.Drawing.Point(435, 235);
            this.OnOffsfx.Name = "OnOffsfx";
            this.OnOffsfx.Size = new System.Drawing.Size(31, 29);
            this.OnOffsfx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OnOffsfx.TabIndex = 9;
            this.OnOffsfx.TabStop = false;
            this.OnOffsfx.Tag = "buttonMenu";
            this.OnOffsfx.Visible = false;
            this.OnOffsfx.Click += new System.EventHandler(this.OnOffsfx_Click);
            this.OnOffsfx.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.OnOffsfx.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // sfxBar
            // 
            this.sfxBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.sfxBar.Location = new System.Drawing.Point(122, 290);
            this.sfxBar.Maximum = 100;
            this.sfxBar.Name = "sfxBar";
            this.sfxBar.Size = new System.Drawing.Size(344, 45);
            this.sfxBar.TabIndex = 11;
            this.sfxBar.TabStop = false;
            this.sfxBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sfxBar.Value = 50;
            this.sfxBar.Visible = false;
            this.sfxBar.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // OnOffMusic
            // 
            this.OnOffMusic.Image = global::Курсовая_работа.Properties.Resources.ON;
            this.OnOffMusic.Location = new System.Drawing.Point(435, 376);
            this.OnOffMusic.Name = "OnOffMusic";
            this.OnOffMusic.Size = new System.Drawing.Size(31, 28);
            this.OnOffMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OnOffMusic.TabIndex = 10;
            this.OnOffMusic.TabStop = false;
            this.OnOffMusic.Tag = "buttonMenu";
            this.OnOffMusic.Visible = false;
            this.OnOffMusic.Click += new System.EventHandler(this.OnOffMusic_Click);
            this.OnOffMusic.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.OnOffMusic.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // MusicBar
            // 
            this.MusicBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.MusicBar.Location = new System.Drawing.Point(122, 432);
            this.MusicBar.Maximum = 50;
            this.MusicBar.Name = "MusicBar";
            this.MusicBar.Size = new System.Drawing.Size(344, 45);
            this.MusicBar.TabIndex = 12;
            this.MusicBar.TabStop = false;
            this.MusicBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.MusicBar.Value = 10;
            this.MusicBar.Visible = false;
            this.MusicBar.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // SettingBackMenu
            // 
            this.SettingBackMenu.Image = global::Курсовая_работа.Properties.Resources.SettingBackMenu;
            this.SettingBackMenu.Location = new System.Drawing.Point(437, 136);
            this.SettingBackMenu.Name = "SettingBackMenu";
            this.SettingBackMenu.Size = new System.Drawing.Size(40, 40);
            this.SettingBackMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingBackMenu.TabIndex = 13;
            this.SettingBackMenu.TabStop = false;
            this.SettingBackMenu.Tag = "buttonMenu";
            this.SettingBackMenu.Visible = false;
            this.SettingBackMenu.Click += new System.EventHandler(this.SettingBackMenu_Click);
            this.SettingBackMenu.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.SettingBackMenu.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // HelpPanel
            // 
            this.HelpPanel.BackgroundImage = global::Курсовая_работа.Properties.Resources.Help;
            this.HelpPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HelpPanel.Controls.Add(this.HelpGame);
            this.HelpPanel.Controls.Add(this.HelpControl);
            this.HelpPanel.Controls.Add(this.HelpTanks);
            this.HelpPanel.Location = new System.Drawing.Point(536, 505);
            this.HelpPanel.Name = "HelpPanel";
            this.HelpPanel.Size = new System.Drawing.Size(61, 239);
            this.HelpPanel.TabIndex = 18;
            this.HelpPanel.Visible = false;
            // 
            // HelpGame
            // 
            this.HelpGame.Image = global::Курсовая_работа.Properties.Resources.aboutgame;
            this.HelpGame.Location = new System.Drawing.Point(0, 23);
            this.HelpGame.Name = "HelpGame";
            this.HelpGame.Size = new System.Drawing.Size(61, 61);
            this.HelpGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HelpGame.TabIndex = 21;
            this.HelpGame.TabStop = false;
            this.HelpGame.Tag = "HelpGame";
            this.HelpGame.Click += new System.EventHandler(this.Help_Click);
            this.HelpGame.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.HelpGame.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // HelpControl
            // 
            this.HelpControl.Image = global::Курсовая_работа.Properties.Resources.aboutcontrol;
            this.HelpControl.Location = new System.Drawing.Point(0, 160);
            this.HelpControl.Name = "HelpControl";
            this.HelpControl.Size = new System.Drawing.Size(61, 61);
            this.HelpControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HelpControl.TabIndex = 19;
            this.HelpControl.TabStop = false;
            this.HelpControl.Tag = "HelpControl";
            this.HelpControl.Click += new System.EventHandler(this.Help_Click);
            this.HelpControl.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.HelpControl.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // HelpTanks
            // 
            this.HelpTanks.Image = global::Курсовая_работа.Properties.Resources.aboutenemy;
            this.HelpTanks.Location = new System.Drawing.Point(0, 91);
            this.HelpTanks.Name = "HelpTanks";
            this.HelpTanks.Size = new System.Drawing.Size(61, 61);
            this.HelpTanks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HelpTanks.TabIndex = 20;
            this.HelpTanks.TabStop = false;
            this.HelpTanks.Tag = "HelpTanks";
            this.HelpTanks.Click += new System.EventHandler(this.Help_Click);
            this.HelpTanks.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.HelpTanks.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // settingMusic
            // 
            this.settingMusic.Image = global::Курсовая_работа.Properties.Resources.settingMusic;
            this.settingMusic.Location = new System.Drawing.Point(93, 132);
            this.settingMusic.Name = "settingMusic";
            this.settingMusic.Size = new System.Drawing.Size(392, 404);
            this.settingMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingMusic.TabIndex = 8;
            this.settingMusic.TabStop = false;
            this.settingMusic.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Курсовая_работа.Properties.Resources.BackGroundMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 800);
            this.Controls.Add(this.HelpPanel);
            this.Controls.Add(this.SettingBackMenu);
            this.Controls.Add(this.MusicBar);
            this.Controls.Add(this.sfxBar);
            this.Controls.Add(this.OnOffMusic);
            this.Controls.Add(this.OnOffsfx);
            this.Controls.Add(this.settingMusic);
            this.Controls.Add(this.inf);
            this.Controls.Add(this.Records);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.Shop);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Start);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Наземная война: танки";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Setting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnOffsfx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnOffMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBackMenu)).EndInit();
            this.HelpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HelpGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelpTanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingMusic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox OnOffsfx;
        private System.Windows.Forms.TrackBar sfxBar;
        private System.Windows.Forms.PictureBox OnOffMusic;
        public System.Windows.Forms.PictureBox Setting;
        public System.Windows.Forms.PictureBox Start;
        public System.Windows.Forms.PictureBox Exit;
        public System.Windows.Forms.PictureBox Shop;
        public System.Windows.Forms.PictureBox Records;
        public System.Windows.Forms.PictureBox inf;
        private System.Windows.Forms.TrackBar MusicBar;
        private System.Windows.Forms.PictureBox SettingBackMenu;
        private System.Windows.Forms.Panel HelpPanel;
        private System.Windows.Forms.PictureBox HelpGame;
        private System.Windows.Forms.PictureBox HelpControl;
        private System.Windows.Forms.PictureBox HelpTanks;
        private System.Windows.Forms.PictureBox settingMusic;
    }
}

