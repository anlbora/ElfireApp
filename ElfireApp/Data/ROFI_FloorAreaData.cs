using ElfireApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Data
{
    public class ROFI_FloorAreaData
    {
        public Dictionary<int, ROFI_FloorArea> ROFI_FloorArea { get; set; }

        public ROFI_FloorAreaData()
        {
            this.ROFI_FloorArea = new Dictionary<int, ROFI_FloorArea>();

            ROFI_FloorArea one = new ROFI_FloorArea(25, 1.10);
            ROFI_FloorArea two = new ROFI_FloorArea(250, 1.50);
            ROFI_FloorArea three = new ROFI_FloorArea(2500, 1.90);
            ROFI_FloorArea four = new ROFI_FloorArea(5000, 2.0);
            ROFI_FloorArea five = new ROFI_FloorArea(10000, 2.13);


            ROFI_FloorArea[0] = one;
            ROFI_FloorArea[1] = two;
            ROFI_FloorArea[2] = three;
            ROFI_FloorArea[3] = four;
            ROFI_FloorArea[4] = five;


        }

        public void AddValue(ROFI_FloorArea rofi_floorArea)
        {
            int lastKey = ROFI_FloorArea.Count > 0 ? ROFI_FloorArea.Keys.Max() : -1;
            ROFI_FloorArea.Add(lastKey + 1, rofi_floorArea);
        }

        public List<ROFI_FloorArea> GetROFI_FloorAreaList()
        {
            return ROFI_FloorArea.Values.ToList();
        }


    }
}
