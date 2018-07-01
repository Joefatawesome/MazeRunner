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
    {//All methods made for this class will be implemented here
        private void FindStartNEnd()
        {//finding starting position in maze
            dimensions[0] = maze.Width;
            dimensions[1] = maze.Height;
            startX = -1;
            startY = -1;
            endX = -1;
            endY = -1;
            //find red start
            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    Color temp = maze.GetPixel(i, j);
                    if (temp.R > temp.B && temp.R > temp.G && startX < 0)
                    {
                        startX = i;
                        startY = j;
                        continue;
                    }
                    else if (temp.B > temp.R && temp.B > temp.G && endX < 0)
                    {
                        endX = i;
                        endY = j;
                        continue;
                    }
                    else if (endX > 0 && startX > 0)
                    {
                        i = int.MaxValue - 1; j = i; //a start and end is found 
                    }
                }
            }
            if (startX == -1 || startY == -1)
            {
                MessageBox.Show("Failure to find start or end of maze");
            }
        }
        
        
    }
}
