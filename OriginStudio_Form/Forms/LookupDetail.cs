using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OriginStudio.Forms
{
    public partial class LookupDetail : Form
    {
        #region Private Variables

        private OR_Lookup _lookup;

        private List<OR_LookupValue> _values;

        private List<OR_LookupValue> _valuesToDelete;

        private List<int> _valuesToCreate;

        private string _lookupOriginId;

        private bool _detailMode;

        private LookupManager _lookupManager;

        private OriginDataContext _dataContext;

        #endregion

        #region Constructor

        public LookupDetail()
        {
            InitializeComponent();

            _values = new List<OR_LookupValue>();
            _valuesToCreate = new List<int>();
            _valuesToDelete = new List<OR_LookupValue>();
            _lookupOriginId = string.Empty;
            _detailMode = false;

            _lookupManager = new LookupManager();
            _dataContext = new OriginDataContext();
        }

        public LookupDetail(string lookupOriginId)
        {
            InitializeComponent();

            _values = new List<OR_LookupValue>();
            _valuesToCreate = new List<int>();
            _valuesToDelete = new List<OR_LookupValue>();
            _lookupOriginId = lookupOriginId;
            _detailMode = true;

            _lookupManager = new LookupManager();
            _dataContext = new OriginDataContext();
        }

        #endregion

        #region Private Functions (Events)

        private void LookupDetail_Load(object sender, EventArgs e)
        {
            try
            {
                // Se DetailMode è TRUE siginifica che devo leggere i valori associati ad una lookup
                if (_detailMode)
                {
                    _lookup = _lookupManager.GetLookup(_dataContext, _lookupOriginId);
                    _values = _lookupManager.GetValuesByLookup(_dataContext, _lookupOriginId);

                    // Valorizzo le proprietà con i valori della lookup
                    tbLookupName.Text = _lookup.Name;
                }

                BindingSource source = new BindingSource()
                {
                    DataSource = _values
                };
                dataGridViewLookupValue.DataSource = source;

                // Nascondo la colonna di sistema relative all'Id, OriginId e RelatedOriginId
                dataGridViewLookupValue.Columns["Id"].Visible = false;
                dataGridViewLookupValue.Columns["OriginId"].Visible = false;
                dataGridViewLookupValue.Columns["RelatedOriginId"].Visible = false;
            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }

        private void dataGridViewLookupValue_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;

            string valueOriginId = dataGridView.CurrentRow.Cells["OriginId"].Value.ToString();
            OR_LookupValue value = _values.Where(i => i.OriginId.Equals(valueOriginId)).FirstOrDefault();
            _valuesToDelete.Add(value);
        }

        private void dataGridViewLookupValue_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;

            int index = dataGridView.CurrentRow.Index;
            _valuesToCreate.Add(index);
        }

        private void btnExecuteLookup_Click(object sender, EventArgs e)
        {
            try
            {
                if (_detailMode)
                {
                    #region Aggiornamento form

                    // Aggiorno la lookup
                    _lookup.Name = tbLookupName.Text;

                    // Elimino i valori
                    foreach (OR_LookupValue value in _valuesToDelete)
                    {
                        _dataContext.OR_LookupValues.DeleteOnSubmit(value);
                    }

                    // Creo i valori
                    foreach (int rowIndex in _valuesToCreate)
                    {
                        string lookupValueOriginId = Guid.NewGuid().ToString();
                        OR_LookupValue lookupValue = new OR_LookupValue()
                        {
                            OriginId = lookupValueOriginId,
                            RelatedOriginId = _lookupOriginId,
                            Value = dataGridViewLookupValue.Rows[rowIndex].Cells["Value"].Value.ToString(),
                        };
                        _dataContext.OR_LookupValues.InsertOnSubmit(lookupValue);
                    }

                    // NB. Gli input vengono aggiornati automaticamente al submit
                    _dataContext.SubmitChanges();

                    DialogResult result = MessageBox.Show("La lookup è stata aggiornata con successo", "Aggiornamento completato",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }

                    #endregion
                }
                else
                {
                    #region Creazione di una nuova form

                    // Creo la lookup
                    string lookupOriginId = Guid.NewGuid().ToString();
                    OR_Lookup lookup = new OR_Lookup()
                    {
                        Name = tbLookupName.Text,
                        OriginId = lookupOriginId,
                    };
                    _dataContext.OR_Lookups.InsertOnSubmit(lookup);
                    _dataContext.SubmitChanges();

                    // Creo i valori
                    foreach (OR_LookupValue val in _values)
                    {
                        string valueOriginId = Guid.NewGuid().ToString();
                        OR_LookupValue value = new OR_LookupValue()
                        {
                            OriginId = valueOriginId,
                            RelatedOriginId = lookupOriginId,
                            Value = val.Value
                        };
                        _dataContext.OR_LookupValues.InsertOnSubmit(value);                 
                    }
                    _dataContext.SubmitChanges();

                    DialogResult result = MessageBox.Show("La lookup è stata creazione con successo", "Esecuzione completata",
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

        #endregion
    }
}
