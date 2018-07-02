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

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        Image imageFile;
        public static int[] dimensions = new int[2];
        public static Bitmap maze; //note: y axis extends down rather than normal cartesian format
        public static int startX, startY, endX, endY; //x and y coordinates of red pixels and blue pixels

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = imageFile;
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
                PixelNode finish = USearch();
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
                //catch null pointers
                try
                {
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
