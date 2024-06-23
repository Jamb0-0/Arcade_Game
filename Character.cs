using System;
using System.Windows.Forms;
using System.Drawing;

namespace Курсовая_работа
{
    public abstract class Character
    {
        protected PictureBox character = new PictureBox();
        protected  int speed, speedShoot;
        private int TimeShooting = 0;
        public ProgressBar TimeShootingBar = new ProgressBar();
        protected bool Left, Right, bullet, timeshoot = false;
        private Timer TimerCharacter = new Timer();
        private Timer TimerBullet = new Timer();
        protected Form form;
        public Bullet _Bullet = new Bullet();

        public void Destroy()
        {
            character = null;
            speed = 0;
            TimeShooting = 0;
            TimeShootingBar = null;
            Left = Right = bullet = false;
            TimerCharacter = null;
            TimerBullet = null;
            form = null;
            _Bullet = null;
        }

        public Character( Form _form)
        {
            form = _form;
            TimerCharacter.Interval = 20;
            TimerBullet.Interval = 20;
            character.Size = new Size(77, 80);
            character.SizeMode = PictureBoxSizeMode.StretchImage;
            character.Location = new Point(form.Width / 2 - character.Width / 2,
                                        form.Height - character.Height - character.Height);
            character.BringToFront();

            TimeShootingBar.Size = new Size(30, 5);
            TimeShootingBar.Minimum = 0;
            //TimeShootingBar.Maximum = TimeShooting/2;
            //TimeShootingBar.Value = TimeShooting/2;
            TimeShootingBar.Location = new Point(character.Left + character.Width / 2 - TimeShootingBar.Width / 2,
                                                character.Top + character.Height / 2 + TimeShootingBar.Height*4 );

            form.Controls.Add(TimeShootingBar);
            form.Controls.Add(character);
        }

        public void Timer_Start()
        {
            TimerCharacter.Start();
            TimerBullet.Start();
        }

        public void Timer_Stop()
        {
            TimerCharacter.Stop();
            TimerBullet.Stop();
        }

        public void Move()
        {
            TimerBullet.Tick += new EventHandler(Timer_Bullet);
            TimerBullet.Start();
            TimerCharacter.Tick += new EventHandler(Timer_Tick);
            TimerCharacter.Start();

            form.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                    Left = true;
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                    Right = true;
                if (e.KeyCode == Keys.Space)
                    bullet = false;
            };

