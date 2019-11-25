using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMWebAPI.Model
{
    public class ResultModel
    {
        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }
        public decimal MedianValue { get; set; }

        public string Message { get; set; }

    }
}
