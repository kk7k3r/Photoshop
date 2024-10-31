using System.Linq;
using System.Reflection;

namespace MyPhotoshop.Filters.Parameters
{
    public class DefaultParametersHandler<TParameters>: IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        private static readonly PropertyInfo[] properties = typeof(TParameters)
            .GetProperties()
            .Where(field => field.GetCustomAttributes<ParameterInfo>().Any())
            .ToArray();
        private static readonly ParameterInfo[] descriptions = properties
            .Select(field => field.GetCustomAttributes<ParameterInfo>().First())
            .ToArray();
        
        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();
            for (var i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(parameters, values[i]);
            }
            return parameters;
        }

        public ParameterInfo[] GetDescription()
        {
            return descriptions;
        }
    }
}