using System;
using System.Windows.Forms;
using System.Drawing;

namespace Курсовая_работа
{
    public class Bullet
    {
        protected PictureBox bullet = new PictureBox();
        protected Timer TimerBullet = new Timer();

        public int bulletLeft;
        public int bulletTop;
        public int Speed { get; set; } = 20;
        public int Damage { get; set; }
        protected Form Form;

        public virtual void Destroy()
        {
            bullet = null;
            TimerBullet = null;
            Form = null;
        }

        public virtual void _Bullet(Form form, Image img, Size size)
        {
            Form = form;
          //  bullet.Size = new Size(8, 16);
            bullet.Size = size;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.Tag = "bullet";
            bullet.BackColor = Color.Transparent;
            bullet.Image = img;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            TimerBullet.Interval = 20;
            TimerBullet.Tick += new EventHandler(Time_Tick);
            TimerBullet.Start();
        }



        public void Tag_Bullet(string teg)
        {
            bullet.Tag =  teg;
        }

        protected virtual void Time_Tick(object sender, EventArgs e)
        {
            if (bullet != null)
            { 
                bullet.Top -= (int)(Speed / 1.5);
                bullet.BringToFront();

                if (bullet.Top < 10 || bullet.Top > 800)
                {
                    Form.Controls.Remove(bullet);
                    TimerBullet.Stop();
                    TimerBullet.Dispose();
                    bullet.Dispose();
                    TimerBullet = null;
                    bullet = null;
                }
            }
        }
    }

    public class BulletEnemy1 : Bullet
    {
        Image[] img = { Properties.Resources.Flame_1,
                        Properties.Resources.Flame_2,
                        Properties.Resources.Flame_3,
                        Properties.Resources.Flame_4,
                        Properties.Resources.Flame_5,
                        Properties.Resources.Flame_6,
                        Properties.Resources.Flame_7,
                        Properties.Resources.Flame_8};
        int Bullet_Enemy_1 = 0;

        public override void Destroy()
        {
            img = null;
            base.Destroy();
        }

        public override void _Bullet(Form form, Image image, Size size)
        {
            Form = form;
            bullet.Size = new Size(img[Bullet_Enemy_1].Width, img[Bullet_Enemy_1].Height);
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.Tag = "bullet";
            bullet.BackColor = Color.Transparent;
            bullet.Image = img[Bullet_Enemy_1];
            bullet.BringToFront();

            TimerBullet.Interval = 40;
            TimerBullet.Tick += new EventHandler(Time_Tick);
            TimerBullet.Start();

            form.Controls.Add(bullet);
        }

        protected override void Time_Tick(object sender, EventArgs e)
        {
            if (bullet != null)
            {
                Bullet_Enemy_1++;
                if (Bullet_Enemy_1 != 8)
                {
                    bullet.Image = img[Bullet_Enemy_1];
                    if (Bullet_Enemy_1 == 7)
                        bullet.Top -= Speed;
                }
                else
                {
                    Form.Controls.Remove(bullet);
                    bullet.Dispose();
                    TimerBullet.Stop();
                    TimerBullet.Dispose();
                    TimerBullet = null;
                    bullet = null;
                    img = null;
                }
            }
        }
    }
}



