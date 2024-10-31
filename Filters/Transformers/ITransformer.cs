using System.Drawing;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters.Transformers
{
    public interface ITransformer<in TParameters> 
        where TParameters : IParameters
    {
        void Prepare(Size originalSize, TParameters parameters);
        Size ResultSize { get; }
        Point? TransformPoint(Point point);
    }
}