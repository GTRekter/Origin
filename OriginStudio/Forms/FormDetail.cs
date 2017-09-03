using OriginStudio.Models.Elements;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace OriginStudio.Forms
{
    public partial class FormDetail : Form
    {
        #region Private Variables

        private OR_Form _form;

        private List<OR_Input> _inputs;

        private List<OR_Input> _inputsToDelete;

        private List<int> _inputsToCreate;

        private string _formOriginId;

        private bool _detailMode;

        private InputManager _inputManager;

        private FormManager _formManager;

        private OriginDataContext _dataContext;

        #endregion

        #region Constructor

        public FormDetail()
        {
            InitializeComponent();

            _inputs = new List<OR_Input>();
            _inputsToCreate = new List<int>();
            _inputsToDelete = new List<OR_Input>();
            _formOriginId = string.Empty;
            _detailMode = false;

            _inputManager = new InputManager();
            _formManager = new FormManager();
            _dataContext  = new OriginDataContext();
        }

        public FormDetail(string formOriginId)
        {
            InitializeComponent();

            _inputsToDelete = new List<OR_Input>();
            _inputsToCreate = new List<int>();
            _inputs = new List<OR_Input>();
            _formOriginId = formOriginId;
            _detailMode = true;

            _inputManager = new InputManager();
            _formManager = new FormManager();
            _dataContext = new OriginDataContext();
        }

        #endregion

        #region Private Functions (Events)

        private void DetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Se DetailMode è TRUE siginifica che devo leggere gli input associati ad una form
                if(_detailMode)
                {
                    _form = _formManager.GetForm(_dataContext, _formOriginId);
                    _inputs = _inputManager.GetInputsByForm(_dataContext, _formOriginId);

                    // Valorizzo gli input con i valori della form
                    tbFormName.Text = _form.Name;

                    int selectedIndex = cbFormType.FindString(_form.Type);
                    cbFormType.SelectedIndex = selectedIndex;
                }

                BindingSource source = new BindingSource()
                {
                    DataSource = _inputs
                };
                dataGridViewInput.DataSource = source;

                // Nascondo la colonna di sistema relative all'Id, OriginId e RelatedOriginId
                dataGridViewInput.Columns["Id"].Visible = false;
                dataGridViewInput.Columns["OriginId"].Visible = false;
                dataGridViewInput.Columns["RelatedOriginId"].Visible = false;

                // Preseleziono il primo item della combobox
                cbFormType.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                Program.showErrorDialog(exc.Message);
            }
        }

        private void dataGridViewInput_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
            DataGridView dataGridView = (DataGridView)sender;

            string inputOriginId = dataGridView.CurrentRow.Cells["OriginId"].Value.ToString();
            OR_Input input = _inputs.Where(i => i.OriginId.Equals(inputOriginId)).FirstOrDefault();
            _inputsToDelete.Add(input);
        }

        private void dataGridViewInput_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

            DataGridView dataGridView = (DataGridView)sender;

            int index = dataGridView.CurrentRow.Index;
            _inputsToCreate.Add(index);
        }

        private void btnExecuteForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (_detailMode)
                {
                    #region Aggiornamento form

                    // Aggiorno la form
                    _form.Name = tbFormName.Text;
                    _form.Type = cbFormType.SelectedItem.ToString();

                    _dataContext.SubmitChanges();

                    // Elimino gli input
                    foreach (OR_Input input in _inputsToDelete)
                    {
                        _dataContext.OR_Inputs.DeleteOnSubmit(input);
                    }

                    // Creo gli input
                    foreach (int rowIndex in _inputsToCreate)
                    {
                        string inputOriginId = Guid.NewGuid().ToString();
                        OR_Input input = new OR_Input()
                        {
                            Name = dataGridViewInput.Rows[rowIndex].Cells["Name"].Value.ToString(),
                            OriginId = inputOriginId,
                            RelatedOriginId = _formOriginId,
                            Type = dataGridViewInput.Rows[rowIndex].Cells["Type"].Value.ToString(),
                        };
                        _dataContext.OR_Inputs.InsertOnSubmit(input);
                    }

                    // NB. Gli input vengono aggiornati automaticamente al submit
                    _dataContext.SubmitChanges();

                    DialogResult result = MessageBox.Show("La form è stata aggiornata con successo", "Aggiornamento completato",
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

                    // Creo la form
                    string formOriginId = Guid.NewGuid().ToString();
                    OR_Form form = new OR_Form()
                    {
                        Name = tbFormName.Text,
                        OriginId = formOriginId,
                        Type = cbFormType.SelectedItem.ToString()
                    };
                    _dataContext.OR_Forms.InsertOnSubmit(form);
                    _dataContext.SubmitChanges();

                    // Creo gli input
                    foreach (OR_Input inp in _inputs)
                    {
                        string inputOriginId = Guid.NewGuid().ToString();
                        OR_Input input = new OR_Input()
                        {
                            Name = inp.Name,
                            OriginId = inputOriginId,
                            RelatedOriginId = formOriginId,
                            Type = inp.Type
                        };
                        _dataContext.OR_Inputs.InsertOnSubmit(input);
                        _dataContext.SubmitChanges();
                    }

                    DialogResult result = MessageBox.Show("La form è stata creazione con successo", "Esecuzione completata",
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
