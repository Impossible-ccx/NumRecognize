using MathNet.Numerics.LinearAlgebra.Double;
using System.Xml;

namespace NumRecognize
{
    public class NeuroNetwork
    {
        private XmlDocument network = new XmlDocument();
        private List<DenseMatrix> MatrixList;
        private int Depth;
        private List<int> Size = new List<int>();
        public NeuroNetwork(string path)
        {
            network.Load(path);
            MatrixList = new List<DenseMatrix>();
            LoadXml();
        }
        private void LoadXml()
        {
            XmlNode root = network.FirstChild!;
            XmlNodeList Layers = root.ChildNodes;

            Depth = Layers.Count;
            foreach (XmlNode Layer in Layers)
            {
                Size.Add(Layer.ChildNodes.Count);
            }
            Size.Add(10);

            
            for (int i = 0; i < Depth; i++)
            {
                MatrixList.Add(new DenseMatrix(Size[i], Size[i + 1]));
            }

            int LayerNote = 0;
            foreach (XmlNode Layer in Layers)
            {
                XmlNodeList rows = Layer.ChildNodes;
                int rowNote = 0;
                foreach (XmlNode Row in rows)
                {
                    XmlNodeList cols = Row.ChildNodes;
                    int colNote = 0;
                    foreach (XmlNode Col in cols)
                    {
                        MatrixList[LayerNote][rowNote, colNote] = Double.Parse(Col.InnerText);
                        colNote++;
                    }
                    rowNote++;
                }
                LayerNote++;
            }
            Console.WriteLine(MatrixList[0].ToString());
        }
    }
}
