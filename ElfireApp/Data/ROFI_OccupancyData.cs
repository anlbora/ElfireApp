using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElfireApp.Properties;

namespace ElfireApp.Data
{
    public class ROFI_OccupancyData
    {
        public Dictionary<int, ROFI_Occupancy> ROFI_Occupancy { get; set; }

        public ROFI_OccupancyData()
        {
            this.ROFI_Occupancy = new Dictionary<int, ROFI_Occupancy>();

            ROFI_Occupancy Museum = new ROFI_Occupancy("Museum", 0.78);
            ROFI_Occupancy ArtGallery = new ROFI_Occupancy("Art Gallery", 0.78);
            ROFI_Occupancy Office = new ROFI_Occupancy("Office", 1);
            ROFI_Occupancy Residence = new ROFI_Occupancy("Residence", 1);
            ROFI_Occupancy Hotel = new ROFI_Occupancy("Hotel", 1);
            ROFI_Occupancy Machinery = new ROFI_Occupancy("Machinery", 1.22);
            ROFI_Occupancy Labotory = new ROFI_Occupancy("Labotory", 1.44);
            ROFI_Occupancy Firework = new ROFI_Occupancy("Firework", 1.66);

            ROFI_Occupancy[0] = Museum;
            ROFI_Occupancy[1] = ArtGallery;
            ROFI_Occupancy[2] = Office;
            ROFI_Occupancy[3] = Residence;
            ROFI_Occupancy[4] = Hotel;
            ROFI_Occupancy[5] = Machinery;
            ROFI_Occupancy[6] = Labotory;
            ROFI_Occupancy[7] = Firework;

        }

        public void AddValue(ROFI_Occupancy rofi_occupancy)
        {
            int lastKey = ROFI_Occupancy.Count > 0 ? ROFI_Occupancy.Keys.Max() : -1;
            ROFI_Occupancy.Add(lastKey + 1, rofi_occupancy);
        }

        public List<ROFI_Occupancy> GetROFI_OccupancyList()
        {
            return ROFI_Occupancy.Values.ToList();
        }

    }
}
