using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Forms
{
    public partial class NeljasVorm : Form
    {
        List<string> pildid;
        PictureBox firstClicked = null;
        PictureBox secondClicked = null;
        Timer hideTimer = new Timer();
        Timer gameTimer = new Timer();
        Label timeLabel, start, names, lblll;
        TextBox txt = new TextBox();
        Button btn = new Button();
        int Time = 0;
        string pathName = @"C:\Users\slava\Source\Repos\Csharp_Forms\Csharp_Forms\name.txt";
        string pathResult = @"C:\Users\slava\Source\Repos\Csharp_Forms\Csharp_Forms\result.txt";

        public NeljasVorm(int w, int h)
        {
            this.Text = "Neljas vorm";
            this.Height = h + 200;
            this.Width = w;
            this.BackColor = Color.CornflowerBlue;



            start = new Label();
            start.Text = "Pildid Mäng";
            start.Size = new Size(300, 50);
            start.Location = new Point(200, 100);
            start.Font = new Font("Arial", 24, FontStyle.Bold);

            txt = new TextBox();
            txt.Size = new Size(300, 200);
            txt.Location = new Point(200, 400);

            names = new Label();
            names.Text = "Sisesta oma nimi";
            names.Size = new Size(300, 50);
            names.Location = new Point(200, 350);
            names.Font = new Font("Arial", 24, FontStyle.Bold);

            btn = new Button();
            btn.Text = "Start";
            btn.Size = new Size(300, 100);
            btn.Location = new Point(200, 500);
            btn.Font = new Font("Arial", 24, FontStyle.Bold);
            btn.Click += btn_Click;


            Controls.Add(names);
            Controls.Add(txt);
            Controls.Add(start);
            Controls.Add(btn);
        }

        private void btn_Click(object sender, EventArgs e)
        {

            Controls.Clear();

            timeLabel = new Label();
            timeLabel.Text = "Time: 0 sec.";
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            timeLabel.Height = 50;
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(timeLabel);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                RowCount = 4,
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            pildid = new List<string>
                        {
                            "sf.png", "kaneki.jpg", "bara.png", "grom.jpg", "sirok.jpg", "kot.jpeg",
                            "metal.jpg", "ivan.jpg", "sf.png", "kaneki.jpg", "bara.png", "grom.jpg",
                            "sirok.jpg", "kot.jpeg", "metal.jpg", "ivan.jpg"
                        };

            Random random = new Random();
            pildid = pildid.OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < 16; i++)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Name = "pbox" + (i + 1),
                    Dock = DockStyle.Fill,
                    BackColor = Color.CornflowerBlue,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = pildid[i],
                };

                pictureBox.Click += PictureBox_Click;
                tableLayoutPanel.Controls.Add(pictureBox);
            }

            this.Controls.Add(tableLayoutPanel);

            hideTimer.Interval = 1000;
            hideTimer.Tick += HideTimer_Tick;

            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Time++;
            timeLabel.Text = $"Time: {Time} sec";
        }

        int a = 0;
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (hideTimer.Enabled || secondClicked != null)
                return;

            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox.BackColor != Color.CornflowerBlue)
                return;

            clickedPictureBox.Image = Image.FromFile(@"..\..\" + clickedPictureBox.Tag.ToString());
            clickedPictureBox.BackColor = Color.White;

            if (firstClicked == null)
            {
                firstClicked = clickedPictureBox;
            }
            else
            {
                secondClicked = clickedPictureBox;

                if (firstClicked.Tag.ToString() == secondClicked.Tag.ToString())
                {
                    firstClicked = null;
                    secondClicked = null;
                    a++;

                }
                else
                {
                    hideTimer.Start();
                }
            }
            if (a == 8)
            {
                gameTimer.Stop();

                Controls.Clear();

                using (StreamWriter sw = new StreamWriter(pathResult, true))
                {
                    sw.WriteLine(Time);
                }

                using (StreamWriter sw = new StreamWriter(pathName, true))
                {
                    sw.WriteLine(txt.Text + " - " + Time);
                }

                int minNumber = 1000;
                int minIndex = 0;
 
                string[] results = File.ReadAllLines(pathResult);
                int[] intArray = new int[results.Length];

                for (int y = 0; y < results.Length; y++)
                {
                    intArray[y] = int.Parse(results[y]);
                }

                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] < minNumber)
                    {
                        minNumber = intArray[i];
                        minIndex = i;
                    }
                }

                
                string[] names = File.ReadAllLines(pathName);


                Label lbl = new Label();
                lbl.Text = "oled mängu läbi teinud"; ///////////////////////////////////
                lbl.Font = new Font("Arial", 24);
                lbl.Size = new Size(600, 50);
                lbl.Location = new Point(100, 300);

                Label lbll = new Label();
                lbll.Text = "Sinu tulemus - " + Time;
                lbll.Font = new Font("Arial", 24);
                lbll.Size = new Size(600, 50);
                lbll.Location = new Point(150, 450);

                Label lblll = new Label();
                lblll.Text = "luchshiy igrok eto " + names[minIndex];
                lblll.Font = new Font("Arial", 24);
                lblll.Size = new Size(600, 50);
                lblll.Location = new Point(150, 350);



                Controls.Add(lbl);
                Controls.Add(lbll);
                Controls.Add(lblll);
                
            }
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            hideTimer.Stop();

            firstClicked.Image = null;
            firstClicked.BackColor = Color.CornflowerBlue;
            secondClicked.Image = null;
            secondClicked.BackColor = Color.CornflowerBlue;

            firstClicked = null;
            secondClicked = null;
        }
    }
}






//label.Image = Image.FromFile(@"..\..\" + fail);