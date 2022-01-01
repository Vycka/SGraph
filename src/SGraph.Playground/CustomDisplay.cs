using SGraph.Core.Rendering;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace SGraph.Playground;

public class CustomDisplay : ImageDisplayBase<Node, Edge>
{
    private readonly Font _font;

    public CustomDisplay(int width, int height) : base(width, height)
    {
        FontCollection collection = new FontCollection();
        FontFamily family = collection.Install("resources/Alice-Regular.ttf");
        _font = family.CreateFont(18, FontStyle.Italic);
    }

    public override void Draw(Node node, int x, int y)
    {
        base.Draw(node, x, y);
        Image.Mutate(i => i.DrawText(node.Name, _font, Color.Black, new PointF(x+8, y+18)));
    }

    public override void Draw(Edge node, int x1, int y1, int x2, int y2)
    {
        base.Draw(node, x1, y1, x2, y2);
    }
}