using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeSolver
{
    //Issue is probably where we compare and store unexplored/explored pixels
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
                int heur1, heur2;
                switch (Frontier.searchType)
                {
                    case "u":
                        heur1 = pn1.myF.pCost;
                        heur2 = pn2.myF.pCost;
                        break;
                    case "g":
                        throw new Exception("Not Ready Yet");
                    //break;
                    case "a":
                        heur1 = pn1.myF.getFCost();
                        heur2 = pn2.myF.getFCost();
                        break;
                    default:
                        throw new Exception("Entered default case in cost calculation in SortedFrontier");
                }
                //TODO Set up U and A case. Fix code. Increment partial cost
                int result = heur1.CompareTo(heur2);
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

                        switch (Frontier.searchType)
                        {
                            case "u":
                                heur1 = pn1.prev.myF.pCost;
                                heur2 = pn1.prev.myF.pCost;
                                return heur1.CompareTo(heur2);
                            case "g":
                                throw new Exception("Not Ready Yet");
                            //break;
                            case "a":
                                heur1 = pn1.prev.myF.getFCost();
                                heur2 = pn2.prev.myF.getFCost();
                                return heur1.CompareTo(heur2);
                            default:
                                throw new Exception("Entered default case in cost calculation in SortedFrontier");
                        }
                    }
                }
                //catching comparison error where we don't fit into one of these cases
                throw new Exception("Error in Compare method for PixelNode");
            }
        }
    }
    public class Frontier
    {
        SortedSet<PixelNode> unexplored;
        public static string searchType;
        public Frontier()
        {
            //default search
            unexplored = new SortedSet<PixelNode>(new PixelNodeComparator());
            searchType = "a";
        }
        public Frontier(string mySearch)
        {
            unexplored = new SortedSet<PixelNode>(new PixelNodeComparator());
            searchType = mySearch;
        }
        public Boolean IsEmpty()
        {//check if empty
            if (!unexplored.Any())
            {
                return true;
            }
            return false;
        }

        public PixelNode PopTop()
        {//remove and return first element
            if (IsEmpty())
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
                for (int j = 0; j < 9; j++)
                {
                    int[] temp = i.myPixel.path[j].getCoord();
                    if (temp[0] == x && temp[1] == y)
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
