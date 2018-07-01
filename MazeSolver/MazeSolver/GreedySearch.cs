using System;
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
        //HashSet<int[]> track = new HashSet<int[]>();
        public PixelNode GSearch(int x, int y)
        {
            MessageBox.Show(x +" " +y);
            int[] temp = { x, y };
           // track.Add(temp);
            PixelPath myPath = new PixelPath(x, y, dimensions);
            pixel choice = new pixel(myPath.path[4].getCoord(),Color.Black);
            if(myPath.path[4].getCoord()[0]==endX && myPath.path[4].getCoord()[1]==endY)
            {
                return new PixelNode(myPath);
            }
            else if(x<0||y<0)
            {
                return null;
            }
            Heuristic fCost = new Heuristic();
            for (int i = 0; i<9; i++)
            {
               // if(track.Contains(myPath.path[i].getCoord()))
                //{
                   // continue;
               // }
                Heuristic tempCost = new Heuristic(myPath.path[i].getCoord());
                if(i == 4)
                {
                    continue; //center pixel is the first pixel we account for and we don't want to stay there.
                }
                if(fCost.getHCost() > tempCost.getHCost())
                {
                    if(myPath.checker[i]==true)
                    {
                        choice = myPath.path[i];
                    }
                    else
                    {
                        //invald pixel location, Skip!
                    }
                }
            }
            int[] currentCoord = { choice.getCoord()[0], choice.getCoord()[1] };
            if(currentCoord[0]==endX && currentCoord[1]==endY)
            {
                PixelPath end = new PixelPath(currentCoord[0], currentCoord[1],dimensions);
                PixelNode myNode = new PixelNode(end);
                return myNode;
            }
            else if(choice.Equals(myPath.path[4]))
            {
                MessageBox.Show("We are not moving");
                return null;
            }
            else
            {
                return GSearch(currentCoord[0], currentCoord[1]);
            }
        }
    }
}
