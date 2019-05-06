namespace SGraph.Core.Simulation.Extensions
{
    public static class Point2DExtensions
    {
        public static Point2D SubCopy(this IPoint2D from, IPoint2D value)
        {
            return new Point2D(from.X - value.X, from.Y - value.Y);
        }

        public static Point2D AddCopy(this IPoint2D from, IPoint2D value)
        {
            return new Point2D(from.X + value.X, from.Y + value.Y);
        }

        public static Point2D MultiplyCopy(this IPoint2D what, double multipier)
        {
            return new Point2D(what.X * multipier, what.Y * multipier);
        }

        public static void Add(this IPoint2D target, IPoint2D other)
        {
            target.X += other.X;
            target.Y += other.Y;
        }
        public static void Add(this IPoint2D target, double x, double y)
        {
            target.X += x;
            target.Y += y;
        }

        public static void Sub(this IPoint2D target, double x, double y)
        {
            target.X -= x;
            target.Y -= y;
        }

        public static void Set(this IPoint2D target, double xyValue)
        {
            target.X = xyValue;
            target.Y = xyValue;
        }

        public static void Constrain(this IPoint2D target, double min, double max)
        {
            if (target.X > max)
                target.X = max;
            else if (target.X < min)
                target.X = min;


            if (target.Y > max)
                target.Y = max;
            else if (target.Y < min)
                target.Y = min;
        }
    }
}
