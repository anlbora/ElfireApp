using System;

namespace ElfireApp.Properties
{
    public class Opening
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area { get; private set; }
        public int Number { get; set; }
        public double OpeningFactor { get; set; }
        public double OpeningFactorLim { get; set; }
        public double OpeningArea { get; set; }
        public double AverageHeight { get; set; }

        public Opening(double width, double height, int number)
        {
            this.Width = width;
            this.Height = height;
            this.Number = number;

            this.Area = CalculateArea();
            
        }
        public Opening()
        {
            
        }

        private double CalculateArea()
        {
            return Width * Height * Number;
        }
    }
}
