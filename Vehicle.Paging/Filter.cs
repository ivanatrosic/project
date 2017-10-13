using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Common
{
    public class Filter : IFilter
    {
        public string FilterTherm { get; set; }

        public Filter (string filterTherm)
        {
            FilterTherm = filterTherm;

        }

    }
}
