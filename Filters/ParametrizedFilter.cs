using MyPhotoshop.Data;
using MyPhotoshop.Filters.Parameters;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
        where TParameters: IParameters, new()
    {
        public ParameterInfo[] GetParameters()
        {
            return new TParameters().GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new TParameters();
            parameters.Parse(values);
            return Process(original, parameters);
        }

        protected abstract Photo Process(Photo original, TParameters parameters);
    }
}
