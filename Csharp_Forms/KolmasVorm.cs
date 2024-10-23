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
        Button start, restart, btn3;
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

            btn3 = new Button();
            btn3.Text = "Set the background color";
            btn3.Height = 30;
            btn3.Width = 150;
            btn3.BackColor = Color.LightBlue;
            btn3.Location = new Point(350, 510);
            btn3.Click += Btn3_Click;

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

            num4 = new NumericUpDown();
            num4.Location = new Point(450, 400);
            num4.Size = new Size(100, 300);
            num4.Font = new Font("Arial", 20);

            start = new Button();
            start.Text = "Start";
            start.Height = 30;
            start.Width = 70;
            start.BackColor = Color.LightGreen;
            start.Location = new Point(250, 510);
            start.Click += start_Click;

            restart = new Button();
            restart.Text = "Restart";
            restart.Height = 30;
            restart.Width = 70;
            restart.BackColor = Color.Red;
            restart.Location = new Point(150, 510);
            restart.Click += restart_Click;

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

            Controls.Add(btn3);
            Controls.Add(start);
            Controls.Add(restart);
            Controls.Add(num);
            Controls.Add(lbll);
            Controls.Add(lbl);
        }
        int t = 0;
        private void Btn3_Click(object sender, EventArgs e)
        {
            t++;
            if (t == 9)
            { t = 1; }
            else if (t == 1)
            { this.BackColor = Color.Gray; }
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

        private void restart_Click(object sender, EventArgs e)
        {
            prav = 0;
            lev = 0;
            k = 30;

            num.Value = 0;
            num2.Value = 0;
            num3.Value = 0;
            num4.Value = 0;

            start_Click(sender, e);
        }

        int k = 30;
        int plusOtvet, minusOtvet, xOtvet, dOtvet;
        public void start_Click(object sender, EventArgs e)
        {


            int randomInt = random.Next(0, 101);
            plusLeftLabel.Text = "" + randomInt;
            int randomInt2 = random.Next(0, 101);
            plusRightLabel.Text = "" + randomInt2;
            plusOtvet = randomInt + randomInt2;


            int randomInt3 = random.Next(0, 101);
            int randomInt4 = random.Next(0, 101);

            while (randomInt3 < randomInt4)
            {
                randomInt3 = random.Next(0, 101);
                randomInt4 = random.Next(0, 101);
            }
            minusLeftLabel.Text = "" + randomInt3;
            minusRightLabel.Text = "" + randomInt4;
            minusOtvet = randomInt3 - randomInt4;


            int randomInt5 = random.Next(0, 50);
            LeftLabel3.Text = "" + randomInt5;
            int randomInt6 = random.Next(0, 15);
            RightLabel3.Text = "" + randomInt6;
            xOtvet = randomInt5 * randomInt6;



            int randomInt7 = random.Next(1, 101);
            int randomInt8 = random.Next(1, 101);

            while (randomInt7 % randomInt8 != 0)
            {
                randomInt7 = random.Next(1, 101);
                randomInt8 = random.Next(1, 101);
            }

            LeftLabel4.Text = "" + randomInt7;
            RightLabel4.Text = "" + randomInt8;
            dOtvet = randomInt7 / randomInt8;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;


        }
        Label lblprav, lbllev, endMessage;

        int prav, lev;
        public void Timer_Tick(object sender, EventArgs e)
        {
            lbll.Text = "" + k;
            k--;

            if (k == 0)
            {
                Timer timer = (Timer)sender;
                timer.Stop();

                Controls.Clear();

                if (num.Value == plusOtvet)
                {
                    prav++;
                }
                else 
                {
                    lev++;
                }

                if (num2.Value == minusOtvet)
                {
                    prav++;
                }
                else
                {
                    lev++;
                }

                if (num3.Value == xOtvet)
                {
                    prav++;
                }
                else
                {
                    lev++;
                }

                if (num4.Value == dOtvet)
                {
                    prav++;
                }
                else 
                {
                    lev++;
                }

                lblprav = new Label();
                lblprav.Text = "õiged vastused - "+ prav;
                lblprav.Font = new Font("Arial", 24);
                lblprav.Size = new Size(250, 80);
                lblprav.Location = new Point(150, 150);

                lbllev = new Label();
                lbllev.Text = "Valed vastused - "+ lev;
                lbllev.Font = new Font("Arial", 24);
                lbllev.Size = new Size(250, 80);
                lbllev.Location = new Point(150, 300);

                endMessage = new Label();
                endMessage.Text = "Aeg on läbi!";
                endMessage.Font = new Font("Arial", 24);
                endMessage.Size = new Size(250, 80);
                endMessage.Location = new Point(250, 0);

                Controls.Add(endMessage);
                Controls.Add(lblprav);
                Controls.Add(lbllev);
            }
        }
    }
}
