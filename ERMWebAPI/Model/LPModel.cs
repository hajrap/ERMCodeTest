using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMWebAPI.Model
{
    public class LPModel
    {
        public string MeterPointCode { get; set; }

        public string SerialNumber { get; set; }

        public string PlantCode { get; set; }

        public DateTime DateTime { get; set; }

        public string DataType { get; set; }

        public decimal DataValue { get; set; }

        public string Units { get; set; }

        public string Status { get; set; }
       
    }
}
