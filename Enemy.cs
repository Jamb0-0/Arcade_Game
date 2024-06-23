using System;
using System.Windows.Forms;
using System.Drawing;

namespace Курсовая_работа
{
    public abstract class Enemy
    {
        protected PictureBox enemy = new PictureBox();
        protected PictureBox HP_icon = new PictureBox();
        private Timer TimerEnemy = new Timer();
        protected int HP, speed;
        protected int TimeShooting = 100;
        protected int Length;
        private ProgressBar HPBar = new ProgressBar();
        private int CharacterBulletDamage;
        protected Form Form;
        public Bullet _Bullet = new Bullet();
        public static int destroyed_Tank = 0;
        public static byte Tank_amount = 0;

        public virtual void Destroy()
        {
            enemy = null;
            HP_icon = null;
            TimerEnemy = null;
            HPBar = null;
            Form = null;
            _Bullet = null;
        }

        public virtual void _Enemy(Form form, int characterBulletDamage)
        {
            Form = form;
            CharacterBulletDamage = characterBulletDamage;
            Random rand = new Random(DateTime.Now.Millisecond);
            enemy.Size = new Size(enemy.Image.Width / 5, enemy.Image.Height / 5);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy.Top = rand.Next(-50 - enemy.Height, -5 - enemy.Height);
            enemy.Left = rand.Next(8, Form.Width - enemy.Width - 16);
            enemy.BackColor = Color.Transparent;
            enemy.Tag = "enemy";

            HPBar.Size = new Size(50, 5);
            HPBar.Minimum = 0;
            HPBar.Maximum = HP;
            HPBar.Value = HP;
            HPBar.Location = new Point(enemy.Left + enemy.Width / 2 - HPBar.Width / 2,
                                        enemy.Top + enemy.Height / 2 - HPBar.Height * 4);

            HP_icon.Size = new Size(10, 10);
            HP_icon.SizeMode = PictureBoxSizeMode.StretchImage;
            HP_icon.Image = Properties.Resources.HP;
            HP_icon.Top = HPBar.Top;
            HP_icon.Left = HPBar.Left-12;
            HP_icon.BackColor = Color.Transparent;

            Tank_amount++;
            Form.Controls.Add(HP_icon);
            Form.Controls.Add(HPBar);
            Form.Controls.Add(enemy);

            TimerEnemy.Interval = 50;
            TimerEnemy.Tick += new EventHandler(Tick_Enemy);
            TimerEnemy.Start();

            enemy.BringToFront();
            HPBar.BringToFront();
            HP_icon.BringToFront();
        }

        public void Timer_Start()
        {
            TimerEnemy.Start();
        }

        public void Timer_Stop()
        {
            TimerEnemy.Stop();
        }

        public bool EmptyPB()
        {
            return enemy == null ? true : false;
        }

        protected void Tick_Enemy(object sender, EventArgs e)
        {
            if (enemy.Top < Length)
            {
                HP_icon.Top = HPBar.Top;
                HP_icon.Left = HPBar.Left-12;
                enemy.Top += speed;
                HPBar.Location = new Point(enemy.Left + enemy.Width / 2 - HPBar.Width / 2,
                        enemy.Top + enemy.Height / 2 - HPBar.Height * 4);
            }
            else
            {
                if(TimeShooting >= 30)
                {
                    if(GetType() != typeof(Enemy_1))
                    {
                        Effects effects = new Effects();
                        effects._Effect_Shooting(Form, new Point(enemy.Left + enemy.Width / 2 - 5, (enemy.Top + enemy.Height - 5)), Properties.Resources.Effect_Enemy_Shooting);
                    }
                    Shoot_Enemy();
                    TimeShooting = 0;
                }
            }
            TimeShooting++;

            Bullet_Dead();
            Touch_Tanks();
        }

        protected void Touch_Tanks()
        {
            if(Form != null)
            foreach (Control i in Form.Controls)
            {
                foreach (Control j in Form.Controls)
                {
                    if (i is PictureBox && (string)i.Tag == "enemy" && j is PictureBox && (string)j.Tag == "enemy")
                    {
                        if (i.Bounds.IntersectsWith(j.Bounds) && i != j)
                        {
                            if (((PictureBox)i).Top < ((PictureBox)j).Top)
                            {
                                ((PictureBox)i).Top -= speed;
                            }
                                

                            if (((PictureBox)j).Top < ((PictureBox)i).Top)
                            {
                                 ((PictureBox)j).Top -= speed;
                            }
                        }
                    }
                }
            }
        }

