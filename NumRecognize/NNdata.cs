using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections;
using System.Xml;

namespace NumRecognize
{
    public class Ndata : INdata
    {
        public static int Scount = 64;
        public static int Tcount = 10;
        private DenseMatrix target;
        private DenseMatrix source;
        public DenseMatrix Target { get { return target; } set { target = value; } }
        public DenseMatrix Source { get { return source; } set { source = value; } }
        public Ndata()
        {
            target = new DenseMatrix(Tcount, 1);
            source = new DenseMatrix(Scount, 1);
        }
    }
    public class MyDataSet : INdataset
    {
        public const int CageDepth = 10;
        private string basePath;
        private int count;
        public int Count { get { return count; } }

        private XmlDocument Controllor;
        public MyDataSet(string Name)
        {
            Controllor = new XmlDocument();
            basePath = $"./{Name}/";
            Controllor.Load(basePath + "Controllor.xml");
            count = (Controllor.FirstChild!.ChildNodes.Count - 1)*10;
            if(Controllor.FirstChild.LastChild != null)
            {
                count += int.Parse(Controllor.FirstChild.LastChild!["Count"]!.InnerText);
            }
            else
            {
                ;
            }
        }
        public static INdataset Boot(string path)
        {
            return new MyDataSet(path);
        }
        private void InsertData(string path, INdata data)
        {
            XmlDocument datacage = new XmlDocument();
            if (File.Exists(path))
            {
                datacage.Load(path);
            }
            else
            {
                XmlElement newRoot = datacage.CreateElement("root");
                XmlElement pro = datacage.CreateElement("Pro");
                newRoot.AppendChild(pro);
                datacage.AppendChild(newRoot);
            }
            XmlNode root = datacage.FirstChild!;
            XmlElement newData = datacage.CreateElement($"case{root.ChildNodes.Count}");
            XmlElement Source = datacage.CreateElement("source");
            newData.AppendChild(Source);
            for(int i = 0; i < Ndata.Scount; i++)
            {
                XmlElement row = datacage.CreateElement($"row{i}");
                row.InnerText = data.Source[i, 0].ToString();
                Source.AppendChild(row);
            }
            XmlElement Target = datacage.CreateElement("target");
            newData.AppendChild(Target);
            for (int i = 0; i < Ndata.Tcount; i++)
            {
                XmlElement row = datacage.CreateElement($"row{i}");
                row.InnerText= data.Target[i, 0].ToString();
                Target.AppendChild(row);
            }
            root.AppendChild(newData);
            datacage.Save(path);
        }
        public bool PopData()
        {
            XmlDocument lastCage = new XmlDocument();
            string CagePath;
            try
            {
                CagePath = basePath + Controllor.FirstChild.LastChild["Path"].InnerText;
            }
            catch 
            {
                return false;
            }
            lastCage.Load(CagePath);
            lastCage!.FirstChild!.RemoveChild(lastCage!.FirstChild!.LastChild!);
            Controllor.FirstChild!.LastChild["Count"]!.InnerText =
                (int.Parse(Controllor.FirstChild!.LastChild["Count"]!.InnerText) - 1).ToString();
            if (Controllor.FirstChild!.LastChild["Count"]!.InnerText == "0")
            {
                File.Delete(CagePath);
                Controllor.FirstChild.RemoveChild(Controllor.FirstChild.LastChild);
            }
            else
            {
                lastCage.Save(CagePath);
            }
            Controllor.Save(basePath + "Controllor.xml");
            return true;
        }
        public void AddData(INdata data)
        {
            XmlNode database = Controllor.FirstChild!;
            int dataCount;
            if(database.LastChild != null)
            {
                dataCount = int.Parse(database.LastChild["Count"]!.InnerText);
            }
            else
            {
                dataCount = CageDepth;
            }
            int cageCount = database.ChildNodes.Count;
            if (dataCount >= CageDepth)
            {
                XmlElement elem = Controllor.CreateElement($"Cage{cageCount}");
                XmlElement path = Controllor.CreateElement($"Path");
                XmlElement count2 = Controllor.CreateElement($"Count");
                path.InnerText = $"./data{cageCount}.xml";
                count2.InnerText = "1";
                elem.AppendChild(path);
                elem.AppendChild(count2);
                database.AppendChild(elem);
                dataCount = 0;
            }
            InsertData(basePath + database.LastChild!["Path"]!.InnerText, data);
            dataCount++;
            count++;
            database.LastChild["Count"]!.InnerText = dataCount.ToString();
            Controllor.Save(basePath + "Controllor.xml");
        }
        public IEnumerator GetEnumerator()
        {
            return new MyDataSetEnum(Controllor, basePath);
        }
    }
    internal class MyDataSetEnum : IEnumerator
    {
        private XmlDocument Controllor;
        private XmlDocument? database;
        private XmlNode? currentCage;
        private XmlNode? currentCase;
        private string basepath;
        private double[] currentSource = new double[Ndata.Scount];
        private double[] currentTarget = new double[Ndata.Tcount];
        public void Dispose()
        {
            ;
        }
        public MyDataSetEnum(XmlDocument Controllor, string basepath)
        {
            this.Controllor = Controllor;
            this.basepath = basepath;
            currentCage = Controllor.FirstChild!.FirstChild;
            if (!Load())
            {
                throw new Exception("E000 L130 in NNdata");
            }
        }
        private bool Load()
        {
            database = new XmlDocument();
            if (currentCage != null)
            {
                database.Load(basepath + currentCage["Path"]!.InnerText);
                currentCase = database.FirstChild!.FirstChild!;
                currentCage = currentCage.NextSibling;
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Current
        {
            get
            {
                Ndata result = new Ndata();
                int i = 0;
                foreach (XmlNode node in currentCase!.FirstChild!.ChildNodes)
                {
                    result.Source[i, 0] = double.Parse(node.InnerText);
                    i++;
                }
                i = 0;
                foreach (XmlNode node in currentCase!.LastChild!.ChildNodes)
                {
                    result.Target[i, 0] = double.Parse(node.InnerText);
                    i++;
                }
                return result;
            }
        }
        public bool MoveNext()
        {
            if (currentCase!.NextSibling != null)
            {
                currentCase = currentCase.NextSibling;
                return true;
            }
            else
            {
                if (Load())
                {
                    return MoveNext();
                }
                else
                {
                    return false;
                }
            }
        }
        public void Reset()
        {
            throw new Exception("E001 L188 in NNdata");
        }

    }
}
