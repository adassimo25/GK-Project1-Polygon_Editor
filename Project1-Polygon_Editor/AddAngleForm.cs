
using System;
using System.Windows.Forms;

namespace Project1_Polygon_Editor
{
    public partial class AddAngleForm : Form
    {
        public Polygon_Editor polygon_Editor;

        public AddAngleForm(Polygon_Editor polygon_Editor)
        {
            InitializeComponent();
            this.polygon_Editor = polygon_Editor;
        }

        private void button_Click(object sender, EventArgs e)
        {
            polygon_Editor.Angle = (double)numericUpDown.Value;
            Close();
        }
    }
}
