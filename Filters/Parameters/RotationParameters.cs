namespace MyPhotoshop.Filters.Parameters
{
    public class RotationParameters: IParameters
    {
        [ParameterInfo("Угол поворота", 0, 5, 0, 360)]
        public double Angle { get; private set; }
    }
}