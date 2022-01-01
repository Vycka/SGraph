using SGraph.Core.Framework;
using SGraph.Core.Rendering;
using SGraph.Core.Simulation;
using SGraph.Playground;

IDisplay<Node, Edge> display = new CustomDisplay(1920, 1080);
IRenderer<Node, Edge> renderer = new DrawCommandsRenderer<Node, Edge>(display);
SharpGraph<Node, Edge> graph = new SharpGraph<Node, Edge>(renderer);

Node nA = new Node("A");
Node nB = new Node("B");
Node nC = new Node("C");
Node nD = new Node("D");
Node nX = new Node("X");
Node nX2 = new Node("X2");
Node nX3 = new Node("X3");
Node nX4 = new Node("X4");
Node nX5 = new Node("X5");

var nodes = new List<PointEntity<Node>>();

nodes.Add(graph.Add(nA));
nodes.Add(graph.Add(nB));
nodes.Add(graph.Add(nC));
nodes.Add(graph.Add(nD));
nodes.Add(graph.Add(nX));

graph.Add(nA, nB);
graph.Add(nB, nC);
graph.Add(nC, nD);
graph.Add(nD, nA);
graph.Add(nX, nX2);
graph.Add(nX, nX3);
graph.Add(nX, nX4);
graph.Add(nX, nX5);
graph.Add(nB, nX5);
graph.Add(nD, nX4);
graph.Add(nA, nX3);
graph.Add(nA, nX2);

Console.WriteLine(String.Join("\r\n", nodes.Select(n => $"{n.Entity.Name} {n.Position}")));

graph.Run(150000);

Console.WriteLine(String.Join("\r\n", nodes.Select(n => $"{n.Entity.Name} {n.Position}")));