namespace MyPhotoshop.Filters.Parameters
{
    public interface IParametersHandler<out TParameters>
    {
        TParameters CreateParameters(double[] values);
        ParameterInfo[] GetDescription();
    }
}   