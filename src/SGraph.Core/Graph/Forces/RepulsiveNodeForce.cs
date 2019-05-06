using System;
using System.Collections.Generic;
using SGraph.Core.Simulation;
using SGraph.Core.Simulation.Extensions;

namespace SGraph.Core.Graph.Forces
{
    class RepulsiveNodeForce<TNode> : IForce<PointEntity<TNode>>
    {
        
        private double _k, _kSquared;
        private double _maxRepulsiveForceDistance;

        public RepulsiveNodeForce(double k, double maxRepulsiveForceDistance)
        {
            _k = k;
            _maxRepulsiveForceDistance = maxRepulsiveForceDistance;

            _kSquared = _k * _k;
        }

        public void Apply(List<PointEntity<TNode>> nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    PointEntity<TNode> nodeA = nodes[i];
                    PointEntity<TNode> nodeB = nodes[j];

                    Point2D delta = nodeB.Position.SubCopy(nodeA.Position);

                    double distanceSquared = delta.X * delta.X + delta.Y * delta.Y;
                    if (distanceSquared < 0.01)
                        distanceSquared = 0.01;

                    double distance = Math.Sqrt(distanceSquared);

                    if (distance < _maxRepulsiveForceDistance)
                    {
                        double repulsiveForce = _kSquared / distance;

                        double forceX = (repulsiveForce * delta.X) / distance;
                        double forceY = (repulsiveForce * delta.Y) / distance;

                        nodeA.Force.Sub(forceX, forceY);
                        nodeB.Force.Add(forceX, forceY);
                    }
                }
            }
        }
    }
}
