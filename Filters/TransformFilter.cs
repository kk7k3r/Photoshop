using System;
using System.Drawing;
using MyPhotoshop.Data;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
    {
        private readonly string name;
        private readonly Func<Size, Size> sizeTransform;
        private readonly Func<Point, Size, Point> pointTransform;

        public TransformFilter(string name, Func<Size, Size> sizeTransform, Func<Point, Size, Point> pointTransform)
        {
            this.name = name;
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        protected override Photo Process(Photo original, EmptyParameters parameters)
        {
            var oldSize = new Size(original.Width, original.Height);
            var newSize = sizeTransform(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);
            for (var x = 0; x < result.Width; x++)
            {
                for (var y = 0; y < result.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize);
                    result[x, y] = original[oldPoint.X, oldPoint.Y];
                }
            }
            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
