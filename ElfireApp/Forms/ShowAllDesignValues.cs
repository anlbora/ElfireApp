using ElfireApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class ShowAllDesignValues : Form
    {
        DesignFireLoadData designFireLoadData;
        ROFI_FloorAreaData rofiFloorAreaData;
        ROFI_OccupancyData rofiOccupancyData;

        private Action _updateComboBox;

        public ShowAllDesignValues(DesignFireLoadData designFireLoadData, ROFI_FloorAreaData rofiFloorAreaData, ROFI_OccupancyData rofiOccupancyData, Action updateComboBox)
        {
            InitializeComponent();
            this.designFireLoadData = designFireLoadData;
            this._updateComboBox = updateComboBox;
            this.rofiFloorAreaData = rofiFloorAreaData;
            this.rofiOccupancyData = rofiOccupancyData;
        }

        #region Design Fire Load Methods
        private void ShowAllDesignFireLoadValues_Load(object sender, EventArgs e)
        {
            var designFireLoadList = designFireLoadData.DesignFireLoadValues.Select(kvp => new
            {
                OccupancyType = kvp.Value.OccupancyType,
                FractileValue = kvp.Value.FractileValue,
                FireGrowthRate = kvp.Value.GrowthRate,
                LimitingTime = kvp.Value.LimitingTime,
            }).ToList();

            dg_designfireloads.DataSource = designFireLoadList;
            dg_designfireloads.AutoResizeColumns();

            ShowAllROFI_OccupancyValues_Load(sender, e);
            ShowAllROFI_FloorAreaValues_Load(sender, e);


        }

        private void btn_AddNewDesignFieLoad_Click(object sender, EventArgs e)
        {
            NewDesignFireLoad newDesignFireLoad = new NewDesignFireLoad(designFireLoadData, _updateComboBox);
            newDesignFireLoad.ShowDialog();
            ShowAllDesignFireLoadValues_Load(sender, e);
        }

        private void btn_EditDesignFireLoad_Click(object sender, EventArgs e)
        {
            EditDesignFireLoad editDesignFireLoad = new EditDesignFireLoad(designFireLoadData, _updateComboBox);
            editDesignFireLoad.ShowDialog();
            ShowAllDesignFireLoadValues_Load(sender, e);
        }
        #endregion

        #region ROFI Occupancy Methods
        private void ShowAllROFI_OccupancyValues_Load(object sender, EventArgs e)
        {
            var rofi_occupancyList = rofiOccupancyData.ROFI_Occupancy.Select(kvp => new
            {
                OccupancyType = kvp.Value.OccupancyType,
                FractileValue = kvp.Value.FractileValue,
            }).ToList();

            dg_rofiOccupancy.DataSource = rofi_occupancyList;
            dg_rofiOccupancy.AutoResizeColumns();
        }

        private void btn_AddNewROFI_Occupancy_Click(object sender, EventArgs e)
        {
            NewROFI_Occupancy newROFI_Occupancy = new NewROFI_Occupancy(rofiOccupancyData, _updateComboBox);
            newROFI_Occupancy.ShowDialog();
            ShowAllROFI_OccupancyValues_Load(sender, e);
        }

        private void btn_EditROFI_Occupancy_Click(object sender, EventArgs e)
        {
            EditROFI_Occupancy editROFI_Occupancy = new EditROFI_Occupancy(rofiOccupancyData, _updateComboBox);
            editROFI_Occupancy.ShowDialog();
            ShowAllROFI_OccupancyValues_Load(sender, e);
        }
        #endregion

        #region ROFI Floor Area Methods
        private void ShowAllROFI_FloorAreaValues_Load(object sender, EventArgs e)
        {
            var rofi_FloorAreaList = rofiFloorAreaData.ROFI_FloorArea.Select(kvp => new
            {
                OccupancyType = kvp.Value.FloorArea,
                FractileValue = kvp.Value.FractileValue,
            }).ToList();

            dg_rofiFloorArea.DataSource = rofi_FloorAreaList;
            dg_rofiFloorArea.AutoResizeColumns();
        }


        private void btn_EditROFI_FloorArea_Click(object sender, EventArgs e)
        {
            EditROFI_FloorArea editROFI_FloorArea = new EditROFI_FloorArea(rofiFloorAreaData, _updateComboBox);
            editROFI_FloorArea.ShowDialog();
            ShowAllROFI_FloorAreaValues_Load(sender, e);
        }
        #endregion
    }
}
