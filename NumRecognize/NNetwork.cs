using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Distributions;
using NumRecognize;
using System.Xml;

namespace NumRecognize
{
    public class NNetwork : INNetwork
    {
        private List<DenseMatrix> network = new List<DenseMatrix>();
        private List<DenseMatrix> NNodes = new List<DenseMatrix>();
        private List<DenseMatrix> bias = new List<DenseMatrix>();
        private XmlDocument NNxml;
        private const int LaySize = 12;
        private const int LayNum = 3;
        public static double sigmoid(double x)
        {
            return 1/(1+Math.Exp(-x));
        }
        public NNetwork()
        {
            NNxml  = new XmlDocument();
            if (File.Exists("./Models/NNxml0.xml"))
            {
                NNxml.Load("./Models/NNxml0.xml");
            }
            else
            {
                
                CreateNNet();
                NNxml.Save("./Models/NNxml0.xml");
            }
            LoadNNet();
            
        }
        private void CreateNNet()
        {
            NNxml.AppendChild(NNxml.CreateElement("root"));
            XmlNode root = NNxml.FirstChild!;
            //初始化输入层
            XmlNode Lay1 = NNxml.CreateElement("Lay1");
            XmlNode Size0 = NNxml.CreateElement("Size0");
            XmlNode Size1 = NNxml.CreateElement("Size1");
            XmlNode Link = NNxml.CreateElement("Link");
            XmlNode Bias = NNxml.CreateElement("Bias");
            Size0.InnerText = Ndata.Scount.ToString();
            Size1.InnerText = LaySize.ToString();
            Lay1.AppendChild(Size0);
            Lay1.AppendChild(Size1);
            Lay1.AppendChild(Link);
            Lay1.AppendChild(Bias);
            root.AppendChild(Lay1);
            XmlNode? Track = null;
            Random randt = new Random();
            for (int i = 0; i < Ndata.Scount * LaySize; i++)
            {
                Track = NNxml.CreateElement("li");
                Track.InnerText = randt.NextDouble().ToString();
                Link.AppendChild(Track);
            }
            for (int i = 0; i < LaySize; i++)
            {
                Track = NNxml.CreateElement("li");
                Track.InnerText = randt.NextDouble().ToString();
                Bias.AppendChild(Track);
            }
            //初始化中间层
            for (int i = 0; i < LayNum - 2; i++)
            {
                XmlNode _Lay1 = NNxml.CreateElement("Lay" + (i + 2).ToString());
                XmlNode _Size0 = NNxml.CreateElement("Size0");
                XmlNode _Size1 = NNxml.CreateElement("Size1");
                XmlNode _Link = NNxml.CreateElement("Link");
                XmlNode _Bias = NNxml.CreateElement("Bias");
                _Size0.InnerText = LaySize.ToString();
                _Size1.InnerText = LaySize.ToString();
                _Lay1.AppendChild(_Size0);
                _Lay1.AppendChild(_Size1);
                _Lay1.AppendChild(_Link);
                _Lay1.AppendChild(_Bias);
                root.AppendChild(_Lay1);
                XmlNode _Track;
                Random _randt = new Random();
                for (int j = 0; j < LaySize * LaySize; j++)
                {
                    _Track = NNxml.CreateElement("li");
                    _Track.InnerText = randt.NextDouble().ToString();
                    _Link.AppendChild(_Track);
                }
                for (int j = 0; j < LaySize; j++)
                {
                    _Track = NNxml.CreateElement("li");
                    _Track.InnerText = randt.NextDouble().ToString();
                    _Bias.AppendChild(_Track);
                }
            }
            //初始化输出层
            XmlNode LayE = NNxml.CreateElement("LayE");
            Size0 = NNxml.CreateElement("Size0");
            Size1 = NNxml.CreateElement("Size1");
            Link = NNxml.CreateElement("Link");
            Bias = NNxml.CreateElement("Bias");
            Size0.InnerText = LaySize.ToString();
            Size1.InnerText = Ndata.Tcount.ToString();
            LayE.AppendChild(Size0);
            LayE.AppendChild(Size1);
            LayE.AppendChild(Link);
            LayE.AppendChild(Bias);
            root.AppendChild(LayE);
            Track = null;
            randt = new Random();
            for (int i = 0; i < Ndata.Tcount * LaySize; i++)
            {
                Track = NNxml.CreateElement("li");
                Track.InnerText = randt.NextDouble().ToString();
                Link.AppendChild(Track);
            }
            for (int i = 0; i < Ndata.Tcount; i++)
            {
                Track = NNxml.CreateElement("li");
                Track.InnerText = randt.NextDouble().ToString();
                Bias.AppendChild(Track);
            }


        }
        private void LoadNNet()
        {
            foreach (XmlNode Layer in NNxml.LastChild!.ChildNodes)
            {
                int size0 = int.Parse(Layer["Size0"]!.InnerText);
                int size1 = int.Parse(Layer["Size1"]!.InnerText);
                network.Add(new DenseMatrix(size1, size0));
                bias.Add(new DenseMatrix(size1, 1));
                int i = 0;
                foreach (XmlNode val in Layer["Link"]!.ChildNodes)
                {
                    network.Last()[i / size0, i % size0] = double.Parse(val.InnerText);
                    i++;
                }
                i = 0;
                foreach (XmlNode val in Layer["Bias"]!.ChildNodes)
                {
                    bias.Last()[i, 0] = double.Parse(val.InnerText);
                    i++;
                }
                NNodes.Add(new DenseMatrix(size1, 0));
                //Console.WriteLine(network.First().ToString());
            }
        }
        public int GetResult(INdata ndata)
        {
            NNodes[0] = network[0] * ndata.Source;
            NNodes[0] += (DenseMatrix)bias[0].RowSums().ToColumnMatrix();
            NNodes[0].Map(sigmoid, NNodes[0]);
            for (int i = 1; i < LayNum; i++)
            {
                NNodes[i] = network[i] * NNodes[i - 1];
                NNodes[i] += bias[i];
                NNodes[i].Map(sigmoid, NNodes[i]);
            }
            DenseMatrix output = NNodes[LayNum - 1];
            int result = -1;
            double maxPos = double.NegativeInfinity;
            for (int i = 0;i < Ndata.Tcount; i++)
            {
                if (maxPos < output[i,0])
                {
                    maxPos = output[i,0];
                    result = i;
                }
            }
            return result;
        }
    }
}
