using ElfireApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class ShowAllMaterial : Form
    {
        MaterialData materialData;



        public ShowAllMaterial(MaterialData materialData)
        {
            InitializeComponent();
            this.materialData = materialData;
        }

        private void ShowAllMaterial_Load(object sender, EventArgs e)
        {
            var materialList = materialData.Materials.Select(kvp => new
            {
                Name = kvp.Value.Name,
                Density = kvp.Value.Density,
                SpecificHeat = kvp.Value.SpecificHeat,
                ThermalConductivity = kvp.Value.ThermalConductivity,
                ThermalInertia = kvp.Value.ThermalInertia.ToString("0.00")
            }).ToList();

            dg_MaterialTable.DataSource = materialList;
            dg_MaterialTable.AutoResizeColumns();
        }

    }
}
