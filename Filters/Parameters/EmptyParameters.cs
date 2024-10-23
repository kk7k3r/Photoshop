namespace MyPhotoshop.Filters.Parameters
{
    public class EmptyParameters : IParameters
    {
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[] { };
        }

        public void Parse(double[] values)
        {
        }
    }
}
