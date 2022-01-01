using System.Reflection.Metadata.Ecma335;

namespace SGraph.Core.Simulation
{
    public class Point2D : IPoint2D
    {
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString()
        {
            return $"x:{X} y:{Y}";
        }
    }
}