using QuickGraph;

namespace NetworkVisualizer.Model
{
    public class ComputerEdge : Edge<ComputerVertex>
    {
        public string Id { get; private set; }

        public ComputerEdge(string id, ComputerVertex source, ComputerVertex target) : base (source, target)
        {
            Id = id;
        }
    }
}
