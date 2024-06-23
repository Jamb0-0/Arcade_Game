using System;
using System.Windows.Forms;
using System.Drawing;

namespace Курсовая_работа
{
    class Shop
    {
        PictureBox shopMenu = new PictureBox();
        PictureBox shopMoney = new PictureBox();
        PictureBox BackMenu = new PictureBox();
        GroupBox shopbox = new GroupBox();
        ComboBox shopindex = new ComboBox();
        Label Money = new Label();
        Form1 form1;
        Save Save;
        

        public Shop(Form1 form, Save save)
        {
            form1 = form;
            Save = save;

            form.Setting.Hide();
            form.inf.Hide();

            shopMenu.Location = new Point(12, 66);
            shopMenu.Size = new Size(576, 677);
            shopMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            shopMenu.Image = Properties.Resources.shopMenu;

            shopMoney.Location = new Point(190, 161);
            shopMoney.Size = new Size(235, 59);
            shopMoney.SizeMode = PictureBoxSizeMode.StretchImage;
            shopMoney.Image = Properties.Resources.Money;

            BackMenu.Location = new Point(519, 74);
            BackMenu.Size = new Size(50, 50);
            BackMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            BackMenu.Image = Properties.Resources.RecordBackMenu;
            BackMenu.Click += new EventHandler(close);
            BackMenu.MouseEnter += form.Button_MouseEnter;
            BackMenu.MouseLeave += form.Button_MouseLeave;
            BackMenu.Tag = "buttonMenu";

            shopindex.Location = new Point(22, 74);
            shopindex.Size = new Size(139, 59);
            shopindex.BackColor = Color.FromArgb(59,69,71);
            shopindex.DropDownStyle = ComboBoxStyle.DropDownList;
            shopindex.Items.Add("Танк");
            shopindex.Items.Add("База");
            shopindex.SelectedIndexChanged += new EventHandler(index);
            shopindex.SelectedIndex = 0;

            shopbox.Location = new Point(93, 226);
            shopbox.Size = new Size(413, 464);
            shopbox.Text = "Танк";
            shopbox.BackColor = Color.FromArgb(21,26,26);
            shopbox.ForeColor = Color.WhiteSmoke;
            shopbox.Font = new Font("Microsoft Sans Serif", (float)15);
            shopbox.FlatStyle = FlatStyle.Flat;

            Money.AutoSize = false;
            Money.Location = new Point(272, 173);
            Money.Size = new Size(141, 35);
            Money.Font = new Font("Microsoft Sans Serif", (float)24);
            Money.BackColor = Color.FromArgb(33,42,41);
            Money.ForeColor = Color.WhiteSmoke;
            Money.Text = save.Money.ToString();

            form.Controls.Add(shopMenu);
            form.Controls.Add(shopindex);
            form.Controls.Add(shopMoney);
            form.Controls.Add(BackMenu);
            form.Controls.Add(shopbox);
            form.Controls.Add(Money);

            shopMenu.BringToFront();
            shopindex.BringToFront();
            shopMoney.BringToFront();
            BackMenu.BringToFront();
            shopbox.BringToFront();
            Money.BringToFront();
        }

        void close(object sender, EventArgs e)
        {
            shopindex.Controls.Clear();
            form1.Controls.Remove(shopMenu);
            form1.Controls.Remove(shopMoney);
            form1.Controls.Remove(BackMenu);
            form1.Controls.Remove(shopindex);
            form1.Controls.Remove(shopbox);
            form1.Controls.Remove(Money);

            shopMenu.Dispose();
            shopMoney.Dispose();
            BackMenu.Dispose();
            shopindex.Dispose();
            shopbox.Dispose();
            Money.Dispose();

            shopMenu = null;
            shopMoney = null;
            BackMenu = null;
            shopindex = null;
            shopbox = null;
            Money = null;

            form1.Setting.Show();
            form1.inf.Show();
            GC.Collect();
        }

