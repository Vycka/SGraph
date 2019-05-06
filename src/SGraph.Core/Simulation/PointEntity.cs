namespace SGraph.Core.Simulation
{
    public class PointEntity<T>
    {
        public PointEntity(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }

        public Point2D Position { get; } = default;
        public Vector2D Force { get; } = default;
    }
}