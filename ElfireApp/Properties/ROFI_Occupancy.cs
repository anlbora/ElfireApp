using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Properties
{
    public class ROFI_Occupancy
    {
        public string OccupancyType { get; set; }
        public double FractileValue { get; set; }

        public ROFI_Occupancy(string OccupancyType, double FractileValue)
        {
            this.OccupancyType = OccupancyType;
            this.FractileValue = FractileValue;
        }

    }
}
