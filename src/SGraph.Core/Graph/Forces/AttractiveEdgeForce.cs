using System;
using System.Collections.Generic;
using SGraph.Core.Simulation;
using SGraph.Core.Simulation.Extensions;

namespace SGraph.Core.Graph.Forces
{
    public class AttractiveEdgeForce<TNode, TEdge> : IForce<EntityLink<TNode, TEdge>>
    {
        private double _k, _kSquared;
        private double _maxRepulsiveForceDistance;
        
        public AttractiveEdgeForce(double k, double maxRepulsiveForceDistance)
        {
            _k = k;
            _maxRepulsiveForceDistance = maxRepulsiveForceDistance;
            _kSquared = k * k;
        }

        public void Apply(List<EntityLink<TNode, TEdge>> edges)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                EntityLink<TNode, TEdge> edge = edges[i];

                PointEntity<TNode> nodeA = edge.From;
                PointEntity<TNode> nodeB = edge.To;

                Point2D delta = nodeB.Position.SubCopy(nodeA.Position);

                double distanceSquared = delta.X * delta.X + delta.Y * delta.Y;
                if (distanceSquared < 0.01)
                    distanceSquared = 0.01;

                double distance = Math.Sqrt(distanceSquared);

                if (distance > _maxRepulsiveForceDistance)
                    distance = _maxRepulsiveForceDistance;

                distanceSquared = distance * distance;

                double attractiveForce = (distanceSquared - _kSquared) / _k;

                double weight = edge.Weight;

                if (weight < 1)
                    weight = 1;

                attractiveForce *= (Math.Log(weight) * 0.5) + 1;

                double forceX = attractiveForce * delta.X / distance;
                double forceY = attractiveForce * delta.Y / distance;

                nodeA.Force.Add(forceX, forceY);
                nodeB.Force.Sub(forceX, forceY);
            }
        }
    }
}