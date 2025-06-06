using System;
using ElfireApp.Data;

namespace ElfireApp.Properties
{

    public class Design
    {
        public string OccupancyType { get; set; }
        public double DesignValue_q_fk { get; set; }
        public FireGrowthRate GrowthRate { get; set; }
        public double LimitingTime_t_lim { get; set; }
        public double ROFI_Occupancy_gama_1 { get; set; }
        public double ROFI_FloorArea_gama_2 { get; set; }
        public double CombustionFactor_m { get; set; }
        public double ActiveSuppressionCoefficient_gama_n { get; set; }
        public double FireDesignLoad_q_fd { get; set; }
        public double TotalDesignFireLoad_q_td { get; set; }
        public double FireDuration { get; set; }
        public double TimeFactor { get; set; }
        public double TimeFactor_lim { get; set; }
        public Geometry Geometry { get; set; }
        public double t_max { get; set; }
        public double t_max_2 { get; set; }
        public double t_max_3 { get; set; }
        public double t_max_4 { get; set; }
        public double MaximumTemperature {get; set;}
        public double MaximumTemperatureTime { get; set; }

        public Design()
        {

         
        }
    }
}
