using System;
using System.Drawing;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters.Transformers
{
    public class RotationTransformer: ITransformer<RotationParameters>
    {
        private RotationParameters parameters;
        private Size originalSize;
        private double angle;
        
        public void Prepare(Size originalSize, RotationParameters parameters)
        {
            this.parameters = parameters;
            this.originalSize = originalSize;
            angle = Math.PI * this.parameters.Angle / 180;
        }

        public Size ResultSize =>
            new Size(
                (int)(originalSize.Width * Math.Abs(Math.Cos(angle)) + originalSize.Height * Math.Abs(Math.Sin(angle))),
                (int)(originalSize.Height * Math.Abs(Math.Cos(angle)) + originalSize.Width * Math.Abs(Math.Sin(angle))));

        public Point? TransformPoint(Point point)
        {
            point = new Point(point.X - ResultSize.Width / 2, point.Y - ResultSize.Height / 2);
            var x = originalSize.Width / 2 + (int)(point.X * Math.Cos(angle) + point.Y * Math.Sin(angle));
            var y = originalSize.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));
            if (x < 0 || x >= originalSize.Width || y < 0 || y >= originalSize.Height) return null;
            return new Point(x, y);
        }
    }
}