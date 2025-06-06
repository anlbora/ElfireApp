using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfireApp.Data
{
    [Serializable]
    public class ControlData
    {
        public string ControlType { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
        public string SelectedValue { get; set; }
    }
}
