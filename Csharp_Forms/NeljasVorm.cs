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
        public NeljasVorm(int w, int h)
        {
            this.Text = "Neljas vorm";
            this.Height = h;
            this.Width = w;
            this.BackColor = Color.CornflowerBlue;
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }


            List<string> pildid = new List<string> { "sf.png", "kaneki.jpg", "bara.png","grom.jpg","sirok.jpg","kot.jpeg", "metal.jpg", "ivan.jpg", "sf.png", "kaneki.jpg", "bara.png", "grom.jpg", "sirok.jpg", "kot.jpeg", "metal.jpg", "ivan.jpg" };

            PictureBox pbox1, pbox2, pbox3, pbox4, pbox5, pbox6, pbox7, pbox8, pbox9, pbox10, pbox11, pbox12, pbox13, pbox14, pbox15, pbox16;
            PictureBox[] pboxes = new PictureBox[16];

            Random random = new Random();
            int x = 0;
            int y = 0;

            for (int i = 0; i < pboxes.Length; i++)
            {
                pboxes[i] = new PictureBox();
                pboxes[i].Name = "pbox" + (i + 1);
                pboxes[i].Location = new Point(x, y);
                pboxes[i].Size = new Size(140, 140);
                pboxes[i].SizeMode = PictureBoxSizeMode.StretchImage;

                int randomNumber = random.Next(0,pildid.Count);
                pboxes[i].Image = Image.FromFile(@"..\..\" + pildid[randomNumber]);
                pildid.RemoveAt(randomNumber);

                x += 150;
                if (i == 3 || i == 7 || i == 11)
                {
                    x = 0; y += 150;
                }

                Controls.Add(pboxes[i]);

            }

            this.Controls.Add(tableLayoutPanel);
        }
    }
}





    //label.Image = Image.FromFile(@"..\..\" + fail);