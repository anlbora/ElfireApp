using ElfireApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Data
{
    public class MaterialData
    {
        public Dictionary<int, Material> Materials { get; set; }

        public MaterialData()
        {
            this.Materials = new Dictionary<int, Material>();

            Material RC = new Material("Reinforced Concrete", 2300, 840, 1.57);
            Material LWC = new Material("Lightweight Concrete", 500, 840, 0.22);
            Material BWK = new Material("Brick", 2300, 840, 7.98);

            this.Materials[0] = RC;
            this.Materials[1] = LWC;
            this.Materials[2] = BWK;
        }

        public Material Material { get; set; }

        public void AddMaterial(Material material)
        {
            int lastKey = Materials.Count - 1;

            Materials.Add(lastKey + 1, material);

        }

        public List<Material> GetMaterialsList()
        {
            return Materials.Values.ToList();
        }
    }
}
