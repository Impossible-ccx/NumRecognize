
using System.Runtime.InteropServices;
using System.Xml;

namespace NumRecognize{
    public static class Program
    {

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        static void Main(string[] args)
        {
            MainForm mainForm = new MainForm();
            XmlDocument settings = new XmlDocument();
            settings.Load("./Forms/settings.xml");
            XmlNode setRoot = settings.FirstChild!;
            OnlineDataset = MyDataSet.Boot(setRoot["Bases"]![setRoot["On"]!.InnerText]!.InnerText);
            NNetwork network = new NNetwork();
            OnlineNetwork = network;
            Application.Run(mainForm);
            //AllocConsole();//调用系统API，调用控制台窗口
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //NNetwork network = new NNetwork();
            //OnlineNetwork = network;
            //FreeConsole();
        }
        public static INNetwork? OnlineNetwork = null;
        public static INdataset? OnlineDataset = null;
    }
}