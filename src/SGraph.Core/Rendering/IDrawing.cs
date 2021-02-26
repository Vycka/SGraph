namespace SGraph.Core.Rendering
{
    public interface IDrawing<TNode, TEdge>
    {
        void Draw(TNode node, int x, int y);
        void Draw(TEdge node, int x, int y);
    }
}