namespace SGraph.Core.Simulation
{
    public class PointEntity<T> 
    {
        public PointEntity(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }

        public Point2D Position = new Point2D(0, 0);
        public Vector2D Force = new Vector2D();
    }
}