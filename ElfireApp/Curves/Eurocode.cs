using ElfireApp.Properties;
using System;
using System.Collections.Generic;

namespace ElfireApp.Curves
{
    public class Eurocode : ICurve
    {
        public string CurveName { get; set; }
        public string CurveCode { get; set; }
        public DateTime Date { get; set; }
        public string FireType { get; set; }
        public Dictionary<int, double> Values { get; set; }
        public List<double> Temperatures { get; set; } = new List<double>();
        public List<double> Times { get; set; } = new List<double>();
        public double MaximumTemperature { get; set; }
        public double Area { get; set; }
        public double OpeningFactor { get; set; }
        public string Material { get; set; }

        public Eurocode() { }

        public void ParseCurveCode(string curveCode)
        {
            // Split the curve code into parts
            var parts = curveCode.Split('-');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid curve code format");
            }

            // Area Mapping
            switch (parts[0])
            {
                case "1":
                    Area = 20;
                    break;
                case "2":
                    Area = 250;
                    break;
                case "3":
                    Area = 500;
                    break;
                default:
                    throw new ArgumentException("Invalid area code");
            }

            // Opening Factor Mapping
            switch (parts[1])
            {
                case "a":
                    OpeningFactor = 0.03;
                    break;
                case "b":
                    OpeningFactor = 0.06;
                    break;
                case "c":
                    OpeningFactor = 0.09;
                    break;
                case "d":
                    OpeningFactor = 0.2;
                    break;
                default:
                    throw new ArgumentException("Invalid opening factor code");
            }

            // Material Mapping
            switch (parts[2])
            {
                case "RC":
                    Material = "Reinforced Concrete";
                    break;
                case "LWC":
                    Material = "Lightweight Concrete";
                    break;
                case "BWK":
                    Material = "Brick Work";
                    break;
                default:
                    throw new ArgumentException("Invalid material code");
            }
        }

        public double CalculateMaximumTemperature(double t_max_2)
        {
            double MaximumTemperature = 20 + 1325 * ((1 - 0.324 * Math.Exp(-0.2 * t_max_2)) - (0.204 * Math.Exp(-1.7 * t_max_2)) - (0.472 * Math.Exp(-19 * t_max_2)));
            return MaximumTemperature;
        }

        public double CalculateHeatingPhaseTemperature(double t)
        {
            double heatingPhaseTemperature = 20 + 1325 * ((1 - 0.324 * Math.Exp(-0.2 * t)) - (0.204 * Math.Exp(-1.7 * t)) - (0.472 * Math.Exp(-19 * t)));
            return heatingPhaseTemperature;
        }

        // Initialize the Eurocode object with data from a CSV file
        public void InitializeFromCsv(string csvPath)
        {
            using (StreamReader reader = new StreamReader(csvPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(' '); // Assuming CSV uses space as delimiter
                    if (double.TryParse(values[0], out double time) && double.TryParse(values[1], out double temp))
                    {
                        Times.Add(time);
                        Temperatures.Add(temp);

                        
                    }
                }
            }
            // Remove the file extension for curve name
            CurveName = Path.GetFileNameWithoutExtension(csvPath);
            MaximumTemperature = Temperatures.Max();
        }
    }
}
