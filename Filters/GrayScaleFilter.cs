
namespace MyPhotoshop
{
    public class GrayScaleFilter : PixelFilter
    {
        public override ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[] { };
        }

        public override string ToString()
        {
            return "Черно-белый фильтр";
        }


        public override Pixel ProcessPixel(Pixel originalPixel, double[] parameters)
        {
            var lightnessValue = (originalPixel.R + originalPixel.G + originalPixel.B) / 3;
           return new Pixel { R = lightnessValue, G = lightnessValue, B = lightnessValue };
        }
    }
}
