using System;
using System.Drawing;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters.Transformers
{
    public class FreeTransformer: ITransformer<EmptyParameters>
    {
        private readonly Func<Size, Size> sizeTransform;
        private readonly Func<Point, Size, Point?> pointTransform;
        private Size originalSize;

        public FreeTransformer(Func<Size, Size> sizeTransform, Func<Point, Size, Point?> pointTransform)
        {
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public void Prepare(Size size, EmptyParameters parameters)
        {
            originalSize = size;
        }

        public Size ResultSize => sizeTransform(originalSize);

        public Point? TransformPoint(Point point)
        {
            return pointTransform(point, ResultSize);
        }
    }
}
