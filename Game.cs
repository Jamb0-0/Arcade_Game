using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Курсовая_работа
{
    class Game
    {
        int money = 0;
        Enemy enemy = new Enemy_1();
        List<Enemy> EnemyList = new List<Enemy>();
        Character character;
        Fence fence;
        System.Windows.Forms.Timer EnemyTimer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer HPFence = new System.Windows.Forms.Timer();
        int Money, kill = 0;
        bool HPFenceGO = true;
        bool bresume = false;
        public static bool easy = false, average = false;
        PictureBox Pause = new PictureBox();
        Form1 form;
        Save save;

        public Game(Form1 Form, Save Save)
        {
            Label LabelKill = new Label();
            Label LabelMoney = new Label();
            PictureBox Coin_icon = new PictureBox();
            PictureBox BlownTank_icon = new PictureBox();
            form = Form;
            save = Save;

            Money = save.Money;
            money = 0;

            if (save.Character == 0)
                character = new Character_1(form);
            else if (save.Character == 1)
                character = new Character_2(form);
            else
                character = new Character_3(form);

            if (save.Fence == 0)
                fence = new Fence_1();
            else
                fence = new Fence_2();


            character.Move();
            fence._Fence(form);

            HPFence.Enabled = true;
            HPFence.Interval = 100;

            EnemyTimer.Enabled = true;
            EnemyTimer.Interval = 2000;

            Pause.Size = new Size(61, 56);
            Pause.SizeMode = PictureBoxSizeMode.StretchImage;
            Pause.Image = Properties.Resources.Pause;
            Pause.Location = new Point(536, 3);
            Pause.BackColor = Color.Transparent;
            Pause.MouseEnter += form.Button_MouseEnter;
            Pause.MouseLeave += form.Button_MouseLeave;
            Pause.Tag = "buttonGame";
            form.Controls.Add(Pause);


            LabelKill.BackColor = Color.Transparent;
            LabelKill.AutoSize = false;
            LabelKill.Size = new Size(110, 40);
            LabelKill.ForeColor = Color.Red;
            LabelKill.Font = new Font("Algerian", (float)20);
            LabelKill.Location = new Point(40, form.Height - 73);
            form.Controls.Add(LabelKill);

            LabelMoney.BackColor = Color.Transparent;
            LabelMoney.AutoSize = false;
            LabelMoney.Size = new Size(110, 40);
            LabelMoney.ForeColor = Color.Red;
            LabelMoney.Font = new Font("Algerian", (float)20);
            LabelMoney.Location = new Point(form.Width - 116, form.Height - 73);
            form.Controls.Add(LabelMoney);

            BlownTank_icon.Size = new Size(30, 30);
            BlownTank_icon.SizeMode = PictureBoxSizeMode.StretchImage;
            BlownTank_icon.Image = Properties.Resources.BlownTank;
            BlownTank_icon.Left = LabelKill.Left - 35;
            BlownTank_icon.Top = LabelKill.Top;
            BlownTank_icon.BackColor = Color.Transparent;
            form.Controls.Add(BlownTank_icon);
            BlownTank_icon.BringToFront();

            Coin_icon.Size = new Size(30, 30);
            Coin_icon.SizeMode = PictureBoxSizeMode.StretchImage;
            Coin_icon.Image = Properties.Resources.Coin;
            Coin_icon.Left = LabelMoney.Left - 35;
            Coin_icon.Top = LabelMoney.Top;
            Coin_icon.BackColor = Color.Transparent;
            form.Controls.Add(Coin_icon);
            Coin_icon.BringToFront();

            timer.Interval = 100;
            timer.Enabled = true;

            //--------------------------------------------------------
            timer.Tick += new EventHandler((sender, e) =>
            {
                money = Enemy.destroyed_Tank;
                kill = Enemy.destroyed_Tank;
                LabelKill.Text = (kill).ToString();
                LabelMoney.Text = (Money + money).ToString();
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    if (EnemyList[i].EmptyPB())
                    {
                        EnemyList.Remove(EnemyList[i]);
                        i = 0;
                    }
                }
            });

            //--------------------------------------------------------
            HPFence.Tick += new EventHandler(HPF);
            //--------------------------------------------------------
            EnemyTimer.Tick += new EventHandler(Enemytimer);
            //---------------------------------------------------------------
            Pause.Click += new EventHandler(PAUSE);
            //--------------------------------------------------------
            form.KeyUp += new KeyEventHandler((s, e) =>
            {
                if (e.KeyCode == Keys.P)
                    if (bresume == false)
                    {
                        bresume = true;
                        PAUSE(s, e);
                    }
            });
        }

        void Enemytimer(object sender, EventArgs e)
        {
            if (Enemy.Tank_amount < 5)
            {
                int a = new Random().Next(0, 3);
                if (kill <= 10)
                    enemy = new Enemy_1();
                else if (kill > 10 && kill <= 30)
                {
                    if (a == 0)
                        enemy = new Enemy_1();
                    else
                        enemy = new Enemy_2();
                }
                else if (kill > 30 && kill <= 50)
                {
                    if (a == 0)
                        enemy = new Enemy_1();
                    else if (a == 1)
                        enemy = new Enemy_2();
                    else
                        enemy = new Enemy_3();
                }
                else if (kill > 50)
                {
                    if (a == 0 || a == 1)
                        enemy = new Enemy_2();
                    else
                        enemy = new Enemy_3();
                }

                EnemyList.Add(enemy);
                enemy._Enemy(form, character._Bullet.Damage);

                enemy = null;
                Pause.BringToFront();
                EnemyTimer.Interval = new Random().Next(3000, 4000);
            }
        }

        void HPF(object sender, EventArgs e)
        {
            if (fence.HP < 1 && HPFenceGO)
            {
                HPFenceGO = false;
                save.Money += money;
                Pause.Hide();

                character.Timer_Stop();
                foreach (var elem in EnemyList)
                {
                    elem.Timer_Stop();
                }
                fence.Timer_Stop();
                EnemyTimer.Stop();
                timer.Stop();
                HPFence.Stop();

                PictureBox GameOver = new PictureBox();
                GameOver.Size = new Size(425, 360);
                GameOver.SizeMode = PictureBoxSizeMode.StretchImage;
                GameOver.Location = new Point(86, 185);
                GameOver.Image = Properties.Resources.GameOver;
                GameOver.BackColor = Color.Transparent;
                form.Controls.Add(GameOver);

                Label Lmoney = new Label();
                Label LMoneys = new Label();
                Label LKill = new Label();
                TextBox NamePlayer = new TextBox();

                Lmoney.BackColor = Color.FromArgb(24, 31, 31);
                Lmoney.AutoSize = false;
                Lmoney.Size = new Size(92, 23);
                Lmoney.ForeColor = Color.WhiteSmoke;
                Lmoney.Font = new Font("Microsoft Sans Serif", (float)18);
                Lmoney.Location = new Point(377, 310);
                Lmoney.Text = "+ (" + money.ToString() + ")";
                form.Controls.Add(Lmoney);

                LMoneys.BackColor = Color.FromArgb(24, 31, 31);
                LMoneys.AutoSize = false;
                LMoneys.Size = new Size(74, 23);
                LMoneys.ForeColor = Color.WhiteSmoke;
                LMoneys.Font = new Font("Microsoft Sans Serif", (float)18);
                LMoneys.Location = new Point(291, 310);
                LMoneys.Text = save.Money.ToString();
                form.Controls.Add(LMoneys);

                LKill.BackColor = Color.FromArgb(24, 31, 31);
                LKill.AutoSize = false;
                LKill.Size = new Size(92, 23);
                LKill.ForeColor = Color.WhiteSmoke;
                LKill.Font = new Font("Microsoft Sans Serif", (float)18);
                LKill.Location = new Point(377, 361);
                LKill.Text = kill.ToString();
                form.Controls.Add(LKill);

                NamePlayer.Focus();
                NamePlayer.TabStop = false;
                NamePlayer.Multiline = true;
                NamePlayer.Text = "";
                NamePlayer.ForeColor = Color.WhiteSmoke;
                NamePlayer.BorderStyle = BorderStyle.FixedSingle;
                NamePlayer.Location = new Point(213, 420);
                NamePlayer.Size = new Size(171, 31);
                NamePlayer.Font = new Font("Microsoft Sans Serif", (float)15);
                NamePlayer.BackColor = Color.FromArgb(21, 26, 26);
                form.Controls.Add(NamePlayer);
                NamePlayer.KeyUp += (s, a) =>
                {
                    if (a.KeyCode == Keys.Enter && NamePlayer.Text.Length != 2)
                    {
                        NamePlayer.Text = NamePlayer.Text.Substring(0, NamePlayer.Text.Length - 2);
                        GameOver.Focus();
                    }
                    else if (NamePlayer.Text.Length == 2 && NamePlayer.Text == "\r\n")
                        NamePlayer.Text = "";
                };


                GameOver.BringToFront();
                Lmoney.BringToFront();
                LMoneys.BringToFront();
                LKill.BringToFront();
                NamePlayer.BringToFront();
                GameOver.PreviewKeyDown += (s, a) =>
                {
                    if (a.KeyCode == Keys.Enter)
                    {
                        HPFence.Tick -= new EventHandler(HPF);
                        EnemyTimer.Tick -= new EventHandler(Enemytimer);
                        Pause.Click -= new EventHandler(PAUSE);

                        save.records.Add(new RecordsData(NamePlayer.Text, kill));

                        for (int i = 0; i < form.Controls.Count; i++)
                        {
                            if (form.Controls[i].Name != "Setting" && form.Controls[i].Name != "Start" && form.Controls[i].Name != "Exit" &&
                                form.Controls[i].Name != "inf" && form.Controls[i].Name != "Records" && form.Controls[i].Name != "Shop")
                            {
                                form.Controls.RemoveAt(i);
                                i = 0;
                            }
                        }

                        character.Destroy();
                        fence.Destroy();

                        Enemy.destroyed_Tank = 0;
                        Enemy.Tank_amount = 0;
                        form.Controls.Remove(GameOver);
                        form.Controls.Remove(Pause);
                        form.Controls.Remove(Lmoney);
                        form.Controls.Remove(LMoneys);
                        form.Controls.Remove(LKill);
                        GameOver.Dispose();
                        Pause.Dispose();
                        Lmoney.Dispose();
                        LMoneys.Dispose();
                        LKill.Dispose();
                        Pause = null;
                        Lmoney = null;
                        LMoneys = null;
                        LKill = null;
                        GameOver = null;
                        timer.Dispose();
                        EnemyTimer.Dispose();
                        HPFence.Dispose();
                        timer = null;
                        EnemyTimer = null;
                        HPFence = null;
                        character = null;
                        fence = null;
                        enemy = null;
                        EnemyList = null;

                        easy = average = false;

                        form.BackgroundImage = Properties.Resources.BackGroundMenu;
                        form.Shop.Show();
                        form.Records.Show();
                        form.Setting.Show();
                        form.inf.Show();
                        form.Start.Show();
                        form.Exit.Show();
                        GC.Collect();
                    }
                };
            }
        }

        void PAUSE(object sender, EventArgs e)
        {
            if(Pause != null)
                Pause.Hide();

            character.Timer_Stop();
            foreach (var elem in EnemyList)
            {
                elem.Timer_Stop();
            }
            fence.Timer_Stop();
            EnemyTimer.Stop();
            timer.Stop();
            HPFence.Stop();

            PictureBox PauseMenu = new PictureBox();
            PictureBox Resume = new PictureBox();
            PictureBox BackMenu = new PictureBox();
            Label AmountKill = new Label();

            AmountKill.BackColor = Color.FromArgb(10, 14, 14);
            AmountKill.AutoSize = false;
            AmountKill.Size = new Size(77, 23);
            AmountKill.ForeColor = Color.WhiteSmoke;
            AmountKill.Font = new Font("Microsoft Sans Serif", (float)15);
            AmountKill.Location = new Point(370, 310);
            AmountKill.Text = kill.ToString();
            form.Controls.Add(AmountKill);

            PauseMenu.Size = new Size(376, 258);
            PauseMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            PauseMenu.Location = new Point(110, 187);
            PauseMenu.Image = Properties.Resources.Menu_Pause;
            PauseMenu.BackColor = Color.Transparent;
            form.Controls.Add(PauseMenu);

            Resume.Size = new Size(66, 62);
            Resume.SizeMode = PictureBoxSizeMode.StretchImage;
            Resume.Location = new Point(334, 355);
            Resume.Image = Properties.Resources.Resume;
            Resume.BackColor = Color.Transparent;
            Resume.MouseEnter += form.Button_MouseEnter;
            Resume.MouseLeave += form.Button_MouseLeave;
            Resume.Tag = "buttonGame";
            form.Controls.Add(Resume);

            BackMenu.Size = new Size(66, 62);
            BackMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            BackMenu.Location = new Point(198, 355);
            BackMenu.Image = Properties.Resources.Menu;
            BackMenu.BackColor = Color.Transparent;
            BackMenu.MouseEnter += form.Button_MouseEnter;
            BackMenu.MouseLeave += form.Button_MouseLeave;
            BackMenu.Tag = "buttonGame";
            form.Controls.Add(BackMenu);

            PauseMenu.BringToFront();
            Resume.BringToFront();
            BackMenu.BringToFront();
            AmountKill.BringToFront();

            Resume.Click += new EventHandler((s, a) =>
            {
                bresume = false;
                Pause.Show();
                form.Controls.Remove(AmountKill);
                form.Controls.Remove(PauseMenu);
                form.Controls.Remove(Resume);
                form.Controls.Remove(BackMenu);
                PauseMenu.Dispose();
                Resume.Dispose();
                BackMenu.Dispose();
                AmountKill.Dispose();
                PauseMenu = null;
                Resume = null;
                BackMenu = null;
                AmountKill = null;
                GC.Collect();
                character.Timer_Start();
                foreach (var elem in EnemyList)
                {
                    elem.Timer_Start();
                }
                fence.Timer_Start();
                EnemyTimer.Start();
                timer.Start();
                HPFence.Start();
            });
            BackMenu.Click += new EventHandler((s, a) =>
            {
                HPFence.Tick -= new EventHandler(HPF);
                EnemyTimer.Tick -= new EventHandler(Enemytimer);
                Pause.Click -= new EventHandler(PAUSE);

                bresume = false;
                save.Money += money;
                for (int i = 0; i < form.Controls.Count; i++)
                {
                    if (form.Controls[i].Name != "Setting" && form.Controls[i].Name != "Start" && form.Controls[i].Name != "Exit" &&
                        form.Controls[i].Name != "inf" && form.Controls[i].Name != "Records" && form.Controls[i].Name != "Shop")
                    {
                        form.Controls.RemoveAt(i);
                        i = 0;
                    }
                }

                character.Destroy();
                fence.Destroy();

                Enemy.destroyed_Tank = 0;
                Enemy.Tank_amount = 0;
                form.Controls.Remove(AmountKill);
                form.Controls.Remove(Pause);
                form.Controls.Remove(PauseMenu);
                form.Controls.Remove(Resume);
                form.Controls.Remove(BackMenu);
                AmountKill.Dispose();
                Pause.Dispose();
                PauseMenu.Dispose();
                Resume.Dispose();
                BackMenu.Dispose();
                Pause = null;
                PauseMenu = null;
                Resume = null;
                BackMenu = null;
                AmountKill = null;
                timer.Dispose();
                EnemyTimer.Dispose();
                HPFence.Dispose();
                timer = null;
                EnemyTimer = null;
                HPFence = null;
                character = null;
                fence = null;
                enemy = null;
                EnemyList = null;

                form.BackgroundImage = Properties.Resources.BackGroundMenu;

                form.Shop.Show();
                form.Records.Show();
                form.Setting.Show();
                form.inf.Show();
                form.Start.Show();
                form.Exit.Show();
                GC.Collect();
            });
        }
    }

    public class Complexity
    {
        public Complexity(Form1 form, Save save)
        {
            Panel PanelComplexity = new Panel();
            PictureBox easy = new PictureBox();
            PictureBox average = new PictureBox();
            PictureBox complex = new PictureBox();

            PanelComplexity.Location = new Point(150, 257);
            PanelComplexity.Size = new Size(279, 267);
            PanelComplexity.BackColor = Color.FromArgb(30,40,40);

            EventHandler Click_Complexity = (s, a) =>
            {
                PictureBox button = (PictureBox)s;
                Game.easy = (string)button.Tag == "easy" ? true : false;
                Game.average = (string)button.Tag == "average" ? true : false;
                form.Controls.Remove(PanelComplexity);
                PanelComplexity.Controls.Remove(easy);
                PanelComplexity.Controls.Remove(average);
                PanelComplexity.Controls.Remove(complex);
                PanelComplexity.Controls.Remove(easy);
                form.Controls.Remove(average);
                form.Controls.Remove(complex);
                PanelComplexity.Dispose();
                easy.Dispose();
                average.Dispose();
                complex.Dispose();
                PanelComplexity = null;
                easy = null;
                average = null;
                complex = null;
                new Game(form,save);
            };

            easy.SizeMode = PictureBoxSizeMode.StretchImage;
            easy.Location = new Point(74, 10);
            easy.Size = new Size(130, 65);
            easy.Image = Properties.Resources.easy;
            easy.Click += Click_Complexity;
            easy.MouseEnter += form.Button_MouseEnter;
            easy.MouseLeave += form.Button_MouseLeave;
            easy.Tag = "easy";

            average.SizeMode = PictureBoxSizeMode.StretchImage;
            average.Location = new Point(42, 102);
            average.Size = new Size(195, 65);
            average.Image = Properties.Resources.average;
            average.Click += Click_Complexity;
            average.MouseEnter += form.Button_MouseEnter;
            average.MouseLeave += form.Button_MouseLeave;
            average.Tag = "average";

            complex.SizeMode = PictureBoxSizeMode.StretchImage;
            complex.Location = new Point(39, 193);
            complex.Size = new Size(200, 65);
            complex.Image = Properties.Resources.complex;
            complex.Click += Click_Complexity;
            complex.MouseEnter += form.Button_MouseEnter;
            complex.MouseLeave += form.Button_MouseLeave;

            form.Controls.Add(PanelComplexity);

            PanelComplexity.Controls.Add(easy);
            PanelComplexity.Controls.Add(average);
            PanelComplexity.Controls.Add(complex);

/*            Music.SoundButton(form);*/

            PanelComplexity.BringToFront();
            easy.BringToFront();
            average.BringToFront();
            complex.BringToFront();
        }
    }
}
