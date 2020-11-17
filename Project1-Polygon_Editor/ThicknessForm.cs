
using System;
using System.Windows.Forms;

namespace Project1_Polygon_Editor
{
    public partial class ThicknessForm : Form
    {
        public Polygon_Editor polygon_Editor;

        public ThicknessForm(Polygon_Editor polygon_Editor)
        {
            InitializeComponent();
            this.polygon_Editor = polygon_Editor;
        }

        private void button_Click(object sender, EventArgs e)
        {
            polygon_Editor.Thickness = (int)numericUpDown.Value;
            Close();
        }
    }
}
