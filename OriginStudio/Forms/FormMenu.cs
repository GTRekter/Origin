using System;
using System.Windows.Forms;
using OriginStudio.Forms;

namespace OriginStudio
{
    public partial class FormMenu : Form
    {
        private FormManager _formManager;

        private OriginDataContext _dataContext;

        public FormMenu()
        {
            InitializeComponent();

            _formManager = new FormManager();
            _dataContext = new OriginDataContext();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewForm.DataSource = _formManager.GetForms(_dataContext);
            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }

        private void btnAddForm_Click(object sender, EventArgs e)
        {
            FormDetail form = new FormDetail();
            form.Show();
        }

        private void dataGridViewForm_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string formOriginId = dataGridView.CurrentRow.Cells["OriginId"].Value.ToString();
            FormDetail form = new FormDetail(formOriginId);
            form.Show();
        }
    }
}
