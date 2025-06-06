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
using ElfireApp.Properties;

namespace ElfireApp.Forms
{
    public partial class EditROFI_Occupancy : Form
    {
        private ROFI_OccupancyData _rofi_occupancyData;
        private Action _updateComboBox;

        public EditROFI_Occupancy(ROFI_OccupancyData _rofi_occupancyData, Action updateComboBox)
        {
            InitializeComponent();
            this._rofi_occupancyData = _rofi_occupancyData;
            _updateComboBox = updateComboBox;
        }

        private void UpdateComboBox()
        {
            if (_rofi_occupancyData == null || cb_OccupancyType == null)
            {
                MessageBox.Show("Occupancy data or ComboBox is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _rofi_occupancyData.GetROFI_OccupancyList();
            cb_OccupancyType.DataSource = bindingSource;
            cb_OccupancyType.DisplayMember = "OccupancyType";
        }


        private void EditROFI_Occupancy_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
            LoadSelectedROFI_OccupancyDetails();
        }

        private void LoadSelectedROFI_OccupancyDetails()
        {
            string occupancyType = cb_OccupancyType.Text;
            ROFI_Occupancy rofi_oocupancy = _rofi_occupancyData.GetROFI_OccupancyList().FirstOrDefault(m => m.OccupancyType == occupancyType);
            if (rofi_oocupancy != null)
            {
                txt_OccupancyType.Text = rofi_oocupancy.OccupancyType;
                txt_FractileValue.Text = rofi_oocupancy.FractileValue.ToString();
            }
        }

        private void cb_OccupancyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedROFI_OccupancyDetails();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string occupancyType = cb_OccupancyType.Text;
            ROFI_Occupancy rofi_oocupancy = _rofi_occupancyData.GetROFI_OccupancyList().FirstOrDefault(m => m.OccupancyType == occupancyType);
            if (rofi_oocupancy != null)
            {
                rofi_oocupancy.OccupancyType = txt_OccupancyType.Text;
                rofi_oocupancy.FractileValue = double.Parse(txt_FractileValue.Text);

            }
            ResetTextAreas();
            UpdateComboBox();
            _updateComboBox?.Invoke();
            this.Close();
        }

        public void ResetTextAreas()
        {
            txt_OccupancyType.Text = string.Empty;
            txt_FractileValue.Text = string.Empty;
        }
    }
}
