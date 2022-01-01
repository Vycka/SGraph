using System.Collections.Generic;
using SGraph.Core.Graph;
using SGraph.Core.Simulation;

namespace SGraph.Core.Rendering
{
    public interface IRenderer<TNode, TEdge>
    {
        void Render();

        void SetNodes(IReadOnlyList<PointEntity<TNode>> nodes);

        void SetEdges(IReadOnlyList<EntityLink<TNode, TEdge>> edges);
    }
}