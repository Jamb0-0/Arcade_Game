using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Курсовая_работа
{
    public partial class Form1 : Form
    {
        public static int sizeble = 16;

        Save save = new Save();
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Save));

        public Form1()
        {
            BackgroundMusic.Backgroundmusic();
            Music.SoundButton(this);

            InitializeComponent();

            if (File.Exists("test.json"))
                using (FileStream FS = new FileStream("test.json", FileMode.Open))
                {
                    save = json.ReadObject(FS) as Save;
                }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Shop.Hide();
            Records.Hide();
            Setting.Hide();
            inf.Hide();
            Start.Hide();
            Exit.Hide();
            new Complexity(this, save); //Game.cs
            GC.Collect();
        }

        private void Records_Click(object sender, EventArgs e)
        {
            new Records(this, save);
        }

        private void Shop_Click(object sender, EventArgs e)
        {
            new Shop(this, save);
        }

        bool saveing = false;
        private void Exit_Click(object sender, EventArgs e)
        {
            if(!saveing)
            {
                using (FileStream FS = new FileStream("test.json", FileMode.Create))
                {
                    json.WriteObject(FS, save);
                }
                saveing = true;
            }

            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saveing)
            {
                using (FileStream FS = new FileStream("test.json", FileMode.Create))
                {
                    json.WriteObject(FS, save);
                }
                saveing = true;
            }
        }

        public void Button_MouseEnter(object sender, EventArgs e)
        {
            PictureBox button =  (PictureBox)sender;
            button.Size = new Size(button.Size.Width + 6, button.Size.Height + 6);
            button.Location = new Point(button.Location.X - 3, button.Location.Y - 3);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            button.Size = new Size(button.Size.Width - 6, button.Size.Height - 6);
            button.Location = new Point(button.Location.X + 3, button.Location.Y + 3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BackgroundMusic.paused())
            {
                BackgroundMusic.soundBackGround.controls.play();
            }
            BackgroundMusic.soundVolume(MusicBar.Value);
            Music.soundVolume(sfxBar.Value);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            Setting.Hide();
            inf.Hide();

            settingMusic.Show();
            MusicBar.Show();
            OnOffMusic.Show();
            sfxBar.Show();
            OnOffsfx.Show();
            SettingBackMenu.Show();

            Controls.Add(settingMusic);
            Controls.Add(MusicBar);
            Controls.Add(OnOffMusic);
            Controls.Add(sfxBar);
            Controls.Add(OnOffsfx);
            Controls.Add(SettingBackMenu);

            settingMusic.BringToFront();
            MusicBar.BringToFront();
            OnOffMusic.BringToFront();
            sfxBar.BringToFront();
            OnOffsfx.BringToFront();
            SettingBackMenu.BringToFront();
        }

        private void OnOffsfx_Click(object sender, EventArgs e)
        {
            if (sfxBar.Value != 0)
            {
                sfxBar.Value = 0;
            }
            else
            {
                sfxBar.Value = 50;
            }
        }

        private void OnOffMusic_Click(object sender, EventArgs e)
        {
            if (MusicBar.Value != 0)
            {
                MusicBar.Value = 0;
            }
            else
            {
                MusicBar.Value = 10;
            }
        }

        private void SettingBackMenu_Click(object sender, EventArgs e)
        {
            Setting.Show();
            inf.Show();

            settingMusic.Hide();
            MusicBar.Hide();
            OnOffMusic.Hide();
            sfxBar.Hide();
            OnOffsfx.Hide();
            SettingBackMenu.Hide();

            Controls.Remove(settingMusic);
            Controls.Remove(MusicBar);
            Controls.Remove(OnOffMusic);
            Controls.Remove(sfxBar);
            Controls.Remove(OnOffsfx);
            Controls.Remove(SettingBackMenu);
            this.Focus();
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            TrackBar a = (TrackBar)sender;
            if(a.Name == "sfxBar")
            {
                Music.soundVolume(sfxBar.Value);
                if (sfxBar.Value != 0)
                {
                    Music.ON = true;
                    OnOffsfx.Image = Properties.Resources.ON;
                }

                else
                {
                    Music.ON = false;
                    OnOffsfx.Image = Properties.Resources.OFF;
                }

            }
            if(a.Name == "MusicBar")
            {
                BackgroundMusic.soundVolume(MusicBar.Value);
                if (MusicBar.Value != 0)
                    OnOffMusic.Image = Properties.Resources.ON;

                else
                    OnOffMusic.Image = Properties.Resources.OFF;
            }
        }

        bool bhelp = true;
        private void inf_Click(object sender, EventArgs e)
        {
            if (bhelp)
            {
                bhelp = !bhelp;
                HelpPanel.Show();
                Controls.Add(HelpPanel);
                HelpPanel.BringToFront();
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            HelpPanel.Hide();
            Controls.Remove(HelpPanel);
            Setting.Hide();
            inf.Hide();

            PictureBox Help = (PictureBox)sender;
            PictureBox PanelHelp = new PictureBox();
            PictureBox closepanel = new PictureBox();

            PanelHelp.SizeMode = PictureBoxSizeMode.StretchImage;
            PanelHelp.Size = new Size(505, 643);
            PanelHelp.Location = new Point(43, 62);

            closepanel.SizeMode = PictureBoxSizeMode.StretchImage;
            closepanel.Size = new Size(50, 50);
            closepanel.Location = new Point(490, 67);
            closepanel.Image = Properties.Resources.RecordBackMenu;
            closepanel.MouseEnter += new EventHandler(Button_MouseEnter);
            closepanel.MouseLeave += new EventHandler(Button_MouseLeave);
            closepanel.Tag = "buttonMenu";


            this.Controls.Add(PanelHelp);
            this.Controls.Add(closepanel);
            PanelHelp.BringToFront();
            closepanel.BringToFront();

            if ((string)Help.Tag == "HelpGame")
            {
                PanelHelp.Image = Properties.Resources.aboutGamePanel;
            }
            else if ((string)Help.Tag == "HelpTanks")
            {
                PanelHelp.Image = Properties.Resources.aboutTanksPanel;
            }
            else if ((string)Help.Tag == "HelpControl")
            {
                PanelHelp.Image = Properties.Resources.aboutControlPanel;
            }

            closepanel.Click += (s, a) =>
            {
                inf.Show();
                Setting.Show();
                bhelp = !bhelp;
                HelpPanel.Hide();
                Controls.Remove(HelpPanel);
                this.Controls.Remove(PanelHelp);
                this.Controls.Remove(closepanel);
                PanelHelp.Dispose();
                closepanel.Dispose();
                PanelHelp = null;
                closepanel = null;
                GC.Collect();
            };
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!bhelp)
            {
                bhelp = !bhelp;
                HelpPanel.Hide();
                Controls.Remove(HelpPanel);
            }
        }
    }
}
