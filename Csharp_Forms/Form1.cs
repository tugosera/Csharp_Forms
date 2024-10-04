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
    public partial class Form1 : Form
    {
        List <string> elemendid = new List<string> {"nupp", "silt", "pilt", "märkeruut", "radionupp", "tekstikast" };
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pBox;
        CheckBox chk1, chk2;
        RadioButton rbtn1, rbtn2, rbtn3;
        TextBox txt;

        public Form1()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid:");
            foreach (var element in elemendid)
            {
                tn.Nodes.Add(new TreeNode(element));
            }
            

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            //nupp
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Height = 50;
            btn.Width = 70;
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;

            //silt-label
            lbl = new Label();
            lbl.Text = "Aknade elemendid c# abil";
            lbl.Font = new Font("Arial", 30, FontStyle.Underline);
            lbl.Size = new Size(200,50);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;

            pBox = new PictureBox();
            pBox.Size = new Size(60, 60);
            pBox.Location = new Point(150, btn.Height + lbl.Height + 5);
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.Image = Image.FromFile(@"..\..\sf.png");
            pBox.DoubleClick += PBox_DoubleClick;

        }
        int tt = 0;
        private void PBox_DoubleClick(object sender, EventArgs e)
        {
            string[] pildid = { "sf.png", "kaneki.jpg", "bara.png" };
            string fail = pildid[tt];
            pBox.Image = Image.FromFile(@"..\..\"+fail);
            tt++;
            if (tt == 3) { tt = 0; }
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.Font = new Font("Arial", 30, FontStyle.Underline);
            lbl.ForeColor = Color.Green;
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.Font = new Font("Arial", 32, FontStyle.Underline);
            lbl.ForeColor = Color.Yellow;
        }

        int t = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            t++;
            if (t%2 == 0)
            {
                btn.BackColor = Color.Red;
            }
            else 
            {
                btn.BackColor = Color.White;
            }
            
            
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "nupp")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "silt")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "pilt")
            {
                Controls.Add(pBox);
            }
            else if (e.Node.Text == "märkeruut")
            {
                chk1=new CheckBox();
                chk1.Checked = false;
                chk1.Text= e.Node.Text;
                chk1.Size = new Size(chk1.Text.Length*10, chk1.Size.Height*2);
                chk1.Location = new Point(150,btn.Height + lbl.Height + pBox.Height );
                chk1.CheckedChanged += new EventHandler(Chk_CheckedChanged);

                chk2 = new CheckBox();
                chk2.Checked = false;
                chk2.BackgroundImage = Image.FromFile(@"..\..\sf.png");
                chk2.BackgroundImageLayout = ImageLayout.Zoom;
                chk2.Size = new Size(100, 100);
                chk2.Location = new Point(150, btn.Height + lbl.Height + pBox.Height +chk1.Height  );
                chk2.CheckedChanged += new EventHandler(Chk_CheckedChanged);

                Controls.Add(chk1);
                Controls.Add(chk2);
            }
            else if (e.Node.Text == "radionupp")
            {
                rbtn1 = new RadioButton();
                rbtn1.Checked = false;
                rbtn1.Text = "Black theme";
                rbtn1.Location = new Point(300, 50);
                rbtn1.CheckedChanged += new EventHandler(Btn_CheckedChanged);

                rbtn2 = new RadioButton();
                rbtn2.Checked = false;
                rbtn2.Text = "Red theme";
                rbtn2.Location = new Point(300, 100);
                rbtn2.CheckedChanged += new EventHandler(Btn_CheckedChanged);

                Controls.Add(rbtn1);
                Controls.Add(rbtn2);

                
            }
            else if (e.Node.Text == "tekstikast")
            {
                txt = new TextBox();
                txt.Location = new Point(300, 200);
                txt.Font = new Font("Arial", 28);
                txt.Width = 200;
                txt.TextChanged += Txt_TextChanged;
                Controls.Add(txt);
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            lbl.Text = txt.Text;
        }

        private void Btn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn1.Checked)
            {
                BackColor = Color.Black;
            }
            else if (rbtn2.Checked)
            {
                BackColor= Color.Red;
            }
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked && chk2.Checked)
            {
                lbl.BorderStyle = BorderStyle.Fixed3D;
                pBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else if(chk1.Checked)
            {
                lbl.BorderStyle= BorderStyle.Fixed3D;
                pBox.BorderStyle= BorderStyle.None;
            }
            else if (chk2.Checked)
            {
                lbl.BorderStyle = BorderStyle.None;
                pBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                lbl.BorderStyle = BorderStyle.None;
                pBox.BorderStyle = BorderStyle.None;
            }
        }
    }
}
