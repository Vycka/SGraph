namespace SGraph.Core.Simulation
{
    public class EntityLink<TEntity, TLink>
    {
        public EntityLink(TLink entity, PointEntity<TEntity> @from, PointEntity<TEntity> to)
        {
            Entity = entity;
            From = @from;
            To = to;
        }

        public TLink Entity { get; }

        public double Weight { get; }
        public PointEntity<TEntity> From { get; }
        public PointEntity<TEntity> To { get; }
    }
}