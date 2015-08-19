namespace NetworkVisualizer.Model
{
    public class ComputerVertex
    {
        public string HostName { get; private set; }
        public string Ip { get; private set; }

        public ComputerVertex(string hostName, string ip)
        {
            HostName = hostName;
            Ip = ip;
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}", HostName, Ip);
        }
    }
}
