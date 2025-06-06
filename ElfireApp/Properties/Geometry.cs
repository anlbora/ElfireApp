using System;

namespace ElfireApp.Properties
{
    public class Geometry
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double FloorArea { get; private set; }
        public double CeilingArea { get; private set; }
        public double WallsArea { get; private set; }
        public double EnclosureArea { get; private set; }

        public Geometry(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;

            CalculateAreas();
        }

        public Geometry()
        {
            
        }

        private void CalculateAreas()
        {
            this.FloorArea = Length * Width;
            this.CeilingArea = Length * Width;
            this.WallsArea = 2 * (Length * Height + Width * Height);
            this.EnclosureArea = FloorArea + CeilingArea + WallsArea;
        }
    }
}