        bool x = true;
        bool y = true;
     
        void index(object sender, EventArgs e)  
        {
            int[] buy_money_tank = new int[3] { 0, 10, 50 };

            if (shopindex.SelectedIndex == 0 && x)
            {
                PictureBox[] tank = new PictureBox[3] { new PictureBox(), new PictureBox(), new PictureBox() };
                HScrollBar bar = new HScrollBar();
                Button button = new Button();
                PictureBox price = new PictureBox();    
                Label labelprice = new Label();

                shopbox.Controls.Clear();
                x = false;
                y = true;
                shopbox.Text = "Танк";

                price.SizeMode = PictureBoxSizeMode.StretchImage;
                price.Size = new Size(202, 59);
                price.Location = new Point(103, 50);
                price.Image = Properties.Resources.Money;
                price.Tag = "None";

                labelprice.AutoSize = false;
                labelprice.Location = new Point(181, 58);
                labelprice.Size = new Size(108, 47);
                labelprice.BackColor = Color.FromArgb(33,42,41);
                labelprice.ForeColor = Color.WhiteSmoke;
                labelprice.Text = buy_money_tank[0].ToString();
                labelprice.Font = new Font("Microsoft Sans Serif", (float)30);

                shopbox.Controls.Add(price);
                shopbox.Controls.Add(labelprice);
                price.BringToFront();
                labelprice.BringToFront();

                bar.Dock = DockStyle.Bottom;
                bar.LargeChange = 1;
                bar.SmallChange = 1;
                bar.Minimum = 0;
                bar.Maximum = 2;
                bar.Value = Save.SelectedCharacter;
                bar.Size = new Size(407, 17);
                shopbox.Controls.Add(bar);
                bar.BringToFront();

                button.Location = new Point(103, 346);
                button.Size = new Size(202, 42);
                button.ForeColor = Color.WhiteSmoke;
                button.BackColor = Color.FromArgb(33,42,41);
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Microsoft Sans Serif", (float)15);
                if (Save.CharacterShop[bar.Value] == true)
                {
                    labelprice.Text = "0";
                    if (Save.SelectedCharacter == (byte)bar.Value)
                        button.Text = "Выбрано";
                    else
                        button.Text = "Выбрать";
                }
                else
                    button.Text = "Купить";
                shopbox.Controls.Add(button);
                button.BringToFront();

                tank[0].Image = Properties.Resources.shopC1;
                tank[1].Image = Properties.Resources.shopC2;
                tank[2].Image = Properties.Resources.shopC3;
                for (int i = 0; i < 3; i++)
                {
                    tank[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    tank[i].Location = bar.Value != 0 ? bar.Value == 1 ? new Point(-149 + 252 * i, 140) : new Point(-401 + 252 * i, 140) : new Point(103 + 252 * i, 140);
                    tank[i].Size = new Size(202, 189);
                    tank[i].Tag = "None";
                    shopbox.Controls.Add(tank[i]);
                    tank[i].BringToFront();
                }

                EventHandler logic = (sss, aaa) =>
                {
                    if (Money != null)
                        Money.Text = Save.Money.ToString();
                    if (bar.Value == 0)
                    {
                        labelprice.Text = buy_money_tank[bar.Value].ToString();
                        if (Save.CharacterShop[bar.Value] == true)
                        {
                            labelprice.Text = "0";
                            if (Save.SelectedCharacter == (byte)bar.Value)
                                button.Text = "Выбрано";
                            else
                            {
                                button.Text = "Выбрать";
                                button.MouseDown += (ss, aa) =>
                                {
                                    Save.SelectedCharacter = (byte)bar.Value;
                                    Save.Character = (byte)bar.Value;
                                };
                            }
                        }
                        else
                        {
                            button.Text = "Купить";
                            button.MouseDown += (ss, aa) =>
                            {
                                if (Save.Money >= buy_money_tank[bar.Value] && Save.CharacterShop[bar.Value] == false)
                                {
                                    Save.CharacterShop[bar.Value] = true;
                                    Save.Money -= buy_money_tank[bar.Value];
                                }
                            };
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            tank[i].Location = new Point(103 + 252 * i, 140);
                            tank[i].BringToFront();
                        }
                    }
                    else if (bar.Value == 1)
                    {
                        labelprice.Text = buy_money_tank[bar.Value].ToString();
                        if (Save.CharacterShop[bar.Value] == true)
                        {
                            labelprice.Text = "0";
                            if (Save.SelectedCharacter == (byte)bar.Value)
                                button.Text = "Выбрано";
                            else
                            {
                                button.Text = "Выбрать";
                                button.MouseDown += (ss, aa) =>
                                {
                                    Save.SelectedCharacter = (byte)bar.Value;
                                    Save.Character = (byte)bar.Value;
                                };
                            }
                        }
                        else
                        {
                            button.Text = "Купить";
                            button.MouseDown += (ss, aa) =>
                            {
                                if (Save.Money >= buy_money_tank[bar.Value] && Save.CharacterShop[bar.Value] == false)
                                {
                                    Save.CharacterShop[bar.Value] = true;
                                    Save.Money -= buy_money_tank[bar.Value];
                                }
                            };
                        }


                        for (int i = 0; i < 3; i++)
                        {
                            tank[i].Location = new Point(-149 + 252 * i, 140);
                            tank[i].BringToFront();
                        }
                    }
                    else
                    {
                        labelprice.Text = buy_money_tank[bar.Value].ToString();
                        if (Save.CharacterShop[bar.Value] == true)
                        {
                            labelprice.Text = "0";
                            if (Save.SelectedCharacter == (byte)bar.Value)
                                button.Text = "Выбрано";
                            else
                            {
                                button.Text = "Выбрать";
                                button.MouseDown += (ss, aa) =>
                                {
                                    Save.SelectedCharacter = (byte)bar.Value;
                                    Save.Character = (byte)bar.Value;
                                };
                            }
                        }
                        else
                        {
                            button.Text = "Купить";
                            button.MouseDown += (ss, aa) =>
                            {
                                if (Save.Money >= buy_money_tank[bar.Value] && Save.CharacterShop[bar.Value] == false)
                                {
                                    Save.CharacterShop[bar.Value] = true;
                                    Save.Money -= buy_money_tank[bar.Value];
                                }
                            };
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            tank[i].Location = new Point(-401 + 252 * i, 140);
                            tank[i].BringToFront();
                        }
                    }
                };
                bar.ValueChanged += logic;
                button.Click += logic;
                GC.Collect();
            }
            int[] buy_money_fence = new int[2] { 0, 50};
            if (shopindex.SelectedIndex == 1 && y)
            {
                PictureBox[] fence = new PictureBox[] { new PictureBox(), new PictureBox() };
                HScrollBar bar = new HScrollBar();
                Button button = new Button();
                PictureBox price = new PictureBox();
                Label labelprice = new Label();

                shopbox.Controls.Clear();
                x = true;
                y = false;
                shopbox.Text = "База";

                price.SizeMode = PictureBoxSizeMode.StretchImage;
                price.Size = new Size(202, 59);
                price.Location = new Point(103, 19);
                price.Image = Properties.Resources.Money;
                price.Tag = "None";

                labelprice.AutoSize = false;
                labelprice.Location = new Point(181, 27);
                labelprice.Size = new Size(108, 47);
                labelprice.BackColor = Color.FromArgb(33, 42, 41);
                labelprice.ForeColor = Color.WhiteSmoke;
                labelprice.Text = buy_money_fence[0].ToString();
                labelprice.Font = new Font("Microsoft Sans Serif", (float)30);

                shopbox.Controls.Add(price);
                shopbox.Controls.Add(labelprice);
                price.BringToFront();
                labelprice.BringToFront();

                bar.Dock = DockStyle.Bottom;
                bar.LargeChange = 1;
                bar.SmallChange = 1;
                bar.Minimum = 0;
                bar.Maximum = 1;
                bar.Value = Save.SelectedFence;
                bar.Size = new Size(407, 17);
                shopbox.Controls.Add(bar);
                bar.BringToFront();

                button.Location = new Point(103, 367);
                button.Size = new Size(202, 42);
                button.ForeColor = Color.WhiteSmoke;
                button.BackColor = Color.FromArgb(33, 42, 41);
                button.FlatStyle = FlatStyle.Flat;
                button.Font = new Font("Microsoft Sans Serif", (float)15);

                if (Save.FenceShop[bar.Value] == true)
                {
                    labelprice.Text = "0";
                    if (Save.SelectedFence == (byte)bar.Value)
                        button.Text = "Выбрано";
                    else
                        button.Text = "Выбрать";
                }
                else
                    button.Text = "Купить";
                shopbox.Controls.Add(button);
                button.BringToFront();

                fence[0].Image = Properties.Resources.shopF1;
                fence[1].Image = Properties.Resources.shopF2;
                for (int i = 0; i < 2; i++)
                {
                    fence[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    fence[i].Location = bar.Value == 0 ? new Point(103 + 252 * i, 84) : new Point(-149 + 252 * i, 84);
                    fence[i].Size = new Size(202, 264);
                    fence[i].Tag = "None";
                    shopbox.Controls.Add(fence[i]);
                    fence[i].BringToFront();
                }

                EventHandler log = (sss, aaa) =>
                {
                    if (Money != null)
                        Money.Text = Save.Money.ToString();
                    if (bar.Value == 0)
                    {
                        labelprice.Text = buy_money_fence[bar.Value].ToString();
                        if (Save.FenceShop[bar.Value] == true)
                        {
                            labelprice.Text = "0";
                            if (Save.SelectedFence == (byte)bar.Value)
                                button.Text = "Выбрано";
                            else
                            {
                                button.Text = "Выбрать";
                                button.MouseDown += (ss, aa) =>
                                {
                                    Save.SelectedFence = (byte)bar.Value;
                                    Save.Fence = (byte)bar.Value;
                                };
                            }
                        }
                        else
                        {
                            button.Text = "Купить";
                            button.MouseDown += (ss, aa) =>
                            {
                                if (Save.Money >= buy_money_fence[bar.Value] && Save.FenceShop[bar.Value] == false)
                                {
                                    Save.FenceShop[bar.Value] = true;
                                    Save.Money -= buy_money_fence[bar.Value];
                                }
                            };
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            fence[i].Location = new Point(103 + 252 * i, 84);
                            fence[i].BringToFront();
                        }
                    }
                    else
                    {
                        labelprice.Text = buy_money_fence[bar.Value].ToString();
                        if (Save.FenceShop[bar.Value] == true)
                        {
                            labelprice.Text = "0";
                            if (Save.SelectedFence == (byte)bar.Value)
                                button.Text = "Выбрано";
                            else
                            {
                                button.Text = "Выбрать";
                                button.MouseDown += (ss, aa) =>
                                {
                                    Save.SelectedFence = (byte)bar.Value;
                                    Save.Fence = (byte)bar.Value;
                                };
                            }
                        }
                        else
                        {
                            button.Text = "Купить";
                            button.MouseDown += (ss, aa) =>
                            {
                                if (Save.Money >= buy_money_fence[bar.Value] && Save.FenceShop[bar.Value] == false)
                                {
                                    Save.FenceShop[bar.Value] = true;
                                    Save.Money -= buy_money_fence[bar.Value];
                                }
                            };
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            fence[i].Location = new Point(-149 + 252 * i, 84);
                            fence[i].BringToFront();
                        }
                    }
                };
                bar.ValueChanged += log;
                button.Click += log;

                GC.Collect();
            }
        }
    }
}
