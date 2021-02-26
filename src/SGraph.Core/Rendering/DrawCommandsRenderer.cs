using System.Collections.Generic;
using SGraph.Core.Simulation;
using SGraph.Core.Simulation.Extensions;

namespace SGraph.Core.Rendering
{
    public class DrawCommandsRenderer<TNode, TEdge> : IRenderer<TNode, TEdge>
    {
        private IReadOnlyList<PointEntity<TNode>> _nodes;
        private IReadOnlyList<EntityLink<TNode, TEdge>> _edges;

        private Point2D _min, _max, _offset, _size, _ratio;

        private readonly Point2D _display;
        private readonly IDrawing<TNode, TEdge> _drawing;

        public DrawCommandsRenderer(Point2D display, IDrawing<TNode, TEdge> drawing)
        {
            _display = display;
            _drawing = drawing;
        }

        public void BeginFrame()
        {
        }

        public void EndFrame()
        {
            CalculateBounds();

            foreach (PointEntity<TNode> node in _nodes)
            {
                
            }
        }

        private void CalculateBounds()
        {

            _min.X = -1;
            _min.Y = -1;
            _max.X = 1;
            _max.Y = 1;

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

            _offset.X = -_min.X;
            _offset.Y = -_min.Y;

            _size = _max.SubCopy(_min);
            _ratio = _display.DivCopy(_size);
        }

        public void DrawNodes(IReadOnlyList<PointEntity<TNode>> nodes)
        {
            _nodes = nodes;
        }

        public void DrawEdges(IReadOnlyList<EntityLink<TNode, TEdge>> edges)
        {
            _edges = edges;
        }

        /*
         if (visibleNodes.size() > 0)
	{
		minX = visibleNodes[0]->getX();
		maxX = visibleNodes[0]->getX();
		minY = visibleNodes[0]->getY();
		maxY = visibleNodes[0]->getY();
	}
	else
	{
		minX = 0;
		maxX = 0;
		minY = 1;
		maxY = 1;
	}
	maxWeight = 0;

	for (unsigned int x = 0; x < visibleNodes.size();x++)	
	{
		if (visibleNodes[x]->getX() > maxX)
			maxX = visibleNodes[x]->getX();

		if (visibleNodes[x]->getX() < minX)
			minX = visibleNodes[x]->getX();

		if (visibleNodes[x]->getY() > maxY)
			maxY = visibleNodes[x]->getY();

		if (visibleNodes[x]->getY() < minY)
			minY = visibleNodes[x]->getY();
	}

	// Increase size if too small.
	double minSize = cfg->gMinDiagramSize;
	if (maxX - minX < minSize)
	{
		double midX = (maxX + minX) / 2;
		minX = midX - (minSize / 2);
		maxX = midX + (minSize / 2);
	}
	if (maxY - minY < minSize)
	{
		double midY = (maxY + minY) / 2;
		minY = midY - (minSize / 2);
		maxY = midY + (minSize / 2);
	}

	for (unsigned int x = 0;x < edges.size();x++)
		if (edges[x]->getWeight() > maxWeight)
			maxWeight = edges[x]->getWeight();

	if (maxWeight < cfg->gMinMaxWeight)
		maxWeight = cfg->gMinMaxWeight;

		
	// Jibble the boundaries to maintain the aspect ratio.
	if (!cfg->gStrechToImageSize)
	{
		double xyRatio = ((maxX - minX) / (maxY - minY)) / (cfg->iOutputWidth / cfg->iOutputHeight);
		if (xyRatio > 1)
		{
			// diagram is wider than it is high.
			double dy = maxY - minY;
			dy = dy * xyRatio - dy;
			minY = minY - dy / 2;
			maxY = maxY + dy / 2;
		}
		else if (xyRatio < 1)
		{
			// Diagram is higher than it is wide.
			double dx = maxX - minX;
			dx = dx / xyRatio - dx;
			minX = minX - dx / 2;
			maxX = maxX + dx / 2;
		}
	}
         */
    }
}