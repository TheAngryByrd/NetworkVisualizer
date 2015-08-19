using System;
using System.Collections.Generic;
using System.ComponentModel;
using NetworkVisualizer.Model;

namespace NetworkVisualizer.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Data
        private string layoutAlgorithmType;
        private ComputerGraph graph;
        private List<String> layoutAlgorithmTypes = new List<string>();
        #endregion

        #region Ctor
        public MainWindowViewModel()
        {
            Graph = new ComputerGraph(true);

            List<ComputerVertex> existingVertices = new List<ComputerVertex>();
            existingVertices.Add(new ComputerVertex("Localhost", "127.0.0.1")); //0
            existingVertices.Add(new ComputerVertex("HanSolo", "10.1.100.1")); //1
            existingVertices.Add(new ComputerVertex("LukeSkywalker", "10.1.100.2")); //2
            existingVertices.Add(new ComputerVertex("Leia", "10.1.100.3")); //3
            existingVertices.Add(new ComputerVertex("Chewy", "10.1.100.4")); //4

            foreach (ComputerVertex vertex in existingVertices)
                Graph.AddVertex(vertex);

            //add some edges to the graph
            AddNewGraphEdge(existingVertices[0], existingVertices[1]);
            AddNewGraphEdge(existingVertices[0], existingVertices[2]);
            AddNewGraphEdge(existingVertices[0], existingVertices[3]);
            AddNewGraphEdge(existingVertices[0], existingVertices[4]);

            AddNewGraphEdge(existingVertices[1], existingVertices[0]);
            AddNewGraphEdge(existingVertices[1], existingVertices[2]);
            AddNewGraphEdge(existingVertices[1], existingVertices[3]);

            AddNewGraphEdge(existingVertices[2], existingVertices[0]);
            AddNewGraphEdge(existingVertices[2], existingVertices[1]);
            AddNewGraphEdge(existingVertices[2], existingVertices[3]);
            AddNewGraphEdge(existingVertices[2], existingVertices[4]);

            AddNewGraphEdge(existingVertices[3], existingVertices[0]);
            AddNewGraphEdge(existingVertices[3], existingVertices[1]);
            AddNewGraphEdge(existingVertices[3], existingVertices[3]);
            AddNewGraphEdge(existingVertices[3], existingVertices[4]);

            AddNewGraphEdge(existingVertices[4], existingVertices[0]);
            AddNewGraphEdge(existingVertices[4], existingVertices[2]);
            AddNewGraphEdge(existingVertices[4], existingVertices[3]);

            string edgeString = string.Format("{0}-{1} Connected",
                existingVertices[0].HostName, existingVertices[0].HostName);
            Graph.AddEdge(new ComputerEdge(edgeString, existingVertices[0], existingVertices[1]));
            Graph.AddEdge(new ComputerEdge(edgeString, existingVertices[0], existingVertices[1]));
            Graph.AddEdge(new ComputerEdge(edgeString, existingVertices[0], existingVertices[1]));
            Graph.AddEdge(new ComputerEdge(edgeString, existingVertices[0], existingVertices[1]));

            //Add Layout Algorithm Types
            layoutAlgorithmTypes.Add("BoundedFR");
            layoutAlgorithmTypes.Add("Circular");
            layoutAlgorithmTypes.Add("CompoundFDP");
            layoutAlgorithmTypes.Add("EfficientSugiyama");
            layoutAlgorithmTypes.Add("FR");
            layoutAlgorithmTypes.Add("ISOM");
            layoutAlgorithmTypes.Add("KK");
            layoutAlgorithmTypes.Add("LinLog");
            layoutAlgorithmTypes.Add("Tree");

            //Pick a default Layout Algorithm Type
            LayoutAlgorithmType = "LinLog";

        }
        #endregion

        #region Private Methods
        private ComputerEdge AddNewGraphEdge(ComputerVertex from, ComputerVertex to)
        {
            string edgeString = string.Format("{0}-{1} Connected", from.HostName, to.HostName);

            var newEdge = new ComputerEdge(edgeString, from, to);
            Graph.AddEdge(newEdge);
            return newEdge;
        }

        #endregion

        #region Public Properties

        public List<String> LayoutAlgorithmTypes
        {
            get { return layoutAlgorithmTypes; }
        }

        public string LayoutAlgorithmType
        {
            get { return layoutAlgorithmType; }
            set
            {
                layoutAlgorithmType = value;
                NotifyPropertyChanged("LayoutAlgorithmType");
            }
        }

        public ComputerGraph Graph
        {
            get { return graph; }
            set
            {
                graph = value;
                NotifyPropertyChanged("Graph");
            }
        }
        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
