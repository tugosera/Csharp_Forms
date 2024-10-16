﻿using System;
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
        List <string> elemendid = new List<string> {"nupp", "silt", "pilt", "märkeruut", "radionupp", "tekstikast","Loetelu", "Tabel", "Dialoogi aknad", "TeineVorm", "KolmasVorm", "NeljasVorm" };
        List<string> rbtn_list = new List<string> { "esimene", "teine", "kolmas" };
        TreeView tree;
        Button btn, btn1, btn2, btn3;
        Label lbl;
        PictureBox pBox;
        CheckBox chk1, chk2;
        RadioButton rbtn1, rbtn2, rbtn3;
        TextBox txt;
        ListBox lb;
        DataSet ds;
        DataGridView dg;

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
                chk1 = new CheckBox();
                chk1.Checked = false;
                chk1.Text = e.Node.Text;
                chk1.Size = new Size(chk1.Text.Length * 10, chk1.Size.Height * 2);
                chk1.Location = new Point(150, btn.Height + lbl.Height + pBox.Height);
                chk1.CheckedChanged += new EventHandler(Chk_CheckedChanged);

                chk2 = new CheckBox();
                chk2.Checked = false;
                chk2.BackgroundImage = Image.FromFile(@"..\..\sf.png");
                chk2.BackgroundImageLayout = ImageLayout.Zoom;
                chk2.Size = new Size(100, 100);
                chk2.Location = new Point(150, btn.Height + lbl.Height + pBox.Height + chk1.Height);
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
            else if (e.Node.Text == "Loetelu")
            {
                lb = new ListBox();
                foreach (string item in rbtn_list)
                {
                    lb.Items.Add(item);
                }
                lb.Location = new Point(300, 300);
                lb.SelectedIndexChanged += lb_SelectedIndexChanged;
                Controls.Add(lb);
            }
            else if (e.Node.Text == "Tabel")
            {
                ds= new DataSet("XML fail");
                ds.ReadXml(@"..\..\menu.xml");
                dg=new DataGridView();
                dg.Location = new Point(450, 0);
                dg.DataSource = ds;
                dg.DataMember = "menu";
                dg.RowHeaderMouseClick += Dg_RowHeaderMouseClick;
                Controls.Add(dg);
            }
            else if (e.Node.Text == "Dialoogi aknad")
            {
                //MessageBox.Show("Dialoog", "See on lihtne akken");
                //var vastus = MessageBox.Show("Sissestame andmed", "Kas tahad InputBoxi kasutada?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if(vastus==DialogResult.Yes)
                //{
                //    string text = Interaction.InputBox("Sisesta midagi siia", "andmete sisestamine");
                //    Random random = new Random();
                //    DataRow dr = ds.Tables["food"].NewRow();
                //    dr["name"] = text;
                //    dr["price"] = "$"+(random.NextSingle()*10).ToString();
                //    dr["describtion"] = "Väga maitsev ";
                //    dr["calories"] = random.Next(10, 1000);

                //    MessageBox.Show("Oli sisestatud: "+ text);
                //}
            }
            else if(e.Node.Text == "TeineVorm")
            { 
                btn1 = new Button();
                btn1.Text = "Teine vorm";
                btn1.Height = 50;
                btn1.Width = 70;
                btn1.BackColor = Color.LightGreen;
                btn1.Location = new Point(500, 50);
                btn1.Click += Btn1_Click;
                Controls.Add(btn1);
            }
            else if (e.Node.Text == "KolmasVorm")
            {
                btn2 = new Button();
                btn2.Text = "Kolmas vorm";
                btn2.Height = 50;
                btn2.Width = 70;
                btn2.BackColor = Color.LightBlue;
                btn2.Location = new Point(500, 150);
                btn2.Click += Btn2_Click;
                Controls.Add(btn2);
            }
            else if (e.Node.Text == "NeljasVorm")
            {
                btn3 = new Button();
                btn3.Text = "Neljas vorm";
                btn3.Height = 50;
                btn3.Width = 70;
                btn3.BackColor = Color.LemonChiffon;
                btn3.Location = new Point(500, 250);
                btn3.Click += Btn3_Click;
                Controls.Add(btn3);
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            NeljasVorm neljasVorm = new NeljasVorm(600, 600);
            neljasVorm.Show();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            KolmasVorm kolmasVorm = new KolmasVorm(600, 600);
            kolmasVorm.Show();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TeineVorm teineVorm = new TeineVorm(550, 550);
            teineVorm.Show();
        }

        private void Dg_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt.Text = dg.Rows[e.RowIndex].Cells[0].Value.ToString() +" hind "+ dg.Rows
            [e.RowIndex].Cells[1].Value.ToString();
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lb.SelectedIndex)
            {
                case 0:tree.BackColor = Color.Chocolate; break;
                case 1:tree.ForeColor = Color.IndianRed; break;
                case 2:tree.BackColor = Color.Lavender; break;
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
