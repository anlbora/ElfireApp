using ElfireApp.Data;
using ElfireApp.Properties;
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
    public partial class EditROFI_FloorArea : Form
    {
        private ROFI_FloorAreaData _rofi_floorAreaData;
        private Action _updateComboBox;

        public EditROFI_FloorArea(ROFI_FloorAreaData _rofi_floorArea, Action updateComboBox)
        {
            InitializeComponent();
            this._rofi_floorAreaData = _rofi_floorArea;
            this._updateComboBox = updateComboBox;
        }

        private void UpdateComboBox()
        {
            if (_rofi_floorAreaData == null || cb_FloorArea == null)
            {
                return;
            }

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _rofi_floorAreaData.GetROFI_FloorAreaList();
            cb_FloorArea.DataSource = bindingSource;
            cb_FloorArea.DisplayMember = "FloorArea";
        }


        private void EditROFI_FloorArea_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
            LoadSelectedROFI_FloorAreaDetails();
        }

        private void LoadSelectedROFI_FloorAreaDetails()
        {
            double FloorArea = double.Parse(cb_FloorArea.Text);
            ROFI_FloorArea rofi_floorArea = _rofi_floorAreaData.GetROFI_FloorAreaList().FirstOrDefault(m => m.FloorArea == FloorArea);
            if (rofi_floorArea != null)
            {
                txt_Fractile.Text = rofi_floorArea.FractileValue.ToString();
            }
        }

        private void cb_FloorArea_IndexChanged(object sender, EventArgs e)
        {
            LoadSelectedROFI_FloorAreaDetails();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            double FloorArea = double.Parse(cb_FloorArea.Text);
            ROFI_FloorArea rofi_floorArea = _rofi_floorAreaData.GetROFI_FloorAreaList().FirstOrDefault(m => m.FloorArea == FloorArea);
            if (rofi_floorArea != null)
            {
                rofi_floorArea.FractileValue = double.Parse(txt_Fractile.Text);

            }
            ResetTextAreas();
            UpdateComboBox();
            _updateComboBox?.Invoke();
            this.Close();
        }

        public void ResetTextAreas()
        {
            txt_Fractile.Text = string.Empty;
        }
    }
}
