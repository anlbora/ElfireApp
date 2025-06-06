using System;
using System.Collections.Specialized;

namespace ElfireApp.Properties
{
    public class Material
    {
        public string Name { get; set; }
        public double Density { get; set; }
        public double SpecificHeat { get; set; }
        public double ThermalConductivity { get; set; }
        public double ThermalInertia { get;  set; }
        public double FloorThermalInertia { get;  set; }
        public double CeilingThermalInertia { get;  set; }
        public double WallThermalInertia { get;  set; }
        public double CompartmentThermalInertia { get;  set; }


        public Material(string name, double density, double specificHeat, double thermalConductivity)
        {


            this.Name = name;
            this.Density = density;
            this.SpecificHeat = specificHeat;
            this.ThermalConductivity = thermalConductivity;

            this.ThermalInertia = CalculateThermalInertia();
        }

        public Material()
        {
            
        }

        private double CalculateThermalInertia()
        {
            return Math.Sqrt(Density * SpecificHeat * ThermalConductivity);
        }
    }
}
