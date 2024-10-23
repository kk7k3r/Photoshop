using System.Drawing;

namespace MyPhotoshop.Filters.Transformers
{
    public interface ITransformer<in TParameters> 
        where TParameters : new()
    {
        void Prepare(Size originalSize, TParameters parameters);
        Size ResultSize { get; }
        Point? TransformPoint(Point point);
    }
}