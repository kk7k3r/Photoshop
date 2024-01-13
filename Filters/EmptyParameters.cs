using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class EmptyParameters : IParameters
    {
        public ParameterInfo[] GetDesctiprion()
        {
            return new ParameterInfo[] { };
        }

        public void SetValues(double[] values)
        {
        }
    }
}
