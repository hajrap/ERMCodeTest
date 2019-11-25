using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMWebAPI.Model
{
    public class TOUModel
    {
        public string MeterCode { get; set; }
        public string Serial { get; set; }
        public string PlantCode { get; set; }

        public DateTime DateTime { get; set; }

        public char Quality { get; set; }

        public string Stream { get; set; }

        public string DataType { get; set; }

        public decimal Energy { get; set; }

        public string Units { get; set; }

    }
}
