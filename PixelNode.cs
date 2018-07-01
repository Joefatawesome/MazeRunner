using System;
using System.Collections.Generic;
using System.Drawing;
namespace MazeSolver
{
    public class PixelNode
    {//made for our frontier class (FIFO structure)
        public int[] myCoord; //for easy center pixel access
        public PixelPath myPixel; //has all possible path up to 1 depth
        public PixelNode prev; //PixelNode we came from
        public List<PixelNode> choices = new List<PixelNode>(); //entire path taken thus far
        public int depth = 0; //current depth we are searching
        public FCost myF; //cost of PixelNode

        public PixelNode()
        {
            choices = new List<PixelNode>();
        }

        public PixelNode(PixelPath pixel)
        {
            myPixel = pixel;
            myCoord = pixel.path[4].getCoord();
            myF = new FCost(myCoord);
        }

        public PixelNode(PixelPath pixel, PixelNode prevPixel)
        {
            myPixel = pixel;
            myCoord = pixel.path[4].getCoord();
            prev = prevPixel;
        }

        public void Expand()
        {
            //foreach (PixelNode temp in choices)
            //{
            //    choices.RemoveAt(0);
            //}
            System.Windows.Forms.MessageBox.Show(myCoord[0] + " " + myCoord[1]);
            Form1.maze.SetPixel(myCoord[0], myCoord[1], Color.Green);
            for(int i = 0; i<9; i++)
            {
                if (i == 4)
                {
                    continue;//don't need to expand same pixel;
                }
                PixelPath temp = new PixelPath(myPixel.path[i].getCoord()[0], myPixel.path[i].getCoord()[1], Form1.dimensions);
                PixelNode choice = new PixelNode(temp, this);
                if (choice.myPixel.checker[i] == true)
                {
                    choice.depth = this.depth + 1;
                    choice.myF = this.myF;
                    choices.Add(choice);
                }
                else
                {
                    //not a valid expansion choice, continue
                    continue;
                }
            }

        }

        public Boolean IsEnd()
        {//check we are at final destination
            if (myCoord[0] == Form1.endX && myCoord[1] == Form1.endY)
            {
                return true;
            }
            return false;
        }
    }
}
