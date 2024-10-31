namespace MyPhotoshop.Filters.Parameters
{
    public class LighteningParameters : IParameters
    {
        [ParameterInfo("Коэффициент", 1, 0.1, 0, 10)]
        public double Coefficient { get; private set; }
    }
}
