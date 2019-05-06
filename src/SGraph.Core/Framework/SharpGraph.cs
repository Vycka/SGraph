using System;
using System.Collections.Generic;
using System.Linq;
using SGraph.Core.Graph;
using SGraph.Core.Graph.Forces;
using SGraph.Core.Rendering;
using SGraph.Core.Simulation;

namespace SGraph.Core.Framework
{
    class SharpGraph<TNode, TEdge>
        where TNode : class
        where TEdge : class 
    {
        private readonly PhysicsEngine _physics;
        private readonly IRenderer<TNode, TEdge> _renderer;

        private readonly List<PointEntity<TNode>> _nodes;
        private readonly List<EntityLink<TNode, TEdge>> _edges;

        public SharpGraph()
        {
            _physics = new PhysicsEngine();
            _physics
                .Add(new RepulsiveNodeForce<TNode>(0.5, 1), _nodes)
                .Add(new AttractiveEdgeForce<TNode, TEdge>(1, 1), _edges)
                .Add(new ApplyLimitedForce<TNode>(0.5, 1), _nodes);
        }

        public void DrawNext()
        {
            _physics.Simulate();
            _renderer.BeginFrame();
            _renderer.DrawNodes(_nodes);
            _renderer.DrawEdges(_edges);
            _renderer.EndFrame();
        }

        public PointEntity<TNode> Add(TNode node)
        {
            PointEntity<TNode> result = _nodes.FirstOrDefault(n => n.Entity == node);

            if (result == null)
            {
                result = new PointEntity<TNode>(node);
                _nodes.Add(result);
            }

            return result;
        }

        public EntityLink<TNode, TEdge> Add(TEdge edge, TNode from, TNode to)
        {
            Add(from);
            Add(to);

            if (!EdgeExists(from, to))
                _edges.Add(new EntityLink<TNode, TEdge>(edge, from, to));

            return this;
        }

        private bool NodeExists(TNode node)
        {
            return _nodes.Any(n => n.Entity == node);
        }

        private bool EdgeExists(TNode from, TNode to)
        {
            return _edges.Any(e => e.From.Entity == from && e.To.Entity == to);
        }
    }
}
