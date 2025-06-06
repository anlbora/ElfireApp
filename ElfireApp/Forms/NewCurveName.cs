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
    public partial class NewCurveName : Form
    {
        public string curveName;
        public NewCurveName()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            this.curveName = txt_CurveName.Text;
            this.Close();
        }

         private void txt_CurveName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.curveName = txt_CurveName.Text;
                this.Close();
            }
        }

    }
}
