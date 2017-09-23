namespace OriginStudio.Forms
{
    partial class LookupDetail
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
            this.lbLookup = new System.Windows.Forms.Label();
            this.dataGridViewLookupValue = new System.Windows.Forms.DataGridView();
            this.btnExecuteLookup = new System.Windows.Forms.Button();
            this.tbLookupName = new System.Windows.Forms.TextBox();
            this.lbLookupName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLookupValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLookup
            // 
            this.lbLookup.AutoSize = true;
            this.lbLookup.Location = new System.Drawing.Point(12, 88);
            this.lbLookup.Name = "lbLookup";
            this.lbLookup.Size = new System.Drawing.Size(100, 25);
            this.lbLookup.TabIndex = 13;
            this.lbLookup.Text = "lbLookup";
            // 
            // dataGridViewLookupValue
            // 
            this.dataGridViewLookupValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLookupValue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewLookupValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLookupValue.Location = new System.Drawing.Point(17, 137);
            this.dataGridViewLookupValue.Name = "dataGridViewLookupValue";
            this.dataGridViewLookupValue.RowTemplate.Height = 33;
            this.dataGridViewLookupValue.Size = new System.Drawing.Size(1089, 547);
            this.dataGridViewLookupValue.TabIndex = 12;
            this.dataGridViewLookupValue.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewLookupValue_UserAddedRow);
            this.dataGridViewLookupValue.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewLookupValue_UserDeletingRow);
            // 
            // btnExecuteLookup
            // 
            this.btnExecuteLookup.Location = new System.Drawing.Point(983, 702);
            this.btnExecuteLookup.Name = "btnExecuteLookup";
            this.btnExecuteLookup.Size = new System.Drawing.Size(123, 59);
            this.btnExecuteLookup.TabIndex = 11;
            this.btnExecuteLookup.Text = "btnExecuteLookup";
            this.btnExecuteLookup.UseVisualStyleBackColor = true;
            this.btnExecuteLookup.Click += new System.EventHandler(this.btnExecuteLookup_Click);
            // 
            // tbLookupName
            // 
            this.tbLookupName.Location = new System.Drawing.Point(183, 30);
            this.tbLookupName.Name = "tbLookupName";
            this.tbLookupName.Size = new System.Drawing.Size(346, 31);
            this.tbLookupName.TabIndex = 15;
            this.tbLookupName.Text = "tbLookupName";
            // 
            // lbLookupName
            // 
            this.lbLookupName.AutoSize = true;
            this.lbLookupName.Location = new System.Drawing.Point(22, 30);
            this.lbLookupName.Name = "lbLookupName";
            this.lbLookupName.Size = new System.Drawing.Size(156, 25);
            this.lbLookupName.TabIndex = 14;
            this.lbLookupName.Text = "lbLookupName";
            // 
            // LookupDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 773);
            this.Controls.Add(this.tbLookupName);
            this.Controls.Add(this.lbLookupName);
            this.Controls.Add(this.lbLookup);
            this.Controls.Add(this.dataGridViewLookupValue);
            this.Controls.Add(this.btnExecuteLookup);
            this.Name = "LookupDetail";
            this.Text = "LookupDetail";
            this.Load += new System.EventHandler(this.LookupDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLookupValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLookup;
        private System.Windows.Forms.DataGridView dataGridViewLookupValue;
        private System.Windows.Forms.Button btnExecuteLookup;
        private System.Windows.Forms.TextBox tbLookupName;
        private System.Windows.Forms.Label lbLookupName;
    }
}