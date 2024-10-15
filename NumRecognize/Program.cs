
using System.Xml;

namespace NumRecognize{
    public static class Program
    {
        static void Main(string[] args)
        {
            MainForm mainForm = new MainForm();
            XmlDocument settings = new XmlDocument();
            settings.Load("./Forms/settings.xml");
            XmlNode setRoot = settings.FirstChild!;
            OnlineDataset = MyDataSet.Boot(setRoot["Bases"]![setRoot["On"]!.InnerText]!.InnerText);
            Application.Run(mainForm);
        }
        public static INNetwork? OnlineNetwork = null;
        public static INdataset? OnlineDataset = null;
    }
}