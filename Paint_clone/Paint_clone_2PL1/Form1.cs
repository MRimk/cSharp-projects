using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Paint_clone_2PL1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SaveFileDialog1.Filter = "PNG file|*.png|JPG file|*.jpg;*.jpeg|BMP file|*.bmp|TIFF file|*.tiff";
            SaveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveFileDialog1.CheckPathExists = true;
            CurrentFont = this.Font;
            FontButton.Text = CurrentFont.Name + " " + CurrentFont.Size;
        }
        FileStream stream;
        Graphics gr;
        Color CurrColor = Color.MediumTurquoise;
        Color CurrColor2 = Color.MistyRose;
        Font CurrentFont;
        Bitmap CurrPicture; // set default width, height
        Pen CurrPen;
        float PenWidth = 1.0f;
        string path = string.Empty;
        bool change = false;
        bool drawing = false;
        Point startP = new Point();
        Point endP = new Point();
        Pen Eraser = new Pen(Color.White);
        int height;
        int width;
        LinearGradientMode gradMode;
        Point[] trianglePoints = new Point[3];
        byte clicks = 0;
        Point multiStart = new Point();
        Point multiLineEnd = new Point();
        short multiClicks = 0;
        int stAngle = 0;
        int swAngle = 0;
        private void ColorButton_Click(object sender, EventArgs e)
        {
            
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorButton.BackColor = ColorDialog1.Color;
                //save curr color
                CurrColor = ColorDialog1.Color;
                UpdatePen();
            }
        }

        private void Color2Button_Click(object sender, EventArgs e)
        {
            if (ColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color2Button.BackColor = ColorDialog1.Color;
                //save curr color
                CurrColor2 = ColorDialog1.Color;
                
            }
        }
        private void FontButton_Click(object sender, EventArgs e)
        {
            if (FontDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentFont = FontDialog1.Font;
                FontButton.Text = CurrentFont.Name + " " + CurrentFont.Size;
            }
        }

        private void P1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PenWidth = 1.0f;
            UpdatePen();
        }

        private void P2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PenWidth = 3.0f;
            UpdatePen();
            
        }

        private void P3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PenWidth = 8.0f;
            UpdatePen();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (path == string.Empty)
            {
                if (SaveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    //save picture 
                    CurrPicture.Save(SaveFileDialog1.FileName);
                    path = SaveFileDialog1.FileName;
                    change = false;
                }
                CurrPicture.Save(path);
                change = false;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //save picture 
                CurrPicture.Save(SaveFileDialog1.FileName);
                path = SaveFileDialog1.FileName;
                change = false;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (change)
            {
                DialogResult rez = MessageBox.Show("Are you sure you want to exit without saving?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rez == DialogResult.Yes)
                {
                    SaveToolStripMenuItem.PerformClick();
                }
            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ColorButton.BackColor = CurrColor;
            Color2Button.BackColor = CurrColor2;
            CurrPicture = new Bitmap(MainPicture.Width, MainPicture.Height);
            //initialise graphics variable
            gr = Graphics.FromImage(CurrPicture);
            //set default back
            gr.Clear(Color.White);
            //init pen
            CurrPen = new Pen(CurrColor, PenWidth);
            MainPicture.Image = CurrPicture;
            
        }

        private void MainPicture_Paint(object sender, PaintEventArgs e)
        {
            gr = this.CreateGraphics();
            gr = Graphics.FromImage(CurrPicture);
        }

        private void UpdatePen()
        {
            CurrPen = new Pen(CurrColor, PenWidth);
            Eraser.Width = PenWidth;
        }

        private void MainPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                if (LineRadioButton.Checked)
                {
                    gr.DrawLine(CurrPen, startP, e.Location);
                    startP = e.Location;
                }
                else if (EraserRadioButton.Checked)
                {
                    gr.DrawLine(Eraser, startP, e.Location);
                    startP = e.Location;
                }
                
                UpdatePic();
            }
        }

        private void MainPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawing == false)
                {
                    drawing = true;
                    // save curr mouse pos
                    startP = e.Location;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (MultiAngleRadioButton.Checked)
                {
                    gr.DrawLine(CurrPen, multiStart, multiLineEnd);
                    multiClicks = 0;
                    
                }
                UpdatePic();
            }
        }

        private void MainPicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                endP = e.Location;
                if (RectangleRadioButton.Checked)
                {
                    endP = e.Location; // rectangle ends
                    //calc height
                    height = Math.Abs(endP.Y - startP.Y);
                    width = Math.Abs(endP.X - startP.X);
                    if (endP.X < startP.X)
                    {
                        startP.X = endP.X;
                    }
                    if (endP.Y < startP.Y)
                    {
                        startP.Y = endP.Y;
                    }
                    if (height == 0 || width == 0)
                    {
                        return;
                    }
                    gr.DrawRectangle(CurrPen, startP.X, startP.Y, width, height);
                }
                else if (GradientRectAngleRadioButton.Checked)
                {
                    endP = e.Location; // rectangle ends
                    height = Math.Abs(endP.Y - startP.Y);
                    width = Math.Abs(endP.X - startP.X);
                    if (endP.X < startP.X)
                    {
                        startP.X = endP.X;
                    }
                    if (endP.Y < startP.Y)
                    {
                        startP.Y = endP.Y;
                    }
                    if (height==0||width==0)
                    {
                        return;
                    }
                    Brush myBrush = new LinearGradientBrush(new Rectangle(startP.X, startP.Y, width, height), CurrColor,CurrColor2, gradMode);
                    gr.FillRectangle(myBrush, startP.X, startP.Y, width, height);
                }
                else if (TriangleRadioButton.Checked)
                {
                    if (clicks<2)
                    {
                        trianglePoints[clicks] = endP;
                        clicks++;
                        if (clicks==2)
                        {
                            gr.DrawLine(CurrPen, trianglePoints[0], trianglePoints[1]);
                        }
                        
                    }
                    else 
                    {
                        trianglePoints[clicks] = endP;
                        clicks = 0;
                        gr.DrawLine(CurrPen, trianglePoints[0], trianglePoints[2]);
                        gr.DrawLine(CurrPen, trianglePoints[1], trianglePoints[2]);
                    }

                }
                else if (CircleRadioButton.Checked)
                {
                    height = Math.Abs(endP.Y - startP.Y);
                    width = Math.Abs(endP.X - startP.X);
                    if (endP.X < startP.X)
                    {
                        startP.X = endP.X;
                    }
                    if (endP.Y < startP.Y)
                    {
                        startP.Y = endP.Y;
                    }
                    if (height == 0 || width == 0)
                    {
                        return;
                    }
                    if (width>height)
                    {
                        height = width;
                    }
                    else
                    {
                        width = height;
                    }
                    gr.DrawEllipse(CurrPen, startP.X, startP.Y, width, height);
                }
                else if (ArcRadioButton.Checked)
                {
                    height = Math.Abs(endP.Y - startP.Y);
                    width = Math.Abs(endP.X - startP.X);
                    if (endP.X < startP.X)
                    {
                        startP.X = endP.X;
                    }
                    if (endP.Y < startP.Y)
                    {
                        startP.Y = endP.Y;
                    }
                    if (height == 0 || width == 0)
                    {
                        return;
                    }
                    gr.DrawArc(CurrPen, startP.X, startP.Y, width, height, stAngle, swAngle);
                }
                else if (MultiAngleRadioButton.Checked)
                {
                    if (multiClicks==0)
                    {
                        multiStart = startP;
                        multiLineEnd = endP;
                        gr.DrawLine(CurrPen, multiStart, multiLineEnd);

                    }
                    else
                    {
                        gr.DrawLine(CurrPen, multiLineEnd, endP);
                        multiLineEnd = endP;
                    }
                    multiClicks++;
                }
                else if (TextRadioButton.Checked)
                {

                    gr.DrawString(TextDrawTextBox.Text, CurrentFont, new SolidBrush(CurrColor), startP);
                }
                UpdatePic();
            }
            drawing = false;

        }
        private void UpdatePic()
        {
            gr = Graphics.FromImage(CurrPicture);
            MainPicture.Image = CurrPicture;
        }

        private void GradientRectAngleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (GradientRectAngleRadioButton.Checked)
            {
                gradientToolStripMenuItem.Visible = true;
                if (chbInfo.Checked)
                {
                    MessageBox.Show("Drag pressed mouse like in MS Paint. Select gradient mode in tool strip menu", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradMode = LinearGradientMode.Horizontal;
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradMode = LinearGradientMode.Vertical;
        }

        private void forwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradMode = LinearGradientMode.ForwardDiagonal;
        }

        private void backwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gradMode = LinearGradientMode.BackwardDiagonal;
        }

        private void TextRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TextDrawTextBox.Visible = TextRadioButton.Checked;
            FontButton.Visible = TextRadioButton.Checked;
            if (TextRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("At first You have to write text in the textbox. Later You can choose font in top left corner and then you can press on Your painting", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ArcRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            grbArc.Visible = ArcRadioButton.Checked;
            if (ArcRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("Choose an angle of which You want to form an arc", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (LineRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("Just draw line like in MS Paint", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void trcStart_Scroll(object sender, EventArgs e)
        {
            stAngle = trcStart.Value;
            lblStartAngle.Text = trcStart.Value.ToString();
        }

        private void trcSweep_Scroll(object sender, EventArgs e)
        {
            swAngle = trcSweep.Value;
            lblSweepAngle.Text = trcSweep.Value.ToString();
        }

        private void chkUpDown_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpDown.Checked)
            {
                stAngle -= 180;
                swAngle -= 180;
            }
        }

        private void RectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RectangleRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("Drag pressed mouse like in MS Paint", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void TriangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TriangleRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("Press 3 points on page to form a triangle", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CircleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CircleRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("Drag a line to choose the radius of a circle", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MultiAngleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MultiAngleRadioButton.Checked && chbInfo.Checked)
            {
                MessageBox.Show("Press left mouse button to draw lines and right mouse button to finish the figure", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}