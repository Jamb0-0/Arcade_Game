using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;

namespace Курсовая_работа
{
    [DataContract]
    public class RecordsData
    {
        [DataMember]
        public int kill { get; set; } = 0;
        [DataMember]
        public string Name { get; set; }

        public RecordsData(string name, int k)
        {
            Name = name;
            kill = k;
        }
    }

    public class Records
    {
        public Records(Form1 form, Save save)
        {
            save.records.Sort((RecordsData R1, RecordsData R2) =>
            {
                if (R1.kill < R2.kill)
                    return 1;
                return -1;
            });

            int k = 0;
            bool x = false;
            form.Setting.Hide();
            form.inf.Hide();

            GroupBox RecordTable = new GroupBox();
            RecordTable.BackColor = Color.Transparent;
            RecordTable.BackgroundImage = Properties.Resources.RecordsTable;
            RecordTable.BackgroundImageLayout = ImageLayout.Zoom;
            RecordTable.Text = "";
            RecordTable.Size = new Size(514, 646);
            RecordTable.Location = new Point(42, 65);
            RecordTable.FlatStyle = FlatStyle.Flat;
            form.Controls.Add(RecordTable);
            RecordTable.BringToFront();

            Timer Timer_Record = new Timer();

            Label[] Namerecords = new Label[5] { new Label(), new Label(), new Label(), new Label(), new Label() };
            Label[] Numberrecords = new Label[5] { new Label(), new Label(), new Label(), new Label(), new Label() };
            Label[] Killrecords = new Label[5] { new Label(), new Label(), new Label(), new Label(), new Label() };
            PictureBox[] RecordPlayer = new PictureBox[5] { new PictureBox(), new PictureBox(), new PictureBox(),
                                                            new PictureBox(), new PictureBox()};
            PictureBox RecordTableLeft = new PictureBox();
            PictureBox RecordTableRight = new PictureBox();
            PictureBox RecordBackMenu = new PictureBox();

            RecordBackMenu.Size = new Size(45, 45);
            RecordBackMenu.SizeMode = PictureBoxSizeMode.StretchImage;
            RecordBackMenu.Location = new Point(457, 10);
            RecordBackMenu.Image = Properties.Resources.RecordBackMenu;
            RecordBackMenu.BackColor = Color.Transparent;
            RecordBackMenu.MouseEnter += form.Button_MouseEnter;
            RecordBackMenu.MouseLeave += form.Button_MouseLeave;

            RecordTableLeft.Size = new Size(56, 52);
            RecordTableLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            RecordTableLeft.Location = new Point(5, form.Height / 2 - RecordTableLeft.Height / 2);
            RecordTableLeft.Image = Properties.Resources.RecordsTableLeft;
            RecordTableLeft.BackColor = Color.Transparent;
            RecordTableLeft.MouseEnter += form.Button_MouseEnter;
            RecordTableLeft.MouseLeave += form.Button_MouseLeave;
            RecordTableLeft.Tag = "buttonMenu";
            RecordTableLeft.Click += new EventHandler((s, a) =>
            {
                if (k - 5 >= 0)
                {
                    x = false;
                    k -= 5;
                    for (int w = 0; w < 5; w++)
                    {
                        Namerecords[w].Text = "";
                        Numberrecords[w].Text = "";
                        Killrecords[w].Text = "";
                    }
                }
            });

            RecordTableRight.Size = new Size(56, 52);
            RecordTableRight.SizeMode = PictureBoxSizeMode.StretchImage;
            RecordTableRight.Location = new Point(form.Width - RecordTableRight.Width - 21, form.Height / 2 - RecordTableRight.Height / 2);
            RecordTableRight.Image = Properties.Resources.RecordsTableRight;
            RecordTableRight.BackColor = Color.Transparent;
            RecordTableRight.MouseEnter += form.Button_MouseEnter;
            RecordTableRight.MouseLeave += form.Button_MouseLeave;
            RecordTableRight.Tag = "buttonMenu";
            RecordTableRight.Click += new EventHandler((s, a) =>
            {
                if (k + 5 < save.records.Count)
                {
                    x = false;
                    k += 5;
                    for (int w = 0; w < 5; w++)
                    {
                        Namerecords[w].Text = "";
                        Numberrecords[w].Text = "";
                        Killrecords[w].Text = "";
                    }
                }
            });

            form.Controls.Add(RecordTableLeft);
            form.Controls.Add(RecordTableRight);
            RecordTableLeft.BringToFront();
            RecordTableRight.BringToFront();
            RecordTable.Controls.Add(RecordBackMenu);

            for (int i = 0; i < 5; i++)
            {
                RecordPlayer[i].Size = new Size(467, 80);
                RecordPlayer[i].Location = new Point(26, 103 + 105 * i);
                RecordPlayer[i].SizeMode = PictureBoxSizeMode.StretchImage;
                RecordPlayer[i].Image = Properties.Resources.RecordPlayer;
                RecordPlayer[i].Tag = "None";

                RecordTable.Controls.Add(Namerecords[i]);
                RecordTable.Controls.Add(Numberrecords[i]);
                RecordTable.Controls.Add(Killrecords[i]);
                RecordTable.Controls.Add(RecordPlayer[i]);
            }

            Timer_Record.Enabled = true;
            Timer_Record.Interval = 100;

            Timer_Record.Tick += new EventHandler((s, a) =>
            {
                if (!x)
                {
                    x = true;
                    for (int i = 0, j = k; j < k + 5 && j < save.records.Count; i++, j++)
                    {
                        Namerecords[i].BackColor = Color.FromArgb(23, 32, 31);
                        Namerecords[i].Location = new Point(117, 127 + 105 * i);//127//232//337//442//547
                        Namerecords[i].AutoSize = false;
                        Namerecords[i].Size = new Size(173, 30);
                        Namerecords[i].ForeColor = Color.WhiteSmoke;
                        Namerecords[i].Font = new Font("Microsoft Sans Serif", (float)18);
                        Namerecords[i].Text = $"{save.records[j].Name}";

                        Numberrecords[i].BackColor = Color.FromArgb(23, 32, 31);
                        Numberrecords[i].Location = new Point(305, 127 + 105 * i);//127//232//337//442//547
                        Numberrecords[i].AutoSize = false;
                        Numberrecords[i].Size = new Size(68, 30);
                        Numberrecords[i].ForeColor = Color.WhiteSmoke;
                        Numberrecords[i].Font = new Font("Microsoft Sans Serif", (float)18);
                        Numberrecords[i].Text = $"#{j + 1}";

                        Killrecords[i].BackColor = Color.FromArgb(23, 32, 31);
                        Killrecords[i].Location = new Point(385, 127 + 105 * i);//127//232//337//442//547
                        Killrecords[i].AutoSize = false;
                        Killrecords[i].Size = new Size(93, 30);
                        Killrecords[i].ForeColor = Color.WhiteSmoke;
                        Killrecords[i].Font = new Font("Microsoft Sans Serif", (float)18);
                        Killrecords[i].Text = $"{save.records[j].kill}";
                    }
                }
            });

            RecordBackMenu.Click += new EventHandler((s, a) =>
            {
                form.Setting.Show();
                form.inf.Show();

                Timer_Record.Stop();
                Timer_Record.Dispose();
                Timer_Record = null;
                form.Controls.Remove(RecordTable);
                RecordTable.Dispose();
                RecordTable = null;
                form.Controls.Remove(RecordTableRight);
                RecordTableRight.Dispose();
                RecordTableRight = null;
                form.Controls.Remove(RecordTableLeft);
                RecordTableLeft.Dispose();
                RecordTableLeft = null;
                form.Controls.Remove(RecordBackMenu);
                RecordBackMenu.Dispose();
                RecordBackMenu = null;

                for (int i = 0; i < 5; i++)
                {
                    form.Controls.Remove(Namerecords[i]);
                    form.Controls.Remove(Numberrecords[i]);
                    form.Controls.Remove(Killrecords[i]);
                    form.Controls.Remove(RecordPlayer[i]);
                    Namerecords[i].Dispose();
                    Numberrecords[i].Dispose();
                    Killrecords[i].Dispose();
                    RecordPlayer[i].Dispose();
                }
                Namerecords = null;
                Numberrecords = null;
                Killrecords = null;
                RecordPlayer = null;

                GC.Collect();
            });
        }
    }
}
