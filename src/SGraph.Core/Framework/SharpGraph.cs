using System;
using System.Collections.Generic;
using System.Linq;
using SGraph.Core.Graph.Forces;
using SGraph.Core.Rendering;
using SGraph.Core.Simulation;

namespace SGraph.Core.Framework
{
    public class SharpGraph<TNode, TEdge>
        where TNode : class
        where TEdge : class 
    {
        private readonly InteractionsHandler _interactions;
        private readonly IRenderer<TNode, TEdge> _renderer;

        private readonly List<PointEntity<TNode>> _nodes;
        private readonly List<EntityLink<TNode, TEdge>> _edges;

        public SharpGraph(IRenderer<TNode, TEdge> renderer)
        {
            _renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));

            _nodes = new List<PointEntity<TNode>>();
            _edges = new List<EntityLink<TNode, TEdge>>();

            _renderer.SetNodes(_nodes);
            _renderer.SetEdges(_edges);

            _interactions = new InteractionsHandler();
            _interactions
                .Add(new RepulsiveNodeForce<TNode>(2, 6), _nodes)
                .Add(new AttractiveEdgeForce<TNode, TEdge>(1, 6), _edges)
                .Add(new ApplyLimitedForce<TNode>(0.01, 0.5), _nodes);
        }

        public void Run(int simulationFrames = 1)
        {
            _interactions.Simulate(simulationFrames);
            _renderer.Render();
        }

        public PointEntity<TNode> Add(TNode node)
        {
            PointEntity<TNode> result = FindNode(node);

            if (result == null)
            {
                result = new PointEntity<TNode>(node);
                result.Position.X = Random.Shared.NextDouble() - 0.5;
                result.Position.Y = Random.Shared.NextDouble() - 0.5;
                _nodes.Add(result);
            }

            return result;
        }

        public EntityLink<TNode, TEdge> Add(TNode from, TNode to, TEdge edge = null)
        {
            PointEntity<TNode> pFrom = Add(from);
            PointEntity<TNode> pTo = Add(to);

            var result = FindEdge(pFrom.Entity, pTo.Entity);
            if (result == null)
            {
                result = new EntityLink<TNode, TEdge>(edge, pFrom, pTo);
                _edges.Add(result);
            }

            return result;
        }

        public void Remove(TNode node)
        {
            var edgesToRemove = FindEdges(node);
            foreach (EntityLink<TNode, TEdge> edge in edgesToRemove)
            {
                _edges.Remove(edge);
            }

            _nodes.Remove(FindNode(node));
        }

        private PointEntity<TNode> FindNode(TNode node)
        {
            return _nodes.FirstOrDefault(n => n.Entity == node);
        }

        private EntityLink<TNode, TEdge> FindEdge(TNode from, TNode to)
        {
            return _edges.FirstOrDefault(e => e.From.Entity == from && e.To.Entity == to);
        }

        private List<EntityLink<TNode, TEdge>> FindEdges(TNode node)
        {
            return _edges.FindAll(e => e.From.Entity == node || e.To.Entity == node);
        }
    }
}
