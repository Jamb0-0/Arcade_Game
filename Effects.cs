using System;
using System.Windows.Forms;
using System.Drawing;

namespace Курсовая_работа
{
    public class Effects
    {
        PictureBox effect_Shooting = new PictureBox();
        PictureBox effect_Explosion = new PictureBox();
        Timer Timer_effect_Shooting = new Timer();
        Timer Timer_effect_Explosion = new Timer();
        Form Form;
        Image[] img = { Properties.Resources.Effect_Explosion_1,
                        Properties.Resources.Effect_Explosion_2,
                        Properties.Resources.Effect_Explosion_3,
                        Properties.Resources.Effect_Explosion_4,
                        Properties.Resources.Effect_Explosion_5,
                        Properties.Resources.Effect_Explosion_6,
                        Properties.Resources.Effect_Explosion_7,
                        Properties.Resources.Effect_Explosion_8};
        int Shooting = 0;
        int Explosion = 0;

        public void _Effect_Shooting(Form form, Point Location, Image img)
        {
            Form = form;
            effect_Shooting.Size = new Size(10,20);
            effect_Shooting.Location = Location;
            effect_Shooting.SizeMode = PictureBoxSizeMode.StretchImage;
            effect_Shooting.BackColor = Color.Transparent;
            effect_Shooting.Image = img;

            Timer_effect_Shooting.Interval = 50;
            Timer_effect_Shooting.Tick += new EventHandler(Timer_Effect_Shooting);
            Timer_effect_Shooting.Start();

            form.Controls.Add(effect_Shooting);
            effect_Shooting.BringToFront();
        }


        public void _Effect_Explosion(Form form, Point Location)
        {
            Form = form;
            effect_Explosion.Size = new Size(img[Explosion].Width / 4, img[Explosion].Height / 4);
            effect_Explosion.SizeMode = PictureBoxSizeMode.StretchImage;
            effect_Explosion.Image = img[Explosion];
            effect_Explosion.BackColor = Color.Transparent;
            effect_Explosion.Location = Location;

            form.Controls.Add(effect_Explosion);

            Timer_effect_Explosion.Interval = 30;
            Timer_effect_Explosion.Tick += new EventHandler(Timer_Effect_Explosion);
            Timer_effect_Explosion.Enabled = true;
            Timer_effect_Explosion.Start();

            effect_Explosion.BringToFront();

        }

        void Timer_Effect_Shooting(object sender, EventArgs e)
        {
            effect_Shooting.BringToFront();
            if (Shooting == 1)
            {
                Form.Controls.Remove(effect_Shooting);
                effect_Shooting.Dispose();
                Timer_effect_Shooting.Stop();
                Timer_effect_Shooting.Dispose();
                Timer_effect_Shooting = null;
                effect_Shooting = null;
            }
            
            Shooting++;
        }

        void Timer_Effect_Explosion(object sender, EventArgs e)
        {
            Explosion++;
            if (Explosion != 8)
            {
                effect_Explosion.Size = new Size(img[Explosion].Width / 4, img[Explosion].Height / 4);
                effect_Explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                effect_Explosion.Image = img[Explosion];
                effect_Explosion.BackColor = Color.Transparent;
            }
            else
            {
                Form.Controls.Remove(effect_Explosion);
                effect_Explosion.Dispose();
                Timer_effect_Explosion.Stop();
                Timer_effect_Explosion.Dispose();
                Timer_effect_Explosion = null;
                effect_Explosion = null;
                img = null;
                
            }
        }
    }
}
