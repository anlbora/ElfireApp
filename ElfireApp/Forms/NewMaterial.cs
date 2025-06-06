using ElfireApp.Data;
using ElfireApp.Properties;
using System;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class NewMaterial : Form
    {
        private MaterialData _materialData;
        private Action _updateComboBoxes;

        public NewMaterial(MaterialData materialData, Action updateComboBoxes)
        {
            InitializeComponent();
            _materialData = materialData;
            _updateComboBoxes = updateComboBoxes;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string Name = txt_Name.Text;
            double Density = double.Parse(txt_Density.Text);
            double SpecificHeat = double.Parse(txt_SpecificHeat.Text);
            double ThermalConductivity = double.Parse(txt_ThermalConductivity.Text);

            Material material = new Material(Name, Density, SpecificHeat, ThermalConductivity);
            _materialData.AddMaterial(material);

            ResetTextAreas();
            _updateComboBoxes?.Invoke();
            this.Close();
        }

        public void ResetTextAreas()
        {
            txt_Name.Text = string.Empty;
            txt_Density.Text = string.Empty;
            txt_SpecificHeat.Text = string.Empty;
            txt_ThermalConductivity.Text = string.Empty;
        }
    }
}
