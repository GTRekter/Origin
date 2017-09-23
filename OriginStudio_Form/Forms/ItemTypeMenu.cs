using System;
using System.Windows.Forms;

namespace OriginStudio.Forms
{
    public partial class ItemTypeMenu : Form
    {

        private ItemManager _itemManager;

        private OriginDataContext _dataContext;

        public ItemTypeMenu()
        {
            InitializeComponent();

            _itemManager = new ItemManager();
            _dataContext = new OriginDataContext();
        }

        private void ItemTypeMenu_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewItemType.DataSource = _itemManager.GetItemTypes(_dataContext);
            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }

        private void btnAddItemType_Click(object sender, EventArgs e)
        {
            ItemTypeDetail form = new ItemTypeDetail();
            form.Show();
        }

        private void dataGridViewItemType_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            string itemTypeOriginId = dataGridView.CurrentRow.Cells["OriginId"].Value.ToString();
            ItemTypeDetail form = new ItemTypeDetail(itemTypeOriginId);
            form.Show();
        }

    }
}
