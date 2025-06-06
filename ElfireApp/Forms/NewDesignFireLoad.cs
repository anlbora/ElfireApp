using ElfireApp.Data;
using ElfireApp.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ElfireApp.Forms
{
    public partial class NewDesignFireLoad : Form
    {
        private DesignFireLoadData _designFireLoadData;
        private Action _updateComboBoxes;

        public NewDesignFireLoad(DesignFireLoadData designFireLoadData, Action updateComboBoxes)
        {
            InitializeComponent();
            _designFireLoadData = designFireLoadData;
            _updateComboBoxes = updateComboBoxes;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string occupancyType = txt_OccupancyType.Text;
            double fractile = double.Parse(txt_Fractile.Text);
            double limitingTime = double.Parse(txt_LimitingTime.Text);

            FireGrowthRate fireGrowthRate = (FireGrowthRate)cb_FireGrowthRate.SelectedValue;

            DesignFireLoad designFireLoad = new DesignFireLoad(occupancyType, fractile, fireGrowthRate, limitingTime);
            _designFireLoadData.AddValue(designFireLoad);

            ResetTextAreas();
            _updateComboBoxes?.Invoke();
            this.Close();
        }

        public void ResetTextAreas()
        {
            txt_OccupancyType.Text = string.Empty;
            txt_Fractile.Text = string.Empty;
            txt_LimitingTime.Text = string.Empty;
        }

        private void NewDesignFireLoad_Load(object sender, EventArgs e)
        {
            cb_FireGrowthRate.DataSource = Enum.GetValues(typeof(FireGrowthRate))
                .Cast<FireGrowthRate>()
                .Select(rate => new { Value = rate, Text = GetDisplayName(rate) })
                .ToList();

            cb_FireGrowthRate.DisplayMember = "Text";
            cb_FireGrowthRate.ValueMember = "Value";
        }

        private string GetDisplayName(FireGrowthRate rate)
        {
            switch (rate)
            {
                case FireGrowthRate.Slow:
                    return "Growth Rate: Slow";
                case FireGrowthRate.Medium:
                    return "Growth Rate: Medium";
                case FireGrowthRate.Fast:
                    return "Growth Rate: Fast";
                default:
                    return rate.ToString();
            }
        }
    }
}
