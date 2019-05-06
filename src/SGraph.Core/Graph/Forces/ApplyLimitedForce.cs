using System.Collections.Generic;
using SGraph.Core.Simulation;
using SGraph.Core.Simulation.Extensions;

namespace SGraph.Core.Graph.Forces
{
    public class ApplyLimitedForce<TNode> : IForce<PointEntity<TNode>>
    {
        private double _c;
        private double _maxMovement;
        private double _negativeMaxMovement;

        public ApplyLimitedForce(double c, double maxMovement)
        {
            _c = c;
            _maxMovement = maxMovement;
            _negativeMaxMovement = -_maxMovement;
        }

        public void Apply(List<PointEntity<TNode>> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                PointEntity<TNode> node = nodes[i];

                Point2D movement = node.Force.MultiplyCopy(_c);

                movement.Constrain(_negativeMaxMovement, _maxMovement);

                node.Position.Add(movement);

                node.Force.Set(0);
            }
        }
    }
}