using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Properties
{
    public class ROFI_FloorArea
    {
        public double FloorArea { get; set; }
        public double FractileValue { get; set; }

        public ROFI_FloorArea(double FloorArea, double FractileValue)
        {
            this.FloorArea = FloorArea;
            this.FractileValue = FractileValue;
        }
    }
}