        protected virtual void Shoot_Enemy() { }

        protected void Bullet_Dead()
        {
            foreach (Control i in Form.Controls)
            {
                if (i is PictureBox && (string)(i.Tag) == "bullet")
                {
                    if(enemy != null)
                    {
                        if (i.Left >= this.enemy.Left && 
                            i.Left <= this.enemy.Left + this.enemy.Width && 
                            i.Top >= this.enemy.Top && 
                            i.Top <= this.enemy.Top + this.enemy.Height)
                        {
                            Form.Controls.Remove(i);
                            ((PictureBox)i).Dispose();
                            this.HP -= CharacterBulletDamage;
                            HPBar.Value = HP;
                            if(this.HP < 1)
                            {
                                Tank_amount--;
                                destroyed_Tank++;
                                Effects effects = new Effects();
                                effects._Effect_Explosion(Form,new Point(enemy.Left + 10,
                                                                        enemy.Top + 10));
                                Form.Controls.Remove(HP_icon);
                                Form.Controls.Remove(enemy);
                                Form.Controls.Remove(HPBar);
                                HP_icon.Dispose();
                                enemy.Dispose();
                                HPBar.Dispose();
                                TimerEnemy.Stop();
                                Destroy();
                                GC.Collect();
                            }
                        }
                    }
                }
            }
        }
    }

    public class Enemy_1 : Enemy
    {
        public Enemy_1()
        {
            HP = Game.easy == true ? 50 : Game.average == true ? 100 : 150;
            speed = 4;
        }

        public override void _Enemy(Form form, int characterBulletDamage)
        {
            Length = 550;
            enemy.Image = Properties.Resources.Enemy_Tank_1;
            base._Enemy(form, characterBulletDamage);
        }

        protected override void Shoot_Enemy()
        {
            _Bullet = new BulletEnemy1();

            _Bullet.Speed = -10;
            _Bullet.bulletLeft = enemy.Left + (int)(enemy.Width / 4);
            _Bullet.bulletTop = (int)(enemy.Top + enemy.Height);
            _Bullet._Bullet(Form,null, new Size(8, 16));
            _Bullet.Tag_Bullet("EnemyBullet1");
        }
    }

    public class Enemy_2 : Enemy
    {
        public Enemy_2()
        {
            HP = Game.easy == true ? 100 : Game.average == true ? 150 : 200;
            speed = 4;
        }

        public override void _Enemy(Form form, int characterBulletDamage)
        {
            Length = 400;
            enemy.Image = Properties.Resources.Enemy_Tank_2;
            base._Enemy(form, characterBulletDamage);
        }

        protected override void Shoot_Enemy()
        {
            _Bullet = new Bullet();

            _Bullet.Speed = -10;
            _Bullet.bulletLeft = enemy.Left + enemy.Width / 2;
            _Bullet.bulletTop = (int)(enemy.Top + enemy.Height * 1.1);
            _Bullet._Bullet(Form, Properties.Resources.Bullet_2, new Size(8,16));
            _Bullet.Tag_Bullet("EnemyBullet2");
            _Bullet = null;
        }
    }

    public class Enemy_3 : Enemy
    {
        public Enemy_3()
        {
            HP = Game.easy == true ? 150 : Game.average == true ? 200 : 250;
            speed = 3;
        }

        public override void _Enemy(Form form, int characterBulletDamage)
        {
            Length = 100;
            enemy.Image = Properties.Resources.Enemy_Tank_3;
            base._Enemy(form, characterBulletDamage);
        }

        protected override void Shoot_Enemy()
        {
            _Bullet = new Bullet();

            _Bullet.Speed = -20;
            _Bullet.bulletLeft = enemy.Left + enemy.Width / 2;
            _Bullet.bulletTop = (int)(enemy.Top + enemy.Height * 1.1);
            _Bullet._Bullet(Form,Properties.Resources.Bullet_3, new Size(8, 36));
            _Bullet.Tag_Bullet("EnemyBullet3");
            _Bullet = null;
        }
    }
}
