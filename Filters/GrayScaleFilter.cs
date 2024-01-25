
using MyPhotoshop.Filters;

namespace MyPhotoshop
{
    public class GrayScaleFilter : PixelFilter<EmptyParameters>
    {
        public override string ToString()
        {
            return "Черно-белый фильтр";
        }


        public override Pixel ProcessPixel(Pixel originalPixel, EmptyParameters parameters)
        {
            var lightnessValue = (originalPixel.R + originalPixel.G + originalPixel.B) / 3;
           return new Pixel { R = lightnessValue, G = lightnessValue, B = lightnessValue };
        }
    }
}
