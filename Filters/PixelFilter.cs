using System;
using MyPhotoshop.Data;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        private readonly string name;
        private readonly Func<Pixel, TParameters, Pixel> processPixel;

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> processPixel)
        {
            this.name = name;
            this.processPixel = processPixel;
        }


        protected override Photo Process(Photo original, TParameters parameters)
        {
            var result = new Photo(original.Width, original.Height);
            for (var x = 0; x < original.Width; x++)
                for (var y = 0; y < original.Height; y++)
                {
                    result[x, y] = processPixel(original[x, y], parameters);
                }
            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
