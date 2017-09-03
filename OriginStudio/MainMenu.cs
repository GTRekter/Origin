using System;
using System.Windows.Forms;
using OriginStudio.Forms;

namespace OriginStudio
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            FormMenu form = new FormMenu();
            form.Show();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            LookupMenu form = new LookupMenu();
            form.Show();
        }

        private void btnItemType_Click(object sender, EventArgs e)
        {
            ItemTypeMenu form = new ItemTypeMenu();
            form.Show();
        }
    }
}
