namespace OriginStudio
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewForm = new System.Windows.Forms.DataGridView();
            this.btnAddForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForm)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewForm
            // 
            this.dataGridViewForm.AllowUserToAddRows = false;
            this.dataGridViewForm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForm.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewForm.Location = new System.Drawing.Point(12, 248);
            this.dataGridViewForm.Name = "dataGridViewForm";
            this.dataGridViewForm.ReadOnly = true;
            this.dataGridViewForm.RowTemplate.Height = 33;
            this.dataGridViewForm.Size = new System.Drawing.Size(1440, 675);
            this.dataGridViewForm.TabIndex = 0;
            this.dataGridViewForm.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForm_CellContentDoubleClick);
            // 
            // btnAddForm
            // 
            this.btnAddForm.Location = new System.Drawing.Point(1275, 169);
            this.btnAddForm.Name = "btnAddForm";
            this.btnAddForm.Size = new System.Drawing.Size(177, 58);
            this.btnAddForm.TabIndex = 1;
            this.btnAddForm.Text = "btnAddForm";
            this.btnAddForm.UseVisualStyleBackColor = true;
            this.btnAddForm.Click += new System.EventHandler(this.btnAddForm_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1464, 932);
            this.Controls.Add(this.btnAddForm);
            this.Controls.Add(this.dataGridViewForm);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewForm;
        private System.Windows.Forms.Button btnAddForm;
    }
}