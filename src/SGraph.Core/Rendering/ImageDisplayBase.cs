using SGraph.Core.Simulation;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Color = SixLabors.ImageSharp.Color;
using PointF = SixLabors.ImageSharp.PointF;

namespace SGraph.Core.Rendering;

public class ImageDisplayBase<TNode, TEdge> : IDisplay<TNode, TEdge>
{

    protected readonly Image Image;

    private readonly Pen _edgePen = new Pen(new Color(new Argb32(102, 102, 255)), 2);
    private readonly IBrush _nodeBrush = new SolidBrush(new Color(new Argb32(255, 255, 0)));

    //private readonly List<Tuple<PointF, PointF>> _edges = new();
    //private readonly List<PointF> _nodes = new();

    public ImageDisplayBase(int width, int height)
    {
        Size = new Point2D(width, height);

        Image = new Image<Rgba32>(width, height);

        Reset();
    }

    public virtual void Draw(TNode node, int x, int y)
    {
        EllipsePolygon ellipse = new EllipsePolygon(x, y, 10);

        Image.Mutate(i => i.Fill(_nodeBrush, ellipse));
        Image.Mutate(i => i.Draw(_edgePen, ellipse));
    }

    public virtual void Draw(TEdge node, int x1, int y1, int x2, int y2)
    {
        Image.Mutate(i => i.DrawLines(_edgePen, new PointF(x1, y1), new PointF(x2, y2)));
    }


    private void Reset()
    {
        Image.Mutate(i => i.Fill(Color.White));
    }
    public void EndDraw()
    {
        Image.Save("out.png", new PngEncoder());
        Reset();
    }

    public Point2D Size { get; }
}