﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MazeSolver
{
    public partial class Form1 : Form
    {
        //Need maze
        //start pixel
        //end pixel
        int depthLimit = 1000; //change for deeper or shallower search
        public PixelNode ASearch()
        {
            Frontier myQueue = new Frontier();
            PixelPath beginPixel, endPixel;
            beginPixel = new PixelPath(startX, startY, dimensions);
            endPixel = new PixelPath(endX, endY, dimensions);
            HashSet<int[]> explored = new HashSet<int[]>();
            PixelNode startNode = new PixelNode(beginPixel);
            if(beginPixel.Equals(endPixel))
            {//start and end is the same place. This line is here for satisfying the 
            //alogorithm rather than consistent application. I don't know if there is a situation that a pixel could be marked as red and blue
                return startNode;
            }
            myQueue.Add(startNode);
            while(!myQueue.IsEmpty())
            {
                PixelNode temp = myQueue.PopTop();
                if(temp==null||temp.depth==depthLimit)
                {
                    MessageBox.Show("TempInvalid");
                    return null;
                }
                else
                {
                    if(explored.Contains(temp.myCoord))
                    {
                        continue;
                        //no reason to do anything, this pixel has been explored
                    }
                    else
                    {//unexplored
                        if(temp.IsEnd())
                        {//We found the end!
                            return temp;
                        }
                        else
                        {//start processing pixelNode
                            temp.Expand();
                            foreach(PixelNode child in temp.choices)
                            {
                                if(!(myQueue.Contains(child)))
                                {//add children not in Queue
                                    myQueue.Add(child);
                                }
                            }
                            explored.Add(temp.myCoord);
                        }
                    }
                }
            }
            MessageBox.Show("We didn't find it");
            return null;
        }
    }
}
