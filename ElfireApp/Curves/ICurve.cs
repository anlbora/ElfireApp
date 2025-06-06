using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Curves
{
    public interface ICurve
    {
        public string CurveName { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<int, double> Values { get; set; }

        public Dictionary<int, double> CalculateValues()
        {
            return Values;
        }

    }
}
