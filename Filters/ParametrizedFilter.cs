using MyPhotoshop.Data;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters: IParameters, new()
    {
        private readonly IParametersHandler<TParameters> parametersHandler = 
            new DefaultParametersHandler<TParameters>();

        public ParameterInfo[] GetParameters()
        {
            return parametersHandler.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = parametersHandler.CreateParameters(values);
            return Process(original, parameters);
        }

        protected abstract Photo Process(Photo original, TParameters parameters);
    }
}
