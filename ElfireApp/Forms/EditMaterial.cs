using ElfireApp.Data;
using ElfireApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class EditMaterial : Form
    {
        private MaterialData _materialData;
        private Action _updateComboBoxes;

        public EditMaterial(MaterialData materialData, Action updateComboBoxes)
        {
            InitializeComponent();
            _materialData = materialData;
            _updateComboBoxes = updateComboBoxes;
        }

        private void UpdateComboBoxes()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _materialData.GetMaterialsList();
            cb_Material.DataSource = bindingSource;
            cb_Material.DisplayMember = "Name";
        }

        private void EditMaterial_Load(object sender, EventArgs e)
        {
            UpdateComboBoxes();
            LoadSelectedMaterialDetails();
        }

        private void LoadSelectedMaterialDetails()
        {
            string materialName = cb_Material.Text;
            Material material = _materialData.GetMaterialsList().FirstOrDefault(m => m.Name == materialName);
            if (material != null)
            {
                txt_Density.Text = material.Density.ToString();
                txt_Name.Text = material.Name;
                txt_SpecificHeat.Text = material.SpecificHeat.ToString();
                txt_ThermalConductivity.Text = material.ThermalConductivity.ToString();
            }
        }

        private void cb_Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedMaterialDetails();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string materialName = cb_Material.Text;
            Material material = _materialData.GetMaterialsList().FirstOrDefault(m => m.Name == materialName);
            if (material != null)
            {
                material.Name = txt_Name.Text;
                material.Density = double.Parse(txt_Density.Text);
                material.SpecificHeat = double.Parse(txt_SpecificHeat.Text);
                material.ThermalConductivity = double.Parse(txt_ThermalConductivity.Text);
            }
            ResetTextAreas();
            UpdateComboBoxes();
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
