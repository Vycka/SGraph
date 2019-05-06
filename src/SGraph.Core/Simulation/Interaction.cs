using System.Collections.Generic;

namespace SGraph.Core.Simulation
{
    public struct Interaction<T> : IInteraction
    {
        public IForce<T> Force;
        public List<T> Entities;

        public Interaction(IForce<T> force, List<T> entities)
        {
            Force = force;
            Entities = entities;
        }

        public void Apply()
        {
            Force.Apply(Entities);
        }
    }
}