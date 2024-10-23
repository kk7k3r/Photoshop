using System.Drawing;
using MyPhotoshop.Data;
using MyPhotoshop.Filters.Parameters;
using MyPhotoshop.Filters.Transformers;

namespace MyPhotoshop.Filters
{
    public class TransformFilter<TParameters>: ParametrizedFilter<TParameters> 
        where TParameters : IParameters, new()
    {
        private readonly ITransformer<TParameters> transformer;
        private readonly string name;

        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }

        public override string ToString()
        {
            return name;
        }

        protected override Photo Process(Photo photo, TParameters parameters)
        {
            var originalSize = new Size(photo.Width, photo.Height);
            transformer.Prepare(originalSize, parameters);
            var newSize = transformer.ResultSize;
            var result = new Photo(newSize.Width, newSize.Height);
            for (var x = 0; x < result.Width; x++)
            {
                for (var y = 0; y < result.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = transformer.TransformPoint(point);
                    if (oldPoint != null)
                    {
                        result[x, y] = photo[oldPoint.Value.X, oldPoint.Value.Y];
                    }
                }
            }
            return result;
        }
    }
}