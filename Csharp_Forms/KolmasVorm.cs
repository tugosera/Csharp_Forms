using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace Csharp_Forms
{
    public partial class KolmasVorm : Form
    {

        Label lbl, plusLeftLabel, plusRightLabel, plus, ravno, minusLeftLabel, minusRightLabel, minus, ravno2, LeftLabel3, RightLabel3, mno, ravno3, LeftLabel4, RightLabel4, dl, ravno4, lbll;
        NumericUpDown num, num2, num3, num4;
        Button start;
        Random random = new Random();
        Timer timer;


        public KolmasVorm(int w, int h)
        {
            this.Text = "Kolmas vorm";
            this.Height = h;
            this.Width = w;

            plusLeftLabel = new Label();
            plusLeftLabel.Text = "?";
            plusLeftLabel.Font = new Font("Arial", 24);
            plusLeftLabel.Size = new Size(80, 80);
            plusLeftLabel.Location = new Point(50, 100);

            plusRightLabel = new Label();
            plusRightLabel.Text = "?";
            plusRightLabel.Font = new Font("Arial", 24);
            plusRightLabel.Size = new Size(80, 80);
            plusRightLabel.Location = new Point(250, 100);

            minusLeftLabel = new Label();
            minusLeftLabel.Text = "?";
            minusLeftLabel.Font = new Font("Arial", 24);
            minusLeftLabel.Size = new Size(80, 80);
            minusLeftLabel.Location = new Point(50, 200);

            minusRightLabel = new Label();
            minusRightLabel.Text = "?";
            minusRightLabel.Font = new Font("Arial", 24);
            minusRightLabel.Size = new Size(80, 80);
            minusRightLabel.Location = new Point(250, 200);

            LeftLabel3 = new Label();
            LeftLabel3.Text = "?";
            LeftLabel3.Font = new Font("Arial", 24);
            LeftLabel3.Size = new Size(80, 80);
            LeftLabel3.Location = new Point(50, 300);

            RightLabel3 = new Label();
            RightLabel3.Text = "?";
            RightLabel3.Font = new Font("Arial", 24);
            RightLabel3.Size = new Size(80, 80);
            RightLabel3.Location = new Point(250, 300);

            minus = new Label();
            minus.Text = "-";
            minus.Font = new Font("Arial", 24);
            minus.Size = new Size(80, 80);
            minus.Location = new Point(150, 200);

            plus = new Label();
            plus.Text = "+";
            plus.Font = new Font("Arial", 24);
            plus.Size = new Size(80, 80);
            plus.Location = new Point(150, 100);

            mno = new Label();
            mno.Text = "*";
            mno.Font = new Font("Arial", 24);
            mno.Size = new Size(80, 80);
            mno.Location = new Point(150, 300);

            ravno = new Label();
            ravno.Text = "=";
            ravno.Font = new Font("Arial", 24);
            ravno.Size = new Size(80, 80);
            ravno.Location = new Point(350, 100);

            ravno2 = new Label();
            ravno2.Text = "=";
            ravno2.Font = new Font("Arial", 24);
            ravno2.Size = new Size(80, 80);
            ravno2.Location = new Point(350, 200);

            ravno3 = new Label();
            ravno3.Text = "=";
            ravno3.Font = new Font("Arial", 24);
            ravno3.Size = new Size(80, 80);
            ravno3.Location = new Point(350, 300);

            lbl = new Label();
            lbl.Text = "Time left";
            lbl.Font = new Font("Arial", 24);
            lbl.Size = new Size(150, 50);
            lbl.Location = new Point(250, 0);

            lbll = new Label();
            lbll.Location = new Point(400, 0);
            lbll.Font = new Font("Arial", 24);
            lbll.Size = new Size(150,50);
            lbll.BorderStyle = BorderStyle.FixedSingle;

            num = new NumericUpDown();
            num.Location = new Point(450, 100);
            num.Size = new Size(100, 300);
            num.Font = new Font("Arial", 20);

            num2 = new NumericUpDown();
            num2.Location = new Point(450, 200);
            num2.Size = new Size(100, 300);
            num2.Font = new Font("Arial", 20);

            num3 = new NumericUpDown();
            num3.Location = new Point(450, 300);
            num3.Size = new Size(100, 300);
            num3.Font = new Font("Arial", 20);

            start = new Button();
            start.Text = "Start";
            start.Height = 30;
            start.Width = 70;
            start.BackColor = Color.LightGreen;
            start.Location = new Point(250, 510);
            start.Click += start_Click;

            LeftLabel4 = new Label();
            LeftLabel4.Text = "?";
            LeftLabel4.Font = new Font("Arial", 24);
            LeftLabel4.Size = new Size(80, 80);
            LeftLabel4.Location = new Point(50, 400);

            RightLabel4 = new Label();
            RightLabel4.Text = "?";
            RightLabel4.Font = new Font("Arial", 24);
            RightLabel4.Size = new Size(80, 80);
            RightLabel4.Location = new Point(250, 400);

            dl = new Label();
            dl.Text = "/";
            dl.Font = new Font("Arial", 24);
            dl.Size = new Size(80, 80);
            dl.Location = new Point(150, 400);

            ravno4 = new Label();
            ravno4.Text = "=";
            ravno4.Font = new Font("Arial", 24);
            ravno4.Size = new Size(80, 80);
            ravno4.Location = new Point(350, 400);

            num4 = new NumericUpDown();
            num4.Location = new Point(450, 400);
            num4.Size = new Size(100, 300);
            num4.Font = new Font("Arial", 20);



            Controls.Add(LeftLabel4);
            Controls.Add(RightLabel4);
            Controls.Add(num4);
            Controls.Add(ravno4);
            Controls.Add(dl);

            Controls.Add(LeftLabel3);
            Controls.Add(RightLabel3);
            Controls.Add(num3);
            Controls.Add(ravno3);
            Controls.Add(mno);

            Controls.Add(minusLeftLabel);
            Controls.Add(minusRightLabel);
            Controls.Add(minus);
            Controls.Add(ravno2);
            Controls.Add(num2);

            Controls.Add(plus);
            Controls.Add(ravno);
            Controls.Add(plusRightLabel);
            Controls.Add(plusLeftLabel);

            Controls.Add(start);
            Controls.Add(num);
            Controls.Add(lbll);
            Controls.Add(lbl);
        }
        int k = 60;
        public void start_Click(object sender, EventArgs e)
        {


            int randomInt = random.Next(0, 101);
            plusLeftLabel.Text = "" + randomInt;
            int randomInt2 = random.Next(0, 101);
            plusRightLabel.Text = "" + randomInt2;
            int plusOtvet = randomInt + randomInt2;


            int randomInt3 = random.Next(0, 101);
            int randomInt4 = random.Next(0, 101);

            while (randomInt3 < randomInt4)
            {
                randomInt3 = random.Next(0, 101);
                randomInt4 = random.Next(0, 101);
            }
            minusLeftLabel.Text = "" + randomInt3;
            minusRightLabel.Text = "" + randomInt4;
            int minusOtvet = randomInt3 + randomInt4;


            int randomInt5 = random.Next(0, 50);
            LeftLabel3.Text = "" + randomInt5;
            int randomInt6 = random.Next(0, 15);
            RightLabel3.Text = "" + randomInt6;
            int xOtvet = randomInt5 + randomInt6;



            int randomInt7 = random.Next(1, 101);
            int randomInt8 = random.Next(1, 101);

            while (randomInt7 % randomInt8 != 0)
            {
                randomInt7 = random.Next(1, 101);
                randomInt8 = random.Next(1, 101);
            }

            LeftLabel4.Text = "" + randomInt7;
            RightLabel4.Text = "" + randomInt8;
            int dOtvet = randomInt7 + randomInt8;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;

            if (k == 0)
            {
                Controls.Remove(LeftLabel4);
                Controls.Remove(RightLabel4);
                Controls.Remove(num4);
                Controls.Remove(ravno4);
                Controls.Remove(dl);

                Controls.Remove(LeftLabel3);
                Controls.Remove(RightLabel3);
                Controls.Remove(num3);
                Controls.Remove(ravno3);
                Controls.Remove(mno);

                Controls.Remove(minusLeftLabel);
                Controls.Remove(minusRightLabel);
                Controls.Remove(minus);
                Controls.Remove(ravno2);
                Controls.Remove(num2);

                Controls.Remove(plus);
                Controls.Remove(ravno);
                Controls.Remove(plusRightLabel);
                Controls.Add(plusLeftLabel);

                Controls.Remove(start);
                Controls.Remove(num);
                Controls.Remove(lbll);
                Controls.Remove(lbl);
            }


        }
        Label lblprav, lbllev;
        public void Timer_Tick(object sender, EventArgs e)
        {
            lbll.Text = "" + k;
            k--;
            
        }
    }
}
