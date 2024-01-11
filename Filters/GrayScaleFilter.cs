namespace MyPhotoshop.Filters
{
    internal class GrayScaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[] { };
        }

        public override string ToString()
        {
            return "Черно-белый фильтр";
        }
        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    var lightnessValue = (original[x, y].R + original[x, y].G + original[x,y].B) / 3;
                    result[x, y] = new Pixel { R = lightnessValue, G = lightnessValue, B = lightnessValue };
                }
            return result;
        }
    }
}
