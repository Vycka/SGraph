using SGraph.Core.Simulation;
using SGraph.Core.Simulation.Extensions;
using System.Collections.Generic;

namespace SGraph.Core.Rendering
{
    public class DrawCommandsRenderer<TNode, TEdge> : IRenderer<TNode, TEdge>
    {
        private IReadOnlyList<PointEntity<TNode>> _nodes;
        private IReadOnlyList<EntityLink<TNode, TEdge>> _edges;

        private readonly Point2D _min;
        private readonly Point2D _max;

        private Point2D _localSize, _displayAdjustedRatio;

        private readonly IDisplay<TNode, TEdge> _display;
        private readonly int _borderSize;

        public DrawCommandsRenderer(IDisplay<TNode, TEdge> display, int borderSize = 100)
        {
            _display = display;
            _borderSize = borderSize;

            _min = new Point2D(double.MaxValue, double.MaxValue);
            _max = new Point2D(double.MinValue, double.MinValue);
        }

        public void Render()
        {
			CalculateBounds();

            foreach (EntityLink<TNode, TEdge> edge in _edges)
            {
                int x1 = (int)((edge.From.Position.X - _min.X) * _displayAdjustedRatio.X) + _borderSize;
				int y1 = (int)((edge.From.Position.Y - _min.Y) * _displayAdjustedRatio.Y) + _borderSize;
                int x2 = (int)((edge.To.Position.X - _min.X) * _displayAdjustedRatio.X) + _borderSize;
                int y2 = (int)((edge.To.Position.Y - _min.Y) * _displayAdjustedRatio.Y) + _borderSize;

                _display.Draw(edge.Entity, x1, y1, x2, y2);
            }

            foreach (PointEntity<TNode> node in _nodes)
            {
                int x = (int)((node.Position.X - _min.X) * _displayAdjustedRatio.X) + _borderSize;
                int y = (int)((node.Position.Y - _min.Y) * _displayAdjustedRatio.Y) + _borderSize;
                 
                _display.Draw(node.Entity, x, y);
            }

            _display.EndDraw();
        }

        private void CalculateBounds()
        {

            _min.X = double.MaxValue;
            _min.Y = double.MaxValue;
            _max.X = double.MinValue;
            _max.Y = double.MinValue;

            for (int i = 0; i < _nodes.Count; i++)
            {
                var position = _nodes[i].Position;

                if (position.X > _max.X)
                    _max.X = position.X;

                if (position.Y > _max.Y)
                    _max.Y = position.Y;

                if (position.X < _min.X)
                    _min.X = position.X;

                if (position.Y < _min.Y)
                    _min.Y = position.Y;
            }

            _localSize = _max.SubCopy(_min);
            _displayAdjustedRatio = _display.Size
                .SubCopy(_borderSize * 2)
                .DivCopy(_localSize);
        }

        public void SetNodes(IReadOnlyList<PointEntity<TNode>> nodes)
        {
            _nodes = nodes;
        }

        public void SetEdges(IReadOnlyList<EntityLink<TNode, TEdge>> edges)
        {
            _edges = edges;
        }
    }
}