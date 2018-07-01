using System;

namespace MazeSolver
{
    public class Heuristic
    {
        int hCost;

        public Heuristic()
        {
            hCost = int.MaxValue;
        }

        public Heuristic(int[] coord)
        {
            if(coord[0]<0||coord[1]<0)
            {
                hCost = int.MaxValue;
            }
            else
            {
                double two = 2.0;
                double tempX = (Math.Pow(System.Convert.ToDouble(Form1.endX - coord[0]), two));
                double tempY = (Math.Pow(System.Convert.ToDouble(Form1.endY - coord[1]), two));
                int result = System.Convert.ToInt32(tempX + tempY);
                hCost = System.Convert.ToInt32(Math.Sqrt(result));
            }
        }

        public int getHCost()
        {
            return hCost;
        }
    }

    public class FCost
    {//heuristic cost + partial cost = function cost
        public int pCost = 1;
        Heuristic hCost;

        public FCost()
        {
            hCost = new Heuristic();
        }

        public FCost(int[] myCoord)
        {
            hCost = new Heuristic(myCoord);
        }

        public int getCost()
        {
            return hCost.getHCost() + pCost;
        }
    }
}
