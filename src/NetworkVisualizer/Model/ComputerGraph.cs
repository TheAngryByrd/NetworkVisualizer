using QuickGraph;

namespace NetworkVisualizer.Model
{
    public class ComputerGraph : BidirectionalGraph<ComputerVertex, ComputerEdge>
    {
        public ComputerGraph() { }

        public ComputerGraph(bool allowParallelEdges)
            : base(allowParallelEdges) { }

        public ComputerGraph(bool allowParallelEdges, int vertexCapacity)
            : base(allowParallelEdges, vertexCapacity) { }
    }

}
