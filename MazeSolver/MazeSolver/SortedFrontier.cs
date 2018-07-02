using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeSolver
{
    public class PixelNodeComparator : IComparer<PixelNode>
    {
        public int Compare(PixelNode pn1, PixelNode pn2)
        {
            if (pn1 == null && pn2 == null)
            {
                return 0;
            }
            else if (pn1 == null)
            {
                return 1;
            }
            else if (pn2 == null)
            {
                return -1;
            }
            else
            {
                int result = pn1.myF.getCost().CompareTo(pn2.myF.getCost());
                if (result != 0)
                {
                    return result;
                }
                else if (result == 0)
                {
                    if (pn1.prev == null && pn2.prev == null)
                    {
                        return 0;
                    }
                    else if (pn1.prev == null)
                    {
                        return -1;
                    }
                    else if (pn2.prev == null)
                    {
                        return 1;
                    }
                    else
                    {
                        return pn1.prev.myF.getCost().CompareTo(pn2.prev.myF.getCost());
                    }
                }
            }
            throw new Exception("Error in Compare method for PixelNode");
        }
    }

    public class Frontier
    {
        SortedSet<PixelNode> unexplored;
        public Frontier()
        {
            unexplored = new SortedSet<PixelNode>(new PixelNodeComparator());
        }

        public Boolean IsEmpty()
        {//check if empty
            if(!unexplored.Any())
            {
                return true;
            }
            return false;
        }

        public PixelNode PopTop()
        {//remove and return first element
            if(IsEmpty())
            {
                return null;
            }
            else
            {
                PixelNode top = unexplored.First();
                unexplored.Remove(top);
                return top;
            }
        }

        public void Add(PixelNode pn)
        {//add PixelNode to unexplored
            unexplored.Add(pn);
        }

        public void Remove(PixelNode pn)
        {//remove PixelNode from unexplored
            unexplored.Remove(pn);
        }

        public Boolean Contains(int x, int y)
        {//checks if unexplored contains this pixel
            foreach (PixelNode i in unexplored)
            {
                for(int j = 0; j<9; j++)
                {
                    int[] temp = i.myPixel.path[j].getCoord();
                    if ( temp[0] == x && temp[1] == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean Contains(PixelNode pn)
        {//checks center of PixelNode to see if that is in unexplored
            int x = pn.myCoord[0];
            int y = pn.myCoord[1];
            return Contains(x, y);
        }
    }
}
