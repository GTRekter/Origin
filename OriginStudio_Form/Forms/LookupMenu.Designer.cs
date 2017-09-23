namespace OriginStudio.Forms
{
    partial class LookupMenu
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
            this.dataGridViewLookup = new System.Windows.Forms.DataGridView();
            this.btnAddLookup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLookup)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLookup
            // 
            this.dataGridViewLookup.AllowUserToAddRows = false;
            this.dataGridViewLookup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLookup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewLookup.Location = new System.Drawing.Point(11, 239);
            this.dataGridViewLookup.Name = "dataGridViewLookup";
            this.dataGridViewLookup.ReadOnly = true;
            this.dataGridViewLookup.RowTemplate.Height = 33;
            this.dataGridViewLookup.Size = new System.Drawing.Size(1440, 675);
            this.dataGridViewLookup.TabIndex = 1;
            this.dataGridViewLookup.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLookup_CellContentDoubleClick);
            // 
            // btnAddLookup
            // 
            this.btnAddLookup.Location = new System.Drawing.Point(1274, 163);
            this.btnAddLookup.Name = "btnAddLookup";
            this.btnAddLookup.Size = new System.Drawing.Size(177, 58);
            this.btnAddLookup.TabIndex = 2;
            this.btnAddLookup.Text = "btnAddLookup";
            this.btnAddLookup.UseVisualStyleBackColor = true;
            this.btnAddLookup.Click += new System.EventHandler(this.btnAddLookup_Click);
            // 
            // LookupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 926);
            this.Controls.Add(this.btnAddLookup);
            this.Controls.Add(this.dataGridViewLookup);
            this.Name = "LookupMenu";
            this.Text = "LookupMenu";
            this.Load += new System.EventHandler(this.LookupMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLookup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLookup;
        private System.Windows.Forms.Button btnAddLookup;
    }
}