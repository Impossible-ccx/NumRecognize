using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections;

namespace NumRecognize
{
    public interface INdata
    {
        DenseMatrix Target { get; }
        DenseMatrix Source { get; }
    }
    public interface INdataset : IEnumerable
    {
        int Count { get; }
    }
   
}
