using CsvHelper;
using CsvHelper.Configuration;
using ERMWebAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERMWebAPI.Services
{
    public class ERMLogic : IERMLogic
    {
        private List<LPModel> LPlist;
        private List<TOUModel> TOUlist;
        private ResultModel result;

        public ResultModel GetCalculations(string date,string datatype,string filename) {
            result = new ResultModel();
            if (File.Exists(@"DataFile\\" + filename + ".csv"))
            {
                string filetype = filename.Substring(0, 2);
                using (var reader = new StreamReader(@"DataFile\\" + filename + ".csv"))
                using (var csv = new CsvReader(reader))
                {

                    csv.Configuration.IgnoreBlankLines = false;
                    if (filetype == "LP")
                    {
                        csv.Configuration.RegisterClassMap<LPModelMap>();
                        LPlist = csv.GetRecords<LPModel>().Where(x => x.DataType == datatype && x.DateTime.ToString("dd/MM/yyyy") == date).OrderBy(x => x.DataValue).ToList<LPModel>();
                        if (LPlist.Count > 0)
                        {
                            result.MinimumValue = LPlist.Min(a => a.DataValue);
                            result.MaximumValue = LPlist.Max(a => a.DataValue);
                            result.MedianValue = CalculateMedian(LPlist.Select(a => a.DataValue).ToList<decimal>());
                        }

                    }
                    else if (filetype == "TO")
                    {
                        TOUlist = csv.GetRecords<TOUModel>().Where(x => x.DataType == datatype && x.DateTime.ToString("dd/MM/yyyy") == date).OrderBy(x => x.Energy).ToList<TOUModel>();
                        if (TOUlist.Count > 0)
                        {
                            result.MinimumValue = TOUlist.Min(a => a.Energy);
                            result.MaximumValue = TOUlist.Max(a => a.Energy);
                            result.MedianValue = CalculateMedian(TOUlist.Select(a => a.Energy).ToList<decimal>());
                        }

                    }

                }
                result.Message = "success";
            }
            else {
                result.Message = "File not found.File should be present on DataFile folder.";
            }
            return result;
        }
        private sealed class LPModelMap : ClassMap<LPModel>
        {
            public LPModelMap()
            {
                Map(m => m.MeterPointCode).Name("MeterPoint Code");
                Map(m => m.SerialNumber).Name("Serial Number");
                Map(m => m.PlantCode).Name("Plant Code");
                Map(m => m.DateTime).Name("Date/Time");
                Map(m => m.DataType).Name("Data Type");
                Map(m => m.DataValue).Name("Data Value");
                Map(m => m.Units);
                Map(m => m.Status);

            }
        }

        private decimal CalculateMedian(dynamic items ) {
            int itemsCount = items.Count;
            int halfIndex = items.Count / 2;
            decimal median;
            if ((itemsCount % 2) == 0)
            {
                median = ((items[halfIndex] +items[halfIndex-1]) / 2);
            }
            else
            {
                median = items[halfIndex];
            }
            return median;
        }

     
    }
}
