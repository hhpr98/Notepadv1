﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadPlus
{
    public partial class MainForm : Form
    {
        private TextBox txt;
        private Panel pn;
        private Label lbLn, lbCol, lblFont;
        private bool isSaved = false;
        private int ln = 1;
        private int col = 1;

        public MainForm()
        {
            InitializeComponent();

            // add textbox to components
            txt = new TextBox();
            txt.AutoSize = false;
            int sz1 = this.Size.Width;
            int sz2 = this.Size.Height;
            txt.Size = new Size(sz1 - 15, sz2 - 24 - 65); // 65 là phần info (footer) dưới cùng
            txt.Location = new Point(0, 24);
            txt.Multiline = true;
            txt.Font = new Font("Time New Roman", 11F, FontStyle.Regular);
            txt.BorderStyle = BorderStyle.None;
            txt.ScrollBars = ScrollBars.Vertical;
            this.Controls.Add(txt);

            // add a panel to footer
            pn = new Panel();
            pn.Size = new Size(sz1, 30);
            pn.Location = new Point(0, sz2 - 65);
            pn.BackColor = Color.Khaki;
            this.Controls.Add(pn);

            lbLn = new Label();
            lbLn.Text = "Ln : " + ln.ToString();
            lbLn.Font = new Font("Arial", 11F, FontStyle.Regular);
            lbLn.Location = new Point(sz1-150,5); // location theo panel
            lbLn.Size = new Size(50, 25);
            pn.Controls.Add(lbLn);

            lbCol = new Label();
            lbCol.Text = "Col : " + col.ToString();
            lbCol.Font = new Font("Arial", 11F, FontStyle.Regular);
            lbCol.Location = new Point(sz1 - 100, 5); // location theo panel
            lbCol.Size = new Size(50, 25);
            pn.Controls.Add(lbCol);

            lblFont = new Label();
            lblFont.Text = "Windows(CRFL)  UTF-8";
            lblFont.Font = new Font("Arial", 11F, FontStyle.Regular);
            lblFont.Location = new Point(sz1 - 350, 5); // location theo panel
            lblFont.Size = new Size(200, 25);
            pn.Controls.Add(lblFont);

            // add event
            this.SizeChanged += MainForm_SizeChanged;
            txt.TextChanged += Txt_TextChanged;
        }

        #region event
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            // count how many line & column
            ln = txt.Lines.Length;
            if (ln == 0)
            {
                setLineColText(1, 1);
                return;
            }
            col = txt.Lines[ln-1].Length + 1;
            setLineColText(ln, col);
        }

        

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            int sz1 = this.Size.Width;
            int sz2 = this.Size.Height;
            txt.Size = new Size(sz1 - 15, sz2 - 24 - 65);
            pn.Size = new Size(sz1, 30);
            pn.Location = new Point(0, sz2 - 65);
            lbLn.Location = new Point(sz1 - 150, 5);
            lbCol.Location = new Point(sz1 - 100, 5);
            lblFont.Location = new Point(sz1 - 350, 5);
        }
        #endregion

        #region function
        private void setLineColText(int line,int column)
        {
            lbLn.Text = "Ln : " + line.ToString();
            lbCol.Text = "Col : " + column.ToString();
        }
        #endregion
    }
}
