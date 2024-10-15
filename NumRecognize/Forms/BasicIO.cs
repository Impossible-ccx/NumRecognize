using System;
using System.Windows.Forms;
using NumRecognize;

namespace NumRecognize.Forms
{
    public partial class BasicIO : Form
    {
        private Button[] bnts = new Button[64];
        private Button[] bntsNum = new Button[10];
        private int[] digt = new int[64];
        private int targ = 0;
        public BasicIO()
        {
            InitializeComponent();
            LoadCavana();
        }
        private void LoadCavana()
        {
            for (int i = 0; i < 64; i++)
            {
                bnts[i] = new Button();
                bnts[i].Name = "bnt" + i.ToString();
                bnts[i].Tag = i;
                bnts[i].Size = new Size(25, 25);
                int x = (i % 8) * 25;
                int y = (i / 8) * 25;
                bnts[i].Location = new Point(x, y);
                bnts[i].Click += PixelClick;
                bnts[i].Parent = this;
                bnts[i].BackColor = Color.White;
                bnts[i].Show();
            }
            for (int i = 0; i < 10; i++)
            {
                bntsNum[i] = new Button();
                bntsNum[i].Name = "bntNum" + i.ToString();
                bntsNum[i].Tag = i;
                bntsNum[i].Text = i.ToString();
                bntsNum[i].Size = new Size(25, 25);
                bntsNum[i].Location = new Point(200, i * 25);
                bntsNum[i].Click += NumClick;
                bntsNum[i].Parent = this;
                bntsNum[i].BackColor = Color.White;
                bntsNum[i].Show();
            }
        }
        private void PixelClick(object? sender, EventArgs e)
        {
            Button butSender = (Button)sender!;
            if (butSender.BackColor == Color.White)
            {
                butSender.BackColor = Color.Black;
                digt[(int)butSender.Tag!] = 1;
            }
            else
            {
                butSender.BackColor = Color.White;
                digt[(int)butSender.Tag!] = 0;
            }


        }
        private void NumClick(object? sender, EventArgs e)
        {
            Button butSender = (Button)sender!;
            targ = (int)butSender.Tag!;
            Ndata input = new Ndata();
            for (int i = 0; i < 64; i++)
            {
                input.Source[i, 0] = digt[i];
            }
            input.Target[targ, 0] = 1;
            TargetLabel.Text = targ.ToString();
            if (Program.OnlineNetwork != null)
            {
                int result = Program.OnlineNetwork.GetResult(input);
                OutputLable.Text = result.ToString();
            }
            if (IsSaveMode.Checked)
            {
                if (Program.OnlineDataset != null)
                {
                    Program.OnlineDataset.AddData(input);
                }
                else
                {
                    throw new Exception("W001 No dataset Online");
                }
            }

            for (int i = 0; i < bnts.Length; i++)
            {
                bnts[i].BackColor = Color.White;
            }
            for (int i = 0; i < digt.Length; i++)
            {
                digt[i] = 0;
            }
        }
        private void ButPop(object sender, EventArgs e)
        {
            if (IsSaveMode.Checked)
            {
                if (Program.OnlineDataset != null)
                {
                    if (Program.OnlineDataset.PopData())
                    {
                        ;
                    }
                    else
                    {
                        throw new Exception("W003 Dataset cleared");
                    }
                }
                else
                {
                    throw new Exception("W001 No online dataset");
                }
            }
            else
            {
                throw new Exception("W002 Save mode is not on");
            }
        }
    }
}
