using ElfireApp.Data;
using ElfireApp.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class EditDesignFireLoad : Form
    {
        private DesignFireLoadData _designFireLoadData;
        private Action _updateComboBoxes;

        public EditDesignFireLoad(DesignFireLoadData designFireLoadData, Action updateComboBoxes)
        {
            InitializeComponent();
            _designFireLoadData = designFireLoadData;
            _updateComboBoxes = updateComboBoxes;
        }

        private void UpdateComboBox()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _designFireLoadData.GetDesignFireLoadList();
            cb_OccupancyType.DataSource = bindingSource;
            cb_OccupancyType.DisplayMember = "OccupancyType";
        }

        private void EditDesignFireLoad_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
            LoadSelectedDesignFireLoadDetails();
        }

        private void LoadSelectedDesignFireLoadDetails()
        {
            string occupancyType = cb_OccupancyType.Text;
            DesignFireLoad designFireLoad = _designFireLoadData.GetDesignFireLoadList().FirstOrDefault(m => m.OccupancyType == occupancyType);
            if (designFireLoad != null)
            {
                txt_OccupancyType.Text = designFireLoad.OccupancyType;
                txt_Fractile.Text = designFireLoad.FractileValue.ToString();

                // Populate the ComboBox with FireGrowthRate enum values
                cb_GrowthRate.DataSource = Enum.GetValues(typeof(FireGrowthRate));

                // Set the ComboBox to display the current GrowthRate value
                cb_GrowthRate.SelectedItem = designFireLoad.GrowthRate;

                txt_LimitingTime.Text = designFireLoad.LimitingTime.ToString();
            }
        }

        private void cb_OccupancyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedDesignFireLoadDetails();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string occupancyType = cb_OccupancyType.Text;
            DesignFireLoad designFireLoad = _designFireLoadData.GetDesignFireLoadList().FirstOrDefault(m => m.OccupancyType == occupancyType);
            if (designFireLoad != null)
            {
                designFireLoad.OccupancyType = txt_OccupancyType.Text;
                designFireLoad.FractileValue = double.Parse(txt_Fractile.Text);
                designFireLoad.GrowthRate = (FireGrowthRate)cb_GrowthRate.SelectedItem;
                designFireLoad.LimitingTime = double.Parse(txt_LimitingTime.Text);
            }
            ResetTextAreas();
            UpdateComboBox();
            _updateComboBoxes?.Invoke();
            this.Close();
        }

        public void ResetTextAreas()
        {
            txt_OccupancyType.Text = string.Empty;
            txt_Fractile.Text = string.Empty;
            txt_LimitingTime.Text = string.Empty;
        }
    }
}
