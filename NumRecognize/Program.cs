using NumRecognize;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //NeuroNetwork neuroNetwork = new NeuroNetwork("./NeuroNetwork.xml");
            //var matrixI = new DenseMatrix(10,10);
            MyDataSet N1Dataset = new MyDataSet("N1DataSet");
            Ndata adata = new Ndata();
            for (int i = 0; i < 1; i++)
            {
                adata.Source[0, 0] = i;
                N1Dataset.AddData(adata);
            }
            //foreach (Ndata case1 in N1Dataset)
            //{
            //    Console.WriteLine(case1.Source.Transpose().ToString());
            //}
            //for (int i = 0; i < 18; i++)
            //{
            //    N1Dataset.PopData();
            //}
        }
    }
}