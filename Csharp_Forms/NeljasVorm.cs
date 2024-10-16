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

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    string[] pildid = { "sf.png", "kaneki.jpg", "bara.png","grom.jpg","sirok.jpg","kot.jpeg", "metal.jpg", "ivan.jpg"};
                    string fail = pildid[col];

                    PictureBox label = new PictureBox();
                    label.Dock = DockStyle.Fill;
                    label.BackColor = Color.CornflowerBlue;
                    label.Image = Image.FromFile(@"..\..\" + fail);
                    label.SizeMode = PictureBoxSizeMode.Zoom;
                    tableLayoutPanel.Controls.Add(label, col, row);
                }
            }

            this.Controls.Add(tableLayoutPanel);

        }
    }
}
