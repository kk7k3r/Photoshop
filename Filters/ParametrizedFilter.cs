using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        private IParameters parameters;

        public ParametrizedFilter(IParameters parameters)
        {
            this.parameters = parameters;
        }

        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDesctiprion();
        }

        public Photo Process(Photo original, double[] parameters)
        {
            this.parameters.SetValues(parameters);
            return Process(original, this.parameters);
        }

        public abstract Photo Process(Photo original, IParameters parameters);
    }
}
