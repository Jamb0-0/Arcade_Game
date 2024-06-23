using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using WMPLib;

namespace Курсовая_работа
{
    static class Music
    {
        static WindowsMediaPlayer soundBullet = new WindowsMediaPlayer();
        static WindowsMediaPlayer soundDown = new WindowsMediaPlayer();
        static WindowsMediaPlayer soundEnter = new WindowsMediaPlayer();
        public static bool ON = true;

        public static void SoundButton(Form form)
        {
            soundEnter.URL = "Звук при наведении.mp3";
            soundDown.URL = "Звук при нажатии.mp3";
            soundDown.settings.volume = 50;
            soundEnter.settings.volume = 50;

            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1;

            timer.Tick += (sender,e) => 
            { 
                foreach (Control element in form.Controls)
                {
                    if (element is PictureBox && ((string)element.Tag == "buttonMenu" || (string)element.Tag == "buttonGame"))
                    {
                        element.MouseEnter -= SoundMouseEnter;
                        element.MouseDown -= SoundMouseDown;
                        element.MouseEnter +=  SoundMouseEnter;
                        element.MouseDown += SoundMouseDown;
                    }

                    else if(element is Panel || element is GroupBox)
                    {
                        foreach(var Pelement in element.Controls)
                        {
                            if(Pelement is PictureBox PB )
                            {
                                if((string)PB.Tag != "None")
                                {
                                    PB.MouseEnter -= SoundMouseEnter;
                                    PB.MouseDown -= SoundMouseDown;
                                    PB.MouseEnter += SoundMouseEnter;
                                    PB.MouseDown += SoundMouseDown;
                                }
                            }

                            else if(Pelement is Button B)
                            {
                                B.MouseEnter -= SoundMouseEnter;
                                B.MouseDown -= SoundMouseDown;
                                B.MouseEnter += SoundMouseEnter;
                                B.MouseDown += SoundMouseDown;
                            }
                        }
                    }
                }
            };
        }

        private static void SoundMouseEnter(object sender, EventArgs e)
        {
            if (ON)
            {
                soundEnter.controls.stop();
                soundEnter.controls.play();
            }
        }

        private static void SoundMouseDown(object sender, EventArgs e)
        {
            if (ON)
            {
                soundDown.controls.stop();
                soundDown.controls.play();
            }
        }

        public static void soundVolume(int volume)
        {
            soundDown.settings.volume = volume;
            soundEnter.settings.volume = volume;
            soundBullet.settings.volume = (int)(volume / 2.5);
        }

        public static void SoundBulletPlay()
        {
            if(ON)
            {
                soundEnter.controls.stop();
                soundBullet.URL = "Звук выстрела.mp3";
                soundBullet.controls.play();
            }
        }
    }

    static class BackgroundMusic
    {
        public static WindowsMediaPlayer soundBackGround = new WindowsMediaPlayer();

        public static void Backgroundmusic()
        {
            soundBackGround.URL = "фоновый звук.mp3";
            BackgroundMusic.soundVolume(10);

            soundBackGround.controls.play();
        }

        public static bool paused()
        {
            if (soundBackGround.playState == WMPPlayState.wmppsStopped)
            {
                return true;
            }
            return false;
        }

        public static void soundVolume(int volume)
        {
            soundBackGround.settings.volume = volume;
        }
    }
}
