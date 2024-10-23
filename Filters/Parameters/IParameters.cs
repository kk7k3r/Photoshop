namespace MyPhotoshop.Filters.Parameters
{
    public interface IParameters
    {
        ParameterInfo[] GetDescription();

        void Parse(double[] values);
    }
}
