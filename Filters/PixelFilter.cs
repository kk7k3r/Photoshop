namespace MyPhotoshop
{
    public abstract class PixelFilter: IFilter
    {
        public abstract ParameterInfo[] GetParameters();

        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], parameters);
                }
            return result;
        }

        public abstract Pixel ProcessPixel(Pixel originalPixel, double[] parameters);
    }
}
