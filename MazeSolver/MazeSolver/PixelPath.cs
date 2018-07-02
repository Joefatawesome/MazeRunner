using System.Collections.Generic;
using System.Drawing;

namespace MazeSolver
{
    public class PixelPath
    {//possible paths at any pixel
        public List<pixel> path = new List<pixel>();
        //public int[][] path = new int[9][]; //possible paths
        public bool[] checker = new bool[9]; //check out of bounds path or black pixel
        public int[] myDimensions;
        int[] outOf = { -1, -1 }; //initialized outside of for loops. This value is used for pixels out of bounds.
        Color deadColor = Color.Black; //initialized outside of for loops. This color is used for pixels out of bounds.
        public PixelPath(int x, int y, int[] dimension)
        {
            int tempX, tempY;
            int[] temp = new int[2];
            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    tempX = x - i;
                    tempY = y + j;
                    temp[0] = tempX;
                    temp[1] = tempY;
                    if((temp[0] < dimension[0]) && (temp[1] < dimension[1]) && (temp[0] >= 0) && (temp[1] >=0))
                    {//fall within the bounds
                        path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
                    }
                    else
                    {//would be out of bitmap boundary
                        path.Add(new pixel(outOf, deadColor));
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                temp = path[i].getCoord();
                int X = temp[0];
                int Y = temp[1];
                Color tempColor = path[i].getColor();
                if ((X >= dimension[0]) || (Y >= dimension[1]) || (X < 0) || (Y < 0))
                {
                    checker[i] = false; //out of bounds path, don't use it
                }
                else if (tempColor.R == tempColor.G && tempColor.G == tempColor.B && tempColor.R == 0)
                {
                    checker[i] = false; //black, don't use it
                }
                else
                {
                    checker[i] = true;
                }
            }
            myDimensions = dimension;
        }
    }
}


//tempX = x - 1;
//tempY = y + 1;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x;
//tempY = y + 1;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x + 1;
//tempY = y + 1;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x - 1;
//tempY = y;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x;
//tempY = y;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x + 1;
//tempY = y;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x - 1;
//tempY = y - 1;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x;
//tempY = y - 1;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));
//tempX = x + 1;
//tempY = y - 1;
//temp[0] = tempX;
//temp[1] = tempY;
//path.Add(new pixel(temp, Form1.maze.GetPixel(temp[0], temp[1])));