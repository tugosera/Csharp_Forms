using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Forms
{
    public partial class TeineVorm : Form
    {
        CheckBox chk1;
        PictureBox pb1;
        Button btn1, btn2, btn3, btn4, btn5;

        public TeineVorm(int w, int h)
        {
            this.Text = "Teine vorm";
            this.Height = h;
            this.Width = w;
            chk1 = new CheckBox();
            chk1.Checked = false;
            chk1.Text = "Strech";
            chk1.Size = new Size(chk1.Text.Length * 10, chk1.Size.Height * 2);
            chk1.Location = new Point(10,410);
            chk1.CheckedChanged += new EventHandler(Chk_CheckedChanged);

            pb1 = new PictureBox();
            pb1.Size = new Size(500,400);
            pb1.Location = new Point(0,0);
            pb1.Image = Image.FromFile(@"..\..\sf.png");

            btn1 = new Button();
            btn1.Text = "Show a picture";
            btn1.Height = 20;
            btn1.Width = 90;
            btn1.Location = new Point(100, 400);
            btn1.Click += Btn1_Click;

            btn2 = new Button();
            btn2.Text = "Clear the picture";
            btn2.Height = 20;
            btn2.Width = 100;
            btn2.Location = new Point(200, 400);
            btn2.Click += Btn2_Click;

            btn3 = new Button();
            btn3.Text = "Set the background color";
            btn3.Height = 20;
            btn3.Width = 150;
            btn3.Location = new Point(310, 400);
            btn3.Click += Btn3_Click;

            btn4 = new Button();
            btn4.Text = "Close";
            btn4.Height = 20;
            btn4.Width = 80;
            btn4.Location = new Point(100, 430);
            btn4.Click += Btn4_Click;

            btn5 = new Button();
            btn5.Text = "Change picture";
            btn5.Height = 20;
            btn5.Width = 100;
            btn5.Location = new Point(200, 430);
            btn5.Click += Btn5_Click;

            Controls.Add(chk1);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn4);
            Controls.Add(btn5);
        }
        int tt = 0;
        private void Btn5_Click(object sender, EventArgs e)
        {
            string[] pildid = { "sf.png", "kaneki.jpg", "bara.png", "grom.jpg" };
            string fail = pildid[tt];
            pb1.Image = Image.FromFile(@"..\..\" + fail);
            tt++;
            if (tt == 4) { tt = 0; }
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            Close();
        }

        int t = 0;
        private void Btn3_Click(object sender, EventArgs e)
        {
            t++;
            if (t == 9)
            { t = 1; }
            else if (t == 1)
            { this.BackColor = Color.Gray;}
            else if (t == 2)
            { this.BackColor = Color.Green; }
            else if (t == 3)
            { this.BackColor = Color.Yellow; }
            else if (t == 4)
            { this.BackColor = Color.Blue; }
            else if (t == 5)
            { this.BackColor = Color.Chocolate; }
            else if (t == 6)
            { this.BackColor = Color.Red; }
            else if (t == 7)
            { this.BackColor = Color.Purple; }
            else if (t == 8)
            { this.BackColor = Color.White; }


        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Controls.Remove(pb1);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Controls.Add(pb1);
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
            {
                pb1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pb1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
