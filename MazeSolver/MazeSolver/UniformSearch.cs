using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

//The Purpose of this file is to solve the maze in a more basic way to help debugging.

namespace MazeSolver
{
    public partial class Form1 : Form
    {
        //Need maze
        //start pixel
        //end pixel
        public PixelNode USearch()
        {
            Frontier myQueue = new Frontier();
            PixelPath beginPixel, endPixel;
            beginPixel = new PixelPath(startX, startY, dimensions);
            endPixel = new PixelPath(endX, endY, dimensions);
            HashSet<int[]> explored = new HashSet<int[]>();
            PixelNode startNode = new PixelNode(beginPixel);
            if (beginPixel.Equals(endPixel))
            {//start and end is the same place. This line is here for satisfying the 
             //alogorithm rather than consistent application. I don't know if there is a situation that a pixel could be marked as red and blue
                return startNode;
            }
            myQueue.Add(startNode);
            while (!myQueue.IsEmpty())
            {
                PixelNode temp = myQueue.PopTop();
                if (temp == null || temp.depth == depthLimit)
                {
                    MessageBox.Show("TempInvalid");
                    return null;
                }
                else
                {
                    if (temp.IsEnd())
                    {//We found the end!
                        return temp;
                    }
                    else
                    {//start processing pixelNode
                        temp.Expand();
                        foreach(PixelNode child in temp.choices)
                        {
                            myQueue.Add(child);
                        }
                        explored.Add(temp.myCoord);
                    }
                }
            }
            MessageBox.Show("We didn't find it");
            return null;
        }
    }
}
