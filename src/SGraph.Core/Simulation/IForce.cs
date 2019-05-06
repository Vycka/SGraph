using System.Collections.Generic;

namespace SGraph.Core.Simulation
{
    public interface IForce<T>
    {
        void Apply(List<T> entities);
    }
}