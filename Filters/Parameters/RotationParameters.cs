namespace MyPhotoshop.Filters.Parameters
{
    public class RotationParameters: IParameters
    {
        public double Angle { get; private set; }
        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Угол поворота", MaxValue = 360, MinValue = 0, Increment = 5, DefaultValue = 0
                }
            };
        }

        public void Parse(double[] parameters)
        {
            Angle = parameters[0];
        }
    }
}