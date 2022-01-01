using SGraph.Core.Simulation;

namespace SGraph.Core.Rendering
{
    public interface IDisplay<TNode, TEdge>
    {
        void Draw(TNode node, int x, int y);
        void Draw(TEdge node, int x1, int y1, int x2, int y2);

        void EndDraw();

        Point2D Size { get; }
    }
}