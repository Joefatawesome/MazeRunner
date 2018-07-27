using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TextBox textBoxInput = new TextBox();
        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            textBoxInput.Width = 250;
            textBoxInput.Height = 50;
            textBoxInput.BackColor = Color.Blue;
            textBoxInput.ForeColor = Color.White;
            textBoxInput.BorderStyle = BorderStyle.Fixed3D;
        }
        Image imageFile;
        public static int[] dimensions = new int[2];
        public static Bitmap maze; //note: y axis extends down rather than normal cartesian format
        public static int startX, startY, endX, endY; //x and y coordinates of red pixels and blue pixels
        public static string searchType; //for search type. Used for cost calculation later
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = imageFile;
        }
        private void keyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                textBoxInput.Text = "a";
            }
            else if (e.KeyCode == Keys.U)
            {
                textBoxInput.Text = "u";
            }
            else if (e.KeyCode == Keys.G)
            {
                textBoxInput.Text = "g";
            }
            else
            {
                textBoxInput.Text = "invalid";
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {//This is set up to execute the entire alogrithm on successful file selection
            //grabbing image file
            OpenFileDialog imageSelect = new OpenFileDialog();
            imageSelect.Filter = "PNG Image|*.png|JPG Image|*.jpg|BMP Image|*.bmp";
            imageSelect.Title = "Select Maze";
            if (imageSelect.ShowDialog() == DialogResult.OK)
            {
                imageFile = Image.FromFile(imageSelect.FileName); //we now have the file location of the maze
                pictureBox1.Image = imageFile;
                MessageBox.Show("Here is the selected Maze", "Maze Selected");
                maze = new Bitmap(imageFile);
                FindStartNEnd();
                MessageBox.Show(dimensions[0].ToString() + " by " + dimensions[1].ToString(), "Maze Dimensions");
                MessageBox.Show("(" + startX.ToString() + "," + startY.ToString() + ")", "Start Pixel");
                MessageBox.Show("(" + endX.ToString() + "," + endY.ToString() + ")", "End Pixel");
                //start search
                PixelNode finish = new PixelNode();
                bool check = true;
                
                while (check)
                {
                    
                    MessageBox.Show("Please type your prefered version of search: A, G, or U");
                    searchType = textBoxInput.Text;
                    switch (searchType)
                    {
                        case "u":
                            finish = USearch();
                            check = false;
                            break;
                        //case "g":
                        //    PixelNode finish = GSearch();
                        //break
                        case "a":
                            finish = ASearch();
                            check = false;
                            break;
                        default:
                            MessageBox.Show("Please type A, G, or U for your preferred search");
                            break;
                    }
                }
                //save output
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image|*.png|JPG Image|*.jpg|BMP Image|*.bmp";
                sfd.FileName = "outputMaze";
                sfd.Title = "Save Output Maze";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;
                    maze.Save(path);
                    imageFile = Image.FromFile(path);
                }
                try
                {//catch null pointers
                    MessageBox.Show(finish.myCoord.ToString());
                }
                catch(Exception myException)
                {
                    MessageBox.Show(myException.Message +" This happened because the algorithm travelled outside of the Maze.");
                }
            }
            else
            {
                MessageBox.Show("You did not select a file!\nPlease reselect the \"Select Maze\" button to choose a maze.", "User Failed to select a file");
            }
            
             
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

    }
}
