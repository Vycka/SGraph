using System.Collections.Generic;
using SGraph.Core.Graph;
using SGraph.Core.Simulation;

namespace SGraph.Core.Rendering
{
    public interface IRenderer<TNode, TEdge>
    {
        void BeginFrame();

        void EndFrame();

        void DrawNodes(IReadOnlyList<PointEntity<TNode>> nodes);

        void DrawEdges(IReadOnlyList<EntityLink<TNode, TEdge>> edges);
    }
}