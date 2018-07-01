using System.Drawing;

namespace MazeSolver
{
    public class pixel
    {
        Color myColor;
        int[] myCoord;
        public pixel(int[] coord, Color color)
        {
            myCoord = coord;
            myColor = color;
        }
        public Color getColor()
        {
            return myColor;
        }
        public int[] getCoord()
        {
            return myCoord;
        }
    }
}
