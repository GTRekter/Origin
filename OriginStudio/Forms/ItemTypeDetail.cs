using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OriginStudio.Forms
{
    public partial class ItemTypeDetail : Form
    {

        #region Private Variables

        private OR_ItemType _itemType;

        private List<OR_ItemAction> _itemActions;

        private List<OR_ItemAction> _itemActionsToDelete;

        private List<int> _itemActionsToCreate;

        private string _itemTypeOriginId;

        private bool _detailMode;

        private ItemManager _itemManager;

        private FormManager _formManager;

        private OriginDataContext _dataContext;

        #endregion

        #region Constructor

        public ItemTypeDetail()
        {
            InitializeComponent();

            _itemActions = new List<OR_ItemAction>();
            _itemActionsToCreate = new List<int>();
            _itemActionsToDelete = new List<OR_ItemAction>();
            _itemTypeOriginId = string.Empty;
            _detailMode = false;

            _itemManager = new ItemManager();
            _formManager = new FormManager();
            _dataContext = new OriginDataContext();
        }

        public ItemTypeDetail(string itemTypeOriginId)
        {
            InitializeComponent();

            _itemActions = new List<OR_ItemAction>();
            _itemActionsToCreate = new List<int>();
            _itemActionsToDelete = new List<OR_ItemAction>();
            _itemTypeOriginId = itemTypeOriginId;
            _detailMode = true;

            _itemManager = new ItemManager();
            _formManager = new FormManager();
            _dataContext = new OriginDataContext();
        }

        #endregion

        private void ItemTypeDetail_Load(object sender, EventArgs e)
        {
            try
            {
                // Se DetailMode è TRUE siginifica che devo leggere le azioni associate al tipo di item
                if (_detailMode)
                {
                    _itemType = _itemManager.GetItemType(_dataContext, _itemTypeOriginId);
                    _itemActions = _itemManager.GetItemActionsByItemType(_dataContext, _itemTypeOriginId);

                    // Valorizzo gli input con i valori del itemType
                    tbItemTypeName.Text = _itemType.Name;
                }

                // DataSource per la Form
                IEnumerable<OR_Form> forms = _formManager.GetForms(_dataContext);

                DataGridViewComboBoxColumn columnForm = new DataGridViewComboBoxColumn();
                columnForm.DataPropertyName = "FormOriginId";
                columnForm.HeaderText = "Form";
                columnForm.DataSource = forms;
                columnForm.ValueMember = "OriginId";
                columnForm.DisplayMember = "Name";

                dataGridViewItemAction.Columns.Add(columnForm);

                // Datasource per l'action
                BindingSource source = new BindingSource()
                {
                    DataSource = _itemActions
                };
                dataGridViewItemAction.DataSource = source;

                // Nascondo la colonna di sistema relative all'Id, OriginId, FormOriginId e ItemTypeOriginId
                dataGridViewItemAction.Columns["Id"].Visible = false;
                dataGridViewItemAction.Columns["OriginId"].Visible = false;
                dataGridViewItemAction.Columns["ItemTypeOriginId"].Visible = false;

            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }

        private void dataGridViewItemAction_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;

            string itemActionOriginId = dataGridView.CurrentRow.Cells["OriginId"].Value.ToString();
            OR_ItemAction action = _itemActions.Where(i => i.OriginId.Equals(itemActionOriginId)).FirstOrDefault();
            _itemActionsToDelete.Add(action);
        }

        private void dataGridViewItemAction_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;

            int index = dataGridView.CurrentRow.Index;
            _itemActionsToCreate.Add(index);
        }

        private void btnExecuteItemType_Click(object sender, EventArgs e)
        {
            try
            {
                if (_detailMode)
                {
                    #region Aggiornamento form

                    // Aggiorno la tipologia
                    _itemType.Name = tbItemTypeName.Text;

                    _dataContext.SubmitChanges();

                    // Elimino gli input
                    foreach (OR_ItemAction action in _itemActionsToDelete)
                    {
                        _dataContext.OR_ItemActions.DeleteOnSubmit(action);
                    }

                    // Creo gli input
                    foreach (int rowIndex in _itemActionsToCreate)
                    {
                        string itemActionOriginId = Guid.NewGuid().ToString();
                        OR_ItemAction action = new OR_ItemAction()
                        {
                            Name = dataGridViewItemAction.Rows[rowIndex].Cells["Name"].Value.ToString(),
                            OriginId = itemActionOriginId,
                            FormOriginId = "",
                            ItemTypeOriginId = _itemTypeOriginId,
                        };
                        _dataContext.OR_ItemActions.InsertOnSubmit(action);
                    }

                    // NB. Gli input vengono aggiornati automaticamente al submit
                    _dataContext.SubmitChanges();

                    DialogResult result = MessageBox.Show("La tipologia è stata aggiornata con successo", "Aggiornamento completato",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }

                    #endregion
                }
                else
                {
                    #region Creazione di una nuova tipologia

                    // Creo la nuova tipologia
                    string itemTypeOriginId = Guid.NewGuid().ToString();
                    OR_ItemType inputType = new OR_ItemType()
                    {
                        Name = tbItemTypeName.Text,
                        OriginId = itemTypeOriginId,
                    };
                    _dataContext.OR_ItemTypes.InsertOnSubmit(inputType);
                    _dataContext.SubmitChanges();

                    // Creo le azioni
                    foreach (OR_ItemAction act in _itemActions)
                    {
                        string itemActionOriginId = Guid.NewGuid().ToString();
                        OR_ItemAction itemAction = new OR_ItemAction()
                        {
                            Name = act.Name,
                            OriginId = itemActionOriginId,
                            ItemTypeOriginId = itemTypeOriginId,
                            FormOriginId = act.FormOriginId
                        };
                        _dataContext.OR_ItemActions.InsertOnSubmit(itemAction);
                        _dataContext.SubmitChanges();
                    }

                    DialogResult result = MessageBox.Show("L'azione è stata associata con successo", "Esecuzione completata",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }

                    #endregion
                }
            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }
    }
}
