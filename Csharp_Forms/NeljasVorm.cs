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
    public partial class NeljasVorm : Form
    {
        List<string> pildid;
        PictureBox firstClicked = null;
        PictureBox secondClicked = null; 
        Timer hideTimer = new Timer();
        Timer gameTimer = new Timer(); 
        Label timeLabel;
        int Time = 0;

        public NeljasVorm(int w, int h)
        {
            this.Text = "Neljas vorm";
            this.Height = h + 200;
            this.Width = w;
            this.BackColor = Color.CornflowerBlue;

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

        int a = 0 ;
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

                Label lbl = new Label();
                lbl.Text = "oled mängu läbi teinud";
                lbl.Font = new Font("Arial", 24);
                lbl.Size = new Size(600, 50);
                lbl.Location = new Point(100, 300);

                Label lbll = new Label();
                lbll.Text = "sinu tulemus - "+ Time;
                lbll.Font = new Font("Arial", 24);
                lbll.Size = new Size(600, 50);
                lbll.Location = new Point(150, 350);

                Controls.Add(lbl);
                Controls.Add(lbll);
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