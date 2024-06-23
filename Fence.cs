using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public abstract class Fence
    {
        protected PictureBox fence = new PictureBox();
        protected ProgressBar HPBar = new ProgressBar();
        protected PictureBox HP_icon = new PictureBox();
        Timer TimerFence = new Timer();
        protected Image image;
        protected Form Form;
        public int HP { get; set; }

        public void Destroy()
        {
            fence = null;
            HPBar = null;
            HP_icon = null;
            TimerFence = null;
            image = null;
            Form = null;
        }

        public void _Fence(Form form)
        {
            Form = form;
            fence.Size = new Size(Form.Width, 50);
            fence.SizeMode = PictureBoxSizeMode.StretchImage;
            fence.Location = new Point(0,682);
            fence.BackColor = Color.Transparent;
            fence.Tag = "fence";
            Form.BackgroundImage = image;

            HPBar.Size = new Size(200,20);
            HPBar.Minimum = 0;
            HPBar.Maximum = HP;
            HPBar.Value = HP;
            HPBar.Location = new Point(fence.Width / 2 - HPBar.Width / 2, fence.Top + fence.Height*2 - HPBar.Height / 2 + 5);


            HP_icon.Size = new Size(30, 30);
            HP_icon.SizeMode = PictureBoxSizeMode.StretchImage;
            HP_icon.BackColor = Color.Transparent;
            HP_icon.Image = Properties.Resources.HP_icon;
            HP_icon.Left = HPBar.Left - 35;
            HP_icon.Top = HPBar.Top - 7;

            TimerFence.Interval = 20;
            TimerFence.Enabled = true;
            TimerFence.Tick += new EventHandler(Tick_Fence);
            Form.Controls.Add(HP_icon);
            Form.Controls.Add(HPBar);
            Form.Controls.Add(fence);
        }

        private void Tick_Fence(object sender, EventArgs e)
        {
            Fence_HP();
        }

        public void Timer_Start()
        {
            TimerFence.Start();
        }

        public void Timer_Stop()
        {
            TimerFence.Stop();
        }

        private void Fence_HP()
        {
            foreach(Control i in Form.Controls)
            {
                if(i is PictureBox && ((string)i.Tag == "EnemyBullet1" || (string)i.Tag == "EnemyBullet2" || (string)i.Tag == "EnemyBullet3" ))
                {
                    if (i.Left >= fence.Left && i.Left <= fence.Width && i.Top + i.Height / 2 >= fence.Top)
                    {

                        Form.Controls.Remove(i);
                        ((PictureBox)i).Dispose();
                        if(HP >= 1)
                        {
                            if ((string)i.Tag == "EnemyBullet1")
                                HP -= 3;
                            if((string)i.Tag == "EnemyBullet2")
                                HP -= 2;
                            if ((string)i.Tag == "EnemyBullet3")
                                HP -= 2;
                            if (HP < 1)
                                HP = 0;
                            HPBar.Value = HP;
                        }
                    }
                }
            }
        }
    }

    public class Fence_1 : Fence
    {
        public Fence_1()
        {
            HP = 100;
            image = Properties.Resources.BackGrund_1;

        }
    }

    public class Fence_2 : Fence
    {
        public Fence_2()
        {
            HP = 200;
            image = Properties.Resources.BackGrund_2;

        }
    }

}
