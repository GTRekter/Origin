using System;
using System.Windows.Forms;

namespace OriginStudio.Forms
{
    public partial class LookupMenu : Form
    {
        private LookupManager _lookupManager;

        private OriginDataContext _dataContext;

        public LookupMenu()
        {
            InitializeComponent();

            _lookupManager = new LookupManager();
            _dataContext = new OriginDataContext();
        }

        private void btnAddLookup_Click(object sender, EventArgs e)
        {
            LookupDetail form = new LookupDetail();
            form.Show();
        }

        private void LookupMenu_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewLookup.DataSource = _lookupManager.GetLookups(_dataContext);
            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }

        private void dataGridViewLookup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string lookupOriginId = dataGridView.CurrentRow.Cells["OriginId"].Value.ToString();
            LookupDetail lookup = new LookupDetail(lookupOriginId);
            lookup.Show();
        }
    }
}