            form.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                    Left = false;
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                    Right = false;
                if (e.KeyCode == Keys.Space)
                    bullet = true;
            };
        }

        protected void Timer_Bullet(object sender, EventArgs e)
        {
            if(!timeshoot)
            {
                timeshoot = true;
                TimeShooting = speedShoot;
                TimeShootingBar.Maximum = speedShoot != 30 ? speedShoot == 20 ? TimeShooting / 4 : TimeShooting / 5 : TimeShooting / 2;
                TimeShootingBar.Value = speedShoot != 30 ? speedShoot == 20 ? TimeShooting / 4 : TimeShooting / 5 : TimeShooting / 2;
            }

            if (TimeShooting <= TimeShootingBar.Maximum)
            {
                TimeShootingBar.Value = TimeShooting;
            }

            if (TimeShooting < speedShoot)
                TimeShooting++;

/*            if (TimeShooting <= TimeShootingBar.Maximum)
            {
                TimeShootingBar.Value = TimeShooting;
            }*/

            if (bullet && TimeShooting >= speedShoot)
            {
                Music.SoundBulletPlay();
                BulletShoot();


                int x = GetType() != typeof(Character_1) ? GetType() == typeof(Character_2) ? 32 : 30 : 28;
                if (Left == true)
                {
                    Effects effect = new Effects();
                    effect._Effect_Shooting(form, new Point(character.Left + x - speed, character.Top - 19),
                        GetType() != typeof(Character_1) ? GetType() == typeof(Character_2) ? Properties.Resources.Effect_Shooting_2 : Properties.Resources.Effect_Shooting : Properties.Resources.Effect_Shooting_1);
                }
                if (Right == true)
                {
                    Effects effect = new Effects();
                    effect._Effect_Shooting(form, new Point(character.Left + x + speed, character.Top - 19),
                        GetType() != typeof(Character_1) ? GetType() == typeof(Character_2) ? Properties.Resources.Effect_Shooting_2 : Properties.Resources.Effect_Shooting : Properties.Resources.Effect_Shooting_1);
                }
                if (Left == false && Right == false)
                {
                    Effects effect = new Effects();
                    effect._Effect_Shooting(form, new Point(character.Left + x, character.Top - 19),
                        GetType() != typeof(Character_1) ? GetType() == typeof(Character_2) ? Properties.Resources.Effect_Shooting_2 : Properties.Resources.Effect_Shooting : Properties.Resources.Effect_Shooting_1);
                }

                bullet = false;
                TimeShooting = 0;
            }
            else bullet = false;
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            if (Left && character.Left >= 8)
            {
                character.Left -= speed;
                TimeShootingBar.Left -= speed;
            }

            if (Right && character.Left <= form.Width - character.Width - 20)
            {
                character.Left += speed;
                TimeShootingBar.Left += speed;
            }
        }

        public virtual void BulletShoot()
        {}
    }

    public class Character_1 : Character
    {
        public Character_1( Form form) : base( form)
        {
            speed = 4;
            _Bullet.Damage = 10;
            speedShoot = 30;
            character.Image = Properties.Resources.character_tank_1;
            character.BackColor = Color.Transparent;
        }

        public override void BulletShoot()
        {
            _Bullet = new Bullet();
            _Bullet.Damage = 10;
            if (Left == true)
            {
                _Bullet.bulletLeft = character.Left + 28 - speed;
            }
            if (Right == true)
            {
                _Bullet.bulletLeft = character.Left + 28 + speed;
            }
            if (Left == false && Right == false)
            {
                _Bullet.bulletLeft = character.Left + 28;
            }
            _Bullet.bulletTop = character.Top + character.Height / 10;
            _Bullet._Bullet(form, Properties.Resources.Bullet_1, new Size(8,16));
        }
    }

    public class Character_2 : Character
    {
        public Character_2( Form form) : base( form)
        {
            speed = 2;
            _Bullet.Damage = 50;
            speedShoot = 50;
            character.Image = Properties.Resources.character_tank_2;
            character.BackColor = Color.Transparent;
        }
        public override void BulletShoot()
        {
             _Bullet = new Bullet();
            _Bullet.Damage = 50;
            if (Left == true)
            {
                _Bullet.bulletLeft = character.Left + 32 - speed;
            }
            if (Right == true)
            {
                _Bullet.bulletLeft = character.Left + 32 + speed;
            }
            if (Left == false && Right == false)
            {
                _Bullet.bulletLeft = character.Left + 32;
            }
            _Bullet.bulletTop = character.Top + character.Height / 10;
            _Bullet._Bullet(form, Properties.Resources.Bullet_5, new Size(16, 16));
        }
    }

    public class Character_3 : Character
    {
        public Character_3( Form form) : base( form)
        {
            speed = 6;
            _Bullet.Damage = 25;
            speedShoot = 5;
            character.Image = Properties.Resources.character_tank_3;
            character.BackColor = Color.Transparent;
        }
        public override void BulletShoot()
        {
             _Bullet = new Bullet();
            _Bullet.Damage = 25;
            if (Left == true)
            {
                _Bullet.bulletLeft = character.Left + 30 - speed;
            }
            if (Right == true)
            {
                _Bullet.bulletLeft = character.Left + 30 + speed;
            }
            if (Left == false && Right == false)
            {
                _Bullet.bulletLeft = character.Left + 30;
            }
            _Bullet.bulletTop = character.Top + character.Height / 10;
            _Bullet._Bullet(form, Properties.Resources.Bullet_4, new Size(8,36));
        }
    }
}
