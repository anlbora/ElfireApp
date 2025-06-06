using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;


namespace ElfireApp.Data
{
    [Serializable]
    public class TabPageData
    {
        public string TabName { get; set; }
        public List<ControlData> Controls { get; set; } = new List<ControlData>();

        public static void SaveTabPage(TabPage tabPage, string filePath)
        {
            var data = new TabPageData
            {
                TabName = tabPage.Text
            };

            foreach (Control control in tabPage.Controls)
            {
                var controlData = new ControlData
                {
                    ControlType = control.GetType().ToString(),
                    Name = control.Name,
                    Text = control.Text,
                    Size = control.Size,
                    Location = control.Location
                };

                if (control is ComboBox comboBox)
                {
                    controlData.SelectedValue = comboBox.SelectedItem?.ToString();
                }

                data.Controls.Add(controlData);
            }

            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
        }

        public static TabPage LoadTabPage(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            TabPageData data = JsonSerializer.Deserialize<TabPageData>(jsonData);

            TabPage tabPage = new TabPage(data.TabName);

            foreach (var controlData in data.Controls)
            {
                Control control = null;

                switch (controlData.ControlType)
                {
                    case "System.Windows.Forms.TextBox":
                        control = new TextBox();
                        break;

                    case "System.Windows.Forms.ComboBox":
                        control = new ComboBox();
                        ((ComboBox)control).Items.Add(controlData.SelectedValue);
                        ((ComboBox)control).SelectedItem = controlData.SelectedValue;
                        break;

                    case "System.Windows.Forms.Label":
                        control = new Label();
                        break;

                    // Add more cases for different control types as needed

                    default:
                        continue;
                }

                control.Name = controlData.Name;
                control.Text = controlData.Text;
                control.Size = controlData.Size;
                control.Location = controlData.Location;

                tabPage.Controls.Add(control);
            }

            return tabPage;
        }
    }
}

