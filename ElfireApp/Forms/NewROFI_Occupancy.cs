using ElfireApp.Data;
using ElfireApp.Properties;
using System;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class NewROFI_Occupancy : Form
    {
        private ROFI_OccupancyData _rofiOccupancyData;
        private Action _updateComboBox;

        public NewROFI_Occupancy(ROFI_OccupancyData rofiOccupancyData, Action updateComboBox)
        {
            InitializeComponent();
            this._rofiOccupancyData = rofiOccupancyData;
            this._updateComboBox = updateComboBox;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string occupancyName = txt_OccupancyType.Text;
            double fractileValue = double.Parse(txt_FractileValue.Text);

            ROFI_Occupancy rofiOccupancy = new ROFI_Occupancy(occupancyName, fractileValue);
            _rofiOccupancyData.AddValue(rofiOccupancy);

            ResetTextAreas();
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
